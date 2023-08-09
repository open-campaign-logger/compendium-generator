// <copyright file="DefaultDungeonsAndDragonsCompendiumService_5e.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Services
{
    using System.Threading.Tasks;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;
    using CampaignKit.Compendium.DungeonsAndDragons.Common;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// Default service for creating Dungeons &amp; Dragons 5e compendiums.
    /// </summary>
    public class DefaultDungeonsAndDragonsCompendiumService_5e : IDungeonsAndDragonsCompendiumService_5e
    {
        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DungeonsAndDragonsService_5e.
        /// </summary>
        private readonly ILogger<DefaultDungeonsAndDragonsCompendiumService_5e> logger;

        /// <summary>
        /// Crate a pricate readonly field to store an IDownloadService instance.
        /// </summary>
        private readonly IDownloadService downloadService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDungeonsAndDragonsCompendiumService_5e"/> class.
        /// </summary>
        /// <param name="downloadService">Source data download service.</param>
        /// <param name="logger">The logger for the service.</param>
        /// <returns>
        /// A DefaultDungeonsAndDragonsCompendiumService_5e instance.
        /// </returns>
        public DefaultDungeonsAndDragonsCompendiumService_5e(
            IDownloadService downloadService,
            ILogger<DefaultDungeonsAndDragonsCompendiumService_5e> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.downloadService = downloadService ?? throw new ArgumentNullException(nameof(downloadService));
        }

        /// <inheritdoc/>
        public async Task CreateCompendium(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogDebug("Processing compendiums for service: {service}.", typeof(IDungeonsAndDragonsCompendiumService_5e).FullName);
            var serviceName = typeof(IDungeonsAndDragonsCompendiumService_5e).FullName
                ?? throw new Exception($"Unable to determine service name for class: {typeof(IDungeonsAndDragonsCompendiumService_5e).FullName}");

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

                // Download license file
                this.logger.LogInformation("Downloading license data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                var licenseFilePath = await this.downloadService.DownloadFile(
                    sourceDataSet.LicenseDataURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting);

                // Parse license file
                this.logger.LogInformation("Parsing local copy of license data from: {LicenseFilePath}.", licenseFilePath);
                var licenseJSON = File.ReadAllText(licenseFilePath)
                    ?? throw new Exception($"Unable to read license information from file: {licenseFilePath}.");
                var licenseParserType = Type.GetType(sourceDataSet.LicenseDataParser)
                    ?? throw new Exception($"Configuration parmater not defined: {nameof(sourceDataSet.LicenseDataParser)}.");
                var licenseListType = typeof(List<>).MakeGenericType(licenseParserType);
                var licenseParsed = JsonConvert.DeserializeObject(licenseJSON, licenseListType);

                // Create a CampaignEntry for the license and add it to the list.
                if (licenseParsed != null && licenseParsed is List<License> license)
                {
                    var licenseCampaignEntry = license[0].ToCampaignEntry();

                    // Check to see if this license is already in the collection.  If it doesn't exist add it.
                    if (!licenseList.Any(c => (c.TagValue is not null) && c.TagValue.Equals(license[0].SourceTitle)))
                    {
                        licenseList.Add(license[0].ToCampaignEntry());
                    }
                }

                // Download SourceDataSet file
                this.logger.LogInformation("Downloading SourceDataSet data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                var sourceDataSetFilePath = await this.downloadService.DownloadFile(
                    sourceDataSet.SourceDataSetURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting);

                // Parse SourceDataSet file
                this.logger.LogInformation("Parsing local copy of SourceDataSet data from: {SourceDataSetFilePath}.", sourceDataSetFilePath);
                var sourceDataSetJSON = File.ReadAllText(sourceDataSetFilePath)
                    ?? throw new Exception($"Unable to read SourceDataSet information from file: {sourceDataSetFilePath}.");
                var sourceDataSetParserType = Type.GetType(sourceDataSet.SourceDataSetParser)
                    ?? throw new Exception($"Configuration parmater not defined: {nameof(sourceDataSet.SourceDataSetParser)}.");
                var sourceDataSetListType = typeof(List<>).MakeGenericType(sourceDataSetParserType);
                var sourceDataSetParsed = JsonConvert.DeserializeObject(sourceDataSetJSON, sourceDataSetListType);

                // Convert each object to Common.Creature and add it to the collection if it doesn't already exist.
                // Cast the deserialized list to the interface type
                IEnumerable<IGameComponent> gameComponents = (IEnumerable<IGameComponent>)(sourceDataSetParsed ?? new List<IGameComponent>());

                // Loop through each gameComponent in the gameComponents list
                foreach (IGameComponent gameComponent in gameComponents)
                {
                    // Log the gameComponent name
                    this.logger.LogDebug("Converting gameComponent to standard format: {LicenseName}.", gameComponent.Name);

                    // Check if licenseParsed is not null and is a list with more than 0 elements
                    if (licenseParsed != null && licenseParsed is List<License> list && list.Count > 0)
                    {
                        // Set the gameComponent's publisher name and license URL to the first element in the list
                        gameComponent.SourceTitle = list[0].SourceTitle;
                    }

                    // Apply TagSymbol if configured, otherwise use a default.
                    if (string.IsNullOrEmpty(sourceDataSet.TagSymbol))
                    {
                        gameComponent.TagSymbol = "~";
                    }
                    else
                    {
                        gameComponent.TagSymbol = sourceDataSet.TagSymbol;
                    }

                    // Apply TagValuePrefix if configured.
                    if (!string.IsNullOrEmpty(sourceDataSet.TagValuePrefix))
                    {
                        gameComponent.TagValuePrefix = sourceDataSet.TagValuePrefix;
                    }
                    else
                    {
                        gameComponent.TagValuePrefix = string.Empty;
                    }

                    // Apply labels if configured.
                    if (sourceDataSet.Labels != null && sourceDataSet.Labels.Count > 0)
                    {
                        gameComponent.Labels ??= new List<string>();

                        gameComponent.Labels.AddRange(sourceDataSet.Labels);
                    }

                    // Check if the componentList does not contain a gameComponent with the same name
                    if (!componentList.Any(c => (c.Name is not null) && c.Name.Equals(sourceDataSet.TagValuePrefix + gameComponent.Name)))
                    {
                        // Log the gameComponent name
                        this.logger.LogDebug("New gameComponent found and added to compendium list: {gameComponent}.", gameComponent.Name);

                        // Add the gameComponent to the componentList
                        componentList.Add(gameComponent);

                        // Increment the importCount
                        importCount++;

                        // Check if the importCount is greater than or equal to the ImportLimit or int.MaxValue
                        if (importCount >= (sourceDataSet.ImportLimit ?? int.MaxValue))
                        {
                            // Break out of the loop
                            break;
                        }
                    }
                }
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
