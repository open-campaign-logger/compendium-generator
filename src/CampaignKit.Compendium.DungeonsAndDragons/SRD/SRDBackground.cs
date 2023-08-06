// <copyright file="SRDBackground.cs" company="Jochen Linnemann - IT-Service">
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
    /// Class representing a Dungeons &amp; Dragons class background.
    /// </summary>
    public class SRDBackground : IGameComponent
    {
        /// <summary>
        /// Gets or sets the ability score increases associated with the background.
        /// </summary>
        [JsonProperty("ability-score_increases")]
        public string? AbilityScoreIncreases { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the adventures and advancement information associated with the background.
        /// </summary>
        [JsonProperty("adventures-and-advancement")]
        public string? AdventuresAndAdvancement { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the background.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the equipment associated with the background.
        /// </summary>
        [JsonProperty("equipment")]
        public string? Equipment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the feature related to the background.
        /// </summary>
        [JsonProperty("feature-desc")]
        public string? FeatureDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the feature related to the background.
        /// </summary>
        [JsonProperty("feature-description")]
        public string? FeatureDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the feature related to the background.
        /// </summary>
        [JsonProperty("feature-name")]
        public string? FeatureName { get; set; } = string.Empty;

        /// <inheritdoc/>
        public List<string>? Labels { get; set; } = new List<string> { };

        /// <summary>
        /// Gets or sets the languages associated with the background.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the background.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the skill proficiencies associated with the background.
        /// </summary>
        [JsonProperty("skill-proficiencies")]
        public string? SkillProficiencies { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? SourceTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the suggested characteristics related to the background.
        /// </summary>
        [JsonProperty("suggested-characteristics")]
        public string? SuggestedCharacteristics { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? TagSymbol { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? TagValuePrefix { get; set; } = string.Empty;

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            stringBuilder.AppendLine(this.Desc);
            if (!string.IsNullOrEmpty(this.SkillProficiencies))
            {
                stringBuilder.AppendLine($"* Skill Profficiencies: {this.SkillProficiencies}");
            }

            if (!string.IsNullOrEmpty(this.AbilityScoreIncreases))
            {
                stringBuilder.AppendLine($"* Ability Score Increates: {this.AbilityScoreIncreases}");
            }

            if (!string.IsNullOrEmpty(this.Languages))
            {
                stringBuilder.AppendLine($"* Languages: {this.Languages}");
            }

            if (!string.IsNullOrEmpty(this.Equipment))
            {
                stringBuilder.AppendLine($"* Equipment: {this.Equipment}");
            }

            if (!string.IsNullOrEmpty(this.FeatureName))
            {
                stringBuilder.AppendLine($"## {this.FeatureName}");
            }

            if (!string.IsNullOrEmpty(this.FeatureDesc))
            {
                stringBuilder.AppendLine($"{this.FeatureDesc}");
            }

            if (!string.IsNullOrEmpty(this.FeatureDescription))
            {
                stringBuilder.AppendLine($"{this.FeatureDescription}");
            }

            if (!string.IsNullOrEmpty(this.SuggestedCharacteristics))
            {
                stringBuilder.AppendLine($"## Suggested Characteristics");
                stringBuilder.AppendLine($"{this.SuggestedCharacteristics}");
            }

            if (!string.IsNullOrEmpty(this.AdventuresAndAdvancement))
            {
                stringBuilder.AppendLine($"## Adventures and Advancement");
                stringBuilder.AppendLine($"{this.AdventuresAndAdvancement}");
            }

            // Add other text generation steps here.

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            CampaignEntry campaignEntry = new ()
            {
                RawText = stringBuilder.ToString(),
                RawPublic = string.Empty,
                Labels = this.Labels,
                TagSymbol = this.TagSymbol,
                TagValue = $"{this.TagValuePrefix}{this.Name}",
            };

            return campaignEntry;
        }
    }
}
