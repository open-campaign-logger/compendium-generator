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

    using CampaignKit.Compendium.ChatGPT.Services;
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;

    using Microsoft.EntityFrameworkCore.Update;

    using OpenAI_API.Chat;
    using OpenAI_API.Models;
    using OpenAI_API.Moderation;

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
        public static async Task<CampaignEntry> GenerateCampaignEntryFromPrompt(Service service, Prompt prompt, string directory, string? gameSystem = "Generic")
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

            // If the service is innactive throw an error message.
            if (!service.IsActive)
            {
                throw new Exception($"Service has been innactivated: {service.Name}");
            }

            // Create a list to hold all the async tasks.
            var tasks = new List<Task<string>>();

            // Setup ChatGPT service
            var api = new OpenAI_API.OpenAIAPI(service.APIKey)
            {
                HttpClientFactory = new CustomHttpClientFactory(service.Timeout),
            };

            // Create chat messages for each of the configured prompt messages.
            foreach (var promptMessage in prompt.PromptMessages)
            {
                // Replace {Name} with the value of prompt.Name
                var modifedPromptMessage = promptMessage.Message.Replace("{Name}", prompt.Name);

                // Replace {GameSystem} with the value of gameSystem
                modifedPromptMessage = modifedPromptMessage.Replace("{GameSystem}", gameSystem);

                // Replace {Genre} with the value of prompt.Genre
                modifedPromptMessage = modifedPromptMessage.Replace("{Genre}", prompt.Genre);

                // Replace {Sentiment} with a sentiment rating of prompt.Sentiment
                modifedPromptMessage = modifedPromptMessage.Replace("{Sentiment}", $"On a sentiment scale of 1 to 10, where 1 represents a very precise and serious reponse and 10 represents a whimsical reponse, please generate reponses with a sentiment rating of {prompt.Sentiment}");

                // Check if the modified prompt message is empty or not
                if (string.IsNullOrEmpty(modifedPromptMessage))
                {
                    continue; // If empty, continue to the next iteration
                }

                // Create a list of chat messages to pass to the chatbot.
                var chatMessages = new List<ChatMessage>()
                {
                    // Create a "System" message that will instruct the chatbot on how to behave.
                    new ChatMessage()
                    {
                        Role = ChatMessageRole.System,
                        Content = prompt.Role,
                    },

                    // Create a "User" message that will prompt the chatbot for a specific response.
                    new ChatMessage()
                    {
                        Role = ChatMessageRole.User,
                        Content = modifedPromptMessage,
                    },
                };

                // Determine which model to use.
                var model = Model.DefaultModel;
                if (!string.IsNullOrEmpty(service.Model))
                {
                    model = service.Model switch
                    {
                        "text-ada-001" => Model.AdaText,
                        "text-babbage-001" => Model.BabbageText,
                        "gpt-3.5-turbo" => Model.ChatGPTTurbo,
                        "gpt-3.5-turbo-0301" => Model.ChatGPTTurbo0301,
                        "text-curie-001" => Model.CurieText,
                        "code-cushman-001" => Model.CushmanCode,
                        "code-davinci-002" => Model.DavinciCode,
                        "text-davinci-003" => Model.DavinciText,
                        "gpt-4" => Model.GPT4,
                        "gpt-4-32k" => Model.GPT4_32k_Context,
                        "text-moderation-latest" => Model.TextModerationLatest,
                        "text-moderation-stable" => Model.TextModerationStable,
                        _ => Model.ChatGPTTurbo,
                    };
                }

                // Create a task for each API call and add it to the list
                var task = Task.Run(async () =>
                {
                    try
                    {
                        // Call the API service.
                        var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                        {
                            Model = model,
                            Messages = chatMessages,
                        });

                        // Ensure that a result was received.
                        if (result is null || result.Choices is null || result.Choices.Count == 0)
                        {
                            throw new Exception("No response received from chatbot.");
                        }

                        // Create StringBuilder to build reponse.
                        var stringBuilder = new StringBuilder();

                        // Add the prompt heading to the output.
                        stringBuilder.AppendLine(promptMessage.Heading);

                        // Append the prompt response to the string builder
                        stringBuilder.AppendLine(result.Choices[0].Message.Content);

                        // If the message creation terminated unexpectedly add a note.
                        if (!result.Choices[0].FinishReason.Equals("stop"))
                        {
                            stringBuilder.AppendLine($"\nChatbot reponse terminated unexpectedly: : {result.Choices[0].FinishReason}");
                        }

                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception here, perhaps logging the error and then rethrowing
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                });

                tasks.Add(task);
            }

            // Wait for all tasks to complete.
            var results = await Task.WhenAll(tasks);

            // Process the results
            var stringBuilder = new StringBuilder();
            foreach (var result in results)
            {
                stringBuilder.Append(result);
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