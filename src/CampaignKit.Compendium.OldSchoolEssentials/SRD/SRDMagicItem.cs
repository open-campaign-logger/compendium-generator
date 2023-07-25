// <copyright file="SRDMagicItem.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.OldSchoolEssentials.SRD
{
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    /// <summary>
    /// Class representing a item from the Old School Essentials System Reference Document (SRD).
    /// </summary>
    public class SRDMagicItem : IGameComponent
    {
        /// <summary>
        /// Represents a read-only instance of a CampaignEntry object.
        /// </summary>
        private readonly CampaignEntry campaignEntry;

        /// <summary>
        /// Initializes a new instance of the <see cref="SRDMagicItem"/> class.
        /// </summary>
        /// <param name="campaignEntry">The source CampaignLogger CampaignEntry that contains the source data.</param>
        public SRDMagicItem(CampaignEntry campaignEntry)
        {
            // Check if campaignEntry is null, if it is, throw an ArgumentNullException
            this.campaignEntry = campaignEntry ?? throw new ArgumentNullException(nameof(campaignEntry));

            // Set the Name property of this object to the value of the TagValue property of the campaignEntry object, or throw an ArgumentNullException if TagValue is null
            this.Name = this.campaignEntry.TagValue ?? throw new Exception($"CampaignEntry missing attribute: TagValue");

            // Check if the Labels property of campaignEntry is null or if it does not contain the label variable
            if (this.campaignEntry.Labels == null || !this.campaignEntry.Labels.Contains("Magic Items"))
            {
                // If either of the conditions are true, throw an exception
                throw new Exception($"Required label not found in CampaignEntry: Magic Items");
            }

            // Set the PublisherName property of this object to "Necrotic Gnome"
            this.PublisherName = "Necrotic Gnome";

            // Set the LicenseURL property of this object to the URL of the Open Game License
            this.LicenseURL = "https://oldschoolessentials.necroticgnome.com/srd/index.php/%E2%A7%BCOpen_Game_License%E2%A7%BD";
        }

        /// <inheritdoc/>
        public string? LicenseURL { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? PublisherName { get; set; } = string.Empty;

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            // Create a new CampaignEntry object.
            var campaignEntry = new CampaignEntry()
            {
                TagSymbol = "+",
                TagValue = this.Name,
                Labels = new List<string>()
                {
                    "OSE",
                },
            };

            // Copy labels from the original campaign entry
            if (this.campaignEntry.Labels != null)
            {
                foreach (var label in this.campaignEntry.Labels)
                {
                    campaignEntry.Labels.Add(label);
                }
            }

            // Create a new StringBuilder object with the RawText of the CampaignEntry.
            var builder = new StringBuilder(string.IsNullOrEmpty(this.campaignEntry.RawText) ? this.campaignEntry.RawPublic ?? string.Empty : this.campaignEntry.RawText);

            // If the PublisherName and LicenseURL are not empty, append them to the RawText.
            if (!string.IsNullOrEmpty(this.PublisherName) && !string.IsNullOrEmpty(this.LicenseURL))
            {
                builder.AppendLine();
                builder.AppendLine();
                builder.AppendLine($"Source: [{this.PublisherName}]({this.LicenseURL})");
            }

            // Set the RawText of the CampaignEntry to the StringBuilder object.
            campaignEntry.RawPublic = builder.ToString();

            // Return the CampaignEntry object.
            return campaignEntry;
        }
    }
}