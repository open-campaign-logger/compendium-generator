// <copyright file="MonstrousMenagerieCreature.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2023 Jochen Linnemann, Cory Gill.
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
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a creature from the Advanced Level Up Monstrous Menagerie.
    /// </summary>
    public class MonstrousMenagerieCreature : TomeOfBeasts3.TomeOfBeasts3Creature
    {
        /// <summary>
        /// Gets or sets the creature's movement speeds, deserialized from the 'speed' field in the JSON source.
        /// </summary>
        [JsonProperty("speed")]
        public new Speed Speed { get; set; } = new Speed();
    }
}
