// <copyright file="CampaignEntry.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Models.CampaignLogger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents an entry in a campaign.
    /// </summary>
    public class CampaignEntry
    {
        /// <summary>
        /// Gets or sets the raw text of the campaign entry.
        /// </summary>
        [JsonProperty("rawText")]
        public string? RawText { get; set; }

        /// <summary>
        /// Gets or sets the public visibility of the raw text of the campaign entry.
        /// </summary>
        [JsonProperty("rawPublic")]
        public string? RawPublic { get; set; }

        /// <summary>
        /// Gets or sets the list of labels associated with the campaign entry.
        /// </summary>
        [JsonProperty("labels")]
        public List<string>? Labels { get; set; }

        /// <summary>
        /// Gets or sets the tag symbol for the campaign entry.
        /// </summary>
        [JsonProperty("tagSymbol")]
        public string? TagSymbol { get; set; }

        /// <summary>
        /// Gets or sets the value of the tag for the campaign entry.
        /// </summary>
        [JsonProperty("tagValue")]
        public string? TagValue { get; set; }
    }
}
