// <copyright file="DefaultChatGPTCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.ChatGPT.Services
{
    using CampaignKit.Compendium.Core.Configuration;
    using Microsoft.Extensions.Logging;

    public class DefaultChatGPTCompendiumService : IChatGPTCompendiumService
    {

        /// <summary>
        /// Create a private readonly field to store an ILogger instance
        /// with the type DefaultChatGPTCompendiumService.
        /// </summary>
        private readonly ILogger<DefaultChatGPTCompendiumService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultChatGPTCompendiumService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <returns>
        /// A DefaultChatGPTCompendiumService instance.
        /// </returns>
        public DefaultChatGPTCompendiumService(ILogger<DefaultChatGPTCompendiumService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public Task CreateCompendiums(ICompendium compendium, string rooDataDirectory)
        {
            throw new NotImplementedException();
        }
    }
}
