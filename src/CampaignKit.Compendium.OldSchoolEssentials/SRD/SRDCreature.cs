// <copyright file="SRDCreature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.OldSchoolEssentials.SRD
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class representing a creature from the Old School Essentials System Reference Document (SRD).
    /// </summary>
    public class SRDCreature : ICreature
    {
        private readonly CampaignEntry campaignEntry;

        /// <summary>
        /// Initializes a new instance of the <see cref="SRDCreature"/> class.
        /// </summary>
        /// <param name="campaignEntry">The source CampaignLogger CampaignEntry that contains the source data.</param>
        public SRDCreature(CampaignEntry campaignEntry)
        {
            this.campaignEntry = campaignEntry ?? throw new ArgumentNullException(nameof(campaignEntry));
        }

        /// <inheritdoc/>
        public string? LicenseURL { get; set; }

        /// <inheritdoc/>
        public string? PublisherName { get; set; }

        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            throw new NotImplementedException();
        }
    }
}
