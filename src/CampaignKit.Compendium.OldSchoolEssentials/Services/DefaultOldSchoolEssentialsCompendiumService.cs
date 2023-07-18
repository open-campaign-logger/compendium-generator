// <copyright file="DefaultOldSchoolEssentialsCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.OldSchoolEssentials.Services
{
    using System.Reflection;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Services;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Default service for creating Old School Essentials compendiums.
    /// </summary>
    public class DefaultOldSchoolEssentialsCompendiumService : IOldSchoolEssentialsCompendiumService
    {
        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DungeonsAndDragonsService_5e.
        /// </summary>
        private readonly ILogger<DefaultOldSchoolEssentialsCompendiumService> logger;

        /// <summary>
        /// Create a private readonly field to store an IConfigurationService instance.
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultOldSchoolEssentialsCompendiumService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <param name="configurationService">Application configuration service.</param>
        /// <returns>
        /// A DefaultOldSchoolEssentialsCompendiumService instance.
        /// </returns>
        public DefaultOldSchoolEssentialsCompendiumService(ILogger<DefaultOldSchoolEssentialsCompendiumService> logger, IConfigurationService configurationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }

        /// <inheritdoc/>
        public async Task CreateCompendiums()
        {
            this.logger.LogDebug("Processing compendiums for service: {service}.", typeof(IOldSchoolEssentialsCompendiumService).FullName);
            var rootDataDirectory = this.configurationService.GetRootDataDirectory();
            var serviceName = typeof(IOldSchoolEssentialsCompendiumService).FullName
                ?? throw new Exception($"Unable to determine service name for class: {typeof(IOldSchoolEssentialsCompendiumService).FullName}");
            var compendiums = this.configurationService.GetCompendiumsForService(serviceName);
            if (compendiums == null || compendiums.Count == 0)
            {
                this.logger.LogInformation("No compendiums to process for service: {service}.", typeof(IOldSchoolEssentialsCompendiumService).FullName);
                return;
            }

            var creatureList = new List<ICreature>();
            foreach (var compendium in compendiums)
            {
                this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

                // Get the current assembly
                Assembly assembly = Assembly.GetExecutingAssembly();

                // The resource name is the default namespace of the project, followed by the file path within the project (with '.' instead of '/')
                // If the file is in the 'SourceDataSets' subfolder under the project root and the default namespace is 'MyNamespace', it would be "MyNamespace.SourceDataSets.MyFile.txt"
                string resourceName = "CampaignKit.Compendium.OldSchoolEssentials.SourceDataSets.OSE-SRD-v1.0.json";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName)
                    ?? throw new Exception($"Unable to load embedded resource: {resourceName}"))
                using (StreamReader reader = new (stream))
                {
                    string result = reader.ReadToEnd();

                    // Now you can use the content of the file
                }

                this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
            }
        }
    }
}
