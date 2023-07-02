// <copyright file="CreatureHelper.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.Generic
{
    using System.Text;

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
        public static int? ParseAttributeValue(string csv, string attributeName)
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
                    string[] subTokens = token.Trim()[(attributeName.Length + 1)..].Split(' ');

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

        /// <summary>
        /// Creates a Campaign-Logger statblock for the creature.
        /// </summary>
        /// <param name="creature">The creature object to convert.</param>
        /// <returns>Campaign-Logger statblock for the creature.</returns>
        public static string ToCampaignLoggerStatBlock(Creature creature)
        {
            StringBuilder builder = new();
            builder.AppendLine($"```clyt");
            builder.AppendLine($"template: stat-block.5e");
            builder.AppendLine($"title: {creature.Name}");
            builder.AppendLine($"description: {creature.Size} {creature.Type}, {creature.Alignment}");
            builder.AppendLine($"stats:");
            builder.AppendLine($"- Armor Class: {creature.ArmorClass} ({creature.ArmorDesc})");
            builder.AppendLine($"- Hit Points: {creature.HitPoints} ({creature.HitDice})");
            List<string> speeds = new()
            {
                $"{creature.Walk} ft.",
            };
            if (creature.Swim > 0)
            {
                speeds.Add($"Swim {creature.Swim} ft.");
            }

            if (creature.Fly > 0)
            {
                speeds.Add($"Fly {creature.Fly} ft." + (creature.Hover ? " (hover)" : string.Empty));
            }

            if (creature.Burrow > 0)
            {
                speeds.Add($"Burrow {creature.Burrow} ft.");
            }

            if (creature.Climb > 0)
            {
                speeds.Add($"Climb {creature.Climb} ft.");
            }

            if (creature.LightWalking > 0)
            {
                speeds.Add($"Lightwalking {creature.LightWalking} ft.");
            }

            builder.AppendLine($"- Speed: {string.Join(", ", speeds)}");
            builder.AppendLine($"- abilities:");
            builder.AppendLine($"     STR: {creature.Strength} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Strength))})");
            builder.AppendLine($"     DEX: {creature.Dexterity} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Dexterity))})");
            builder.AppendLine($"     CON: {creature.Constitution} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Constitution))})");
            builder.AppendLine($"     INT: {creature.Intelligence} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Intelligence))})");
            builder.AppendLine($"     WIS: {creature.Wisdom} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Wisdom))})");
            builder.AppendLine($"     CHA: {creature.Charisma} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Charisma))})");
            List<string> savingThrows = new();
            if (creature.StrengthSave > CreatureHelper.CalculateAbilityBonus(creature.Strength))
            {
                savingThrows.Add($"STR {CreatureHelper.ConvertBonusToSignedString(creature.StrengthSave)}");
            }

            if (creature.DexteritySave > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                savingThrows.Add($"DEX {CreatureHelper.ConvertBonusToSignedString(creature.DexteritySave)}");
            }

            if (creature.ConstitutionSave > CreatureHelper.CalculateAbilityBonus(creature.Constitution))
            {
                savingThrows.Add($"CON {CreatureHelper.ConvertBonusToSignedString(creature.ConstitutionSave)}");
            }

            if (creature.IntelligenceSave > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                savingThrows.Add($"INT {CreatureHelper.ConvertBonusToSignedString(creature.IntelligenceSave)}");
            }

            if (creature.WisdomSave > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                savingThrows.Add($"WIS {CreatureHelper.ConvertBonusToSignedString(creature.WisdomSave)}");
            }

            if (creature.CharismaSave > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                savingThrows.Add($"CHA {CreatureHelper.ConvertBonusToSignedString(creature.CharismaSave)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"- Saving Throws: {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new();
            if (creature.Acrobatics > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Acrobatics {CreatureHelper.ConvertBonusToSignedString(creature.Acrobatics)}");
            }

            if (creature.AnimalHandling > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Animal Handling {CreatureHelper.ConvertBonusToSignedString(creature.AnimalHandling)}");
            }

            if (creature.Arcana > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Arcana {CreatureHelper.ConvertBonusToSignedString(creature.Arcana)}");
            }

            if (creature.Athletics > CreatureHelper.CalculateAbilityBonus(creature.Strength))
            {
                skillsList.Add($"Athletics {CreatureHelper.ConvertBonusToSignedString(creature.Athletics)}");
            }

            if (creature.Deception > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Deception {CreatureHelper.ConvertBonusToSignedString(creature.Deception)}");
            }

            if (creature.History > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"History {CreatureHelper.ConvertBonusToSignedString(creature.History)}");
            }

            if (creature.Insight > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Insight {CreatureHelper.ConvertBonusToSignedString(creature.Insight)}");
            }

            if (creature.Intimidation > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Intimidation {CreatureHelper.ConvertBonusToSignedString(creature.Intimidation)}");
            }

            if (creature.Investigation > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Investigation {CreatureHelper.ConvertBonusToSignedString(creature.Investigation)}");
            }

            if (creature.Medicine > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Medicine {CreatureHelper.ConvertBonusToSignedString(creature.Medicine)}");
            }

            if (creature.Nature > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Nature {CreatureHelper.ConvertBonusToSignedString(creature.Nature)}");
            }

            if (creature.Perception > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Perception {CreatureHelper.ConvertBonusToSignedString(creature.Perception)}");
            }

            if (creature.Performance > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Performance {CreatureHelper.ConvertBonusToSignedString(creature.Performance)}");
            }

            if (creature.Persuasion > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Persuasion {CreatureHelper.ConvertBonusToSignedString(creature.Persuasion)}");
            }

            if (creature.Religion > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Religion {CreatureHelper.ConvertBonusToSignedString(creature.Religion)}");
            }

            if (creature.SleightOfHand > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {CreatureHelper.ConvertBonusToSignedString(creature.SleightOfHand)}");
            }

            if (creature.Stealth > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Stealth {CreatureHelper.ConvertBonusToSignedString(creature.Stealth)}");
            }

            if (creature.Survival > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Survival {CreatureHelper.ConvertBonusToSignedString(creature.Survival)}");
            }

            if (skillsList.Count > 0)
            {
                builder.AppendLine($"- Skills: {string.Join(", ", skillsList)}");
            }

            if (!string.IsNullOrEmpty(creature.DamageVulnerabilities))
            {
                builder.AppendLine($"- Damage Vulnerabilities: {creature.DamageVulnerabilities}");
            }

            if (!string.IsNullOrEmpty(creature.DamageResistances))
            {
                builder.AppendLine($"- Damage Resistances: {creature.DamageResistances}");
            }

            if (!string.IsNullOrEmpty(creature.DamageImmunities))
            {
                builder.AppendLine($"- Damage Immunities: {creature.DamageImmunities}");
            }

            if (!string.IsNullOrEmpty(creature.ConditionImmunities))
            {
                builder.AppendLine($"- Condition Immunities: {creature.ConditionImmunities}");
            }

            List<string> sensesList = new();
            if (creature.Blindsight > 0)
            {
                sensesList.Add($"Blindsight {creature.Blindsight} ft.");
            }

            if (creature.Darkvision > 0)
            {
                sensesList.Add($"Darkvision {creature.Darkvision} ft.");
            }

            if (creature.Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {creature.Tremorsense} ft.");
            }

            if (creature.Truesight > 0)
            {
                sensesList.Add($"Truesight {creature.Truesight} ft.");
            }

            sensesList.Add($"Passive Perception {creature.PassivePerception}");
            builder.AppendLine($"- Senses: {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(creature.Languages))
            {
                builder.AppendLine($"- Languages: {creature.Languages}");
            }

            builder.AppendLine($"- Challenge: {CreatureHelper.ConvertChallengeRatingToString(creature.ChallengeRating)} ({CreatureHelper.CalculateExperiencePoints(creature.ChallengeRating)} XP)");
            builder.AppendLine($"- Proficiency Bonus: {CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateProficiencyBonus(creature.ChallengeRating))}");
            if (creature.SpecialAbilities != null && creature.SpecialAbilities.Count > 0)
            {
                builder.AppendLine("traits:");
                foreach (SpecialAbility specialAbility in creature.SpecialAbilities)
                {
                    builder.AppendLine($"- {specialAbility.Name}: >");
                    foreach (string line in specialAbility.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.StartsWith("•"))
                            {
                                builder.AppendLine($"- {line[2..]}");
                            }
                            else if (line.StartsWith("Cantrips")
                                || line.StartsWith("1st level")
                                || line.StartsWith("2nd level")
                                || line.StartsWith("3rd level")
                                || line.StartsWith("4th level")
                                || line.StartsWith("5th level")
                                || line.StartsWith("6th level")
                                || line.StartsWith("7th level")
                                || line.StartsWith("8th level")
                                || line.StartsWith("9th level")
                                || line.StartsWith("10th level")
                                || line.StartsWith("11th level")
                                || line.StartsWith("12th level"))
                            {
                                builder.AppendLine($"- {line}");
                            }
                            else
                            {
                                builder.AppendLine($"    {line}");
                            }
                        }
                    }
                }
            }

            if (creature.Actions != null && creature.Actions.Count > 0)
            {
                builder.AppendLine("actions:");
                foreach (Action action in creature.Actions)
                {
                    builder.AppendLine($"- {action.Name}: >");
                    foreach (string line in action.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }

            if (creature.Reactions != null && creature.Reactions.Count > 0)
            {
                builder.AppendLine($"- Reactions: The {creature.Name} has the following reactions.");
                foreach (Reaction reaction in creature.Reactions)
                {
                    builder.AppendLine($"- {reaction.Name}: >");
                    foreach (string line in reaction.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }

            if (creature.LegendaryActions != null && creature.LegendaryActions.Count > 0)
            {
                builder.AppendLine($"- Legendary Actions: {creature.LegendaryActionDescription}");
                foreach (LegendaryAction legendaryAction in creature.LegendaryActions)
                {
                    builder.AppendLine($"-  {legendaryAction.Name}: >");
                    foreach (string line in legendaryAction.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }

            builder.AppendLine($"```");
            return builder.ToString();
        }

        /// <summary>
        /// Creates a text statblock for the creature.
        /// </summary>
        /// <param name="creature">The creature object to convert.</param>
        /// <returns>Standard text statblock for the creature.</returns>
        public static string ToTextStatBlock(Creature creature)
        {
            StringBuilder builder = new();
            builder.AppendLine($"{creature.Name}");
            builder.AppendLine($"{creature.Size} {creature.Type}, {creature.Alignment}");
            builder.AppendLine($"Armor Class {creature.ArmorClass} ({creature.ArmorDesc})");
            builder.AppendLine($"Hit Points {creature.HitPoints} ({creature.HitDice})");
            List<string> speeds = new()
            {
                $"{creature.Walk} ft.",
            };
            if (creature.Swim > 0)
            {
                speeds.Add($"Swim {creature.Swim} ft.");
            }

            if (creature.Fly > 0)
            {
                speeds.Add($"Fly {creature.Fly} ft." + (creature.Hover ? " (hover)" : string.Empty));
            }

            if (creature.Burrow > 0)
            {
                speeds.Add($"Burrow {creature.Burrow} ft.");
            }

            if (creature.Climb > 0)
            {
                speeds.Add($"Climb {creature.Climb} ft.");
            }

            if (creature.LightWalking > 0)
            {
                speeds.Add($"Lightwalking {creature.LightWalking} ft.");
            }

            builder.AppendLine($"Speed {string.Join(", ", speeds)}");
            builder.AppendLine($"STR {creature.Strength} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Strength))})");
            builder.AppendLine($"DEX {creature.Dexterity} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Dexterity))})");
            builder.AppendLine($"CON {creature.Constitution} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Constitution))})");
            builder.AppendLine($"INT {creature.Intelligence} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Intelligence))})");
            builder.AppendLine($"WIS {creature.Wisdom} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Wisdom))})");
            builder.AppendLine($"CHA {creature.Charisma} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(creature.Charisma))})");
            List<string> savingThrows = new();
            if (creature.StrengthSave > CreatureHelper.CalculateAbilityBonus(creature.Strength))
            {
                savingThrows.Add($"STR {CreatureHelper.ConvertBonusToSignedString(creature.StrengthSave)}");
            }

            if (creature.DexteritySave > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                savingThrows.Add($"DEX {CreatureHelper.ConvertBonusToSignedString(creature.DexteritySave)}");
            }

            if (creature.ConstitutionSave > CreatureHelper.CalculateAbilityBonus(creature.Constitution))
            {
                savingThrows.Add($"CON {CreatureHelper.ConvertBonusToSignedString(creature.ConstitutionSave)}");
            }

            if (creature.IntelligenceSave > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                savingThrows.Add($"INT {CreatureHelper.ConvertBonusToSignedString(creature.IntelligenceSave)}");
            }

            if (creature.WisdomSave > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                savingThrows.Add($"WIS {CreatureHelper.ConvertBonusToSignedString(creature.WisdomSave)}");
            }

            if (creature.CharismaSave > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                savingThrows.Add($"CHA {CreatureHelper.ConvertBonusToSignedString(creature.CharismaSave)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"Saving Throws {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new();
            if (creature.Acrobatics > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Acrobatics {CreatureHelper.ConvertBonusToSignedString(creature.Acrobatics)}");
            }

            if (creature.AnimalHandling > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Animal Handling {CreatureHelper.ConvertBonusToSignedString(creature.AnimalHandling)}");
            }

            if (creature.Arcana > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Arcana {CreatureHelper.ConvertBonusToSignedString(creature.Arcana)}");
            }

            if (creature.Athletics > CreatureHelper.CalculateAbilityBonus(creature.Strength))
            {
                skillsList.Add($"Athletics {CreatureHelper.ConvertBonusToSignedString(creature.Athletics)}");
            }

            if (creature.Deception > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Deception {CreatureHelper.ConvertBonusToSignedString(creature.Deception)}");
            }

            if (creature.History > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"History {CreatureHelper.ConvertBonusToSignedString(creature.History)}");
            }

            if (creature.Insight > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Insight {CreatureHelper.ConvertBonusToSignedString(creature.Insight)}");
            }

            if (creature.Intimidation > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Intimidation {CreatureHelper.ConvertBonusToSignedString(creature.Intimidation)}");
            }

            if (creature.Investigation > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Investigation {CreatureHelper.ConvertBonusToSignedString(creature.Investigation)}");
            }

            if (creature.Medicine > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Medicine {CreatureHelper.ConvertBonusToSignedString(creature.Medicine)}");
            }

            if (creature.Nature > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Nature {CreatureHelper.ConvertBonusToSignedString(creature.Nature)}");
            }

            if (creature.Perception > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Perception {CreatureHelper.ConvertBonusToSignedString(creature.Perception)}");
            }

            if (creature.Performance > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Performance {CreatureHelper.ConvertBonusToSignedString(creature.Performance)}");
            }

            if (creature.Persuasion > CreatureHelper.CalculateAbilityBonus(creature.Charisma))
            {
                skillsList.Add($"Persuasion {CreatureHelper.ConvertBonusToSignedString(creature.Persuasion)}");
            }

            if (creature.Religion > CreatureHelper.CalculateAbilityBonus(creature.Intelligence))
            {
                skillsList.Add($"Religion {CreatureHelper.ConvertBonusToSignedString(creature.Religion)}");
            }

            if (creature.SleightOfHand > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {CreatureHelper.ConvertBonusToSignedString(creature.SleightOfHand)}");
            }

            if (creature.Stealth > CreatureHelper.CalculateAbilityBonus(creature.Dexterity))
            {
                skillsList.Add($"Stealth {CreatureHelper.ConvertBonusToSignedString(creature.Stealth)}");
            }

            if (creature.Survival > CreatureHelper.CalculateAbilityBonus(creature.Wisdom))
            {
                skillsList.Add($"Survival {CreatureHelper.ConvertBonusToSignedString(creature.Survival)}");
            }

            if (skillsList.Count > 0)
            {
                builder.AppendLine($"Skills {string.Join(", ", skillsList)}");
            }

            if (!string.IsNullOrEmpty(creature.DamageVulnerabilities))
            {
                builder.AppendLine($"Damage Vulnerabilities {creature.DamageVulnerabilities}");
            }

            if (!string.IsNullOrEmpty(creature.DamageResistances))
            {
                builder.AppendLine($"Damage Resistances {creature.DamageResistances}");
            }

            if (!string.IsNullOrEmpty(creature.DamageImmunities))
            {
                builder.AppendLine($"Damage Immunities {creature.DamageImmunities}");
            }

            if (!string.IsNullOrEmpty(creature.ConditionImmunities))
            {
                builder.AppendLine($"Condition Immunities {creature.ConditionImmunities}");
            }

            List<string> sensesList = new();
            if (creature.Blindsight > 0)
            {
                sensesList.Add($"Blindsight {creature.Blindsight} ft.");
            }

            if (creature.Darkvision > 0)
            {
                sensesList.Add($"Darkvision {creature.Darkvision} ft.");
            }

            if (creature.Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {creature.Tremorsense} ft.");
            }

            if (creature.Truesight > 0)
            {
                sensesList.Add($"Truesight {creature.Truesight} ft.");
            }

            sensesList.Add($"Passive Perception {creature.PassivePerception}");
            builder.AppendLine($"Senses {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(creature.Languages))
            {
                builder.AppendLine($"Languages {creature.Languages}");
            }

            builder.AppendLine($"Challenge {CreatureHelper.ConvertChallengeRatingToString(creature.ChallengeRating)} ({CreatureHelper.CalculateExperiencePoints(creature.ChallengeRating)} XP)");
            builder.AppendLine($"Proficiency Bonus {CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateProficiencyBonus(creature.ChallengeRating))}");
            if (creature.SpecialAbilities != null && creature.SpecialAbilities.Count > 0)
            {
                foreach (SpecialAbility specialAbility in creature.SpecialAbilities)
                {
                    builder.AppendLine($"{specialAbility.Name}. {specialAbility.Description}");
                }
            }

            if (creature.Actions != null && creature.Actions.Count > 0)
            {
                builder.AppendLine("Actions");
                foreach (Action action in creature.Actions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            if (creature.LegendaryActions != null && creature.LegendaryActions.Count > 0)
            {
                builder.AppendLine("Legendary Actions");
                builder.AppendLine($"{creature.LegendaryActionDescription}");
                foreach (LegendaryAction action in creature.LegendaryActions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            return builder.ToString();
        }
    }
}