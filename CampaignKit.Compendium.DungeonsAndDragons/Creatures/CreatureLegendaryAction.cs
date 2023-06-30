// <copyright file="CreatureLegendaryAction.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Creatures
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a creature LegendaryAction in a Dungeons &amp; Dragons game.
    /// A LegendaryAction represents a special action that can be performed by a legendary creature.
    /// </summary>
    public class CreatureLegendaryAction
    {
        /// <summary>
        /// Gets or sets the creature which can perform this legendary action.
        /// This property is ignored during JSON serialization and deserialization.
        /// </summary>
        [JsonIgnore]
        public Creature? Creature { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the creature which can perform this legendary action.
        /// This property is ignored during JSON serialization and deserialization.
        /// </summary>
        [JsonIgnore]
        public int CreatureId { get; set; }

        /// <summary>
        /// Gets or sets the description of this legendary action.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the identifier of this legendary action.
        /// This property is ignored during JSON serialization and deserialization.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of this legendary action.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not CreatureLegendaryAction)
            {
                return false;
            }

            if (obj is not CreatureLegendaryAction other)
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
