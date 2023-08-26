// <copyright file="IGameComponent.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Common
{
    using CampaignKit.Compendium.Core.CampaignLogger;

    /// <summary>
    /// Common interface for all game components.
    /// </summary>
    public interface IGameComponent
    {
        /// <summary>
        /// Gets or sets the list of labels associated with this game component.
        /// </summary>
        public List<string>? Labels { get; set; }

        /// <summary>
        /// Gets or sets the description of the game component.
        /// </summary>
        public string? Desc { get; set; }

        /// <summary>
        /// Gets or sets the name of the game component.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the title of the source of the game component's data.
        /// </summary>
        public string? SourceTitle { get; set; }

        /// <summary>
        /// Gets or sets the list of labels associated with this game component.
        /// </summary>
        public string? TagSymbol { get; set; }

        /// <summary>
        /// Gets or sets the tag value prefix for this game component.
        /// </summary>
        public string? TagValuePrefix { get; set; }

        /// <summary>
        /// Generates a CampaignLogger Entry for this game component.
        /// </summary>
        /// <returns>A CampaignLogger Entry for this game component.</returns>
        public CampaignEntry ToCampaignEntry();
    }
}