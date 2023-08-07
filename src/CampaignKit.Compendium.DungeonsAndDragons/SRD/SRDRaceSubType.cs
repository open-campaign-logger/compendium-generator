// <copyright file="SRDRaceSubType.cs" company="Jochen Linnemann - IT-Service">
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

    /// <summary>
    /// Represents the SRD Race Subtype information including attributes like name, description, ASI description, ASI details, and traits.
    /// </summary>
    public class SRDRaceSubType
    {
        /// <summary>
        /// Gets or sets the name of the race subtype.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the race subtype.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ASI (Ability Score Increase) description.
        /// </summary>
        [JsonProperty("asi-desc")]
        public string? AsiDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ASI (Ability Score Increase) details.
        /// </summary>
        [JsonProperty("asi")]
        public List<SRDAbilityScoreIncrease>? Asi { get; set; } = new List<SRDAbilityScoreIncrease>();

        /// <summary>
        /// Gets or sets the traits information.
        /// </summary>
        [JsonProperty("traits")]
        public string? Traits { get; set; } = string.Empty;
    }
}
