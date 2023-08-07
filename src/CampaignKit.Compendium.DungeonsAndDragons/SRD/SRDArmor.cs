// <copyright file="SRDArmor.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents an item of gear in a Dungeons and Dragons game.
    /// </summary>
    public class SRDArmor : SRDBase
    {
        /// <summary>
        /// Gets or sets the base AC for the armor.
        /// </summary>
        [JsonProperty("base_ac")]
        public int? BaseAc { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the cateogry of the armor.
        /// </summary>
        [JsonProperty("category")]
        public string? Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the cost of the armor.
        /// </summary>
        [JsonProperty("cost")]
        public string? Cost { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the whether this armor allows the character to add their constitution modifier
        /// to the armor's base AC.
        /// </summary>
        [JsonProperty("plus_con_mod")]
        public bool? PlusConMod { get; set; } = false;

        /// <summary>
        /// Gets or sets the whether this armor allows the character to add their dexterity modifier
        /// to the armor's base AC.
        /// </summary>
        [JsonProperty("plus_dex_mod")]
        public bool? PlusDexMod { get; set; } = false;

        /// <summary>
        /// Gets or sets the the flat modified to add to the character's current AC.
        /// </summary>
        [JsonProperty("plus_flat_mod")]
        public int? PlusFlatMod { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the maximum dexterity bonus which is the maximum amount of additional Armor
        /// Class you can gain from your Dexterity bonus while wearing an item.
        /// </summary>
        [JsonProperty("plus_max")]
        public int? PlusMax { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the whether this armor allows the character to add their wisdom modifier
        /// to the armor's base AC.
        /// </summary>
        [JsonProperty("plus_wis_mod")]
        public bool? PlusWisMod { get; set; } = false;

        /// <summary>
        /// Gets or sets the rarity of the magic item.
        /// </summary>
        [JsonProperty("rarity")]
        public string? Rarity { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the player has a stealth disadvantage while wearing this armor.
        /// </summary>
        [JsonProperty("stealth_disadvantage")]
        public bool? StealthDisadvantage { get; set; } = false;

        /// <summary>
        /// Gets or sets the strength requirement to wear this armor.
        /// </summary>
        [JsonProperty("strength_requirement")]
        public int? StrengthRequirement { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the weight of the armor.
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

            if (!string.IsNullOrEmpty(this.Category))
            {
                stringBuilder.AppendLine($"* {{b|Category}}: {this.Category}");
            }

            if (!string.IsNullOrEmpty(this.Rarity))
            {
                stringBuilder.AppendLine($"* {{b|Rarity}}: {this.Rarity}");
            }

            stringBuilder.AppendLine($"* {{b|Base AC}}: {this.BaseAc}");
            if (this.PlusDexMod ?? false)
            {
                stringBuilder.AppendLine($"* {{b|Add Dexterity Modifier?}}: Yes");
            }

            if (this.PlusConMod ?? false)
            {
                stringBuilder.AppendLine($"* {{b|Add Constitution Modifier?}}: Yes");
            }

            if (this.PlusFlatMod != int.MinValue)
            {
                stringBuilder.AppendLine($"* {{b|Flat AC Bonus}}: {this.PlusFlatMod}");
            }

            stringBuilder.AppendLine($"* {{b|Cost}}: {this.Cost}");
            stringBuilder.AppendLine($"* {{b|Weight}}: {this.Weight}");

            if (this.StealthDisadvantage ?? false)
            {
                stringBuilder.AppendLine($"* {{b|Disadvantage on Stealth}}: Yes");
            }

            if (this.StrengthRequirement != int.MinValue)
            {
                stringBuilder.AppendLine($"* {{b|Strength Requirement}}: {this.StrengthRequirement}");
            }

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
