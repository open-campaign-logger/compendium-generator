// <copyright file="OriginalLogEntry.cs" company="Jochen Linnemann - IT-Service">
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
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents the original entry in a log for a specific campaign.
    /// </summary>
    public class OriginalLogEntry
    {
        /// <summary>
        /// Gets or sets the identifier for the original log entry.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the revision number of the original log entry.
        /// </summary>
        [JsonProperty("revision")]
        public string? Revision { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the original log entry.
        /// </summary>
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the original log entry was created.
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the original log entry was last updated.
        /// </summary>
        [JsonProperty("updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}
