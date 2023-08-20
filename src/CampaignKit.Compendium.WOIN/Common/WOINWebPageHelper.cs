// <copyright file="WOINWebPageHelper.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2023 Jochen Linnemann, Cory Gill.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace CampaignKit.Compendium.WOIN.Common
{
    using System;

    using HtmlAgilityPack;

    /// <summary>
    /// Utility class for WOIN content conversions.
    /// </summary>
    public class WOINWebPageHelper
    {
        /// <summary>
        /// Adds a new rowNode to the specified HTML tableNode. The rowNode is created from the provided
        /// HtmlNode, and cells are extracted based on specific criteria. If the rowNode is determined
        /// to be a header rowNode, the cells will be created with the 'th' tag; otherwise, they will be
        /// created with the 'td' tag.
        /// </summary>
        /// <param name="tableNode">The HtmlNode representing the tableNode to which the rowNode will be added.</param>
        /// <param name="rowNode">
        /// The HtmlNode representing the rowNode that will be added to the tableNode. The rowNode should
        /// contain span elements with class 'C9DxTc' and not contain nested span elements with
        /// class 'Apple-tab-span'.
        /// </param>
        public static void AddRowToTable(HtmlNode tableNode, HtmlNode rowNode)
        {
            // Validate method parametesr
            if (tableNode == null)
            {
                throw new ArgumentNullException(nameof(tableNode));
            }

            if (rowNode == null)
            {
                throw new ArgumentNullException(nameof(rowNode));
            }

            // Create a new HTML node for the row
            var newRow = HtmlNode.CreateNode("<tr></tr>");

            // Select all <span> elements within the rowNode
            var cellNodes = rowNode.SelectNodes(".//span[@class='C9DxTc ' and not(.//span[@class='Apple-tab-span '])]");

            // Determine if this is a header rowNode, if so use the 'th' tag
            // for the content.  If not, use 'td'.
            var isHeaderRow = tableNode.ChildNodes.Count == 0;

            // Iterate through each cell in the cellNodes collection
            foreach (var cellNode in cellNodes)
            {
                // Determine if a new line has been found
                if (cellNode.FirstChild.Name.Equals("br", StringComparison.InvariantCultureIgnoreCase))
                {
                    // Add the rowNode to the tableNode
                    tableNode.AppendChild(newRow);

                    // Create a new HTML node for the row
                    newRow = HtmlNode.CreateNode("<tr></tr>");
                    isHeaderRow = false;
                }

                // Create a new HTML node for the cell
                var tagSymbol = isHeaderRow ? "th" : "td";
                var newCellNode = HtmlNode.CreateNode($"<{tagSymbol}>{cellNode.InnerText}</{tagSymbol}>");

                // Append the cell node to the rowNode
                newRow.AppendChild(newCellNode);
            }

            // Add the rowNode to the tableNode
            tableNode.AppendChild(newRow);
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains list data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNod contains list data, false otherwise.</returns>
        public static bool ContainsListData(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Evaluate parameter.
            return node.Name.Equals("ol", StringComparison.InvariantCultureIgnoreCase)
                || node.Name.Equals("ul", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains tableNode data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNod contains tableNode data, false otherwise.</returns>
        public static bool ContainsTableData(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Evaluate parameter.
            return node.SelectNodes(".//span[@class='Apple-tab-span ']") != null;
        }

        /// <summary>
        /// Creates a new HTML list node by extracting list items from the provided node. If a list
        /// item contains more than one span element, the content of the first span is wrapped in a
        /// bold ('b') tag. The resulting list structure is returned as an HtmlNode.
        /// </summary>
        /// <param name="node">
        /// The HtmlNode representing the list to be processed. Must not be null.
        /// </param>
        /// <returns>An HtmlNode containing the newly created list structure.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided node is null.</exception>
        /// <exception cref="NotImplementedException">Thrown as the method is not fully implemented.</exception>
        /// <remarks>
        /// The method specifically looks for 'li' elements within the provided node and processes
        /// 'span' elements within each list item. Note that the method currently ends with a
        /// 'NotImplementedException', indicating that it may not be complete.
        /// </remarks>
        public static HtmlNode GetList(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Instantiate a new list to hold the results.
            var newListNode = HtmlNode.CreateNode($"<{node.Name}></{node.Name}>");

            // Select list item nodes
            var listItemNodes = node.SelectNodes(".//li");

            foreach (var listItemNode in listItemNodes)
            {
                // Create a new list item node
                var newListItemNode = HtmlNode.CreateNode("<li></li>");

                // Select all span nodes from the list item node
                var spanNodes = listItemNode.SelectNodes(".//span");

                // Loop through each span node
                foreach (var spanNode in spanNodes)
                {
                    // If the item should be bold, create a bold node with the inner text of the span node
                    var styleAttribute = spanNode.GetAttributeValue("style", string.Empty);
                    var boldItem = styleAttribute.Contains("font-weight: 700");
                    if (boldItem)
                    {
                        newListItemNode.AppendChild(HtmlNode.CreateNode($"<b>{spanNode.InnerText}</b>"));
                        newListItemNode.AppendChild(HtmlNode.CreateNode($"<span>&nbsp;</span>"));
                    }

                    // Otherwise, just append the span node
                    else
                    {
                        newListItemNode.AppendChild(spanNode);
                    }
                }

                // Append the new list item node to the new list node
                newListNode.AppendChild(newListItemNode);
            }

            // Return the converted list
            return newListNode;
        }

        /// <summary>
        /// Parses the content of a given HTML section node, extracting specific elements such as
        /// headings, lists, and paragraphs. If the content contains tableNode data, it is organized
        /// into a tableNode structure within the returned node.
        /// </summary>
        /// <param name="node">The HtmlNode representing the section to be parsed.</param>
        /// <returns>
        /// An HtmlNode containing the parsed content, organized into a 'div' element, with any
        /// tableNode data structured into 'tableNode' elements.
        /// </returns>
        /// <remarks>
        /// The method specifically looks for the following elements within the section: h1, h2, h3,
        /// h4, h5, h6, ul, ol, and p. If tableNode data is detected, it is handled using the
        /// WOINWebPageHelper.ContainsTableData and WOINWebPageHelper.AddRowToTable methods.
        /// </remarks>
        public static HtmlNode ParseSectionContent(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Create a new node to hold content extracted from the section.
            var newSectionNode = HtmlNode.CreateNode("<div></div>");

            // Select all content elements.
            var contentNodes = node.SelectNodes(".//h1 | .//h2 | .//h3 | .//h4 | .//h5 | .//h6 | .//ul[not(.//ul)] | .//ol | .//p[not(ancestor::ul) and not(ancestor::ol)] | .//table");

            // If contentNodes is not null, process its contents
            if (contentNodes != null)
            {
                // Create tableNode node for holding parsed tableNode data.
                var table = HtmlNode.CreateNode("<table></table>");

                // Add each content item to the new node.
                foreach (var contentNode in contentNodes)
                {
                    if (table != null && WOINWebPageHelper.ContainsTableData(contentNode))
                    {
                        WOINWebPageHelper.AddRowToTable(table, contentNode);
                    }
                    else if (WOINWebPageHelper.ContainsListData(contentNode))
                    {
                        newSectionNode.AppendChild(WOINWebPageHelper.GetList(contentNode));
                    }
                    else
                    {
                        // Is there tableNode data that needs to be copied?
                        if (table != null && table.ChildNodes.Count > 0)
                        {
                            newSectionNode.AppendChild(table);
                            table = HtmlNode.CreateNode("<table></table>");
                        }

                        // Copy the node as-is
                        newSectionNode.AppendChild(contentNode);
                    }
                }

                // Is there tableNode data that needs to be copied?
                if (table != null && table.ChildNodes.Count > 0)
                {
                    newSectionNode.AppendChild(table);
                }
            }

            // Return the result
            return newSectionNode;
        }
    }
}
