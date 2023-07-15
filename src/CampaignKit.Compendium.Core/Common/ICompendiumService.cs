// <copyright file="ICompendiumService.cs" company="Jochen Linnemann - IT-Service">
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
    /// <summary>
    /// All Tabletop Roleplaying Game (TTRPG) compendium services must implement this interface.
    /// </summary>
    public interface ICompendiumService
    {
        /// <summary>
        /// Each TTRPG compendium service must implement the following functionality:
        /// 1. Download the open-source source material if required.
        /// 2. Parse the ruleset data.
        /// 3. Convert the objects to a standard form, (i.e. IMonster, IItem, IRolltable)
        /// 4. Generate a compendium file that can be imported into the CampaignLogger application.
        /// </summary>
        /// <returns>
        /// This operation is asynchronous. A task is returned so that the client code can execute
        /// other code while this function completes.
        /// </returns>
        public Task CreateCompendiums();
    }
}
