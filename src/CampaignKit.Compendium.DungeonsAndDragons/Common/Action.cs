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

namespace CampaignKit.Compendium.DungeonsAndDragons.Common
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to represent a particular action that a creature can perform.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Gets or sets the description of this creature Action.
        /// </summary>
        [JsonProperty("desc")]
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of this creature Action.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the attack bonus of the SpecialAbility, if any.
        /// The attack bonus is a number you add to your attack roll.
        /// </summary>
        [JsonProperty("attack_bonus")]
        public int? AttackBonus { get; set; } = 0;

        /// <summary>
        /// Gets or sets the dice used for the damage of the LegendaryAction.
        /// This is a string representation of the dice roll (e.g., "1d6").
        /// </summary>
        [JsonProperty("damage_dice")]
        public string? DamageDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the damage bonus of the Action, if any.
        /// The damage bonus is a number you add to your damage roll.
        /// </summary>
        [JsonProperty("damage_bonus")]
        public int? DamageBonus { get; set; } = 0;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Action)
            {
                return false;
            }

            if (obj is not Action other)
            {
                return false;
            }
            else
            {
                return (this.Name ?? string.Empty).Equals(other.Name);
            }
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return (this.Name ?? string.Empty).GetHashCode();
        }
    }
}
