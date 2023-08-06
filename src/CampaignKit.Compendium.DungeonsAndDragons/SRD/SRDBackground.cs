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
    using Newtonsoft.Json;

    public class SRDBackground
    {
        /// <summary>
        /// Gets or sets the name of the background.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the background.
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the skill proficiencies associated with the background.
        /// </summary>
        [JsonProperty("skill-proficiencies")]
        public string SkillProficiencies { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the languages associated with the background.
        /// </summary>
        [JsonProperty("languages")]
        public string Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the equipment associated with the background.
        /// </summary>
        [JsonProperty("equipment")]
        public string Equipment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the feature related to the background.
        /// </summary>
        [JsonProperty("feature-name")]
        public string FeatureName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the feature related to the background.
        /// </summary>
        [JsonProperty("feature-desc")]
        public string FeatureDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the suggested characteristics related to the background.
        /// </summary>
        [JsonProperty("suggested-characteristics")]
        public string SuggestedCharacteristics { get; set; } = string.Empty;
    }

}
