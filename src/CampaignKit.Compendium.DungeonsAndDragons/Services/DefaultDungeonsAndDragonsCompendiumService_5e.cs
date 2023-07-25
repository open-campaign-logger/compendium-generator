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
        public async Task CreateCompendiums(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogDebug("Processing compendiums for service: {service}.", typeof(IDungeonsAndDragonsCompendiumService_5e).FullName);
            var serviceName = typeof(IDungeonsAndDragonsCompendiumService_5e).FullName
                ?? throw new Exception($"Unable to determine service name for class: {typeof(IDungeonsAndDragonsCompendiumService_5e).FullName}");

            var creatureList = new List<IGameComponent>();

            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

            // Download data sets
            foreach (var sourceDataSet in compendium.SourceDataSets)
            {
                // Keep track of how many items we import from this data source.
                var importCount = 0;

                // Download license file
                this.downloadService.DerivePathAndFileNames(sourceDataSet.LicenseDataURI, out string licenseDirectory, out string licenseFile);
                var licenseFilePath = Path.Combine(rootDataDirectory, licenseDirectory, licenseFile);
                this.logger.LogInformation("Downloading license data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                await this.downloadService.DownloadFile(
                    sourceDataSet.LicenseDataURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting);

                // Parse license file
                this.logger.LogInformation("Parsing local copy of license data from: {LicenseFilePath}.", licenseFilePath);
                var licenseJSON = File.ReadAllText(Path.Combine(rootDataDirectory, licenseDirectory, licenseFile))
                    ?? throw new Exception($"Unable to read license information from file: {licenseFilePath}.");
                var licenseParserType = Type.GetType(sourceDataSet.LicenseDataParser)
                    ?? throw new Exception($"Configuration parmater not defined: {nameof(sourceDataSet.LicenseDataParser)}.");
                var licenseListType = typeof(List<>).MakeGenericType(licenseParserType);
                var licenseParsed = JsonConvert.DeserializeObject(licenseJSON, licenseListType);

                // Download SourceDataSet file
                this.downloadService.DerivePathAndFileNames(sourceDataSet.SourceDataSetURI, out string sourceDataSetDirectory, out string sourceDataSetFile);
                var sourceDataSetFilePath = Path.Combine(rootDataDirectory, sourceDataSetDirectory, sourceDataSetFile);
                this.logger.LogInformation("Downloading SourceDataSet data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                await this.downloadService.DownloadFile(
                    sourceDataSet.SourceDataSetURI,
                    rootDataDirectory,
                    sourceDataSet.OverwriteExisting);

                // Parse SourceDataSet file
                this.logger.LogInformation("Parsing local copy of SourceDataSet data from: {SourceDataSetFilePath}.", sourceDataSetFilePath);
                var sourceDataSetJSON = File.ReadAllText(Path.Combine(rootDataDirectory, sourceDataSetDirectory, sourceDataSetFile))
                    ?? throw new Exception($"Unable to read SourceDataSet information from file: {sourceDataSetFilePath}.");
                var sourceDataSetParserType = Type.GetType(sourceDataSet.SourceDataSetParser)
                    ?? throw new Exception($"Configuration parmater not defined: {nameof(sourceDataSet.SourceDataSetParser)}.");
                var sourceDataSetListType = typeof(List<>).MakeGenericType(sourceDataSetParserType);
                var sourceDataSetParsed = JsonConvert.DeserializeObject(sourceDataSetJSON, sourceDataSetListType);

                // Convert each object to Common.Creature and add it to the collection if it doesn't already exist.
                // Cast the deserialized list to the interface type
                IEnumerable<IGameComponent> creatures = (IEnumerable<IGameComponent>)(sourceDataSetParsed ?? new List<IGameComponent>());

                // Convert each creature to the standard format
                foreach (IGameComponent creature in creatures)
                {
                    this.logger.LogDebug("Converting creature to standard format: {Name}.", creature.Name);
                    if (licenseParsed != null && licenseParsed is List<License> list && list.Count > 0)
                    {
                        creature.PublisherName = list[0].Organization;
                        creature.LicenseURL = list[0].Url;
                    }

                    if (!creatureList.Any(c => (c.Name is not null) && c.Name.Equals(creature.Name)))
                    {
                        this.logger.LogDebug("New creature found and added to compendium list: {creature}.", creature.Name);
                        creatureList.Add(creature);
                        importCount++;
                        if (importCount >= (sourceDataSet.ImportLimit ?? int.MaxValue))
                        {
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

            foreach (var creature in creatureList)
            {
                campaignLoggerFile.CampaignEntries.Add(creature.ToCampaignEntry());
            }

            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            File.WriteAllText(Path.Combine(rootDataDirectory, compendium.Title + ".json"), campaignLoggerFileString);

            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}
