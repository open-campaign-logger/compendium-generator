// <copyright file="DefaultDungeonsAndDragonsCompendiumService_5e.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Services
{
    using System.Text;
    using System.Threading.Tasks;
    using CampaignKit.Compendium.Core.CampaignLogger;
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
        /// Create a private readonly field to store an IConfigurationService instance.
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Crate a pricate readonly field to store an IDownloadService instance.
        /// </summary>
        private readonly IDownloadService downloadService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDungeonsAndDragonsCompendiumService_5e"/> class.
        /// </summary>
        /// <param name="downloadService">Source data download service.</param>
        /// <param name="logger">The logger for the service.</param>
        /// <param name="configurationService">Application configuration service.</param>
        /// <returns>
        /// A DefaultDungeonsAndDragonsCompendiumService_5e instance.
        /// </returns>
        public DefaultDungeonsAndDragonsCompendiumService_5e(
            IDownloadService downloadService,
            ILogger<DefaultDungeonsAndDragonsCompendiumService_5e> logger,
            IConfigurationService configurationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            this.downloadService = downloadService ?? throw new ArgumentNullException(nameof(downloadService));
        }

        /// <summary>
        /// Processes any Dungeons &amp; Dragons 5e compendiums defined in the application's configuration.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task CreateCompendiums()
        {
            this.logger.LogDebug("Processing compendiums for service: {service}.", typeof(DefaultDungeonsAndDragonsCompendiumService_5e).FullName);
            var rootDataDirectory = this.configurationService.GetRootDataDirectory();
            var serviceName = typeof(DefaultDungeonsAndDragonsCompendiumService_5e).FullName
                ?? throw new Exception($"Unable to determine service name for class: {typeof(DefaultDungeonsAndDragonsCompendiumService_5e).FullName}");
            var compendiums = this.configurationService.GetCompendiumsForService(serviceName);
            if (compendiums == null || compendiums.Count == 0)
            {
                this.logger.LogInformation("No compendiums to process for service: {service}.", typeof(DefaultDungeonsAndDragonsCompendiumService_5e).FullName);
                return;
            }

            var creatureList = new List<Common.Creature>();
            foreach (var compendium in compendiums)
            {
                this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

                // Download data sets
                foreach (var sourceDataSet in compendium.SourceDataSets)
                {
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
                    IEnumerable<ICreature> creatures = (IEnumerable<ICreature>)(sourceDataSetParsed ?? new List<ICreature>());

                    // Convert each creature to the standard format
                    foreach (ICreature creature in creatures.Take(sourceDataSet.ExportLimit ?? int.MaxValue))
                    {
                        this.logger.LogDebug("Converting creature to standard format: {Name}.", creature.Name);
                        var convertedCreature = creature.ToCreature();
                        if (licenseParsed != null && licenseParsed is List<License> && ((List<License>)licenseParsed).Count > 0)
                        {
                            convertedCreature.License = ((List<License>)licenseParsed)[0];
                        }

                        if (!creatureList.Contains(convertedCreature))
                        {
                            this.logger.LogDebug("New creature found and added to compendium list: {creature}.", convertedCreature.Name);
                            creatureList.Add(convertedCreature);
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

                CampaignEntry campaignEntry;
                foreach (var creature in creatureList)
                {
                    campaignEntry = new CampaignEntry()
                    {
                        RawText = CreatureHelper.ToCampaignLoggerStatBlock(creature),
                        Labels = new List<string>() { "Monster", $"CR {creature.ChallengeRating}" },
                        TagSymbol = "~",
                        TagValue = creature.Name,
                    };

                    if (creature.Type != null)
                    {
                        campaignEntry.Labels.Add(creature.Type);
                    }

                    if (creature.License != null && creature.License.Organization != null)
                    {
                        campaignEntry.Labels.Add(creature.License.Organization);
                    }

                    campaignLoggerFile.CampaignEntries.Add(campaignEntry);
                }

                string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

                File.WriteAllText(Path.Combine(rootDataDirectory, compendium.Title + ".json"), campaignLoggerFileString);

                this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
            }
        }
    }
}
