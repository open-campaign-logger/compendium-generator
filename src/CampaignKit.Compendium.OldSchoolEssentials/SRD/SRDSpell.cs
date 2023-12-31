﻿// <copyright file="SRDSpell.cs" company="Jochen Linnemann - IT-Service">
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
    /// Class representing a spell from the Old School Essentials System Reference Document (SRD).
    /// </summary>
    public class SRDSpell : GameComponentBase
    {
        /// <summary>
        /// Represents a read-only instance of a CampaignEntry object.
        /// </summary>
        private readonly CampaignEntry campaignEntry;

        /// <summary>
        /// Initializes a new instance of the <see cref="SRDSpell"/> class.
        /// </summary>
        /// <param name="campaignEntry">The source CampaignLogger CampaignEntry that contains the source data.</param>
        public SRDSpell(CampaignEntry campaignEntry)
        {
            // Check if campaignEntry is null, if it is, throw an ArgumentNullException
            this.campaignEntry = campaignEntry ?? throw new ArgumentNullException(nameof(campaignEntry));

            // Set the Name property of this object to the value of the TagValue property of the campaignEntry object, or throw an ArgumentNullException if TagValue is null
            this.Name = this.campaignEntry.TagValue ?? throw new Exception($"CampaignEntry missing attribute: TagValue");

            // Check if the Labels property of campaignEntry is null or if it does not contain the label variable
            if (this.campaignEntry.Labels == null || !this.campaignEntry.Labels.Contains("Spell"))
            {
                // If either of the conditions are true, throw an exception
                throw new Exception($"Required label not found in CampaignEntry: Spell");
            }

            // Set caster type and level if possible.
            if (this.campaignEntry.Labels != null)
            {
                this.Level = this.campaignEntry.Labels.FirstOrDefault(l => l.StartsWith("Level")) ?? string.Empty;
                this.CasterType = this.campaignEntry.Labels.FirstOrDefault(l => l.StartsWith("Cleric") || l.StartsWith("Magic User")) ?? string.Empty;
            }

            // Set the SourceTitle property of this object to "Necrotic Gnome OGL"
            this.SourceTitle = SRDHelper.NECROTICGNOMEOGL;
        }

        /// <summary>
        /// Gets or sets the caster type for this spell.
        /// </summary>
        public string? CasterType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the level of this spell.
        /// </summary>
        public string? Level { get; set; } = string.Empty;

        /// <inheritdoc/>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a new CampaignEntry object.
            var campaignEntry = new CampaignEntry()
            {
                TagSymbol = this.TagSymbol,
                TagValue = this.Name,
                Labels = new List<string>(),
            };

            // Copy any predefined labels over to the new object.
            if (this.Labels != null && this.Labels.Count > 0)
            {
                campaignEntry.Labels.AddRange(this.Labels);
            }

            // If the Level is not empty, add it to the Labels list.
            if (!string.IsNullOrEmpty(this.Level))
            {
                campaignEntry.Labels.Add(this.Level);
            }

            // If the CasterType is not empty, add it to the Labels list.
            if (!string.IsNullOrEmpty(this.CasterType))
            {
                campaignEntry.Labels.Add(this.CasterType);
            }

            // Create a new StringBuilder object with the RawText of the CampaignEntry.
            var builder = new StringBuilder(string.IsNullOrEmpty(this.campaignEntry.RawText) ? this.campaignEntry.RawPublic ?? string.Empty : this.campaignEntry.RawText);

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                builder.AppendLine();
                builder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            // Set the RawText of the CampaignEntry to the StringBuilder object.
            campaignEntry.RawPublic = builder.ToString();

            // Return the CampaignEntry object.
            return campaignEntry;
        }
    }
}