// <copyright file="SpeedJson.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents a creature's speed in a Dungeons &amp; Dragons game.
    /// SpeedJson is a class that describes the various movement speeds of a creature.
    /// </summary>
    public class SpeedJson
    {
        /// <summary>
        /// Gets or sets the burrowing speed of the creature in feet.
        /// </summary>
        [JsonProperty("burrow")]
        public int? Burrow { get; set; } = 0;

        /// <summary>
        /// Gets or sets the climbing speed of the creature in feet.
        /// </summary>
        [JsonProperty("climb")]
        public int? Climb { get; set; } = 0;

        /// <summary>
        /// Gets or sets the flying speed of the creature in feet.
        /// </summary>
        [JsonProperty("fly")]
        public int? Fly { get; set; } = 0;

        /// <summary>
        /// Gets or sets a boolean indicating whether the creature can hover while flying.
        /// </summary>
        [JsonProperty("hover")]
        public bool? Hover { get; set; } = false;

        /// <summary>
        /// Gets or sets any additional notes about the creature's speed.
        /// </summary>
        [JsonProperty("notes")]
        public string? Notes { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the swimming speed of the creature in feet.
        /// </summary>
        [JsonProperty("swim")]
        public int? Swim { get; set; } = 0;

        /// <summary>
        /// Gets or sets the walking speed of the creature in feet.
        /// </summary>
        [JsonProperty("walk")]
        public int? Walk { get; set; } = 0;
    }
}