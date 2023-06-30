// <copyright file="MonsterSpecialAbility.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Models.Monsters
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Monster's Special Ability entity in the Compendium Generator database.
    /// This class is used to represent a particular special ability that a monster can perform.
    /// </summary>
    public class MonsterSpecialAbility
    {
        /// <summary>
        /// Gets or sets the unique identifier for this Monster's Special Ability.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Monster Id associated with this Monster's Special Ability.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [JsonIgnore]
        public int MonsterId { get; set; }

        /// <summary>
        /// Gets or sets the name of this Monster's Special Ability.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of this Monster's Special Ability.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Monster associated with this Special Ability.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [JsonIgnore]
        public Monster? Monster { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not MonsterSpecialAbility)
            {
                return false;
            }

            if (obj is not MonsterSpecialAbility other)
            {
                return false;
            }
            else
            {
                return this.Name.Equals(other.Name);
            }
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}