// <copyright file="DefaultChatGPTCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.ChatGPT.Services
{
    using System.Threading.Tasks;

    using CampaignKit.Compendium.ChatGPT.Common;
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// DefaultChatGPTCompendiumService provides a set of methods for managing chat-based GPT
    /// Compendiums. It allows users to create, edit, and delete Compendiums, as well as add and
    /// remove entries from them.
    /// </summary>
    public class DefaultChatGPTCompendiumService : IChatGPTCompendiumService
    {
        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DefaultChatGPTCompendiumService.
        /// </summary>
        private readonly ILogger<DefaultChatGPTCompendiumService> logger;

        /// <summary>
        /// Create a private readonly field to store an IConfigurationService instance.
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultChatGPTCompendiumService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <param name="configurationService">Application configuration service.</param>
        /// <returns>
        /// A DefaultChatGPTCompendiumService instance.
        /// </returns>
        public DefaultChatGPTCompendiumService(ILogger<DefaultChatGPTCompendiumService> logger, IConfigurationService configurationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }

        /// <inheritdoc/>
        public async Task CreateCompendiums(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);
            if (compendium is null)
            {
                throw new ArgumentNullException(nameof(compendium));
            }

            if (string.IsNullOrEmpty(rootDataDirectory))
            {
                throw new ArgumentException($"'{nameof(rootDataDirectory)}' cannot be null or empty.", nameof(rootDataDirectory));
            }

            // Combine the rootDataDirectory with the compendium title to create a file name
            var fileName = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            // Determine if the operation should be skipped.
            if (File.Exists(fileName) && !compendium.OverwriteExisting)
            {
                this.logger.LogWarning("Processing of compendium skipped due to OverwriteExisting flag: {OverwriteExisting}.", compendium.OverwriteExisting);
                return;
            }

            // Create a task list to keep track of asynchronously running operations.
            var tasks = new List<Task<CampaignEntry>>();
            foreach (var prompt in compendium.Prompts)
            {
                tasks.Add(ChatGPTHelper.ParseCampaignEntries(
                        this.configurationService.GetService(prompt.Service),
                        prompt,
                        rootDataDirectory,
                        compendium.GameSystem));
            }

            // Wait for all tasks to complete
            var results = await Task.WhenAll(tasks);

            // Create CampaignLogger File
            this.logger.LogInformation("Creating CampaignLogger file for compendium: {compendium}.", compendium.Title);
            var campaignLoggerFile = new Campaign()
            {
                Version = 2,
                Type = "campaign",
                Title = compendium.Title,
                Description = compendium.Description,
                CampaignEntries = results.ToList(),
                Logs = new List<Log>(),
                ImageUrl = string.Empty,
            };

            // Serialize the campaignLoggerFile object into a string using JsonConvert
            string campaignLoggerFileString = JsonConvert.SerializeObject(campaignLoggerFile, Formatting.Indented);

            // Write the campaignLoggerFileString to the fileName
            File.WriteAllText(fileName, campaignLoggerFileString);

            // Log a message to the logger that the processing of the compendium is complete
            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}
