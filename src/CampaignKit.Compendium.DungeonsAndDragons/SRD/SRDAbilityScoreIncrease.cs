// <copyright file="SRDAbilityScoreIncrease.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an ability score increase in a Dugneons and Dragons campaign.
    /// </summary>
    public class SRDAbilityScoreIncrease
    {
        /// <summary>
        /// Gets or sets the attributes affected by this ability score increase.
        /// </summary>
        [JsonProperty("attributes")]
        public List<string> Attributes { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the value of the ability score increase.
        /// </summary>
        [JsonProperty("value")]
        public int? Value { get; set; } = int.MinValue;
    }
}
