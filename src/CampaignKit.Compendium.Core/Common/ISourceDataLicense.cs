// <copyright file="ISourceDataLicense.cs" company="Jochen Linnemann - IT-Service">
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
    /// Represents the license information for a particular data set within the application.
    /// </summary>
    public interface ISourceDataLicense
    {
        /// <summary>
        /// Gets or sets the title of the license.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Gets or sets the slug of the license.
        /// A slug is a URL-friendly version of the title which is typically used in links to the license.
        /// </summary>
        string? Slug { get; set; }

        /// <summary>
        /// Gets or sets the description of the license.
        /// </summary>
        string? Desc { get; set; }

        /// <summary>
        /// Gets or sets the actual text of the license agreement.
        /// </summary>
        string? License { get; set; }

        /// <summary>
        /// Gets or sets the author of the licensed content.
        /// </summary>
        string? Author { get; set; }

        /// <summary>
        /// Gets or sets the organization that owns the licensed content.
        /// </summary>
        string? Organization { get; set; }

        /// <summary>
        /// Gets or sets the version of the licensed content.
        /// </summary>
        string? Version { get; set; }

        /// <summary>
        /// Gets or sets the copyright information for the licensed content.
        /// </summary>
        string? Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL where more information about the license can be found.
        /// </summary>
        string? Url { get; set; }
    }
}