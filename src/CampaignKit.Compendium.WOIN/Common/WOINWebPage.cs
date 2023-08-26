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
            // Execute base class functionality
            markdown = base.PostProcessMarkdown(markdown);

            // Regular expression pattern to bullet lists with text on a separate line
            var pattern = @"^(#+ )─+";

            // Replacement pattern to move the header text to the same line as the markdown header
            var replacement = "#$1 Actions";

            // Perform the replacement using Regex.Replace
            markdown = Regex.Replace(markdown, pattern, replacement, RegexOptions.Multiline);

            return markdown;
        }

        /// <inheritdoc/>
        public override string PreProcessHtml(string html)
        {
            // Execute base class functionality
            html = base.PreProcessHtml(html);

            // Create an HTML object for the data.
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Process each section
            var sectionNodes = doc.DocumentNode.SelectNodes("//div[@role='main']/section");
            foreach (var sectionNode in sectionNodes)
            {
                // Parse the section conent
                var newSectionNode = WOINWebPageHelper.ParseSectionContent(sectionNode);

                // Replace the old section node with the new section node.
                sectionNode.ParentNode.ReplaceChild(newSectionNode, sectionNode);
            }

            return doc.DocumentNode.OuterHtml;
        }
    }
}