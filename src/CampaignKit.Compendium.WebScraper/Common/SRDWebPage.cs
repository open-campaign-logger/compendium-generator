﻿// <copyright file="SRDWebPage.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.WebScraper.Common
{
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;


    /// <summary>
    /// Represents an Systems Reference Document (SRD) web page containing TTRPG game components.
    /// </summary>
    public class SRDWebPage : GameComponentBase
    {
        /// <inheritdoc/>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            stringBuilder.AppendLine(this.Desc);

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            CampaignEntry campaignEntry = new ()
            {
                RawText = string.Empty,
                RawPublic = stringBuilder.ToString(),
                Labels = this.Labels,
                TagSymbol = this.TagSymbol,
                TagValue = $"{this.TagValuePrefix}{this.Name}",
            };

            return campaignEntry;
        }
    }
}