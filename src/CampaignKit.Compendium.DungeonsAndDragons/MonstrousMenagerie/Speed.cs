// <copyright file="Speed.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.MonstrousMenagerie
{
    /// <summary>
    /// Represents the movement capabilities of a creature in various modalities.
    /// </summary>
    public class Speed
    {
        /// <summary>
        /// Gets or sets the walking speed of the creature.
        /// This property may be null if the creature does not have a walking speed.
        /// </summary>
        public string? Walk { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the swimming speed of the creature.
        /// This property may be null if the creature does not have a swimming speed.
        /// </summary>
        public string? Swim { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the climbing speed of the creature.
        /// This property may be null if the creature does not have a climbing speed.
        /// </summary>
        public string? Climb { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the burrowing speed of the creature.
        /// This property may be null if the creature does not have a burrowing speed.
        /// </summary>
        public string? Burrow { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the flying speed of the creature.
        /// This property may be null if the creature does not have a flying speed.
        /// </summary>
        public string? Fly { get; set; } = string.Empty;
    }
}
