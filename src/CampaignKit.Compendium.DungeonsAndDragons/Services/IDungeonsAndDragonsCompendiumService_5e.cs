// <copyright file="IDungeonsAndDragonsCompendiumService_5e.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Services
{
    /// <summary>
    /// Interface for services that create Dungeons &amp; Dragons 5e compendiums.
    /// </summary>
    public interface IDungeonsAndDragonsCompendiumService_5e
    {
        /// <summary>
        /// Processes any Dungeons &amp; Dragons 5e compendiums defined in the application's configuration.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateCompendiums();
    }
}
