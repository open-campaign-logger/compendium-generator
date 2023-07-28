﻿// <copyright file="CustomHttpClientFactory.cs" company="Jochen Linnemann - IT-Service">
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
    /// <summary>
    /// Creates a new instance of the <see cref="CustomHttpClientFactory"/> class.
    /// </summary>
    /// <param name="timeSpan">The timeout value for the <see cref="HttpClient"/>.</param>
    /// <returns>
    /// A new instance of the <see cref="CustomHttpClientFactory"/> class.
    /// </returns>
    internal class CustomHttpClientFactory : IHttpClientFactory
    {
        private int timeSpan = 300;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHttpClientFactory"/> class.
        /// </summary>
        /// <param name="timeSpan">The desired number of seconds to use for determining timeouts.</param>
        public CustomHttpClientFactory(int timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        /// <inheritdoc/>
        public HttpClient CreateClient(string name)
        {
            return new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(this.timeSpan),
            };
        }
    }
}
