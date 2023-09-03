// <copyright file="CompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper.Data
{
    using CampaignKit.Compendium.Core.Configuration;

    using Newtonsoft.Json;

    /// <summary>
    /// CompendiumService provides methods for loading compendiums.
    /// </summary>
    public class CompendiumService
    {
        private readonly ILogger<CompendiumService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompendiumService"/> class.
        /// </summary>
        /// <param name="logger">Logger object for logging.</param>
        /// <returns>
        /// DownloadService object.
        /// </returns>
        public CompendiumService(ILogger<CompendiumService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Loads a PublicCompendium object from a JSON string.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>A PublicCompendium object.</returns>
        public PublicCompendium LoadCompendium(string json)
        {
            // Validate parameters
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            // Log method entry.
            this.logger.LogInformation("LoadCompendium method called with JSON: {JSON}.", json[0..50]);

            // Create a PublicCompendium object using Newtonsoft.Json
            var compendium = JsonConvert.DeserializeObject<PublicCompendium>(json) 
                ?? throw new Exception("Unable to deserialize JSON into PublicCompendium object.");

            // Return the PublicCompendium object.
            return compendium;
        }
    }
}