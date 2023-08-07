// <copyright file="SRDWeapon.cs" company="Jochen Linnemann - IT-Service">
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
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a weapon in a Dungeons and Dragons game.
    /// </summary>
    public class SRDWeapon : SRDBase
    {
        /// <summary>
        /// Gets or sets the cateogry of the weapon.
        /// </summary>
        [JsonProperty("category")]
        public string? Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the cost of the weapon.
        /// </summary>
        [JsonProperty("cost")]
        public string? Cost { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the damage dice for the weapon.
        /// </summary>
        [JsonProperty("damage_dice")]
        public object DamageDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the damage type of the weapon.
        /// </summary>
        [JsonProperty("damage_type")]
        public string? DamageType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the properties of the weapon.
        /// </summary>
        [JsonProperty("properties")]
        public List<string> Properties { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the weight of the weapon.
        /// </summary>
        [JsonProperty("weight")]
        public string? Weight { get; set; } = string.Empty;

        /// <summary>
        /// Generate a Campaign Entry that represents this object.
        /// </summary>
        /// <returns>A Campaign Entry that represents this object.</returns>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            if (!string.IsNullOrEmpty(this.Desc))
            {
                stringBuilder.AppendLine($"{this.Desc}");
            }

            stringBuilder.AppendLine($"* {{b|Category}}: {this.Category}");
            stringBuilder.AppendLine($"* {{b|Cost}}: {this.Cost}");
            stringBuilder.AppendLine($"* {{b|Damage Dice}}: {this.DamageDice}");
            stringBuilder.AppendLine($"* {{b|Damage Type}}: {this.DamageType}");
            stringBuilder.AppendLine($"* {{b|Weight}}: {this.Weight}");
            stringBuilder.AppendLine($"* {{b|Properties}}: {string.Join(", ", this.Properties)}");

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
