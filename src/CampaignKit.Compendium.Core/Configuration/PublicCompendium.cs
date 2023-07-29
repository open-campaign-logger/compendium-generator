// <copyright file="PublicCompendium.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Configuration
{
    /// <summary>
    /// Represents the configuration of an open-source compendium within the application.
    /// These should be defined and shared in the appsettings.json file.
    /// </summary>
    public class PublicCompendium : ICompendium
    {
        /// <inheritdoc/>
        public string CompendiumService { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GameSystem { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string ImageUrl { get; set; } = string.Empty;

        /// <inheritdoc/>
        public bool IsActive { get; set; } = true;

        /// <inheritdoc/>
        public bool OverwriteExisting { get; set; } = false;

        /// <inheritdoc/>
        public List<Prompt> Prompts { get; set; } = new List<Prompt> { };

        /// <inheritdoc/>
        public List<SourceDataSet> SourceDataSets { get; set; } = new List<SourceDataSet>();

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;
    }
}
