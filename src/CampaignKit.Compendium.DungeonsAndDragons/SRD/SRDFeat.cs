// <copyright file="SRDFeat.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a feat in a Dungeons and Dragons game.
    /// </summary>
    public class SRDFeat : SRDBase
    {
        /// <summary>
        /// Gets or sets the effects associated with the feat.
        /// </summary>
        [JsonProperty("effects_desc")]
        public List<string>? Effects { get; set; } = new List<string> { };

        /// <summary>
        /// Gets or sets the prerequisite of the feat.
        /// </summary>
        [JsonProperty("prerequisite")]
        public string? Prerequisite { get; set; } = string.Empty;

        /// <summary>
        /// Generate a Campaign Entry that represents this object.
        /// </summary>
        /// <returns>A Campaign Entry that represents this object.</returns>
        public override CampaignEntry ToCampaignEntry()
        {
            // Create a markdown representation of the data.
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# {this.Name}");
            stringBuilder.AppendLine(this.Desc);
            if (!string.IsNullOrEmpty(this.Prerequisite))
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"{{b|Prerequisite}}: {this.Prerequisite}");
            }

            if (this.Effects != null && this.Effects.Count > 0)
            {
                stringBuilder.AppendLine("## Effects");
                foreach (var effect in this.Effects)
                {
                    if (!effect.StartsWith("*"))
                    {
                        stringBuilder.Append("* ");
                    }

                    stringBuilder.AppendLine($"{effect}");
                }
            }

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
