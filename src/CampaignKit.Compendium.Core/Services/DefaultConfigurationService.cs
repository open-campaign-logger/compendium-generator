// <copyright file="DefaultConfigurationService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Services
{
    using System;
    using System.Collections.Generic;

    using CampaignKit.Compendium.Core.Configuration;

    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// DefaultConfigurationService provides a default implementation of the IConfigurationService interface.
    /// </summary>
    public class DefaultConfigurationService : IConfigurationService
    {
        // Create a private readonly field to store an IConfiguration instance.
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConfigurationService"/> class.
        /// </summary>
        /// <param name="configuration">Application configuration information.</param>
        /// <returns>
        /// A DefaultDownloadService instance.
        /// </returns>
        public DefaultConfigurationService(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <inheritdoc/>
        public string GetPublicDataDirectory()
        {
            var rootFolder = this.configuration.GetValue<string>("PublicDataFolder");
            if (string.IsNullOrEmpty(rootFolder))
            {
                rootFolder = Path.Combine(Path.GetTempPath(), "CompendiumGenerator", "Public");
            }

            return rootFolder;
        }

        /// <inheritdoc/>
        public string GetPrivateDataDirectory()
        {
            var rootFolder = this.configuration.GetValue<string>("PrivateDataFolder");
            if (string.IsNullOrEmpty(rootFolder))
            {
                rootFolder = Path.Combine(Path.GetTempPath(), "CompendiumGenerator", "Private");
            }

            return rootFolder;
        }

        /// <inheritdoc/>
        public List<ICompendium> GetAllPublicCompendiums()
        {
            var result = new List<ICompendium>();

            // Iterate through all the sections in the configuration
            foreach (var section in this.configuration.GetChildren())
            {
                // Check if the section key ends with "Compendium"
                if (section.Key.EndsWith("PublicCompendiums"))
                {
                    result.AddRange(section.Get<List<PublicCompendium>>() ?? new List<PublicCompendium>());
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public List<ICompendium> GetAllPrivateCompendiums()
        {
            var result = new List<ICompendium>();
            result.AddRange(this.configuration.GetSection("PrivateCompendiums").Get<List<PublicCompendium>>() ?? new List<PublicCompendium>());
            return result;
        }

        /// <inheritdoc/>
        public Service GetService(string serviceName)
        {
            return this.GetAllServices().FirstOrDefault(s => s.Name == serviceName) ?? new Service();
        }

        /// <inheritdoc/>
        public List<Service> GetAllServices()
        {
            return this.configuration.GetSection("Services").Get<List<Service>>() ?? new List<Service>();
        }
    }
}
