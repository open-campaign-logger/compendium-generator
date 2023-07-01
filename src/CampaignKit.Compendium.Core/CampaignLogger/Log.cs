// <copyright file="Log.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.CampaignLogger
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a log for a specific campaign.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Gets or sets the version of the log.
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>
        /// Gets or sets the type of the log.
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the original entry of the log.
        /// </summary>
        [JsonProperty("original")]
        public OriginalLogEntry? Original { get; set; }

        /// <summary>
        /// Gets or sets the title of the log.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the log.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with the log.
        /// </summary>
        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the list of log entries for this log.
        /// </summary>
        [JsonProperty("logEntries")]
        public List<LogEntry>? LogEntries { get; set; }
    }
}
