// <copyright file="Creature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Models.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to represent a creature.
    /// </summary>
    public class Creature
    {
        // ************************************************************* //
        // ************************************************************* //
        //                  Part II - Tombstone Info
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Gets or sets acrobatics skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Acrobatics { get; set; } = 0;

        /// <summary>
        /// Gets or sets a collection of actions associated with the creature.
        /// </summary>
        public List<CreatureAction> Actions { get; set; } = new List<CreatureAction> { };

        /// <summary>
        /// Gets or sets alignment of the creature.  Example: lawful evil.
        /// </summary>
        public string Alignment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets animal Handling skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int AnimalHandling { get; set; } = 0;

        /// <summary>
        /// Gets or sets arcana skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Arcana { get; set; } = 0;

        /// <summary>
        /// Gets or sets armor class of the creature.  Example: 17.
        /// </summary>
        public int ArmorClass { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part III - AC, HP, Speed
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Gets or sets type of armor worn by the creature.  Example: natural armor.
        /// </summary>
        public string ArmorDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets athletics skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Athletics { get; set; } = 0;

        /// <summary>
        /// Gets or sets author of the creature data.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with blindsight.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int Blindsight { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int Burrow { get; set; } = 0;

        /// <summary>
        /// Gets or sets the challenge rating of th creature.  Fractional CRs should be expressed as a decimal.  Example: 10.
        /// </summary>
        public double ChallengeRating { get; set; } = 0.0;

        /// <summary>
        /// Gets or sets charisma of the creature.  Example: 18.
        /// </summary>
        public int Charisma { get; set; } = 0;

        /// <summary>
        /// Gets or sets charisma saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int CharismaSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int Climb { get; set; } = 0;

        /// <summary>
        /// Gets or sets creature data formatted in standard CL format.
        /// </summary>
        [JsonIgnore]
        public string CLStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets condition immunities belonging to the creature.  Example: Charmed, Exhaustion, Frightened, Paralyzed, Petrified, Poisoned.
        /// </summary>
        public string ConditionImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets constitution of the creature.  Example: 15.
        /// </summary>
        public int Constitution { get; set; } = 0;

        /// <summary>
        /// Gets or sets constitution saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 15.
        /// </summary>
        public int ConstitutionSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets copyright associated with the creature data.
        /// </summary>
        public string Copyright { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets damage immunities belonging to the creature.  Example: Poison, Psychic; Bludgeoning, Piercing, and Slashing From Nonmagical Attacks That Aren't Adamantine.
        /// </summary>
        public string DamageImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets damage resistances belonging to the creature.  Example: Fire.
        /// </summary>
        public string DamageResistances { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets damage vulnerabilities belonging to the creature.  Example: Thunder.
        /// </summary>
        public string DamageVulnerabilities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with darkvision.
        /// Leave 0 if not specified.
        /// Example 120.
        /// </summary>
        public int Darkvision { get; set; } = 0;

        /// <summary>
        /// Gets or sets deception skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Deception { get; set; } = 0;

        /// <summary>
        /// Gets or sets dexterity of the creature.  Example: 9.
        /// </summary>
        public int Dexterity { get; set; } = 0;

        /// <summary>
        /// Gets or sets dexterity saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int DexteritySave { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int Fly { get; set; } = 0;

        /// <summary>
        /// Gets or sets history skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int History { get; set; } = 0;

        /// <summary>
        /// Gets or sets hit dice calculation for the creature.  Example 18d10+36.
        /// </summary>
        public string HitDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets average hit points of the creature.  Example 135.
        /// </summary>
        public int HitPoints { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether ability of the creature to hover.  Example: false.
        /// </summary>
        public bool Hover { get; set; } = false;

        /// <summary>
        /// Gets or sets primary key for creature.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets insight skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Insight { get; set; } = 0;

        /// <summary>
        /// Gets or sets intelligence of the creature.  Example: 18.
        /// </summary>
        public int Intelligence { get; set; } = 0;

        /// <summary>
        /// Gets or sets intelligence saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 8.
        /// </summary>
        public int IntelligenceSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets intimidation skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Intimidation { get; set; } = 0;

        /// <summary>
        /// Gets or sets investigation skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Investigation { get; set; } = 0;

        /// <summary>
        /// Gets or sets creature data formatted in JSON format.
        /// </summary>
        [JsonIgnore]
        public string JSONStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets languages the creature is able to speak or understand.  Example Deep Speech, telepathy 120 ft.
        /// </summary>
        public string Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets legendary action description.
        /// </summary>
        public string LegendaryActionDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of legendary actions associated with the creature.
        /// </summary>
        public List<CreatureLegendaryAction> LegendaryActions { get; set; } = new List<CreatureLegendaryAction> { };

        /// <summary>
        /// Gets or sets name of the license associated with the creature data.
        /// </summary>
        public string LicenseName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets license URL associated with the creature data.
        /// </summary>
        public string LicenseURL { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets light walking capability of the creature to hover.  Example: 80.
        /// </summary>
        public int LightWalking { get; set; } = 0;

        /// <summary>
        /// Gets or sets medicine skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Medicine { get; set; } = 0;

        /// <summary>
        /// Gets or sets name of the creature.  Example: Aboleth.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets nature skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Nature { get; set; } = 0;

        /// <summary>
        /// Gets or sets organization owning the content.
        /// </summary>
        public string Organization { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets passive perception is calculated as 10+all modifiers that would apply to a rolled
        /// perception check for that character (such as the wisdom modifier and proficiency bonus).
        /// </summary>
        public int PassivePerception { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //      Part VI - Resistances, Vulnerabilities, and Immunities
        // ************************************************************* //
        // ************************************************************* //

        // ************************************************************* //
        // ************************************************************* //
        //                    Part VII - Skills
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Gets or sets perception skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Perception { get; set; } = 0;

        /// <summary>
        /// Gets or sets performance skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Performance { get; set; } = 0;

        /// <summary>
        /// Gets or sets persuasion skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Persuasion { get; set; } = 0;

        /// <summary>
        /// Gets or sets a collection of reactions associated with the creature.
        /// </summary>
        public List<CreatureReaction> Reactions { get; set; } = new List<CreatureReaction> { };

        /// <summary>
        /// Gets or sets religion skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Religion { get; set; } = 0;

        /// <summary>
        /// Gets or sets rule system associated with the creature data.
        /// </summary>
        public string RuleSystem { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets size of the creature.  Example: Large.
        /// </summary>
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets sleight of hand skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int SleightOfHand { get; set; } = 0;

        /// <summary>
        /// Gets or sets source document descrition associated with the creature data.
        /// </summary>
        public string SourceDocumentDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets source document of the creature data.
        /// </summary>
        public string SourceDocumentTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets version of the source document associated with the creature data.
        /// </summary>
        public string SourceDocumentVersion { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of special abilities associated with the creature.
        /// </summary>
        public List<CreatureSpecialAbility> SpecialAbilities { get; set; } = new List<CreatureSpecialAbility> { };

        /// <summary>
        /// Gets or sets stealth skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Stealth { get; set; } = 0;

        /// <summary>
        /// Gets or sets strength of the creature.  Example: 21.
        /// </summary>
        public int Strength { get; set; } = 0;

        /// <summary>
        /// Gets or sets strength saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int StrengthSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets survival skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int Survival { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 40.
        /// </summary>
        public int Swim { get; set; } = 0;

        /// <summary>
        /// Gets or sets creature data formatted in standard text format.
        /// </summary>
        [JsonIgnore]
        public string TextStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can feel with tremorsense.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int Tremorsense { get; set; } = 0;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with truesight.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int Truesight { get; set; } = 0;

        /// <summary>
        /// Gets or sets type of the creature.  Example: aberration.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets walking speed of the creature in feet per round.  Example 10.
        /// </summary>
        public int Walk { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part IV - Ability Scores
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Gets or sets wisdom of the creature.  Example: 15.
        /// </summary>
        public int Wisdom { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //           Part V - Saving Throws, Senses, Language,
        //                 Challenge, Proficiency Bonus
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Gets or sets wisdom saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 6.
        /// </summary>
        public int WisdomSave { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part VIII - Utility Methods
        // ************************************************************* //
        // ************************************************************* //

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
            else if (challengeRating == 0.5)
            {
                return "1/2";
            }

            return challengeRating.ToString();
        }

        /// <summary>
        /// Implementation of Equals method.
        /// </summary>
        /// <param name="obj">creature object to compare this to.</param>
        /// <returns>True if objects are equal, false otherwise.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Creature)
            {
                return false;
            }

            Creature other = (Creature)obj;
            return (this.Name ?? string.Empty).Equals(other.Name, StringComparison.OrdinalIgnoreCase)
                && (this.Size ?? string.Empty).Equals(other.Size, StringComparison.OrdinalIgnoreCase)
                && (this.Type ?? string.Empty).Equals(other.Type, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Implementation of GetHashCode method.
        /// </summary>
        /// <returns>int hashcode for this object.</returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Name.ToLower().GetHashCode();
            hash = (hash * 7) + this.Size.ToLower().GetHashCode();
            hash = (hash * 7) + this.Type.ToLower().GetHashCode();
            return hash;
        }

        /// <summary>
        /// Creates a Campaign-Logger statblock for the creature.
        /// </summary>
        /// <returns>Campaign-Logger statblock for the creature.</returns>
        public string ToCampaignLoggerStatBlock()
        {
            StringBuilder builder = new ();
            builder.AppendLine($"```clyt");
            builder.AppendLine($"template: stat-block.5e");
            builder.AppendLine($"title: {this.Name}");
            builder.AppendLine($"description: {this.Size} {this.Type}, {this.Alignment}");
            builder.AppendLine($"stats:");
            builder.AppendLine($"- Armor Class: {this.ArmorClass} ({this.ArmorDesc})");
            builder.AppendLine($"- Hit Points: {this.HitPoints} ({this.HitDice})");
            List<string> speeds = new ()
            {
                $"{this.Walk} ft.",
            };
            if (this.Swim > 0)
            {
                speeds.Add($"Swim {this.Swim} ft.");
            }

            if (this.Fly > 0)
            {
                speeds.Add($"Fly {this.Fly} ft." + (this.Hover ? " (hover)" : string.Empty));
            }

            if (this.Burrow > 0)
            {
                speeds.Add($"Burrow {this.Burrow} ft.");
            }

            if (this.Climb > 0)
            {
                speeds.Add($"Climb {this.Climb} ft.");
            }

            if (this.LightWalking > 0)
            {
                speeds.Add($"Lightwalking {this.LightWalking} ft.");
            }

            builder.AppendLine($"- Speed: {string.Join(", ", speeds)}");
            builder.AppendLine($"- abilities:");
            builder.AppendLine($"     STR: {this.Strength} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Strength))})");
            builder.AppendLine($"     DEX: {this.Dexterity} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Dexterity))})");
            builder.AppendLine($"     CON: {this.Constitution} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Constitution))})");
            builder.AppendLine($"     INT: {this.Intelligence} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Intelligence))})");
            builder.AppendLine($"     WIS: {this.Wisdom} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Wisdom))})");
            builder.AppendLine($"     CHA: {this.Charisma} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Charisma))})");
            List<string> savingThrows = new ();
            if (this.StrengthSave > CalculateAbilityBonus(this.Strength))
            {
                savingThrows.Add($"STR {ConvertBonusToSignedString(this.StrengthSave)}");
            }

            if (this.DexteritySave > CalculateAbilityBonus(this.Dexterity))
            {
                savingThrows.Add($"DEX {ConvertBonusToSignedString(this.DexteritySave)}");
            }

            if (this.ConstitutionSave > CalculateAbilityBonus(this.Constitution))
            {
                savingThrows.Add($"CON {ConvertBonusToSignedString(this.ConstitutionSave)}");
            }

            if (this.IntelligenceSave > CalculateAbilityBonus(this.Intelligence))
            {
                savingThrows.Add($"INT {ConvertBonusToSignedString(this.IntelligenceSave)}");
            }

            if (this.WisdomSave > CalculateAbilityBonus(this.Wisdom))
            {
                savingThrows.Add($"WIS {ConvertBonusToSignedString(this.WisdomSave)}");
            }

            if (this.CharismaSave > CalculateAbilityBonus(this.Charisma))
            {
                savingThrows.Add($"CHA {ConvertBonusToSignedString(this.CharismaSave)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"- Saving Throws: {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new ();
            if (this.Acrobatics > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Acrobatics {ConvertBonusToSignedString(this.Acrobatics)}");
            }

            if (this.AnimalHandling > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Animal Handling {ConvertBonusToSignedString(this.AnimalHandling)}");
            }

            if (this.Arcana > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Arcana {ConvertBonusToSignedString(this.Arcana)}");
            }

            if (this.Athletics > CalculateAbilityBonus(this.Strength))
            {
                skillsList.Add($"Athletics {ConvertBonusToSignedString(this.Athletics)}");
            }

            if (this.Deception > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Deception {ConvertBonusToSignedString(this.Deception)}");
            }

            if (this.History > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"History {ConvertBonusToSignedString(this.History)}");
            }

            if (this.Insight > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Insight {ConvertBonusToSignedString(this.Insight)}");
            }

            if (this.Intimidation > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Intimidation {ConvertBonusToSignedString(this.Intimidation)}");
            }

            if (this.Investigation > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Investigation {ConvertBonusToSignedString(this.Investigation)}");
            }

            if (this.Medicine > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Medicine {ConvertBonusToSignedString(this.Medicine)}");
            }

            if (this.Nature > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Nature {ConvertBonusToSignedString(this.Nature)}");
            }

            if (this.Perception > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Perception {ConvertBonusToSignedString(this.Perception)}");
            }

            if (this.Performance > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Performance {ConvertBonusToSignedString(this.Performance)}");
            }

            if (this.Persuasion > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Persuasion {ConvertBonusToSignedString(this.Persuasion)}");
            }

            if (this.Religion > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Religion {ConvertBonusToSignedString(this.Religion)}");
            }

            if (this.SleightOfHand > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {ConvertBonusToSignedString(this.SleightOfHand)}");
            }

            if (this.Stealth > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Stealth {ConvertBonusToSignedString(this.Stealth)}");
            }

            if (this.Survival > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Survival {ConvertBonusToSignedString(this.Survival)}");
            }

            if (skillsList.Count > 0)
            {
                builder.AppendLine($"- Skills: {string.Join(", ", skillsList)}");
            }

            if (!string.IsNullOrEmpty(this.DamageVulnerabilities))
            {
                builder.AppendLine($"- Damage Vulnerabilities: {this.DamageVulnerabilities}");
            }

            if (!string.IsNullOrEmpty(this.DamageResistances))
            {
                builder.AppendLine($"- Damage Resistances: {this.DamageResistances}");
            }

            if (!string.IsNullOrEmpty(this.DamageImmunities))
            {
                builder.AppendLine($"- Damage Immunities: {this.DamageImmunities}");
            }

            if (!string.IsNullOrEmpty(this.ConditionImmunities))
            {
                builder.AppendLine($"- Condition Immunities: {this.ConditionImmunities}");
            }

            List<string> sensesList = new ();
            if (this.Blindsight > 0)
            {
                sensesList.Add($"Blindsight {this.Blindsight} ft.");
            }

            if (this.Darkvision > 0)
            {
                sensesList.Add($"Darkvision {this.Darkvision} ft.");
            }

            if (this.Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {this.Tremorsense} ft.");
            }

            if (this.Truesight > 0)
            {
                sensesList.Add($"Truesight {this.Truesight} ft.");
            }

            sensesList.Add($"Passive Perception {this.PassivePerception}");
            builder.AppendLine($"- Senses: {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(this.Languages))
            {
                builder.AppendLine($"- Languages: {this.Languages}");
            }

            builder.AppendLine($"- Challenge: {ConvertChallengeRatingToString(this.ChallengeRating)} ({CalculateExperiencePoints(this.ChallengeRating)} XP)");
            builder.AppendLine($"- Proficiency Bonus: {ConvertBonusToSignedString(CalculateProficiencyBonus(this.ChallengeRating))}");
            if (this.SpecialAbilities != null && this.SpecialAbilities.Count > 0)
            {
                builder.AppendLine("traits:");
                foreach (CreatureSpecialAbility specialAbility in this.SpecialAbilities)
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

            if (this.Actions != null && this.Actions.Count > 0)
            {
                builder.AppendLine("actions:");
                foreach (CreatureAction action in this.Actions)
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

            if (this.Reactions != null && this.Reactions.Count > 0)
            {
                builder.AppendLine($"- Reactions: The {this.Name} has the following reactions.");
                foreach (CreatureReaction reaction in this.Reactions)
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

            if (this.LegendaryActions != null && this.LegendaryActions.Count > 0)
            {
                builder.AppendLine($"- Legendary Actions: {this.LegendaryActionDescription}");
                foreach (CreatureLegendaryAction legendaryAction in this.LegendaryActions)
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
        /// Exports a simple textual description of this creature.
        /// </summary>
        /// <returns>string representation of creature.</returns>
        public override string ToString()
        {
            return $"Name: {this.Name}, Size: {this.Size}, Type: {this.Type}";
        }

        /// <summary>
        /// Creates a text statblock for the creature.
        /// </summary>
        /// <returns>Standard text statblock for the creature.</returns>
        public string ToTextStatBlock()
        {
            StringBuilder builder = new ();
            builder.AppendLine($"{this.Name}");
            builder.AppendLine($"{this.Size} {this.Type}, {this.Alignment}");
            builder.AppendLine($"Armor Class {this.ArmorClass} ({this.ArmorDesc})");
            builder.AppendLine($"Hit Points {this.HitPoints} ({this.HitDice})");
            List<string> speeds = new ()
            {
                $"{this.Walk} ft.",
            };
            if (this.Swim > 0)
            {
                speeds.Add($"Swim {this.Swim} ft.");
            }

            if (this.Fly > 0)
            {
                speeds.Add($"Fly {this.Fly} ft." + (this.Hover ? " (hover)" : string.Empty));
            }

            if (this.Burrow > 0)
            {
                speeds.Add($"Burrow {this.Burrow} ft.");
            }

            if (this.Climb > 0)
            {
                speeds.Add($"Climb {this.Climb} ft.");
            }

            if (this.LightWalking > 0)
            {
                speeds.Add($"Lightwalking {this.LightWalking} ft.");
            }

            builder.AppendLine($"Speed {string.Join(", ", speeds)}");
            builder.AppendLine($"STR {this.Strength} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Strength))})");
            builder.AppendLine($"DEX {this.Dexterity} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Dexterity))})");
            builder.AppendLine($"CON {this.Constitution} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Constitution))})");
            builder.AppendLine($"INT {this.Intelligence} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Intelligence))})");
            builder.AppendLine($"WIS {this.Wisdom} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Wisdom))})");
            builder.AppendLine($"CHA {this.Charisma} ({ConvertBonusToSignedString(CalculateAbilityBonus(this.Charisma))})");
            List<string> savingThrows = new ();
            if (this.StrengthSave > CalculateAbilityBonus(this.Strength))
            {
                savingThrows.Add($"STR {ConvertBonusToSignedString(this.StrengthSave)}");
            }

            if (this.DexteritySave > CalculateAbilityBonus(this.Dexterity))
            {
                savingThrows.Add($"DEX {ConvertBonusToSignedString(this.DexteritySave)}");
            }

            if (this.ConstitutionSave > CalculateAbilityBonus(this.Constitution))
            {
                savingThrows.Add($"CON {ConvertBonusToSignedString(this.ConstitutionSave)}");
            }

            if (this.IntelligenceSave > CalculateAbilityBonus(this.Intelligence))
            {
                savingThrows.Add($"INT {ConvertBonusToSignedString(this.IntelligenceSave)}");
            }

            if (this.WisdomSave > CalculateAbilityBonus(this.Wisdom))
            {
                savingThrows.Add($"WIS {ConvertBonusToSignedString(this.WisdomSave)}");
            }

            if (this.CharismaSave > CalculateAbilityBonus(this.Charisma))
            {
                savingThrows.Add($"CHA {ConvertBonusToSignedString(this.CharismaSave)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"Saving Throws {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new ();
            if (this.Acrobatics > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Acrobatics {ConvertBonusToSignedString(this.Acrobatics)}");
            }

            if (this.AnimalHandling > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Animal Handling {ConvertBonusToSignedString(this.AnimalHandling)}");
            }

            if (this.Arcana > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Arcana {ConvertBonusToSignedString(this.Arcana)}");
            }

            if (this.Athletics > CalculateAbilityBonus(this.Strength))
            {
                skillsList.Add($"Athletics {ConvertBonusToSignedString(this.Athletics)}");
            }

            if (this.Deception > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Deception {ConvertBonusToSignedString(this.Deception)}");
            }

            if (this.History > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"History {ConvertBonusToSignedString(this.History)}");
            }

            if (this.Insight > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Insight {ConvertBonusToSignedString(this.Insight)}");
            }

            if (this.Intimidation > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Intimidation {ConvertBonusToSignedString(this.Intimidation)}");
            }

            if (this.Investigation > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Investigation {ConvertBonusToSignedString(this.Investigation)}");
            }

            if (this.Medicine > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Medicine {ConvertBonusToSignedString(this.Medicine)}");
            }

            if (this.Nature > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Nature {ConvertBonusToSignedString(this.Nature)}");
            }

            if (this.Perception > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Perception {ConvertBonusToSignedString(this.Perception)}");
            }

            if (this.Performance > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Performance {ConvertBonusToSignedString(this.Performance)}");
            }

            if (this.Persuasion > CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Persuasion {ConvertBonusToSignedString(this.Persuasion)}");
            }

            if (this.Religion > CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Religion {ConvertBonusToSignedString(this.Religion)}");
            }

            if (this.SleightOfHand > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {ConvertBonusToSignedString(this.SleightOfHand)}");
            }

            if (this.Stealth > CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Stealth {ConvertBonusToSignedString(this.Stealth)}");
            }

            if (this.Survival > CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Survival {ConvertBonusToSignedString(this.Survival)}");
            }

            if (skillsList.Count > 0)
            {
                builder.AppendLine($"Skills {string.Join(", ", skillsList)}");
            }

            if (!string.IsNullOrEmpty(this.DamageVulnerabilities))
            {
                builder.AppendLine($"Damage Vulnerabilities {this.DamageVulnerabilities}");
            }

            if (!string.IsNullOrEmpty(this.DamageResistances))
            {
                builder.AppendLine($"Damage Resistances {this.DamageResistances}");
            }

            if (!string.IsNullOrEmpty(this.DamageImmunities))
            {
                builder.AppendLine($"Damage Immunities {this.DamageImmunities}");
            }

            if (!string.IsNullOrEmpty(this.ConditionImmunities))
            {
                builder.AppendLine($"Condition Immunities {this.ConditionImmunities}");
            }

            List<string> sensesList = new ();
            if (this.Blindsight > 0)
            {
                sensesList.Add($"Blindsight {this.Blindsight} ft.");
            }

            if (this.Darkvision > 0)
            {
                sensesList.Add($"Darkvision {this.Darkvision} ft.");
            }

            if (this.Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {this.Tremorsense} ft.");
            }

            if (this.Truesight > 0)
            {
                sensesList.Add($"Truesight {this.Truesight} ft.");
            }

            sensesList.Add($"Passive Perception {this.PassivePerception}");
            builder.AppendLine($"Senses {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(this.Languages))
            {
                builder.AppendLine($"Languages {this.Languages}");
            }

            builder.AppendLine($"Challenge {ConvertChallengeRatingToString(this.ChallengeRating)} ({CalculateExperiencePoints(this.ChallengeRating)} XP)");
            builder.AppendLine($"Proficiency Bonus {ConvertBonusToSignedString(CalculateProficiencyBonus(this.ChallengeRating))}");
            if (this.SpecialAbilities != null && this.SpecialAbilities.Count > 0)
            {
                foreach (CreatureSpecialAbility specialAbility in this.SpecialAbilities)
                {
                    builder.AppendLine($"{specialAbility.Name}. {specialAbility.Description}");
                }
            }

            if (this.Actions != null && this.Actions.Count > 0)
            {
                builder.AppendLine("Actions");
                foreach (CreatureAction action in this.Actions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            if (this.LegendaryActions != null && this.LegendaryActions.Count > 0)
            {
                builder.AppendLine("Legendary Actions");
                builder.AppendLine($"{this.LegendaryActionDescription}");
                foreach (CreatureLegendaryAction action in this.LegendaryActions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            return builder.ToString();
        }
    }
}
