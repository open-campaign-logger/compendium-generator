// <copyright file="ChatGPTHelper.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.ChatGPT.Common
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;

    using OpenAI_API.Chat;

    /// <summary>
    /// This static class provides helper methods for working with Markdown.
    /// </summary>
    public static class ChatGPTHelper
    {
        /// <summary>
        /// Executes the prompt and generates a campaign entry from the response.
        /// </summary>
        /// <param name="service">Service configuration to use for executing prompt.</param>
        /// <param name="prompt">Prompt to use with the chat service.</param>
        /// <param name="directory">Directory where the downloaded prompt response can be stored.</param>
        /// <param name="gameSystem">The name of the game system that the generated content should pertain to.  Default: "Generic".</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<CampaignEntry> ParseCampaignEntries(Service service, Prompt prompt, string directory, string? gameSystem = "Generic")
        {
            // Check if the service, prompt, and directory are null
            if (service is null)
            {
                // Throw an ArgumentNullException if service is null
                throw new ArgumentNullException(nameof(service));
            }

            if (prompt is null)
            {
                // Throw an ArgumentNullException if prompt is null
                throw new ArgumentNullException(nameof(prompt));
            }

            if (string.IsNullOrEmpty(directory))
            {
                // Throw an ArgumentException if directory is null or empty
                throw new ArgumentException($"'{nameof(directory)}' cannot be null or empty.", nameof(directory));
            }

            // Verify service has required values
            if (string.IsNullOrEmpty(service.APIKey))
            {
                throw new Exception($"API key not specified for service: {service.Name}");
            }

            if (!service.IsActive)
            {
                throw new Exception($"Service has been innactivated: {service.Name}");
            }

            // Setup ChatGPT service
            var api = new OpenAI_API.OpenAIAPI(service.APIKey);

            // Converse with ChatGPT
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage(prompt.Role);

            // Iterate through the prompt messages and capture the responses.
            var stringBuilder = new StringBuilder();
            foreach (var promptMessage in prompt.PromptMessages)
            {
                var modifedPromptMessage = promptMessage.Message.Replace("{Name}", prompt.Name);
                modifedPromptMessage = modifedPromptMessage.Replace("{GameSystem}", gameSystem);
                modifedPromptMessage = modifedPromptMessage.Replace("{Genre}", prompt.Genre);
                modifedPromptMessage = modifedPromptMessage.Replace("{Sentiment}", $"On a sentiment scale of 1 to 10, where 1 represents a very precise and serious reponse and 10 represents a whimsical reponse, please generate reponses with a sentiment rating of {prompt.Sentiment}");

                if (string.IsNullOrEmpty(modifedPromptMessage))
                {
                    continue;
                }

                chat.AppendUserInput(modifedPromptMessage);
                var response = await chat.GetResponseFromChatbotAsync();

                if (response != null && !promptMessage.Heading.Equals("IGNORE", StringComparison.InvariantCultureIgnoreCase))
                {
                    stringBuilder.AppendLine(promptMessage.Heading);
                    stringBuilder.AppendLine(response);
                }
            }

            // Create the CampaignEntry
            var campaignEntry = new CampaignEntry()
            {
                Labels = prompt.Labels,
                RawPublic = string.Empty,
                RawText = stringBuilder.ToString(),
                TagSymbol = prompt.TagSymbol,
                TagValue = prompt.Name,
            };

            return campaignEntry;
        }
    }
}