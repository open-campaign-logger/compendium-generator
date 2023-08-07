// <copyright file="SRDSpell.cs" company="Jochen Linnemann - IT-Service">
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
    using Microsoft.IdentityModel.Tokens;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a spell in a Dungeons and Dragons game.
    /// </summary>
    public class SRDSpell : SRDBase
    {
        /// <summary>
        /// Gets or sets the Advanced 5th Edition schools that this spell belongs to.
        /// </summary>
        public List<string>? A5ESchools { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the archetype of the spell.
        /// </summary>
        [JsonProperty("archetype")]
        public string? Archetype { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the casting time of the spell.
        /// </summary>
        [JsonProperty("casting_time")]
        public string? CastingTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the circle of magic property for the spell.
        /// </summary>
        [JsonProperty("circles")]
        public string? Circles { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the spell casting class for this spell.
        /// </summary>
        [JsonProperty("class")]
        public string? Class { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the classes that this spell belongs to.
        /// </summary>
        public List<string>? Classes { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the components required to cast the spell.
        /// </summary>
        [JsonProperty("components")]
        public string? Components { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the concentration property of this spell.
        /// </summary>
        [JsonProperty("concentration")]
        public string? Concentration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the dame types associated with this spell.
        /// </summary>
        public List<string>? DamageType { get; set; } = new List<string> { };

        /// <summary>
        /// Gets or sets the domains property of this spell.
        /// </summary>
        [JsonProperty("domains")]
        public string? Domains { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the duration property of the spell.
        /// </summary>
        [JsonProperty("duration")]
        public string? Duration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the higher level casting information for the spell.
        /// </summary>
        [JsonProperty("higher_level")]
        public string? HigherLevel { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the level of the spell.
        /// </summary>
        [JsonProperty("level")]
        public string? Level { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the level of the spell in integer format.
        /// </summary>
        [JsonProperty("level_int")]
        public int? LevelInt { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the material components of the spell.
        /// </summary>
        [JsonProperty("material")]
        public string? Material { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the oaths property of the spell.
        /// </summary>
        [JsonProperty("oaths")]
        public string? Oaths { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the page property of the spell.
        /// </summary>
        [JsonProperty("page")]
        public string? Page { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the patrons property of the spell.
        /// </summary>
        [JsonProperty("patrons")]
        public string? Patrons { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the range property of the spell.
        /// </summary>
        [JsonProperty("range")]
        public string? Range { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ritual property of the spell.
        /// </summary>
        [JsonProperty("ritual")]
        public string? Ritual { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rolls attack property of the spell.
        /// </summary>
        [JsonProperty("rolls-attack")]
        public bool? RollsAttack { get; set; } = false;

        /// <summary>
        /// Gets or sets the saving throws associated with this spell.
        /// </summary>
        [JsonProperty("saving_throw_ability")]
        public List<string>? SavingThrowAbility { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the school of magic that this spell belongs to.
        /// </summary>
        [JsonProperty("school")]
        public string? School { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the shape of the spell.
        /// </summary>
        [JsonProperty("shape")]
        public string? Shape { get; set; } = string.Empty;

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

            if (!string.IsNullOrEmpty(this.Page))
            {
                stringBuilder.AppendLine($"* {{b|Page}}: {this.Page}");
            }

            if (!string.IsNullOrEmpty(this.Range))
            {
                stringBuilder.AppendLine($"* {{b|Range}}: {this.Range}");
            }

            if (!string.IsNullOrEmpty(this.Components))
            {
                stringBuilder.AppendLine($"* {{b|Components}}: {this.Components}");
            }

            if (!string.IsNullOrEmpty(this.Material))
            {
                stringBuilder.AppendLine($"* {{b|Material}}: {this.Material}");
            }

            if (!string.IsNullOrEmpty(this.Ritual))
            {
                stringBuilder.AppendLine($"* {{b|Ritual}}: {this.Ritual}");
            }

            if (!string.IsNullOrEmpty(this.Duration))
            {
                stringBuilder.AppendLine($"* {{b|Duration}}: {this.Duration}");
            }

            if (!string.IsNullOrEmpty(this.Concentration))
            {
                stringBuilder.AppendLine($"* {{b|Concentration}}: {this.Concentration}");
            }

            if (!string.IsNullOrEmpty(this.CastingTime))
            {
                stringBuilder.AppendLine($"* {{b|Casting Time}}: {this.CastingTime}");
            }

            if (this.LevelInt != int.MinValue)
            {
                stringBuilder.AppendLine($"* {{b|Level Int}}: {this.LevelInt}");
            }

            if (!string.IsNullOrEmpty(this.HigherLevel))
            {
                stringBuilder.AppendLine($"* {{b|HigherLevel}}: {this.HigherLevel}");
            }

            if (!string.IsNullOrEmpty(this.School))
            {
                stringBuilder.AppendLine($"* {{b|School}}: {this.School}");
            }

            if (!string.IsNullOrEmpty(this.Class))
            {
                stringBuilder.AppendLine($"* {{b|Class}}: {this.Class}");
            }

            if (!string.IsNullOrEmpty(this.Archetype))
            {
                stringBuilder.AppendLine($"* {{b|Archetype}}: {this.Archetype}");
            }

            if (!string.IsNullOrEmpty(this.Circles))
            {
                stringBuilder.AppendLine($"* {{b|Circles}}: {this.Circles}");
            }

            if (this.RollsAttack ?? false)
            {
                stringBuilder.AppendLine($"* {{b|Is Rolled Attack?}}: {this.RollsAttack}");
            }

            if (this.Classes != null && this.Classes.Count > 0)
            {
                stringBuilder.AppendLine($"* {{b|Classes}}: {string.Join(", ", this.Classes)}");
            }

            if (this.A5ESchools != null && this.A5ESchools.Count > 0)
            {
                stringBuilder.AppendLine($"* {{b|Advanced Fifth Edition Schools}}: {string.Join(", ", this.A5ESchools)}");
            }

            if (this.SavingThrowAbility != null && this.SavingThrowAbility.Count > 0)
            {
                stringBuilder.AppendLine($"* {{b|Saving Throws}}: {string.Join(", ", this.SavingThrowAbility ?? new List<string>())}");
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
