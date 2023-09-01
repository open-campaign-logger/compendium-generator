// <copyright file="MarkdownService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper.Data
{
    using HtmlAgilityPack;

    using ReverseMarkdown;

    /// <summary>
    /// Service for converting text to Markdown format.
    /// </summary>
    public class MarkdownService
    {
        /// <summary>
        /// Converts HTML to Markdown using the Markdig library.
        /// </summary>
        /// <param name="html">The HTML to convert.</param>
        /// <returns>The Markdown representation of the HTML.</returns>
        public static string ConvertHtmlToMarkdown(string html)
        {
            // Create a new HtmlDocument object
            var doc = new HtmlDocument();

            // Load the HTML string into the HtmlDocument object
            doc.LoadHtml(html);

            // Convert the HTML to Markdown
            var config = new Config
            {
                // Include the unknown tag completely in the result (default as well)
                UnknownTags = Config.UnknownTagsOption.Bypass,

                // generate GitHub flavoured markdown, supported for BR, PRE and table tags
                GithubFlavored = true,

                // will ignore all comments
                RemoveComments = true,

                // remove markdown output for links where appropriate
                SmartHrefHandling = true,
            };

            // Create a converter to convert the HTML to Markdown
            var converter = new Converter(config);
            var markdown = converter.Convert(html);

            return markdown;
        }
    }
}
