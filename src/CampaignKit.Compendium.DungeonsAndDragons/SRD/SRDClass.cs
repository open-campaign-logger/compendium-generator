// <copyright file="SRDClass.cs" company="Jochen Linnemann - IT-Service">
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
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a class in a Dungeons and Dragons game.
    /// </summary>
    public class SRDClass : SRDBase
    {
        /// <summary>
        /// Gets or sets the features associated with this class.
        /// </summary>
        [JsonProperty("features")]
        public SRDClassFeature ClassFeatures { get; set; } = new ();

        /// <summary>
        /// Gets or sets the subtypes associated with this class.
        /// </summary>
        [JsonProperty("subtypes")]
        public List<SRDBase>? Subtypes { get; set; } = new();

        /// <summary>
        /// Gets or sets the subtypes name for this class.
        /// </summary>
        [JsonProperty("subtypes-name")]
        public string? SubtypesName { get; set; } = string.Empty;

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

            if (this.ClassFeatures != null)
            {
                stringBuilder.AppendLine("## Class Features");
                stringBuilder.AppendLine($"* {{b|Hit Dice}}: {this.ClassFeatures.HitDice}");
                stringBuilder.AppendLine($"* {{b|Hit Points at First Level}}: {this.ClassFeatures.HpAt1stLevel}");
                stringBuilder.AppendLine($"* {{b|Hit Points at Higher Levels}}: {this.ClassFeatures.HpAtHigherLevels}");
                stringBuilder.AppendLine($"* {{b|Armor Proficiencies}}: {this.ClassFeatures.ProfArmor}");
                stringBuilder.AppendLine($"* {{b|Weapon Proficiencies}}: {this.ClassFeatures.ProfWeapons}");
                stringBuilder.AppendLine($"* {{b|Tool Proficiencies}}: {this.ClassFeatures.ProfTools}");
                stringBuilder.AppendLine($"* {{b|Saving Throw Proficiencies}}: {this.ClassFeatures.ProfSavingThrows}");
                stringBuilder.AppendLine($"* {{b|Skill Proficiencies}}: {this.ClassFeatures.ProfSkills}");
                stringBuilder.AppendLine($"* {{b|Starting Equipment}}: {this.ClassFeatures.Equipment}");
                if (!string.IsNullOrEmpty(this.ClassFeatures.SpellcastingAbility))
                {
                    stringBuilder.AppendLine($"* {{b|Spell Casting Ability}}: {this.ClassFeatures.SpellcastingAbility}");
                }

                stringBuilder.AppendLine(this.ClassFeatures.Table);
                stringBuilder.AppendLine(this.ClassFeatures.Desc);
            }

            if (!string.IsNullOrEmpty(this.SubtypesName) && this.Subtypes != null && this.Subtypes.Count > 0)
            {
                stringBuilder.AppendLine($"## {this.SubtypesName}");
                foreach (var subtype in this.Subtypes)
                {
                    stringBuilder.AppendLine($"### {subtype.Name}");
                    stringBuilder.AppendLine($"{subtype.Desc}");
                }
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
