// <copyright file="DefaultMarkdownCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Markdown.Services
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Default service for creating Dungeons &amp; Dragons 5e compendiums.
    /// </summary>
    public class DefaultMarkdownCompendiumService : IMarkdownCompendiumService
    {
        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DungeonsAndDragonsService_5e.
        /// </summary>
        private readonly ILogger<DefaultMarkdownCompendiumService> logger;

        /// <summary>
        /// Create a private readonly field to store an IConfigurationService instance.
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMarkdownCompendiumService"/> class.
        /// </summary>
        /// <param name="downloadService">Source data download service.</param>
        /// <param name="logger">The logger for the service.</param>
        /// <param name="configurationService">Application configuration service.</param>
        /// <returns>
        /// A DefaultDungeonsAndDragonsCompendiumService_5e instance.
        /// </returns>
        public DefaultMarkdownCompendiumService(
            ILogger<DefaultMarkdownCompendiumService> logger,
            IConfigurationService configurationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }

        /// <inheritdoc/>
        public async Task CreateCompendiums(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

            // Create local variables
            var campaignEntries = new List<CampaignEntry>();
            var stringBuilder = new StringBuilder();
            var stringEntryName = string.Empty;

            // Download data sets
            foreach (var sourceDataSet in compendium.SourceDataSets)
            {
                // Keep track of how many items we import from this data source.
                var importCount = 0;

                // Read all lines from the file specified in the sourceDataSetURI
                var lines = await File.ReadAllLinesAsync(Path.Combine(this.configurationService.GetPrivateDataDirectory(), sourceDataSet.SourceDataSetURI));

                // Iterate through each line
                foreach (var line in lines)
                {
                    // If the line starts with "# "
                    if (line.StartsWith("# "))
                    {
                        // If the stringBuilder has content
                        if (stringBuilder.Length > 0)
                        {
                            // Create a new CampaignEntry object and add it to the campaignEntries list
                            campaignEntries.Add(new CampaignEntry()
                            {
                                RawText = stringBuilder.ToString(),
                                TagSymbol = sourceDataSet.TagSymbol,
                                TagValue = stringEntryName,
                            });
                            // Clear the stringBuilder
                            stringBuilder.Clear();

                            // Increment the import count
                            importCount++;

                            // Check if the import count is greater than or equal to the
                            // ImportLimit, or if the ImportLimit is null, then check if it is
                            // greater than or equal to the maximum integer value
                            if (importCount >= (sourceDataSet.ImportLimit ?? int.MaxValue))
                            {
                                // If the condition is true, break out of the loop
                                break;
                            }
                        }
                        // Set the stringEntryName to the line starting from the third character
                        stringEntryName = line[2..];
                    }
                    // Append the line to the stringBuilder
                    stringBuilder.AppendLine(line);
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
                CampaignEntries = campaignEntries,
                Logs = new List<Log>(),
                ImageUrl = string.Empty,
            };

            //Serialize the campaignLoggerFile object into a string using JsonConvert
            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            //Combine the rootDataDirectory with the compendium title to create a file name
            var fileName = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            //Write the campaignLoggerFileString to the fileName
            File.WriteAllText(fileName, campaignLoggerFileString);

            //Log a message to the logger that the processing of the compendium is complete
            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}