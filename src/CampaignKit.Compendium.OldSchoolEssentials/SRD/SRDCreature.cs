// <copyright file="SRDCreature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.OldSchoolEssentials.SRD
{
    using System.Text;
    using System.Text.RegularExpressions;

    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    /// <summary>
    /// Class representing a creature from the Old School Essentials System Reference Document (SRD).
    /// </summary>
    public partial class SRDCreature : IGameComponent
    {
        /// <summary>
        /// Represents a read-only instance of a CampaignEntry object.
        /// </summary>
        private readonly CampaignEntry campaignEntry;

        /// <summary>
        /// Initializes a new instance of the <see cref="SRDCreature"/> class.
        /// </summary>
        /// <param name="campaignEntry">The source CampaignLogger CampaignEntry that contains the source data.</param>
        public SRDCreature(CampaignEntry campaignEntry)
        {
            // Check if campaignEntry is null, if it is, throw an ArgumentNullException
            this.campaignEntry = campaignEntry ?? throw new ArgumentNullException(nameof(campaignEntry));

            // Set the Name property of this object to the value of the TagValue property of the campaignEntry object, or throw an ArgumentNullException if TagValue is null
            this.Name = this.campaignEntry.TagValue ?? throw new Exception($"CampaignEntry missing attribute: TagValue");

            // Check if the Labels property of campaignEntry is null or if it does not contain the label variable
            if (this.campaignEntry.Labels == null || !this.campaignEntry.Labels.Contains("Monster"))
            {
                // If either of the conditions are true, throw an exception
                throw new Exception($"Required label not found in CampaignEntry: Monster");
            }

            // Set the SourceTitle property of this object to "Necrotic Gnome OGL"
            this.SourceTitle = "Necrotic Gnome OGL";

            // Sets the tag symbol to use when rendering the stat block.
            this.TagSymbol = campaignEntry.TagSymbol;
        }

        /// <inheritdoc/>
        public string? Desc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of labels associated with the creature.
        /// </summary>
        public List<string>? Labels { get; set; } = new List<string>();

        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public string? SourceTitle { get; set; }

        /// <summary>
        /// Gets or sets the campaign tag symbol to use for this creature.
        /// </summary>
        public string? TagSymbol { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? TagValuePrefix { get; set; } = string.Empty;

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            // Declare a label variable and set it to "Monster"
            var label = "Monster";

            // Check if the Labels property of campaignEntry is null or if it does not contain the label variable
            if (this.campaignEntry.Labels == null || !this.campaignEntry.Labels.Contains(label))
            {
                // If either of the conditions are true, throw an exception
                throw new Exception($"Required label not found in CampaignEntry: {label}");
            }

            // Check if the RawText property of campaignEntry is null or empty
            if (string.IsNullOrEmpty(this.campaignEntry.RawText))
            {
                // If it is, throw an exception
                throw new Exception($"Required data not found in CampaignEntry: {nameof(this.campaignEntry.RawText)}");
            }

            var lines = this.campaignEntry.RawText.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // Initialize variables for each property you want to extract
            string title = string.Empty, description = string.Empty, treasureType = string.Empty, alignment = string.Empty, hitdice = string.Empty;
            List<string> stats = new ();
            List<string> traits = new ();
            List<string> freetext = new ();

            // Initialize a variable to keep track of the current section
            string currentSection = string.Empty;

            // Iterate over the lines
            foreach (string line in lines)
            {
                // Trim leading and trailing whitespace
                string trimmedLine = line.Trim();

                // Match lines with the format "key: value"
                Match match = OSEStatBlockRegEx().Match(trimmedLine);

                // If the match is successful, assign the key and value to the appropriate variables.
                if (match.Success)
                {
                    string key = match.Groups[1].Value.Trim();
                    string value = match.Groups[2].Value.Trim();

                    switch (key)
                    {
                        case "title":
                            title = trimmedLine;
                            currentSection = string.Empty;
                            break;
                        case "description":
                            description = trimmedLine;
                            currentSection = string.Empty;
                            break;
                        case "stats":
                            currentSection = "stats";
                            break;
                        case "traits":
                            currentSection = "traits";
                            break;
                        default:
                            switch (currentSection)
                            {
                                case "stats":
                                    stats.Add(trimmedLine);
                                    switch (key)
                                    {
                                        case "- Treasure Type":
                                            treasureType = value;
                                            break;
                                        case "- Alignment":
                                            alignment = value;
                                            break;
                                        case "- Hit Dice":
                                            hitdice = value;
                                            break;
                                    }

                                    break;
                                case "traits":
                                    traits.Add(trimmedLine);
                                    break;
                            }

                            break;
                    }
                }

                // If the trimmed line does not start with a backtick, add the trimmed line to the freetext list and set the currentSection to an empty string
                else if (!trimmedLine.StartsWith("```"))
                {
                    currentSection = string.Empty;
                    freetext.Add(trimmedLine);
                }

                // Otherwise, set the currentSection to an empty string
                else
                {
                    currentSection = string.Empty;
                }
            }

            var campaignEntry = new CampaignEntry();
            var builder = new StringBuilder();

            builder.AppendLine("```clyt");
            builder.AppendLine("template: stat-block.ose");
            builder.AppendLine(title);
            builder.AppendLine(description);
            builder.AppendLine("stats:");
            foreach (var stat in stats)
            {
                builder.AppendLine(stat);
            }

            builder.AppendLine("traits:");
            foreach (var trait in traits)
            {
                builder.AppendLine(trait);
            }

            builder.AppendLine("```");
            foreach (var text in freetext)
            {
                builder.AppendLine(text);
            }

            if (freetext.Count == 0)
            {
                builder.AppendLine();
            }

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                builder.AppendLine();
                builder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            builder.AppendLine(string.Empty);
            campaignEntry.RawText = builder.ToString();
            campaignEntry.TagSymbol = this.TagSymbol;
            campaignEntry.TagValue = this.TagValuePrefix + this.Name;
            campaignEntry.Labels = this.Labels ?? new List<string>();

            if (!string.IsNullOrEmpty(treasureType))
            {
                var treasureTypeLables = this.ParseTreasureTypes(treasureType);
                if (treasureTypeLables.Count > 0)
                {
                    foreach (var treasureTypeLabel in treasureTypeLables)
                    {
                        campaignEntry.Labels.Add($"Treasure Type: {treasureTypeLabel}");
                    }
                }
                else
                {
                    campaignEntry.Labels.Add($"Treasure Type: None");
                }
            }

            if (!string.IsNullOrEmpty(alignment))
            {
                if (alignment.Contains("Chaotic"))
                {
                    campaignEntry.Labels.Add($"Alignment: Chaotic");
                }

                if (alignment.Contains("Lawful"))
                {
                    campaignEntry.Labels.Add($"Alignment: Lawful");
                }

                if (alignment.Contains("Neutral"))
                {
                    campaignEntry.Labels.Add($"Alignment: Neutral");
                }

                if (alignment.Contains("Any"))
                {
                    campaignEntry.Labels.Add($"Alignment: Any");
                }
            }

            if (!string.IsNullOrEmpty(hitdice))
            {
                if (hitdice.Contains('*'))
                {
                    campaignEntry.Labels.Add("Special Abilities");
                }

                var hitdicelabels = this.ParseHitDiceValues(hitdice);
                foreach (var hitdicelabel in hitdicelabels)
                {
                    campaignEntry.Labels.Add($"HD: {hitdicelabel}");
                }
            }

            return campaignEntry;
        }

        [GeneratedRegex("(\\d+)")]
        private static partial Regex HitDiceRegEx();

        [GeneratedRegex("^(.*?):(.*)$")]
        private static partial Regex OSEStatBlockRegEx();

        [GeneratedRegex("\\(?([A-Z])\\)?")]
        private static partial Regex TreasureTypeRegEx();

        /// <summary>
        /// Parses a string for hit dice values before the opening parenthesis.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>A list of strings containing the hit dice values.</returns>
        private List<string> ParseHitDiceValues(string input)
        {
            // Instantiate local variables
            var result = new List<string>();

            // Search for hit dice values before the opening parenthesis.
            string hd_combined = input.Split('(')[0].Trim();

            // Split the hitdice values into pieces.
            var hd_separated = hd_combined.Split(" ") ?? Array.Empty<string>();

            // Iterate over hitdice values and create labels.
            foreach (var hd in hd_separated)
            {
                // Use RegEx to extract just the first grouping of digits.
                var match = HitDiceRegEx().Match(hd);

                // Check if the match was successful and the value of the first group is not empty.
                if (match.Success && match.Groups.Count > 1 && !string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    // Add the value of the first group to the result list.
                    result.Add(match.Groups[1].Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Parses a string for treasure type values.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>A list of strings containing the hit treasure types.</returns>
        private List<string> ParseTreasureTypes(string input)
        {
            // Instantiate local variables
            var result = new List<string>();

            // Split the treasure type values into pieces.
            var tt_separated = input.Split(" ") ?? Array.Empty<string>();

            // Iterate over treasure type values and create labels.
            foreach (var tt in tt_separated)
            {
                // Check for the keyword "None"
                if (tt.Trim().Equals("None"))
                {
                    result.Add("None");
                    break;
                }

                // Use RegEx to extract just the first grouping of digits.
                var match = TreasureTypeRegEx().Match(tt);

                // Check if the match was successful and the value of the first group is not empty.
                if (match.Success && match.Groups.Count > 1 && !string.IsNullOrEmpty(match.Groups[1].Value) && match.Groups[1].Value.Length == 1)
                {
                    // Add the value of the first group to the result list.
                    result.Add(match.Groups[1].Value);
                }
            }

            return result;
        }
    }
}
