﻿// <copyright file="SRDBase.cs" company="Jochen Linnemann - IT-Service">
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
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a base class for all Dungeons and Dragons game components.
    /// </summary>
    public class SRDBase : GameComponentBase
    {
        /// <summary>
        /// Gets or sets the description of the game component.
        /// </summary>
        [JsonProperty("desc")]
        public override string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the game component.
        /// </summary>
        [JsonProperty("name")]
        public override string? Name { get; set; } = string.Empty;
    }
}
