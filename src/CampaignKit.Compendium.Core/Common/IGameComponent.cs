// <copyright file="IGameComponent.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Common
{
    using CampaignKit.Compendium.Core.CampaignLogger;

    /// <summary>
    /// Common interface for all game components.
    /// </summary>
    public interface IGameComponent
    {
        /// <summary>
        /// Gets or sets the URL of the license for the game component's source data.
        /// </summary>
        public string? LicenseURL { get; set; }

        /// <summary>
        /// Gets or sets the name of the game component.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the publisher of the game component's source data.
        /// </summary>
        public string? PublisherName { get; set; }

        /// <summary>
        /// Generates a CampaignLogger Entry for this game component.
        /// </summary>
        /// <returns>A CampaignLogger Entry for this game component.</returns>
        public CampaignEntry ToCampaignEntry();
    }
}