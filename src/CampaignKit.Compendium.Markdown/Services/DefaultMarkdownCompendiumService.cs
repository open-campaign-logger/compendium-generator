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
    using System.Text;
    using System.Threading.Tasks;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

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
                var lines = await File.ReadAllLinesAsync(Path.Combine(this.configurationService.GetPrivateDataDirectory(), sourceDataSet.SourceDataSetURI));
                foreach (var line in lines)
                {
                    if (line.StartsWith("# "))
                    {
                        if (stringBuilder.Length > 0)
                        {
                            campaignEntries.Add(new CampaignEntry()
                            {
                                RawText = stringBuilder.ToString(),
                                TagSymbol = sourceDataSet.TagSymbol,
                                TagValue = stringEntryName,
                            });
                            stringBuilder.Clear();
                        }
                        stringEntryName = line[2..];
                    }
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

            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            var fileName = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            File.WriteAllText(fileName, campaignLoggerFileString);

            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}
