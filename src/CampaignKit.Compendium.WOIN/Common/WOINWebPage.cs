// <copyright file="WOINWebPage.cs" company="Jochen Linnemann - IT-Service">
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
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Transactions;

    using CampaignKit.Compendium.WebScraper.Common;

    using HtmlAgilityPack;

    /// <summary>
    /// Represents a web page for the WOIN system. Inherits from SRDWebPage.
    /// </summary>
    public class WOINWebPage : SRDWebPage
    {
        /// <inheritdoc/>
        public override string PostProcessMarkdown(string markdown)
        {
            // Regular expression pattern to match headers with text on a separate line
            string pattern = @"(##)\s*\n\s*(\w.*)";

            // Replacement pattern to move the header text to the same line as the markdown header
            string replacement = "$1 $2";

            // Perform the replacement using Regex.Replace
            var result = Regex.Replace(markdown, pattern, replacement);

            return result;
        }

        /// <inheritdoc/>
        public override string PreProcessHtml(string html)
        {
            // Create an HTML object for the data.
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Select all <img> elements
            var images = doc.DocumentNode.SelectNodes("//img");

            // If images were found, remove them
            if (images != null)
            {
                foreach (var img in images)
                {
                    img.Remove();
                }
            }

            // Process each section
            var sectionNodes = doc.DocumentNode.SelectNodes("//div[@role='main']/section");
            foreach (var sectionNode in sectionNodes)
            {
                // Select all content elements.
                var contentNodes = sectionNode.SelectNodes(".//p | .//h1 | .//h2 | .//h3 | .//h4 | .//h5 | .//h6");

                // If contentNodes is null, skip it.
                if (contentNodes == null)
                {
                    continue;
                }

                // Create a new node to hold the extracted content.
                var newSectionNode = HtmlNode.CreateNode("<div></div>");

                // Add each content item to the new node.
                foreach (var contentNode in contentNodes)
                {
                    newSectionNode.AppendChild(contentNode);
                }

                // Replace the old section node with the new section node.
                sectionNode.ParentNode.ReplaceChild(newSectionNode, sectionNode);
            }

            return doc.DocumentNode.OuterHtml;
        }

        /// <summary>
        /// Converts WOIN div/span tables in the source material to standard HTML table.
        /// </summary>
        /// <param name="html">HTML with table elements to be converted.</param>
        /// <returns>HTML containing updated table elements.</returns>
        private static string ConvertTables(string html)
        {
            HtmlDocument document = new ();
            document.LoadHtml(html);

            // The following XPath will retrieve all table row nodes from the document.
            var tableRowNodes = document.DocumentNode.SelectNodes("//p[count(span[@class='C9DxTc ']) > 1 and not(parent::li) and count(span/span[@class='Apple-tab-span ']) > 1]");
            var tableNodes = new List<HtmlNode>();

            // Retrieve parent nodes for the retrieved table rows.
            // (We have to derive this because table rows don't have a clear parent that can be selected via XPath.)
            if (tableRowNodes != null)
            {
                // This loop iterates through each table row node in the tableRowNodes list and
                // adds the parent node of the table row node to the tableNodes list if it is
                // not already present in the list. The HtmlNodeXPathComparer class is used to
                // compare the nodes in the list.
                foreach (var tableRow in tableRowNodes)
                {
                    var tableNode = tableRow.ParentNode as HtmlNode;
                    if (!tableNodes.Contains(tableNode, new HtmlNodeXPathComparer()))
                    {
                        tableNodes.Add(tableNode);
                    }
                }
            }

            // Replace table nodes
            foreach (var tableNode in tableNodes)
            {
                // Instantiate local variables
                var builder = new StringBuilder();
                var isHeaderRow = true;

                // Iterate through the 

                // See if there's a header row
                // This code is used to select all header nodes from a table node and append them to a builder.
                // It then parses the header level from the header node name and appends it to the builder with the inner text of the header node.
                var headerNodes = tableNode.SelectNodes(".//h1 | .//h2 | .//h3 | .//h4 | .//h5 | .//h6");

                // Check if header nodes exist and if there is more than one
                if (headerNodes != null && headerNodes.Count > 0)
                {
                    // Loop through each header node
                    foreach (var header in headerNodes)
                    {
                        // Append the header.
                        builder.AppendLine(header.OuterHtml);
                    }
                }

                // Select all <p> elements with more than one <span> element with class 'C9DxTc '
                var rowNodes = tableNode.SelectNodes(".//p[count(span[@class='C9DxTc ']) > 1]");

                // Start building the table
                builder.AppendLine("<table>");

                // Iterate through each row
                foreach (var row in rowNodes)
                {
                    // Set the cell tag to either 'th' or 'td' depending on if it is the header row
                    var cellTag = isHeaderRow ? "th" : "td";

                    // Start the row
                    builder.AppendLine("<tr>");

                    // Select all <span> elements within the row
                    var cellNodes = row.SelectNodes(".//span[@class='C9DxTc ' and not(.//span[@class='Apple-tab-span '])]");

                    // Iterate through each cell
                    foreach (var cell in cellNodes)
                    {
                        // Append the cell tag with the inner text of the cell
                        builder.AppendLine($"<{cellTag}>{cell.InnerText}</{cellTag}>");
                    }

                    // End the row
                    builder.AppendLine("</tr>");

                    // Set the isHeaderRow flag to false
                    isHeaderRow = false;
                }

                // End the table
                builder.AppendLine("</table>");

                // Substitute the new HTML for the old.
                var newTableDoc = new HtmlDocument();
                newTableDoc.LoadHtml(builder.ToString());
                tableNode.ParentNode.ReplaceChild(newTableDoc.DocumentNode, tableNode);
            }

            return document.DocumentNode.OuterHtml;
        }
    }
}
