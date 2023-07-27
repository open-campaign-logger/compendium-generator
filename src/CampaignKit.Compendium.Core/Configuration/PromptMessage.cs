// <copyright file="PromptMessage.cs" company="Jochen Linnemann - IT-Service">
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
    /// Configuration class for chat prompt messages to be executed by a module.
    /// </summary>
    public class PromptMessage
    {
        /// <summary>
        /// Gets or sets the prompt message to send to the service.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the header text that should preceed the generated text
        /// in the Campaign Entry.
        /// </summary>
        public string Heading { get; set; } = string.Empty;
    }
}
