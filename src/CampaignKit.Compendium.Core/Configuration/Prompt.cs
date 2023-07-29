// <copyright file="Prompt.cs" company="Jochen Linnemann - IT-Service">
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
    /// Configuration class for chat prompts to be executed by a module.
    /// </summary>
    public class Prompt
    {
        /// <summary>
        /// Gets or sets the genre that the generated response should pertain to.
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a list of default labels to apply to all entries created from this prompt.
        /// </summary>
        public List<string> Labels { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the name of the prompt. This will used for naming the campaign entry that's created from the prompt response.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of prompts to use for generating content.
        /// </summary>
        public List<PromptMessage> PromptMessages { get; set; } = new List<PromptMessage>();

        /// <summary>
        /// Gets or sets the role that the service will play when generating content.
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sentiment to use for generating the response.
        /// Value is an integer from 1 to 10.
        /// A value of `1` means that responses should be entirely serious.
        /// A value of `10` means that responses should be entirely whimsical.
        /// Default value is: 5.
        /// </summary>
        public int Sentiment { get; set; } = 5;

        /// <summary>
        /// Gets or sets the name of the configured service to use for executing this prompt.
        /// </summary>
        public string Service { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tag entry to use for campaign entries created from this prompt.
        /// </summary>
        public string TagSymbol { get; set; } = string.Empty;
    }
}
