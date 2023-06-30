// <copyright file="Action.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents a creature action in a Dungeons &amp; Dragons.
    /// An Action represents what a character or creature can do during their turn in a combat scenario.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Gets or sets the attack bonus of the action. This represents the numerical bonus added
        /// to an attack roll, determined by the attacking creature's strength or dexterity.
        /// </summary>
        [JsonProperty("attack_bonus")]
        public int? AttackBonus { get; set; } = 0;

        /// <summary>
        /// Gets or sets the damage bonus of the Action, if any.
        /// The damage bonus is a number you add to your damage roll.
        /// </summary>
        [JsonProperty("damage_bonus")]
        public int? DamageBonus { get; set; } = 0;

        /// <summary>
        /// Gets or sets the dice used for the damage of the Action.
        /// This is a string representation of the dice roll (e.g., "1d6").
        /// </summary>
        [JsonProperty("damage_dice")]
        public string? DamageDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the action. This includes details on how it is performed
        /// and its effects.
        /// </summary>
        [JsonProperty("desc")]
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the action. This is the unique identifier used to refer to the action in the game.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;
    }
}