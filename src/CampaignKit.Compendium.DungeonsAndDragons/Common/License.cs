// <copyright file="License.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Common
{
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents the license information for a particular data set within the application.
    /// </summary>
    public class License
    {
        /// <summary>
        /// Gets or sets the author of the licensed content.
        /// </summary>
        [JsonProperty("author")]
        public string? Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the copyright information for the licensed content.
        /// </summary>
        [JsonProperty("copyright")]
        public string? Copyright { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the license.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the actual text of the license agreement.
        /// </summary>
        [JsonProperty("license")]
        public string? LicenseName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of OGL lines.
        /// </summary>
        [JsonProperty("ogl-lines")]
        public List<string>? OGLLines { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the organization that owns the licensed content.
        /// </summary>
        [JsonProperty("organization")]
        public string? Organization { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the slug of the license.
        /// A slug is a URL-friendly version of the title which is typically used in links to the license.
        /// </summary>
        [JsonProperty("slug")]
        public string? Slug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the license.
        /// </summary>
        [JsonProperty("title")]
        public string? SourceTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL where more information about the license can be found.
        /// </summary>
        [JsonProperty("url")]
        public string? Url { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the version of the licensed content.
        /// </summary>
        [JsonProperty("version")]
        public string? Version { get; set; } = string.Empty;

        /// <summary>
        /// Converts this license configuration into a campaign entry.
        /// </summary>
        /// <returns>Campaign entry representing this license configuration.</returns>
        public CampaignEntry ToCampaignEntry()
        {
            // Create a new StringBuilder object called licenseBuilder
            var licenseBuilder = new StringBuilder();

            // Append a line to the licenseBuilder object with the title of the license
            licenseBuilder.AppendLine($"# {this.SourceTitle}");

            // Check if the description of the license is not empty
            if (!string.IsNullOrEmpty(this.Desc))
            {
                // If the description is not empty, append a line with the heading "Description"
                licenseBuilder.AppendLine("## Description");

                // Append a line with the description of the license
                licenseBuilder.AppendLine(this.Desc);
            }

            // Check if LicenseName is not null or empty
            if (!string.IsNullOrEmpty(this.LicenseName))
            {
                // Append "## License" to licenseBuilder
                licenseBuilder.AppendLine("## License");

                // Append LicenseName to licenseBuilder
                licenseBuilder.AppendLine(this.LicenseName);
            }

            // Check if Version is not null or empty
            if (!string.IsNullOrEmpty(this.Version))
            {
                // Append "## License" to licenseBuilder
                licenseBuilder.AppendLine("## Version");

                // Append LicenseName to licenseBuilder
                licenseBuilder.AppendLine(this.Version);
            }

            // Check if Author is not null or empty
            if (!string.IsNullOrEmpty(this.Author))
            {
                // Append "## Author(s)" to licenseBuilder
                licenseBuilder.AppendLine("## Author(s)");

                // Append Author to licenseBuilder
                licenseBuilder.AppendLine(this.Author);
            }

            // Check if Organization is not null or empty
            if (!string.IsNullOrEmpty(this.Organization))
            {
                // Append "## Organization" to licenseBuilder
                licenseBuilder.AppendLine("## Organization");

                // Append Organization to licenseBuilder
                licenseBuilder.AppendLine(this.Organization);
            }

            // Check if Url is not null or empty
            if (!string.IsNullOrEmpty(this.Url))
            {
                // Append "## URL" to licenseBuilder
                licenseBuilder.AppendLine("## URL");

                // Append Url to licenseBuilder
                licenseBuilder.AppendLine(this.Url);
            }

            // Check if the Copyright property is not empty
            if (!string.IsNullOrEmpty(this.Copyright))
            {
                // Append the copyright header
                licenseBuilder.AppendLine("## Copyright");

                // Append the copyright value
                licenseBuilder.AppendLine(this.Copyright);
            }

            // Check if the OGLLines property is not empty and has more than 0 elements
            if (this.OGLLines != null && this.OGLLines.Count > 0)
            {
                // Append the OGL header
                licenseBuilder.AppendLine("## OGL");

                // Iterate through the OGLLines
                foreach (var oGLLine in this.OGLLines)
                {
                    // Append each line of the OGL
                    licenseBuilder.AppendLine(oGLLine.ToString());
                }
            }

            // Create a new CampaignEntry object
            var result = new CampaignEntry()
            {
                // Set the TagSymbol property to "~"
                TagSymbol = "~",

                // Set the TagValue property to the Organization property
                TagValue = this.SourceTitle,

                // Set the RawPublic property to the licenseBuilder string
                RawPublic = licenseBuilder.ToString(),
            };

            // Return the CampaignEntry object
            return result;
        }
    }
}
