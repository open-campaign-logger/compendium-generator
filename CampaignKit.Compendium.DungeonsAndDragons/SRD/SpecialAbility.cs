// <copyright file="SpecialAbility.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2021 Jochen Linnemann, Cory Gill.
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
    /// Represents a creature's SpecialAbility in a Dungeons &amp; Dragons game.
    /// A SpecialAbility is a unique ability that certain creatures can use.
    /// </summary>
    public class SpecialAbility
    {
        /// <summary>
        /// Gets or sets the attack bonus of the SpecialAbility, if any.
        /// The attack bonus is a number you add to your attack roll.
        /// </summary>
        [JsonProperty("attack_bonus")]
        public int? AttackBonus { get; set; } = 0;

        /// <summary>
        /// Gets or sets the dice used for the damage of the SpecialAbility.
        /// This is a string representation of the dice roll (e.g., "1d6").
        /// </summary>
        [JsonProperty("damage_dice")]
        public string? DamageDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the SpecialAbility.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the SpecialAbility.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;
    }
}
