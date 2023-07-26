// <copyright file="DefaultMarkdownCompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Markdown.Common
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Configuration;

    using System.Text;

    /// <summary>
    /// This static class provides helper methods for working with Markdown.
    /// </summary>
    public static class MarkdownHelper
    {

        /// <summary>
        /// Parses the campaign entries from the given source data set, directory, tag symbol and labels.
        /// <paramref name="sourceDataSet">The source data set to extract campaign entries from.</paramref>
        /// <paramref name="directory">Directory where the file can be found.</paramref>
        /// </summary>
        public static async Task<List<CampaignEntry>> ParseCampaignEntries(SourceDataSet sourceDataSet, string directory)
        {
            // Keep track of how many items we import from this data source.
            var importCount = 0;

            // Read all lines from the file specified in the sourceDataSetURI
            var lines = await File.ReadAllLinesAsync(Path.Combine(directory, sourceDataSet.SourceDataSetURI));
            var stringBuilder = new StringBuilder();
            var campaignEntries = new List<CampaignEntry>();
            var stringEntryName = string.Empty;

            // Iterate through each line
            foreach (var line in lines)
            {
                // If the line starts with "# "
                if (line.StartsWith("# "))
                {
                    // If the stringBuilder has content
                    if (stringBuilder.Length > 0)
                    {
                        campaignEntries.Add(ParseCampaignEntry(sourceDataSet, stringBuilder, stringEntryName));

                        // Clear the stringBuilder
                        stringBuilder.Clear();

                        // Increment the import count
                        importCount++;

                        // Check if the import count is greater than or equal to the
                        // ImportLimit, or if the ImportLimit is null, then check if it is
                        // greater than or equal to the maximum integer value
                        if (importCount >= (sourceDataSet.ImportLimit ?? int.MaxValue))
                        {
                            // If the condition is true, break out of the loop
                            break;
                        }
                    }
                    // Set the stringEntryName to the line starting from the third character
                    stringEntryName = line[2..];
                }
                // Append the line to the stringBuilder
                stringBuilder.AppendLine(line);
            }
            
            if (stringBuilder.Length > 0) {
                campaignEntries.Add(ParseCampaignEntry(sourceDataSet, stringBuilder, stringEntryName));
            }

            return campaignEntries;
        }

        private static CampaignEntry ParseCampaignEntry(SourceDataSet sourceDataSet, StringBuilder stringBuilder, string stringEntryName)
        {
            // Create a new CampaignEntry object and add it to the campaignEntries list
            var campaignEntry = new CampaignEntry()
            {
                RawText = stringBuilder.ToString(),
                TagSymbol = sourceDataSet.TagSymbol,
                TagValue = stringEntryName,
                Labels = new List<string>(),
            };

            // Add any default labels
            if (sourceDataSet.Labels != null && sourceDataSet.Labels.Count > 0)
            {
                campaignEntry.Labels.AddRange(sourceDataSet.Labels);
            }

            return campaignEntry;
        }
    }
}