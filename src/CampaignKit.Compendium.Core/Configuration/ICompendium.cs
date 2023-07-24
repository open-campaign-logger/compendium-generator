﻿// <copyright file="ICompendium.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents the configuration of a compendium within the application.
    /// These should be defined and shared in the appsettings.json and secrets.json files.
    /// </summary>
    public interface ICompendium
    {
        /// <summary>
        /// Gets or sets the name of the CompendiumService to use for processing this compendium.
        /// </summary>
        string CompendiumService { get; set; }

        /// <summary>
        /// Gets or sets the description of the Compendium.
        /// This property is typically used to provide a brief explanation of the Compendium's content.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with the Compendium.
        /// This property is typically used to provide a visual representation of the Compendium's content.
        /// </summary>
        string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the list of source data sets associated with the Compendium.
        /// Each item in this list represents a set of data that is used in the Compendium.
        /// </summary>
        List<SourceDataSet> SourceDataSets { get; set; }

        /// <summary>
        /// Gets or sets the title of the Compendium.
        /// This property is typically used to provide a succinct name for the Compendium.
        /// </summary>
        string Title { get; set; }
    }
}
