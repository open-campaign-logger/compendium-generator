// <copyright file="DefaultWebScraperCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.WebScraper.Services
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// Default service for creating compendiums via web page scraping.
    /// </summary>
    public class DefaultWebScraperCompendiumService : IWebScraperCompendiumService
    {
        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DungeonsAndDragonsService_5e.
        /// </summary>
        private readonly ILogger<DefaultWebScraperCompendiumService> logger;

        /// <summary>
        /// Crate a pricate readonly field to store an IDownloadService instance.
        /// </summary>
        private readonly IDownloadService downloadService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWebScraperCompendiumService"/> class.
        /// </summary>
        /// <param name="downloadService">Source data download service.</param>
        /// <param name="logger">The logger for the service.</param>
        /// <returns>
        /// A DefaultWebScraperCompendiumService instance.
        /// </returns>
        public DefaultWebScraperCompendiumService(
            IDownloadService downloadService,
            ILogger<DefaultWebScraperCompendiumService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.downloadService = downloadService ?? throw new ArgumentNullException(nameof(downloadService));
        }

        /// <inheritdoc/>
        public async Task CreateCompendium(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogDebug("Processing compendiums for service: {service}.", typeof(DefaultWebScraperCompendiumService).FullName);
            var serviceName = typeof(DefaultWebScraperCompendiumService).FullName
                ?? throw new Exception($"Unable to determine service name for class: {typeof(DefaultWebScraperCompendiumService).FullName}");

            // Combine the rootDataDirectory with the compendium title to create a file name
            var filePath = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            // Determine if the operation should be skipped.
            if (File.Exists(filePath) && !compendium.OverwriteExisting)
            {
                this.logger.LogWarning("Processing of compendium skipped due to OverwriteExisting flag: {OverwriteExisting}.", compendium.OverwriteExisting);
                return;
            }

            // Instantiate output variables
            var licenseList = new List<CampaignEntry>();
            var componentList = new List<IGameComponent>();

            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

            // Download data sets
            foreach (var sourceDataSet in compendium.SourceDataSets)
            {
                // Keep track of how many items we import from this data source.
                var importCount = 0;

                // Download license file (if required)
                this.logger.LogInformation("Downloading license data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                var licenseFilePath = await this.downloadService.DownloadFile(
                    sourceDataSet.LicenseDataURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting,
                    "license");

                // Download SourceDataSet file (if required)
                this.logger.LogInformation("Downloading SourceDataSet data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                var sourceDataSetFilePath = await this.downloadService.DownloadFile(
                    sourceDataSet.SourceDataSetURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting,
                    sourceDataSet.SourceDataSetName);
            }

            // Create CampaignLogger File
            this.logger.LogInformation("Creating CampaignLogger file for compendium: {compendium}.", compendium.Title);
            var campaignLoggerFile = new Campaign()
            {
                Version = 2,
                Type = "campaign",
                Title = compendium.Title,
                Description = compendium.Description,
                CampaignEntries = new List<CampaignEntry>(),
                Logs = new List<Log>(),
                ImageUrl = string.Empty,
            };

            // Convert and add each item to the list.
            foreach (var creature in componentList)
            {
                campaignLoggerFile.CampaignEntries.Add(creature.ToCampaignEntry());
            }

            // Add any license entries.
            campaignLoggerFile.CampaignEntries.AddRange(licenseList);

            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            File.WriteAllText(filePath, campaignLoggerFileString);

            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}
