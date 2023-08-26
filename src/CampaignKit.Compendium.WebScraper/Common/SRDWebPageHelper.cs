// <copyright file="SRDWebPageHelper.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.WebScraper.Common
{
    using HtmlAgilityPack;

    /// <summary>
    /// Uility class for SRDWebPage content manipulation routines.
    /// </summary>
    public static class SRDWebPageHelper
    {
        /// <summary>
        /// Loads an HTML document from the provided HTML string. If a main content XPath is
        /// provided, the method navigates to the specified node and reloads the document with the
        /// content of that node. If the XPath is not found, an exception is thrown.
        /// </summary>
        /// <param name="html">The HTML string from which the document will be loaded.</param>
        /// <param name="mainContentPath">
        /// Optional. The XPath to the main content node. If provided, the document will be reloaded
        /// with the content of this node.
        /// </param>
        /// <returns>An HtmlDocument object representing the loaded HTML document.</returns>
        /// <exception cref="Exception">Thrown if the provided XPath is not found in the document.</exception>
        public static HtmlDocument LoadHtmlDocument(string html, string? mainContentPath = "")
        {
            // Create an HTML object for the data.
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Navigate to the chosen HTML node if an XPath has been provided.
            if (!string.IsNullOrEmpty(mainContentPath))
            {
                var node = doc.DocumentNode.SelectSingleNode(mainContentPath);
                if (node != null)
                {
                    html = node.OuterHtml;
                    doc.LoadHtml(html);
                }
                else
                {
                    throw new Exception($"Unable to find node corresponding to XPath: {mainContentPath}");
                }
            }

            return doc;
        }
    }
}
