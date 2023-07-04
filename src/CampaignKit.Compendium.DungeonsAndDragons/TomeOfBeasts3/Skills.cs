// <copyright file="Skills.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.TomeOfBeasts3
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the skillset of a creature in the Tome of Beasts 3.
    /// Each property represents a different skill and its proficiency level.
    /// </summary>
    public class Skills
    {
        /// <summary>
        /// Gets or sets the creature's proficiency in the Acrobatics skill.
        /// </summary>
        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Animal Handling skill.
        /// </summary>
        [JsonProperty("animal_handling")]
        public int? AnimalHandling { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Arcana skill.
        /// </summary>
        [JsonProperty("arcana")]
        public int? Arcana { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Athletics skill.
        /// </summary>
        [JsonProperty("athletics")]
        public int? Athletics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Deception skill.
        /// </summary>
        [JsonProperty("deception")]
        public int? Deception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the History skill.
        /// </summary>
        [JsonProperty("history")]
        public int? History { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Insight skill.
        /// </summary>
        [JsonProperty("insight")]
        public int? Insight { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Investigation skill.
        /// </summary>
        [JsonProperty("investigation")]
        public int? Investigation { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Intimidation skill.
        /// </summary>
        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Medicine skill.
        /// </summary>
        [JsonProperty("medicine")]
        public int? Medicine { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Nature skill.
        /// </summary>
        [JsonProperty("nature")]
        public int? Nature { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Perception skill.
        /// </summary>
        [JsonProperty("perception")]
        public int? Perception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Performance skill.
        /// </summary>
        [JsonProperty("performance")]
        public int? Performance { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Persuasion skill.
        /// </summary>
        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Religion skill.
        /// </summary>
        [JsonProperty("religion")]
        public int? Religion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Sleight of Hand skill.
        /// </summary>
        [JsonProperty("slight_of_hand")]
        public int? SleightOfHand { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Stealth skill.
        /// </summary>
        [JsonProperty("stealth")]
        public int? Stealth { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Survival skill.
        /// </summary>
        [JsonProperty("survival")]
        public int? Survival { get; set; } = int.MinValue;
    }
}
