// <copyright file="CreatureHelper.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Common
{
    using System.Text;

    using CampaignKit.Compendium.Core.CampaignLogger;

    /// <summary>
    /// Utility class for working with Dungeons &amp; Dragons creatures.
    /// </summary>
    public static class CreatureHelper
    {
        /// <summary>
        /// Calculate the ability score bonus.
        /// </summary>
        /// <param name="abilityScore">The relevant ability score. Example: 17.</param>
        /// <returns>Int representing ability bonus for the specified ability score. Example: 3.</returns>
        public static int CalculateAbilityBonus(int? abilityScore)
        {
            return (int)Math.Floor(((abilityScore ?? 0) - 10) / 2.00);
        }

        /// <summary>
        /// Calculate the XP of the creature based on its challenge rating.
        /// </summary>
        /// <param name="challengeRating">The double value of the creature's challenge rating.  Example: 0.25.</param>
        /// <returns>Int value of experience points for the specified challenge rating.  Example: 50.</returns>
        public static int CalculateExperiencePoints(double challengeRating)
        {
            if (challengeRating == 0)
            {
                return 10;
            }
            else if (challengeRating < 2)
            {
                return (int)Math.Round(200 * challengeRating);
            }
            else if (challengeRating == 2)
            {
                return 450;
            }
            else if (challengeRating == 3)
            {
                return 700;
            }
            else if (challengeRating == 4)
            {
                return 1100;
            }
            else if (challengeRating == 5)
            {
                return 1800;
            }
            else if (challengeRating == 6)
            {
                return 2300;
            }
            else if (challengeRating == 7)
            {
                return 2900;
            }
            else if (challengeRating == 8)
            {
                return 3900;
            }
            else if (challengeRating == 9)
            {
                return 5000;
            }
            else if (challengeRating == 10)
            {
                return 5900;
            }
            else if (challengeRating == 11)
            {
                return 7200;
            }
            else if (challengeRating == 12)
            {
                return 8400;
            }
            else if (challengeRating == 13)
            {
                return 10000;
            }
            else if (challengeRating == 14)
            {
                return 11500;
            }
            else if (challengeRating == 15)
            {
                return 13000;
            }
            else if (challengeRating == 16)
            {
                return 15000;
            }
            else if (challengeRating == 17)
            {
                return 18000;
            }
            else if (challengeRating == 18)
            {
                return 20000;
            }
            else if (challengeRating == 19)
            {
                return 22000;
            }
            else if (challengeRating == 20)
            {
                return 25000;
            }
            else if (challengeRating == 21)
            {
                return 33000;
            }
            else if (challengeRating == 22)
            {
                return 41000;
            }
            else if (challengeRating == 23)
            {
                return 50000;
            }
            else if (challengeRating == 24)
            {
                return 62000;
            }
            else if (challengeRating == 25)
            {
                return 75000;
            }
            else if (challengeRating == 26)
            {
                return 90000;
            }
            else if (challengeRating == 27)
            {
                return 105000;
            }
            else if (challengeRating == 28)
            {
                return 120000;
            }
            else if (challengeRating == 29)
            {
                return 135000;
            }
            else if (challengeRating == 30)
            {
                return 155000;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Calculates the proficiency bonus for the moster based on its challenge rating.
        /// </summary>
        /// <param name="challengeRating">The double value of the creature's challenge rating.  Example: 0.25.</param>
        /// <returns>Int value of the challenge rating.  Example: 2.</returns>
        public static int CalculateProficiencyBonus(double challengeRating)
        {
            if (challengeRating <= 1)
            {
                return 2;
            }
            else if (challengeRating <= 4)
            {
                return 3;
            }
            else if (challengeRating <= 8)
            {
                return 4;
            }
            else if (challengeRating <= 12)
            {
                return 5;
            }
            else if (challengeRating <= 16)
            {
                return 6;
            }
            else if (challengeRating <= 20)
            {
                return 7;
            }
            else
            {
                return 8;
            }
        }

        /// <summary>
        /// Adds a "+" or "-" to the bonus value.
        /// </summary>
        /// <param name="bonus">Bonus value.  e.g. 1. </param>
        /// <returns>Bonus value with "+" or "-" prepended to it.  e.g. "+1".</returns>
        public static string ConvertBonusToSignedString(int bonus)
        {
            if (bonus >= 0)
            {
                return "+" + bonus;
            }
            else
            {
                return "-" + Math.Abs(bonus);
            }
        }

        /// <summary>
        /// Converts challenge ratings string to a double value.  Converts "1/4" to 0.25.
        /// </summary>
        /// <param name="challengeRating">The string value of the creature's challenge rating.  Example: "1/4".</param>
        /// <returns>Double value of the challenge rating or null if it could not be converted.  Example: 0.25.</returns>
        public static double? ConvertChallengeRatingToDouble(string challengeRating)
        {
            string[] tokens = challengeRating.Split("/");
            if (tokens.Length > 1)
            {
                if (double.TryParse(tokens[0].Trim(), out double numerator) && double.TryParse(tokens[1].Trim(), out double denominator))
                {
                    return numerator / denominator;
                }
            }
            else
            {
                if (double.TryParse(challengeRating, out double result))
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Converts challenge ratings double to a string value.  Converts 0.25 to "1/4".
        /// </summary>
        /// <param name="challengeRating">The double value of the creature's challenge rating.  Example: 0.25.</param>
        /// <returns>String value of the challenge rating or null if it could not be converted.  Example: "1/4".</returns>
        public static string? ConvertChallengeRatingToString(double challengeRating)
        {
            if (challengeRating == 0.125)
            {
                return "1/8";
            }
            else if (challengeRating == 0.25)
            {
                return "1/4";
            }
            else if (challengeRating == 0.33)
            {
                return "1/3";
            }
            else if (challengeRating == 0.5)
            {
                return "1/2";
            }

            return challengeRating.ToString();
        }

        /// <summary>
        /// Searches a CSV string for the integer value associated with the specified attribute.
        /// </summary>
        /// <param name="csv">A comma separated list of values to search.  Example: "darkvision 120 ft., Passive Perception 20".</param>
        /// <param name="attributeName">The name of the attribute to search for.  Example: "passive perception" (case insensitive).</param>
        /// <returns>Integer associated with the attribute or null if attribute is not found.  Example: 20.</returns>
        public static int? ParseAttributeValue(string? csv, string? attributeName)
        {
            if (string.IsNullOrEmpty(csv) || string.IsNullOrEmpty(attributeName) || attributeName.Length > csv.Length)
            {
                return null;
            }

            string[] tokens = csv.Split(',');
            foreach (string token in tokens)
            {
                if (token.Trim().StartsWith(attributeName, StringComparison.OrdinalIgnoreCase))
                {
                    string[] subTokens = token.Trim()[(attributeName.Length + 1) ..].Split(' ');

                    if (int.TryParse(subTokens[0], out int result))
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}