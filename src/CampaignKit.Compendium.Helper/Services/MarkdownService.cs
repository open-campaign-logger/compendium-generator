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

namespace CampaignKit.Compendium.Helper.Services
{
    using HtmlAgilityPack;

    using ReverseMarkdown;

    /// <summary>
    /// Service for converting text to Markdown format.
    /// </summary>
    public class MarkdownService
    {
        private readonly ILogger<MarkdownService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownService"/> class.
        /// </summary>
        /// <param name="logger">Logger object for logging.</param>
        /// <returns>
        /// MarkdownService object.
        /// </returns>
        public MarkdownService(ILogger<MarkdownService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Converts HTML to Markdown using the Markdig library.
        /// </summary>
        /// <param name="html">The HTML to convert.</param>
        /// <returns>The Markdown representation of the HTML.</returns>
        public string ConvertHtmlToMarkdown(string html)
        {
            // Validate parameters
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            // Log method entry.
            logger.LogInformation("ConvertHtmlToMarkdown method called with html: {Html}", html[..50]);

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

            // Log the response
            logger.LogInformation("ConvertHtmlToMarkdown method completed with response: {Response}", markdown[..50]);

            // Return the reponse.
            return markdown;
        }
    }
}
