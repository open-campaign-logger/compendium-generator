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
    /// An interface that each tabletop role playing game (TTRPG) ruleset service will implement.
    /// </summary>
    public interface ICompendiumService
    {
        /// <summary>
        /// 1. Search through appsettings.json for compendium configurations.
        /// 2. Process any compendiums associated with this service.
        /// </summary>
        /// <returns>
        /// This is an asynchronous operation. A task is returned so that the calling code can
        /// continue other work while this function completes.
        /// </returns>
        public Task CreateCompendiums();
    }
}
