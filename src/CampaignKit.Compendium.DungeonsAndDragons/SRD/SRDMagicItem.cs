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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using System.Collections.Generic;
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a magic item in a Dungeons and Dragons game.
    /// </summary>
    public class SRDMagicItem : SRDBase
    {
        /// <summary>
        /// Gets or sets the rarity of the magic item.
        /// </summary>
        [JsonProperty("rarity")]
        public string? Rarity { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether or not this magic item requires attunement.
        /// </summary>
        [JsonProperty("requires-attunement")]
        public string? RequiresAttunement { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of magic item.
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; } = string.Empty;

        /// <summary>
        /// Generate a Campaign Entry that represents this object.
        /// </summary>
        /// <returns>A Campaign Entry that represents this object.</returns>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            stringBuilder.AppendLine(this.Desc);
            stringBuilder.AppendLine($"* {{b|Type}}: {this.Type}");
            stringBuilder.AppendLine($"* {{b|Rarity}}: {this.Rarity}");
            stringBuilder.AppendLine($"* {{b|Requires Attunement}}: {this.RequiresAttunement}");

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
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
