// <copyright file="SRDRace.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.DungeonsAndDragons.Common;
    using CampaignKit.Compendium.DungeonsAndDragons.MonstrousMenagerie;

    using Newtonsoft.Json;

    using System.Text;

    /// <summary>
    /// Represents the SRD Race information including attributes like ASI description, size, speed, languages, vision, traits, and subtypes.
    /// </summary>
    public class SRDRace : SRDBase
    {
        /// <summary>
        /// Gets or sets the ASI description.
        /// </summary>
        [JsonProperty("asi-desc")]
        public string? AsiDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ASI (Ability Score Increase) details.
        /// </summary>
        [JsonProperty("asi")]
        public List<SRDAbilityScoreIncrease>? Asi { get; set; } = new List<SRDAbilityScoreIncrease>();

        /// <summary>
        /// Gets or sets the age information.
        /// </summary>
        [JsonProperty("age")]
        public string? Age { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alignment information.
        /// </summary>
        [JsonProperty("alignment")]
        public string? Alignment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the size information.
        /// </summary>
        [JsonProperty("size")]
        public string? Size { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the raw size information.
        /// </summary>
        [JsonProperty("size-raw")]
        public string? SizeRaw { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the speed information.
        /// </summary>
        [JsonProperty("speed")]
        public SpeedJson? Speed { get; set; } = new SpeedJson();

        /// <summary>
        /// Gets or sets the speed description.
        /// </summary>
        [JsonProperty("speed-desc")]
        public string? SpeedDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vision information.
        /// </summary>
        [JsonProperty("vision")]
        public string? Vision { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the traits information.
        /// </summary>
        [JsonProperty("traits")]
        public string? Traits { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subtypes information.
        /// </summary>
        [JsonProperty("subtypes")]
        public List<SRDRaceSubType>? Subtypes { get; set; } = new List<SRDRaceSubType>();

        /// <summary>
        /// Generates a Campaign Entry from this object.
        /// </summary>
        /// <returns>A Campaign Entry from this object.</returns>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            stringBuilder.AppendLine(this.Desc);
            stringBuilder.AppendLine();
            if (!string.IsNullOrEmpty(this.AsiDesc))
            {
                stringBuilder.AppendLine(this.AsiDesc);
            }

            if (!string.IsNullOrEmpty(this.Age))
            {
                stringBuilder.AppendLine(this.Age);
            }

            if (!string.IsNullOrEmpty(this.Alignment))
            {
                stringBuilder.AppendLine(this.Alignment);
            }

            if (!string.IsNullOrEmpty(this.Size))
            {
                stringBuilder.AppendLine(this.Size);
            }

            if (!string.IsNullOrEmpty(this.Alignment))
            {
                stringBuilder.AppendLine(this.Alignment);
            }

            if (!string.IsNullOrEmpty(this.Size))
            {
                stringBuilder.AppendLine(this.Size);
            }

            if (!string.IsNullOrEmpty(this.SpeedDesc))
            {
                stringBuilder.AppendLine(this.SpeedDesc);
            }

            if (!string.IsNullOrEmpty(this.Languages))
            {
                stringBuilder.AppendLine(this.Languages);
            }

            if (!string.IsNullOrEmpty(this.Vision))
            {
                stringBuilder.AppendLine(this.Vision);
            }

            if (!string.IsNullOrEmpty(this.Traits))
            {
                stringBuilder.AppendLine(this.Traits);
            }

            if (this.Subtypes != null && this.Subtypes.Count > 0)
            {
                stringBuilder.AppendLine($"## Subtypes");
                foreach (var subtype in this.Subtypes)
                {
                    stringBuilder.AppendLine($"### {subtype.Name}");
                    stringBuilder.AppendLine($"{subtype.Desc}");
                    stringBuilder.AppendLine();
                    if (!string.IsNullOrEmpty(subtype.AsiDesc))
                    {
                        stringBuilder.AppendLine(subtype.AsiDesc);
                    }

                    if (!string.IsNullOrEmpty(subtype.Traits))
                    {
                        stringBuilder.AppendLine(subtype.Traits);
                    }
                }
            }

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            CampaignEntry campaignEntry = new()
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
