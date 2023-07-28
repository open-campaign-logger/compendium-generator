// <copyright file="DefaultOldSchoolEssentialsCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.OldSchoolEssentials.Services
{
    using System.Reflection;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;
    using CampaignKit.Compendium.OldSchoolEssentials.SRD;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

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
        /// Initializes a new instance of the <see cref="DefaultOldSchoolEssentialsCompendiumService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <returns>
        /// A DefaultOldSchoolEssentialsCompendiumService instance.
        /// </returns>
        public DefaultOldSchoolEssentialsCompendiumService(ILogger<DefaultOldSchoolEssentialsCompendiumService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task CreateCompendiums(ICompendium compendium, string rootDataDirectory)
        {
            this.logger.LogInformation("Processing of compendium starting: {compendium}.", compendium.Title);

            // Combine the rootDataDirectory with the compendium title to create a file name
            var filePath = Path.Combine(rootDataDirectory, compendium.Title + ".json");

            // Determine if the operation should be skipped.
            if (File.Exists(filePath) && !compendium.OverwriteExisting)
            {
                this.logger.LogWarning("Processing of compendium skipped due to OverwriteExisting flag: {OverwriteExisting}.", compendium.OverwriteExisting);
                return;
            }

            // Create a campaign object to hold the new campaign entries.
            var destinationCampaign = new Campaign()
            {
                Version = 2,
                Type = "campaign",
                Title = compendium.Title,
                Description = compendium.Description,
                CampaignEntries = new List<CampaignEntry>(),
                Logs = new List<Log>(),
                ImageUrl = "https://cdn.shopify.com/s/files/1/0592/6934/9566/files/OSE_Black_Box_480x480.png?v=1632224048",
            };

            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // The resource name is the default namespace of the project, followed by the file
            // path within the project (with '.' instead of '/') If the file is in the
            // 'SourceDataSets' subfolder under the project root and the default namespace is
            // 'MyNamespace', it would be "MyNamespace.SourceDataSets.MyFile.txt"
            string resourceName = "CampaignKit.Compendium.OldSchoolEssentials.SourceDataSets.OSE-SRD-v1.0.json";
            string campaignJSON;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new Exception($"Unable to load embedded resource: {resourceName}"))
            {
                using StreamReader reader = new (stream);
                campaignJSON = await reader.ReadToEndAsync();
            }

            // Deserialize the JSON string into a Campaign object
            var campaign = JsonConvert.DeserializeObject<Campaign>(campaignJSON) ?? throw new Exception($"Source data could not be parsed.");

            // Iterate through each CampaignEntry in the Campaign
            if (campaign.CampaignEntries != null)
            {
                // Keep track of how many items we import from this data source.
                var monsterDataSourceConfig = compendium.SourceDataSets.FirstOrDefault(ds => ds.SourceDataSetName.Equals("Monsters"));
                var monsterImportLimit = monsterDataSourceConfig?.ImportLimit ?? int.MaxValue;
                var monsterImportCount = 0;
                var spellDataSourceConfig = compendium.SourceDataSets.FirstOrDefault(ds => ds.SourceDataSetName.Equals("Spells"));
                var spellImportLimit = spellDataSourceConfig?.ImportLimit ?? int.MaxValue;
                var spellImportCount = 0;
                var itemDataSourceConfig = compendium.SourceDataSets.FirstOrDefault(ds => ds.SourceDataSetName.Equals("Items"));
                var itemImportLimit = itemDataSourceConfig?.ImportLimit ?? int.MaxValue;
                var itemImportCount = 0;

                foreach (var campaignEntry in campaign.CampaignEntries)
                {
                    // Check if the CampaignEntry contains labels
                    if (campaignEntry != null && campaignEntry.Labels != null)
                    {
                        // Process monsters
                        if (campaignEntry.Labels.Contains("Monster"))
                        {
                            // Create a new SRDCreature object from the CampaignEntry
                            var creature = new SRDCreature(campaignEntry)
                            {
                                TagSymbol = monsterDataSourceConfig?.TagSymbol ?? "~",
                            };
                            creature.Labels ??= new List<string>();
                            if (monsterDataSourceConfig != null
                                && monsterDataSourceConfig.Labels != null
                                && monsterDataSourceConfig.Labels.Count > 0)
                            {
                                creature.Labels.AddRange(monsterDataSourceConfig.Labels);
                            }

                            // Add the creature to the destination Campaign
                            destinationCampaign.CampaignEntries.Add(creature.ToCampaignEntry());

                            // Increment the counter
                            monsterImportCount++;

                            // Check if the counter is greater than or equal to the import limit.
                            if (monsterImportCount >= monsterImportLimit)
                            {
                                // Break out of the loop
                                break;
                            }
                        }

                        // Process spells
                        if (campaignEntry.Labels.Contains("Spell"))
                        {
                            // Create a new SRDSpell object from the CampaignEntry
                            var spell = new SRDSpell(campaignEntry)
                            {
                                TagSymbol = monsterDataSourceConfig?.TagSymbol ?? "~",
                            };
                            spell.Labels ??= new List<string>();
                            if (monsterDataSourceConfig != null
                                && monsterDataSourceConfig.Labels != null
                                && monsterDataSourceConfig.Labels.Count > 0)
                            {
                                spell.Labels.AddRange(monsterDataSourceConfig.Labels);
                            }

                            // Add the spell to the destination Campaign
                            destinationCampaign.CampaignEntries.Add(spell.ToCampaignEntry());

                            // Increment the counter
                            spellImportCount++;

                            // Check if the counter is greater than or equal to the import limit.
                            if (spellImportCount >= spellImportLimit)
                            {
                                // Break out of the loop
                                break;
                            }
                        }

                        // Process magic items
                        if (campaignEntry.Labels.Contains("Magic Items"))
                        {
                            // Create a new SRDItem object from the CampaignEntry
                            var magicItem = new SRDMagicItem(campaignEntry)
                            {
                                TagSymbol = monsterDataSourceConfig?.TagSymbol ?? "+",
                            };
                            magicItem.Labels ??= new List<string>();
                            if (monsterDataSourceConfig != null
                                && monsterDataSourceConfig.Labels != null
                                && monsterDataSourceConfig.Labels.Count > 0)
                            {
                                magicItem.Labels.AddRange(monsterDataSourceConfig.Labels);
                            }

                            // Add the magic magicItem to the destination Campaign
                            destinationCampaign.CampaignEntries.Add(magicItem.ToCampaignEntry());

                            // Increment the counter
                            itemImportCount++;

                            // Check if the counter is greater than or equal to the import limit.
                            if (itemImportCount >= itemImportLimit)
                            {
                                // Break out of the loop
                                break;
                            }
                        }
                    }
                }
            }

            // Serialize the destinationCampaign object into a string
            string campaignLoggerFileString = JsonConvert.SerializeObject(destinationCampaign, Formatting.Indented);

            // Write the campaignLoggerFileString to the filePath
            File.WriteAllText(filePath, campaignLoggerFileString);

            this.logger.LogInformation("Processing of compendium complete: {compendium}.", compendium.Title);
        }
    }
}