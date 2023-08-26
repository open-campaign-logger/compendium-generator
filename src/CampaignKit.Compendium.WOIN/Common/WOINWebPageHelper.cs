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
    using System.Text;
    using System.Text.RegularExpressions;

    using HtmlAgilityPack;

    using Microsoft.EntityFrameworkCore.Update;

    /// <summary>
    /// Utility class for WOIN content conversions.
    /// </summary>
    public class WOINWebPageHelper
    {
        /// <summary>
        /// Adds the provided definition to the provided definitionList.
        /// </summary>
        /// <param name="definitionList">The HtmlNode representing the definitionList to which the definition will be added.</param>
        /// <param name="definition">The HtmlNode representing the definition that will be added to the definitionList.</param>
        public static void AddRowToDefinitionList(HtmlNode definitionList, HtmlNode definition)
        {
            // Validate method parametesr
            if (definitionList == null)
            {
                throw new ArgumentNullException(nameof(definitionList));
            }

            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            // Select the span nodes
            var spanNodes = definition.SelectNodes(".//span");

            if (spanNodes != null)
            {
                // Create the definition
                var definitionBuilder = new StringBuilder();

                var firstRun = true;
                foreach (var span in spanNodes)
                {
                    if (firstRun)
                    {
                        firstRun = false;
                        continue;
                    }

                    definitionBuilder.Append(span.OuterHtml);
                }

                // Create the definition term.
                definitionList.AppendChild(HtmlNode.CreateNode($"<dt><b>{spanNodes[0].OuterHtml}</b></dt>"));

                // Create the definition item
                definitionList.AppendChild(HtmlNode.CreateNode($"<dd>{definitionBuilder.ToString()}</dd>"));
            }
        }

        /// <summary>
        /// Adds the provided definition to the provided definitionList.
        /// </summary>
        /// <param name="statblock">The HtmlNode representing the definitionList to which the definition will be added.</param>
        /// <param name="stat">The HtmlNode representing the definition that will be added to the definitionList.</param>
        public static void AddRowToStatblock(HtmlNode statblock, HtmlNode stat)
        {
            // Validate method parametesr
            if (statblock == null)
            {
                throw new ArgumentNullException(nameof(statblock));
            }

            if (stat == null)
            {
                throw new ArgumentNullException(nameof(stat));
            }

            // Add a line break.
            statblock.AppendChild(HtmlNode.CreateNode("</br>"));

            // Add the definition.
            // Create a new HTML node for the row
            statblock.AppendChild(stat);
        }

        /// <summary>
        /// Adds a new definition to the specified HTML definitionList. The definition is created from the provided
        /// HtmlNode, and cells are extracted based on specific criteria. If the definition is determined
        /// to be a header definition, the cells will be created with the 'th' tag; otherwise, they will be
        /// created with the 'td' tag.
        /// </summary>
        /// <param name="tableNode">The HtmlNode representing the definitionList to which the definition will be added.</param>
        /// <param name="rowNode">
        /// The HtmlNode representing the definition that will be added to the definitionList. The definition should
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

            // Select all <span> elements within the definition
            var cellNodes = rowNode.SelectNodes(".//span[@class='C9DxTc ' and not(.//span[@class='Apple-tab-span '])]");

            // Determine if this is a header definition, if so use the 'th' tag
            // for the content.  If not, use 'td'.
            var isHeaderRow = tableNode.ChildNodes.Count == 0;

            // Iterate through each cell in the cellNodes collection

            // Shortcut the process if no nodes match the criteria.
            if (cellNodes != null)
            {
                foreach (var cellNode in cellNodes)
                {
                    // Determine if a new line has been found
                    if (cellNode.FirstChild.Name.Equals("br", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Add the definition to the definitionList
                        tableNode.AppendChild(newRow);

                        // Create a new HTML node for the row
                        newRow = HtmlNode.CreateNode("<tr></tr>");
                        isHeaderRow = false;
                    }

                    // Create a new HTML node for the cell
                    var tagSymbol = isHeaderRow ? "th" : "td";
                    var newCellNode = HtmlNode.CreateNode($"<{tagSymbol}>{cellNode.InnerText}</{tagSymbol}>");

                    // Append the cell node to the definition
                    newRow.AppendChild(newCellNode);
                }
            }

            // Add the definition to the definitionList
            tableNode.AppendChild(newRow);
        }

        /// <summary>
        /// Closes the given definitionList and appends it to the given destination node.
        /// </summary>
        /// <param name="destination">The node to append the definitionList to.</param>
        /// <param name="definitionList">The definitionList to close.</param>
        /// <returns>The newly opened definitionList.</returns>
        public static HtmlNode CloseDefinitionList(HtmlNode destination, HtmlNode definitionList)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (definitionList == null)
            {
                throw new ArgumentNullException(nameof(definitionList));
            }

            if (definitionList.ChildNodes != null && definitionList.ChildNodes.Count > 0)
            {
                destination.AppendChild(definitionList);
            }

            return WOINWebPageHelper.OpenDefiintionList();
        }

        /// <summary>
        /// Closes the given statblock and appends it to the given destination node.
        /// </summary>
        /// <param name="destination">The node to append the statblock to.</param>
        /// <param name="statblock">The statblock to close.</param>
        /// <returns>The newly opened statblock.</returns>
        public static HtmlNode CloseStatblock(HtmlNode destination, HtmlNode statblock)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (statblock == null)
            {
                throw new ArgumentNullException(nameof(statblock));
            }

            if (statblock.ChildNodes != null && statblock.ChildNodes.Count > 0)
            {
                destination.AppendChild(statblock);
            }

            return WOINWebPageHelper.OpenStatBlock();
        }

        /// <summary>
        /// Closes the given table and appends it to the given destination node.
        /// </summary>
        /// <param name="destination">The node to append the table to.</param>
        /// <param name="table">The table to close.</param>
        /// <returns>The newly opened table.</returns>
        public static HtmlNode CloseTable(HtmlNode destination, HtmlNode table)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            if (table.ChildNodes != null && table.ChildNodes.Count > 0)
            {
                destination.AppendChild(table);
            }

            return WOINWebPageHelper.OpenTable();
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains definition data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNode contains definition data, false otherwise.</returns>
        public static bool ContainsDefinitionData(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Look for paragraphs masquerading as a list item.
            if (node.Name.Equals("p", StringComparison.InvariantCultureIgnoreCase))
            {
                var spanNodes = node.SelectNodes(".//span");
                if (spanNodes != null && spanNodes[0].GetAttributeValue("style", string.Empty).Contains("font-weight: 700"))
                {
                    return true;
                }
            }

            // If all conditions fail, return false;
            return false;
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains list data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNode contains list data, false otherwise.</returns>
        public static bool ContainsListData(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Look for actual lists
            if (node.Name.Equals("ol", StringComparison.InvariantCultureIgnoreCase)
                || node.Name.Equals("ul", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            // If all conditions fail, return false;
            return false;
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains definitionList data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNode contains definitionList  data, false otherwise.</returns>
        public static bool ContainsStatblockData(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Evaluate parameter.
            return node.Name.Equals("small", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains definitionList data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNod contains definitionList data, false otherwise.</returns>
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
        /// Gets the content nodes from the specified HTML node.
        /// </summary>
        /// <param name="node">The HTML node.</param>
        /// <returns>A collection of HTML nodes.</returns>
        public static HtmlNodeCollection GetContentNodes(HtmlNode node)
        {
            // Validate method parametesr
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return node.SelectNodes(".//h1 | .//h2 | .//h3 | .//h4 | .//h5 | .//h6 | .//ul[not(.//ul)] | .//ol | .//p[not(ancestor::ul) and not(ancestor::ol)] | .//table | .//small");
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
                // Shortcut the process if no nodes match the criteria.
                if (spanNodes != null)
                {
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
                }
                else
                {
                    newListItemNode.AppendChild(HtmlNode.CreateNode($"<span>{listItemNode.InnerText}</span>"));
                }

                // Append the new list item node to the new list node
                newListNode.AppendChild(newListItemNode);
            }

            // Return the converted list
            return newListNode;
        }

        /// <summary>
        /// Creates an HTML definition list node.
        /// </summary>
        /// <returns>An HTML definition list node.</returns>
        public static HtmlNode OpenDefiintionList()
        {
            return HtmlNode.CreateNode("<dl></dl>");
        }

        /// <summary>
        /// Creates an HTML node with a div tag.
        /// </summary>
        /// <returns>
        /// An HTML node with a div tag.
        /// </returns>
        public static HtmlNode OpenStatBlock()
        {
            return HtmlNode.CreateNode("<div></div>");
        }

        /// <summary>
        /// Creates an HTML table node.
        /// </summary>
        /// <returns>An HTML table node.</returns>
        public static HtmlNode OpenTable()
        {
            return HtmlNode.CreateNode("<table></table>");
        }

        /// <summary>
        /// Parses the content of a given HTML section node, extracting specific elements such as
        /// headings, lists, and paragraphs. If the content contains definitionList data, it is organized
        /// into a definitionList structure within the returned node.
        /// </summary>
        /// <param name="node">The HtmlNode representing the section to be parsed.</param>
        /// <returns>
        /// An HtmlNode containing the parsed content, organized into a 'div' element, with any
        /// definitionList data structured into 'definitionList' elements.
        /// </returns>
        /// <remarks>
        /// The method specifically looks for the following elements within the section: h1, h2, h3,
        /// h4, h5, h6, ul, ol, and p. If definitionList data is detected, it is handled using the
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
            var contentNodes = WOINWebPageHelper.GetContentNodes(node);

            // If contentNodes is not null, process its contents
            if (contentNodes != null)
            {
                // Create node for holding parsed table data.
                var table = WOINWebPageHelper.OpenTable();

                // Create node for holding parsed definition block data.
                var statblock = WOINWebPageHelper.OpenStatBlock();

                // Create node for holding parsed definition data.
                var definitionList = WOINWebPageHelper.OpenDefiintionList();

                // Add each content item to the new node.
                foreach (var contentNode in contentNodes)
                {
                    if (table != null
                        && statblock != null
                        && definitionList != null
                        && WOINWebPageHelper.ContainsTableData(contentNode))
                    {
                        // Closeout any in-memory structures that have been started but not closed.
                        statblock = WOINWebPageHelper.CloseStatblock(newSectionNode, statblock);
                        definitionList = WOINWebPageHelper.CloseDefinitionList(newSectionNode, definitionList);

                        // Add to current in-memory structure.
                        WOINWebPageHelper.AddRowToTable(table, contentNode);
                    }
                    else if (table != null
                        && statblock != null
                        && definitionList != null
                        && WOINWebPageHelper.ContainsListData(contentNode))
                    {
                        // Closeout any in-memory structures that have been started but not closed.
                        table = WOINWebPageHelper.CloseTable(newSectionNode, table);
                        statblock = WOINWebPageHelper.CloseStatblock(newSectionNode, statblock);
                        definitionList = WOINWebPageHelper.CloseDefinitionList(newSectionNode, definitionList);

                        // Add to current in-memory structure.
                        newSectionNode.AppendChild(WOINWebPageHelper.GetList(contentNode));
                    }
                    else if (table != null
                        && statblock != null
                        && definitionList != null
                        && WOINWebPageHelper.ContainsStatblockData(contentNode))
                    {
                        // Closeout any in-memory structures that have been started but not closed.
                        table = WOINWebPageHelper.CloseTable(newSectionNode, table);
                        definitionList = WOINWebPageHelper.CloseDefinitionList(newSectionNode, definitionList);

                        // Add to current in-memory structure.
                        WOINWebPageHelper.AddRowToStatblock(statblock, contentNode);
                    }
                    else if (table != null && statblock != null && definitionList != null && WOINWebPageHelper.ContainsDefinitionData(contentNode))
                    {
                        // Closeout any in-memory structures that have been started but not closed.
                        table = WOINWebPageHelper.CloseTable(newSectionNode, table);
                        statblock = WOINWebPageHelper.CloseStatblock(newSectionNode, statblock);

                        // Add to current in-memory structure.
                        WOINWebPageHelper.AddRowToDefinitionList(definitionList, contentNode);
                    }
                    else
                    {
                        // Closeout any in-memory structures that have been started but not closed.
                        if (table != null && statblock != null && definitionList != null)
                        {
                            table = WOINWebPageHelper.CloseTable(newSectionNode, table);
                            statblock = WOINWebPageHelper.CloseStatblock(newSectionNode, statblock);
                            definitionList = WOINWebPageHelper.CloseDefinitionList(newSectionNode, definitionList);
                        }

                        // Copy the node as-is
                        newSectionNode.AppendChild(contentNode);
                    }
                }

                // Is there table data that needs to be copied?
                if (table != null && table.ChildNodes.Count > 0)
                {
                    newSectionNode.AppendChild(table);
                }

                // Is there stat block data that needs to be copied?
                if (statblock != null && statblock.ChildNodes.Count > 0)
                {
                    newSectionNode.AppendChild(statblock);
                }

                // Is there definitionList data that needs to be copied?
                if (definitionList != null && definitionList.ChildNodes.Count > 0)
                {
                    newSectionNode.AppendChild(definitionList);
                }
            }

            // Return the result
            return newSectionNode;
        }
    }
}
