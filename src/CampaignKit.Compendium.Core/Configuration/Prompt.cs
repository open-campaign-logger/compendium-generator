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
        /// Gets or sets a list of default labels to apply to all entries created from this prompt.
        /// </summary>
        public List<string> Labels { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the name of the prompt. This will used for two purposes:
        /// <list type="bullet">
        /// <item>Naming the directory and file where the prompt response will be stored, and</item>
        /// <item>Naming the campaign entry that's created from the prompt response.</item>
        /// </list>
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether new data should be downloaded to replace saved prompt responses.
        /// </summary>
        public bool OverwriteExisting { get; set; } = false;

        /// <summary>
        /// Gets or sets the prompt to use for generation.
        /// </summary>
        public string PromptInput { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the prompt template to import from the Prompts folder.
        /// </summary>
        public string PromptTemplate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sentiment to use for generating the response.
        /// Value is a float from zero to one.
        /// A value of `0` means that responses should be entirely serious.
        /// A value of `1` means that responses should be entirely comedic.
        /// Default value is: 0.5.
        /// </summary>
        public float Sentiment { get; set; } = 0.5F;

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
