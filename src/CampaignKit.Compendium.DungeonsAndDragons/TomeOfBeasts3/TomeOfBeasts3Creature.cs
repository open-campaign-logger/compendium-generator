// <copyright file="TomeOfBeasts3Creature.cs" company="Jochen Linnemann - IT-Service">
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
    /// Defines a creature from the Tome of Beasts 3, extending from the base class KoboldPressCreature.
    /// </summary>
    public class TomeOfBeasts3Creature : KoboldPress.KoboldPressCreature
    {
        /// <summary>
        /// Gets or sets the list of bonus actions associated with this object.
        /// </summary>
        /// <returns>The list of bonus actions associated with this object.</returns>
        [JsonProperty("bonus_actions")]
        public List<Common.Action>? BonusActions { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets the document slug.  The slug (short name used in URLs and similar places) of
        /// the document where the creature is described, deserialized from the 'document__slug'
        /// field in the JSON source.
        /// </summary>
        [JsonProperty("document__slug")]
        public string? DocumentSlug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the document where the creature is described, deserialized
        /// from the 'document__title' field in the JSON source.
        /// </summary>
        [JsonProperty("document__title")]
        public string? DocumentTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the page number in the document where the creature is described,
        /// deserialized from the 'page_no' field in the JSON source.
        /// </summary>
        [JsonProperty("page_no")]
        public int? PageNumber { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the skills the creature possesses, deserialized from the 'skills' field in
        /// the JSON source.
        /// </summary>
        [JsonProperty("skills")]
        public Skills Skills { get; set; } = new Skills();

        /// <summary>
        /// Gets or sets the unique identifier for the creature, deserialized from the 'slug' field
        /// in the JSON source.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's movement speeds, deserialized from the 'speed' field in the JSON source.
        /// </summary>
        [JsonProperty("speed")]
        public new Common.SpeedJson Speed { get; set; } = new Common.SpeedJson();

        /// <summary>
        /// Gets or sets the creature's movement speeds in a more detailed format, deserialized from
        /// the 'speed_json' field in the JSON source.
        /// </summary>
        [JsonProperty("speed_json")]
        public new Common.SpeedJson SpeedJson { get; set; } = new Common.SpeedJson();
    }
}
