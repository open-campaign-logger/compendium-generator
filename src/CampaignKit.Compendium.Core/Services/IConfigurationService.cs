// <copyright file="IConfigurationService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Services
{
    using System.Collections.Generic;
    using CampaignKit.Compendium.Core.Configuration;

    /// <summary>
    /// IConfigurationService provides an interface for accessing configuration related services.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// This method returns the private data directory from the configuration
        /// or a default path if it is not set.
        /// </summary>
        /// <returns>The root data directory.</returns>
        string GetPrivateDataDirectory();

        /// <summary>
        /// This method returns the public data directory from the configuration
        /// or a default path if it is not set.
        /// </summary>
        /// <returns>The root data directory.</returns>
        string GetPublicDataDirectory();

        /// <summary>
        /// Gets a list of open source compendiums configured for the specified service name.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>A list of open source compendiums configured for the specified service name.</returns>
        List<PublicCompendium> GetPublicCompendiumsForService(string serviceName);

        /// <summary>
        /// Gets a list of all configured open source compendiums.
        /// </summary>
        /// <returns>A list of configured open source compendiums.</returns>
        List<PublicCompendium> GetAllPublicCompendiums();

        /// <summary>
        /// Gets a list of private compendiums configured for the specified service name.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>A list of private compendiums configured for the specified service name.</returns>
        List<PublicCompendium> GetPrivateCompendiumsForService(string serviceName);

        /// <summary>
        /// Gets a list of all configured private compendiums.
        /// </summary>
        /// <returns>A list of configured private compendiums.</returns>
        List<PublicCompendium> GetAllPrivateCompendiums();
    }
}