// <copyright file="Substitution.cs" company="Jochen Linnemann - IT-Service">
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
    /// Configuration class for XPath/HTML substitutions.
    /// </summary>
    public class Substitution
    {
        /// <summary>
        /// Gets or sets the XPath of the element to replace in the data set.
        /// </summary>
        public string? XPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HTML to replace the element in the document found at location XPath.
        /// </summary>
        public string? HTML { get; set; } = string.Empty;
    }
}
