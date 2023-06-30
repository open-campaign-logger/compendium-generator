// <copyright file="CreatureAction.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Models.Creatures
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to represent a particular action that a creature can perform.
    /// </summary>
    public class CreatureAction
    {
        /// <summary>
        /// Gets or sets the creature associated with this creature Action.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [JsonIgnore]
        public Creature? Creature { get; set; }

        /// <summary>
        /// Gets or sets the creature Id associated with this creature Action.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [JsonIgnore]
        public int CreatureId { get; set; }

        /// <summary>
        /// Gets or sets the description of this creature Action.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier for this creature Action.
        /// This property is marked to be ignored by Json serialization.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of this creature Action.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not CreatureAction)
            {
                return false;
            }

            if (obj is not CreatureAction other)
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
