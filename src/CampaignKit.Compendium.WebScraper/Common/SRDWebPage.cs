// <copyright file="SRDWebPage.cs" company="Jochen Linnemann - IT-Service">
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
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using HtmlAgilityPack;

    using ReverseMarkdown;

    /// <summary>
    /// Represents an Systems Reference Document (SRD) web page containing TTRPG game components.
    /// </summary>
    public partial class SRDWebPage : GameComponentBase, IComparable<SRDWebPage>
    {
        /// <summary>
        /// Gets or sets the local file path to the downloaded web page.
        /// </summary>
        public string LocalPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the markdown conversion of this page.
        /// </summary>
        public string Markdown { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether to overwrite previously downloaded files.  Default: false.
        /// </summary>
        public bool OverwriteExisting { get; set; } = false;

        /// <summary>
        /// Gets or sets the local directory where this page will be downloaded to and read from.
        /// </summary>
        public string RootDataDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URI of the source data to download.
        /// </summary>
        public string SourceDataSetURI { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of XPath/HTML susbstitutions to use with for this data source.
        /// </summary>
        public List<Substitution> Substitutions { get; set; } = new List<Substitution> { };

        /// <summary>
        /// Gets or sets the optional XPath to use to navigate to the web page content.
        /// </summary>
        public string XPath { get; set; } = string.Empty;

        /// <inheritdoc/>
        public int CompareTo(SRDWebPage? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return 0;
            }
            else
            {
                return this.SourceDataSetURI.CompareTo(obj.SourceDataSetURI);
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            SRDWebPage webPage = (SRDWebPage)obj;
            return this.SourceDataSetURI == webPage.SourceDataSetURI;
        }

        /// <summary>
        /// Downloads a file from the given URI and returns a list of SRDWebPage objects containing
        /// this web page and its child pages.
        /// </summary>
        /// <param name="downloadService">The download service to use.</param>
        /// <param name="filenameOverride">Optional filename override for URIs that are difficult to derive a filename from.</param>
        /// <param name="filenameOverrideOption">The filename override options to use when downloading the source file.</param>ram>
        /// <returns>A list of SRDWebPage objects.</returns>
        public async Task<List<CampaignEntry>> GetCampaignEntitiesAsync(
            IDownloadService downloadService,
            string filenameOverride,
            FilenameOverrideOptions filenameOverrideOption)
        {
            // Download the file from the given source
            this.LocalPath = await downloadService.DownloadFile(
                this.SourceDataSetURI,
                this.RootDataDirectory,
                this.OverwriteExisting,
                filenameOverride,
                filenameOverrideOption);

            // Read the contents of the file
            var html = File.ReadAllText(this.LocalPath);

            // Load the HTML and, optionally, navigate to the content location.
            var doc = SRDWebPageHelper.LoadHtmlDocument(html, this.XPath);

            // Perform substitutions if required
            if (this.Substitutions != null && this.Substitutions.Count > 0)
            {
                foreach (var substitution in this.Substitutions)
                {
                    // Find the node
                    var oldNode = doc.DocumentNode.SelectSingleNode(substitution.XPath);

                    // Perform the substitution
                    if (oldNode != null)
                    {
                        // Create a new node with the new HTML content
                        HtmlNode newNode = HtmlNode.CreateNode(substitution.HTML);

                        // Replace the old node with the new node
                        oldNode.ParentNode.ReplaceChild(newNode, oldNode);
                    }
                }
            }

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

            // Pre-process HTML (if required)
            html = this.PreProcessHtml(doc.DocumentNode.OuterHtml);

            // Create a converter to convert the HTML to Markdown
            var converter = new Converter(config);
            var markdown = converter.Convert(html);

            // Post-process Markdown (if required)
            markdown = this.PostProcessMarkdown(markdown);
            this.Markdown = markdown;

            // Add this web page to the return collection
            return new List<CampaignEntry>()
            {
                this.ToCampaignEntry(),
            };
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.SourceDataSetURI);
        }

        /// <summary>
        /// Post-processes the Markdown before it is added to the campaign entry.
        /// </summary>
        /// <param name="markdown">A string of markdown text.</param>
        /// <returns>The post-processed markdown.</returns>
        public virtual string PostProcessMarkdown(string markdown)
        {
            // Regular expression pattern to match headers with text on a separate line
            string pattern = @"(##)\s*\n\s*(\w.*)";

            // Replacement pattern to move the header text to the same line as the markdown header
            string replacement = "$1 $2";

            // Perform the replacement using Regex.Replace
            var result = Regex.Replace(markdown, pattern, replacement);

            return result;
        }

        /// <summary>
        /// Pre-processes the HTML before it is converted into markdown.
        /// </summary>
        /// <param name="html">The HTML to pre-process.</param>
        /// <returns>The pre-processed HTML.</returns>
        public virtual string PreProcessHtml(string html)
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

            return doc.DocumentNode.OuterHtml;
        }

        /// <inheritdoc/>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();

            // Add Markdown
            stringBuilder.AppendLine(this.Markdown);

            // Add an attribution line if this is not the license file
            if (this.Name != null && !this.Name.Equals("License"))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"Source: ~License");
            }

            CampaignEntry campaignEntry = new ()
            {
                RawText = string.Empty,
                RawPublic = stringBuilder.ToString(),
                Labels = this.Labels,
                TagSymbol = this.TagSymbol,
                TagValue = $"{this.TagValuePrefix}{this.Name}",
            };

            return campaignEntry;
        }
    }
}