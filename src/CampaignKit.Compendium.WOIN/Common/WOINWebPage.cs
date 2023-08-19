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
    using System.Text.RegularExpressions;

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
                var contentNodes = sectionNode.SelectNodes(".//h1 | .//h2 | .//h3 | .//h4 | .//h5 | .//h6 | .//ul | .//ol | .//p");

                // If contentNodes is null, skip this section.
                if (contentNodes == null)
                {
                    continue;
                }

                // Create a new node to hold content extracted from the section.
                var newSectionNode = HtmlNode.CreateNode("<div></div>");

                // Create table node for holding parsed table data.
                var table = HtmlNode.CreateNode("<table></table>");

                // Add each content item to the new node.
                foreach (var contentNode in contentNodes)
                {
                    if (table != null && WOINHelper.ContainsTableData(contentNode))
                    {
                        WOINHelper.AddRowToTable(table, contentNode);
                    }
                    else
                    {
                        // Is there table data that needs to be copied?
                        if (table != null && table.ChildNodes.Count > 0)
                        {
                            newSectionNode.AppendChild(table);
                            table = HtmlNode.CreateNode("<table></table>");
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

                // Replace the old section node with the new section node.
                sectionNode.ParentNode.ReplaceChild(newSectionNode, sectionNode);
            }

            return doc.DocumentNode.OuterHtml;
        }
    }
}