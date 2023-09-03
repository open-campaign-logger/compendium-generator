// <copyright file="CompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper.Data
{
    using CampaignKit.Compendium.Core.Configuration;

    using Newtonsoft.Json;

    using System.Text.RegularExpressions;

    using CampaignKit.Compendium.WebScraper.Common;
    using Newtonsoft.Json.Linq;
    using System.Net.Http.Json;

    /// <summary>
    /// CompendiumService provides methods for loading compendiums.
    /// </summary>
    public partial class CompendiumService
    {
        private readonly ILogger<CompendiumService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompendiumService"/> class.
        /// </summary>
        /// <param name="logger">Logger object for logging.</param>
        /// <returns>
        /// DownloadService object.
        /// </returns>
        public CompendiumService(ILogger<CompendiumService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a TreeNode from a PublicCompendium object.
        /// </summary>
        /// <param name="compendium">The PublicCompendium object to create the TreeNode from.</param>
        /// <returns>A TreeNode object created from the PublicCompendium object.</returns>
        public TreeNode CreateTreeFromCompendium(PublicCompendium compendium)
        {
            var sourceDataSets = new List<TreeNode>();
            foreach (var sds in compendium.SourceDataSets)
            {
                var substitutions = new List<TreeNode>();
                foreach (var sub in sds.Substitutions)
                {
                    substitutions.Add(new TreeNode { Text = sub.XPath ?? string.Empty });
                }

                sourceDataSets.Add(new TreeNode { Text = sds.SourceDataSetName, Children = substitutions });
            }

            return new TreeNode
            {
                Text = compendium.Title,
                Children = new List<TreeNode>()
                {
                    new TreeNode { Text = $"Description: {compendium.Description}" },
                    new TreeNode { Text = $"GameSystem: {compendium.GameSystem}" },
                    new TreeNode { Text = "SourceDataSets", Children = sourceDataSets },
                },
            };
        }

        /// <summary>
        /// Loads a PublicCompendium object from a JSON string.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>A PublicCompendium object.</returns>
        public PublicCompendium LoadCompendium(string json)
        {
            // Validate parameters
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            // Log method entry.
            this.logger.LogInformation("LoadCompendium method called with JSON: {JSON}.", json[0..50]);

            // Deserialize the JSON string into a Dictionary object using Newtonsoft.Json
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<PublicCompendium>>>(json);

            // Validate that the dictionary contains a "compendium" key.
            if (dictionary == null || dictionary.Keys.Count != 1)
            {
                throw new Exception("Unable to deserialize JSON into PublicCompendium object.");
            }

            // Get the List of PublicCompendium objects from the dictionary.
            List<PublicCompendium> compendiumList = dictionary.Values.FirstOrDefault(new List<PublicCompendium>());

            // Validate that the List contains a PublicCompendium object.
            if (compendiumList == null || compendiumList.Count != 1)
            {
                this.logger.LogError("Multiple compendium configurations detected.  Only the first will be used.");
            }

            // Return the PublicCompendium object.
            return compendiumList?[0] ?? new PublicCompendium();
        }
    }
}