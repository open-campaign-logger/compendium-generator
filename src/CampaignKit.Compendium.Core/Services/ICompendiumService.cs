// <copyright file="ICompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Services
{
    using CampaignKit.Compendium.Core.Configuration;

    /// <summary>
    /// All Tabletop Roleplaying Game (TTRPG) compendium services must implement this interface.
    /// </summary>
    public interface ICompendiumService
    {
        /// <summary>
        /// Each TTRPG compendium service should implement the following functionality:
        /// 1. Access the source material.
        /// 2. Parse the source material.
        /// 3. Convert the source material into standard IGameComponent objects.
        /// 4. Generate a compendium file that can be imported into the CampaignLogger application.
        /// </summary>
        /// <param name="compendium">The compendium configuration to use.</param>
        /// <param name="rooDataDirectory">Directory where files will be read from and written to.</param>
        /// <returns>
        /// This operation is asynchronous. A task is returned so that the client code can execute
        /// other code while this function completes.
        /// </returns>
        public Task CreateCompendium(ICompendium compendium, string rooDataDirectory);
    }
}
