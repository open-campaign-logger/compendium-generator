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
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Services;

    using ReverseMarkdown;

    /// <summary>
    /// Represents an Systems Reference Document (SRD) web page containing TTRPG game components.
    /// </summary>
    public class SRDWebPage : GameComponentBase, IComparable<SRDWebPage>
    {
        /// <summary>
        /// Gets or sets the list of child pages referenced by this page.
        /// </summary>
        public List<SRDWebPage> Children { get; set; } = new List<SRDWebPage>();

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
        public string SourceDataURI { get; set; } = string.Empty;

        /// <inheritdoc/>
        public int CompareTo(SRDWebPage? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return 0;
            }
            else
            {
                return this.SourceDataURI.CompareTo(obj.SourceDataURI);
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            SRDWebPage person = (SRDWebPage)obj;
            return this.SourceDataURI == person.SourceDataURI;
        }

        /// <summary>
        /// Downloads a file from the given URI and returns a list of SRDWebPage objects containing
        /// this web page and its child pages.
        /// </summary>
        /// <param name="downloadService">The download service to use.</param>
        /// <param name="filenameOverride">Optional filename override for URIs that are difficult to derive a filename from.</param>
        /// <param name="filenameOverrideOption">The filename override options to use when downloading the source file.</param>
        /// <returns>A list of SRDWebPage objects.</returns>
        public async Task<List<CampaignEntry>> GetCampaignEntitiesAsync(
            IDownloadService downloadService,
            string filenameOverride,
            FilenameOverrideOptions filenameOverrideOption)
        {
            // Create a new list to store the results
            var result = new List<CampaignEntry>();

            // Download the file from the given source
            this.LocalPath = await downloadService.DownloadFile(
                this.SourceDataURI,
                this.RootDataDirectory,
                this.OverwriteExisting,
                filenameOverride,
                filenameOverrideOption);

            // Read the contents of the file
            var html = File.ReadAllText(this.LocalPath);

            // Todo
            // 1. Use config provided regex to navigate to starting node in HTML
            // 2. this.Name = page title.
            // 3. Extract links
            // 4. Create child objects for each linked resource (if they are a sub-page)

            // Convert the HTML to Markdown
            var config = new ReverseMarkdown.Config
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
            var converter = new ReverseMarkdown.Converter(config);

            this.Markdown = converter.Convert(html);

            // Add this web page to the return collection
            result.Add(this.ToCampaignEntry());

            // Return the result
            return result;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.SourceDataURI);
        }

        /// <inheritdoc/>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");

            // Add Markdown
            stringBuilder.AppendLine(this.Markdown);

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

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Name: {this.Name}, URI: {this.SourceDataURI}";
        }
    }
}