// <copyright file="ICreature.cs" company="Jochen Linnemann - IT-Service">
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
    /// <summary>
    /// Common interface for all creature classes.
    /// </summary>
    public interface ICreature
    {
        /// <summary>
        /// Gets or sets the License object. This needs to be done before calling the "ToCreature" method.
        /// </summary>
        public License? License { get; set; }

        /// <summary>
        /// Gets or sets the creature's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Creates a generic Creature object populated with values from the underlying class.
        /// </summary>
        /// <returns>Generic Creature object populated with values from the underlying class.</returns>
        public Creature ToCreature();
    }
}
