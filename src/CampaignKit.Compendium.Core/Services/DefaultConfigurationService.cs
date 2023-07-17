// <copyright file="DefaultConfigurationService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using CampaignKit.Compendium.Core.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Identity.Client;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// DefaultConfigurationService provides a default implementation of the IConfigurationService interface.
    /// </summary>
    public class DefaultConfigurationService : IConfigurationService
    {
        // Create a private readonly field to store an ILogger instance.
        private readonly ILogger<DefaultDownloadService> logger;

        // Create a private readonly field to store an IConfiguration instance.
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConfigurationService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <param name="configuration">Application configuration information.</param>
        /// <returns>
        /// A DefaultDownloadService instance.
        /// </returns>
        public DefaultConfigurationService(ILogger<DefaultDownloadService> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// This method returns the root data directory from the configuration or a default path if
        /// it is not set.
        /// </summary>
        /// <returns>The root data directory.</returns>
        public string GetRootDataDirectory()
        {
            var rootFolder = this.configuration.GetValue<string>("RootDataFolder");
            if (string.IsNullOrEmpty(rootFolder))
            {
                rootFolder = Path.Combine(Path.GetTempPath(), "CompendiumGenerator");
            }

            return rootFolder;
        }

        /// <summary>
        /// Gets a list of Compendiums for the specified service name.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>A list of Compendiums for the specified service name.</returns>
        public List<Compendium> GetCompendiumsForService(string serviceName)
        {
            var compendiums = this.configuration.GetSection("Compendiums").Get<List<Compendium>>() ?? new List<Compendium>();
            return compendiums.Where(c => c.CompendiumService == serviceName).ToList();
        }
    }
}
