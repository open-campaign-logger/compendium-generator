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
    using System.Data.Common;
    using System.Reflection;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;
    using CampaignKit.Compendium.WebScraper.Common;

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

            // Skip processing if this compendium has been innactivated.
            if (!compendium.IsActive)
            {
                this.logger.LogWarning("Processing of compendium skipped due to IsActive flag: {IsActive}", compendium.IsActive);
                return;
            }

            // Combine the rootDataDirectory with the compendium title to create a file name
            var filePath = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            // Determine if the operation should be skipped.
            if (File.Exists(filePath) && !compendium.OverwriteExisting)
            {
                this.logger.LogWarning("Processing of compendium skipped due to OverwriteExisting flag: {OverwriteExisting}.", compendium.OverwriteExisting);
                return;
            }

            // Instantiate output variables
            var campaignEntries = new List<CampaignEntry>();

            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

            // Download data sets
            foreach (var sourceDataSet in compendium.SourceDataSets)
            {
                // Load data set configuration.
                this.logger.LogInformation("Loading configuration for SourceDataSet: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);

                // Split the SourceDataSetParserType string into class name and assembly name
                this.logger.LogInformation("Instantiating the required parser type: {SourceDataSetParser}.", sourceDataSet.SourceDataSetParser);
                var sourceDataSetParserType = sourceDataSet.SourceDataSetParser.Split(",");

                // Load the assembly containing the compendium service
                var className = sourceDataSetParserType[0].Trim();
                var assemblyName = sourceDataSetParserType[1].Trim();
                Assembly assembly = Assembly.LoadFrom(assemblyName);

                // Get the type of the parser service
                var parserType = assembly.GetType(className)
                    ?? throw new Exception($"Unable to load class: {className}");
                var parser = Activator.CreateInstance(parserType)
                    ?? throw new Exception($"Unable to instantiate the required parser type: {className}");

                // Populate the SRDWebPage object
                ((SRDWebPage)parser).SourceDataSetURI = sourceDataSet.SourceDataSetURI;
                ((SRDWebPage)parser).RootDataDirectory = rootDataDirectory;
                ((SRDWebPage)parser).OverwriteExisting = sourceDataSet.OverwriteExisting;
                ((SRDWebPage)parser).XPath = sourceDataSet.XPath ?? string.Empty;
                ((SRDWebPage)parser).Name = sourceDataSet.SourceDataSetName ?? string.Empty;
                ((SRDWebPage)parser).TagSymbol = sourceDataSet.TagSymbol ?? string.Empty;
                ((SRDWebPage)parser).TagValuePrefix = sourceDataSet.TagValuePrefix ?? string.Empty;
                ((SRDWebPage)parser).Labels = sourceDataSet.Labels ?? new List<string>();

                // Extract campaign entries from the SRDWebPage opbject.
                campaignEntries.AddRange(await ((SRDWebPage)parser).GetCampaignEntitiesAsync(
                    this.downloadService,
                    sourceDataSet.SourceDataSetName ?? "DEFAULT",
                    FilenameOverrideOptions.ReplaceAlways));
            }

            // Create CampaignLogger File
            this.logger.LogInformation("Creating CampaignLogger file for compendium: {compendium}.", compendium.Title);
            var campaignLoggerFile = new Campaign()
            {
                Version = 2,
                Type = "campaign",
                Title = compendium.Title,
                Description = compendium.Description,
                CampaignEntries = campaignEntries,
                Logs = new List<Log>(),
                ImageUrl = string.Empty,
            };

            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            File.WriteAllText(filePath, campaignLoggerFileString);

            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}
