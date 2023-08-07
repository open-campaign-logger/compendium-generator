// <copyright file="SRDClassFeature.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents class features in a Dungeons and Dragons class.
    /// </summary>
    public class SRDClassFeature
    {
        /// <summary>
        /// Gets or sets the hit dice.
        /// </summary>
        [JsonProperty("hit-dice")]
        public string? HitDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HP at 1st level.
        /// </summary>
        [JsonProperty("hp-at-1st-level")]
        public string? HpAt1stLevel { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HP at higher levels.
        /// </summary>
        [JsonProperty("hp-at-higher-levels")]
        public string? HpAtHigherLevels { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the proficiency with armor.
        /// </summary>
        [JsonProperty("prof-armor")]
        public string? ProfArmor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the proficiency with weapons.
        /// </summary>
        [JsonProperty("prof-weapons")]
        public string? ProfWeapons { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the proficiency with tools.
        /// </summary>
        [JsonProperty("prof-tools")]
        public string? ProfTools { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the proficiency with saving throws.
        /// </summary>
        [JsonProperty("prof-saving-throws")]
        public string? ProfSavingThrows { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the proficiency with skills.
        /// </summary>
        [JsonProperty("prof-skills")]
        public string? ProfSkills { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the equipment.
        /// </summary>
        [JsonProperty("equipment")]
        public string? Equipment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        [JsonProperty("table")]
        public string? Table { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the spellcasting ability.
        /// </summary>
        [JsonProperty("spellcasting-ability")]
        public string? SpellcastingAbility { get; set; } = string.Empty;
    }
}
