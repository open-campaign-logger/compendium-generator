// <copyright file="Creature.cs" company="Jochen Linnemann - IT-Service">
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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to represent a creature.
    /// </summary>
    public class Creature : IGameComponent
    {
        /// <summary>
        /// Gets or sets acrobatics skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Acrobatics { get; set; } = 0;

        /// <summary>
        /// Gets or sets a collection of actions associated with the creature.
        /// </summary>
        public List<Action>? Actions { get; set; } = new List<Action> { };

        /// <summary>
        /// Gets or sets alignment of the creature.  Example: lawful evil.
        /// </summary>
        public string? Alignment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets animal Handling skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? AnimalHandling { get; set; } = 0;

        /// <summary>
        /// Gets or sets arcana skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Arcana { get; set; } = 0;

        /// <summary>
        /// Gets or sets armor class of the creature.  Example: 17.
        /// </summary>
        public int? ArmorClass { get; set; } = 0;

        /// <summary>
        /// Gets or sets type of armor worn by the creature.  Example: natural armor.
        /// </summary>
        public string? ArmorDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets athletics skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Athletics { get; set; } = 0;

        /// <summary>
        /// Gets or sets the SourceDataLicense object.
        /// </summary>
        /// <returns>The SourceDataLicense object.</returns>
        public string? Attribution { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with blindsight.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int? Blindsight { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int? Burrow { get; set; } = 0;

        /// <summary>
        /// Gets or sets the challenge rating of th creature.  Fractional CRs should be expressed as a decimal.  Example: 10.
        /// </summary>
        public double ChallengeRating { get; set; } = 0.0;

        /// <summary>
        /// Gets or sets charisma of the creature.  Example: 18.
        /// </summary>
        public int? Charisma { get; set; } = 0;

        /// <summary>
        /// Gets or sets charisma saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int? CharismaSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int? Climb { get; set; } = 0;

        /// <summary>
        /// Gets or sets creature data formatted in standard CL format.
        /// </summary>
        [JsonIgnore]
        public string? CLStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets condition immunities belonging to the creature.  Example: Charmed, Exhaustion, Frightened, Paralyzed, Petrified, Poisoned.
        /// </summary>
        public string? ConditionImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets constitution of the creature.  Example: 15.
        /// </summary>
        public int? Constitution { get; set; } = 0;

        /// <summary>
        /// Gets or sets constitution saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 15.
        /// </summary>
        public int? ConstitutionSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets damage immunities belonging to the creature.  Example: Poison, Psychic; Bludgeoning, Piercing, and Slashing From Nonmagical Attacks That Aren't Adamantine.
        /// </summary>
        public string? DamageImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets damage resistances belonging to the creature.  Example: Fire.
        /// </summary>
        public string? DamageResistances { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets damage vulnerabilities belonging to the creature.  Example: Thunder.
        /// </summary>
        public string? DamageVulnerabilities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with darkvision.
        /// Leave 0 if not specified.
        /// Example 120.
        /// </summary>
        public int? Darkvision { get; set; } = 0;

        /// <summary>
        /// Gets or sets deception skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Deception { get; set; } = 0;

        /// <summary>
        /// Gets or sets dexterity of the creature.  Example: 9.
        /// </summary>
        public int? Dexterity { get; set; } = 0;

        /// <summary>
        /// Gets or sets dexterity saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int? DexteritySave { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 0.
        /// </summary>
        public int? Fly { get; set; } = 0;

        /// <summary>
        /// Gets or sets history skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? History { get; set; } = 0;

        /// <summary>
        /// Gets or sets hit dice calculation for the creature.  Example 18d10+36.
        /// </summary>
        public string? HitDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets average hit points of the creature.  Example 135.
        /// </summary>
        public int? HitPoints { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether ability of the creature to hover.  Example: false.
        /// </summary>
        public bool? Hover { get; set; } = false;

        /// <summary>
        /// Gets or sets insight skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Insight { get; set; } = 0;

        /// <summary>
        /// Gets or sets intelligence of the creature.  Example: 18.
        /// </summary>
        public int? Intelligence { get; set; } = 0;

        /// <summary>
        /// Gets or sets intelligence saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 8.
        /// </summary>
        public int? IntelligenceSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets intimidation skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Intimidation { get; set; } = 0;

        /// <summary>
        /// Gets or sets investigation skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Investigation { get; set; } = 0;

        /// <summary>
        /// Gets or sets creature data formatted in JSON format.
        /// </summary>
        [JsonIgnore]
        public string? JSONStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the campaign labels associated with this creature.
        /// </summary>
        public List<string>? Labels { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets languages the creature is able to speak or understand.  Example Deep Speech, telepathy 120 ft.
        /// </summary>
        public string? Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets legendary action description.
        /// </summary>
        public string? LegendaryActionDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of legendary actions associated with the creature.
        /// </summary>
        public List<Common.Action>? LegendaryActions { get; set; } = new List<Common.Action> { };

        /// <summary>
        /// Gets or sets light walking capability of the creature to hover.  Example: 80.
        /// </summary>
        public int? LightWalking { get; set; } = 0;

        /// <summary>
        /// Gets or sets medicine skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Medicine { get; set; } = 0;

        /// <summary>
        /// Gets or sets name of the creature.  Example: Aboleth.
        /// </summary>
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets nature skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Nature { get; set; } = 0;

        /// <summary>
        /// Gets or sets passive perception is calculated as 10+all modifiers that would apply to a rolled
        /// perception check for that character (such as the wisdom modifier and proficiency bonus).
        /// </summary>
        public int? PassivePerception { get; set; } = 0;

        /// <summary>
        /// Gets or sets perception skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Perception { get; set; } = 0;

        /// <summary>
        /// Gets or sets performance skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Performance { get; set; } = 0;

        /// <summary>
        /// Gets or sets persuasion skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Persuasion { get; set; } = 0;

        /// <summary>
        /// Gets or sets a collection of reactions associated with the creature.
        /// </summary>
        public List<Common.Action>? Reactions { get; set; } = new List<Common.Action> { };

        /// <summary>
        /// Gets or sets religion skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Religion { get; set; } = 0;

        /// <summary>
        /// Gets or sets size of the creature.  Example: Large.
        /// </summary>
        public string? Size { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets sleight of hand skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? SleightOfHand { get; set; } = 0;

        /// <inheritdoc/>
        public string? SourceTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of special abilities associated with the creature.
        /// </summary>
        public List<Common.Action>? SpecialAbilities { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets stealth skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Stealth { get; set; } = 0;

        /// <summary>
        /// Gets or sets strength of the creature.  Example: 21.
        /// </summary>
        public int? Strength { get; set; } = 0;

        /// <summary>
        /// Gets or sets strength saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 0.
        /// </summary>
        public int? StrengthSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets survival skill bonus.
        /// Leave zero if creature does not have the skill specified.
        /// Example: 0.
        /// </summary>
        public int? Survival { get; set; } = 0;

        /// <summary>
        /// Gets or sets swimming speed of the creature in feet per round.  Example 40.
        /// </summary>
        public int? Swim { get; set; } = 0;

        /// <summary>
        /// Gets or sets the campaign tag symbol to use for this creature.
        /// </summary>
        public string? TagSymbol { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? TagValuePrefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets creature data formatted in standard text format.
        /// </summary>
        [JsonIgnore]
        public string? TextStatBlock { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets distance in feet that the creature can feel with tremorsense.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int? Tremorsense { get; set; } = 0;

        /// <summary>
        /// Gets or sets distance in feet that the creature can see with truesight.
        /// Leave 0 if not specified.
        /// Example 0.
        /// </summary>
        public int? Truesight { get; set; } = 0;

        /// <summary>
        /// Gets or sets type of the creature.  Example: aberration.
        /// </summary>
        public string? Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets walking speed of the creature in feet per round.  Example 10.
        /// </summary>
        public int? Walk { get; set; } = 0;

        /// <summary>
        /// Gets or sets wisdom of the creature.  Example: 15.
        /// </summary>
        public int? Wisdom { get; set; } = 0;

        /// <summary>
        /// Gets or sets wisdom saving throw of the creature.
        /// Leave zero if creature does not have the saving throw specified.
        /// Example: 6.
        /// </summary>
        public int? WisdomSave { get; set; } = 0;

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
            hash = (hash * 7) + (this.Name ?? string.Empty).ToLower().GetHashCode();
            hash = (hash * 7) + (this.Size ?? string.Empty).ToLower().GetHashCode();
            hash = (hash * 7) + (this.Type ?? string.Empty).ToLower().GetHashCode();
            return hash;
        }

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            CampaignEntry campaignEntry = new ()
            {
                RawText = this.ToCampaignLoggerStatBlock(),
                RawPublic = string.Empty,
                Labels = this.Labels ?? new List<string>(),
                TagSymbol = this.TagSymbol,
                TagValue = $"{this.TagValuePrefix}{this.Name}",
            };

            if (this.Type != null)
            {
                campaignEntry.Labels.Add(this.Type);
            }

            return campaignEntry;
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
            if (!string.IsNullOrEmpty(this.ArmorDesc))
            {
                builder.AppendLine($"- Armor Class: {this.ArmorClass} ({this.ArmorDesc})");
            }
            else
            {
                builder.AppendLine($"- Armor Class: {this.ArmorClass}");
            }

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
                speeds.Add($"Fly {this.Fly} ft." + ((this.Hover ?? false) ? " (hover)" : string.Empty));
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
            builder.AppendLine($"     STR: {this.Strength} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Strength))})");
            builder.AppendLine($"     DEX: {this.Dexterity} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Dexterity))})");
            builder.AppendLine($"     CON: {this.Constitution} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Constitution))})");
            builder.AppendLine($"     INT: {this.Intelligence} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Intelligence))})");
            builder.AppendLine($"     WIS: {this.Wisdom} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Wisdom))})");
            builder.AppendLine($"     CHA: {this.Charisma} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Charisma))})");
            List<string> savingThrows = new ();
            if (this.StrengthSave > CreatureHelper.CalculateAbilityBonus(this.Strength))
            {
                savingThrows.Add($"STR {CreatureHelper.ConvertBonusToSignedString(this.StrengthSave ?? 0)}");
            }

            if (this.DexteritySave > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                savingThrows.Add($"DEX {CreatureHelper.ConvertBonusToSignedString(this.DexteritySave ?? 0)}");
            }

            if (this.ConstitutionSave > CreatureHelper.CalculateAbilityBonus(this.Constitution))
            {
                savingThrows.Add($"CON {CreatureHelper.ConvertBonusToSignedString(this.ConstitutionSave ?? 0)}");
            }

            if (this.IntelligenceSave > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                savingThrows.Add($"INT {CreatureHelper.ConvertBonusToSignedString(this.IntelligenceSave ?? 0)}");
            }

            if (this.WisdomSave > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                savingThrows.Add($"WIS {CreatureHelper.ConvertBonusToSignedString(this.WisdomSave ?? 0)}");
            }

            if (this.CharismaSave > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                savingThrows.Add($"CHA {CreatureHelper.ConvertBonusToSignedString(this.CharismaSave ?? 0)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"- Saving Throws: {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new ();
            if (this.Acrobatics > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Acrobatics {CreatureHelper.ConvertBonusToSignedString(this.Acrobatics ?? 0)}");
            }

            if (this.AnimalHandling > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Animal Handling {CreatureHelper.ConvertBonusToSignedString(this.AnimalHandling ?? 0)}");
            }

            if (this.Arcana > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Arcana {CreatureHelper.ConvertBonusToSignedString(this.Arcana ?? 0)}");
            }

            if (this.Athletics > CreatureHelper.CalculateAbilityBonus(this.Strength))
            {
                skillsList.Add($"Athletics {CreatureHelper.ConvertBonusToSignedString(this.Athletics ?? 0)}");
            }

            if (this.Deception > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Deception {CreatureHelper.ConvertBonusToSignedString(this.Deception ?? 0)}");
            }

            if (this.History > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"History {CreatureHelper.ConvertBonusToSignedString(this.History ?? 0)}");
            }

            if (this.Insight > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Insight {CreatureHelper.ConvertBonusToSignedString(this.Insight ?? 0)}");
            }

            if (this.Intimidation > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Intimidation {CreatureHelper.ConvertBonusToSignedString(this.Intimidation ?? 0)}");
            }

            if (this.Investigation > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Investigation {CreatureHelper.ConvertBonusToSignedString(this.Investigation ?? 0)}");
            }

            if (this.Medicine > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Medicine {CreatureHelper.ConvertBonusToSignedString(this.Medicine ?? 0)}");
            }

            if (this.Nature > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Nature {CreatureHelper.ConvertBonusToSignedString(this.Nature ?? 0)}");
            }

            if (this.Perception > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Perception {CreatureHelper.ConvertBonusToSignedString(this.Perception ?? 0)}");
            }

            if (this.Performance > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Performance {CreatureHelper.ConvertBonusToSignedString(this.Performance ?? 0)}");
            }

            if (this.Persuasion > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Persuasion {CreatureHelper.ConvertBonusToSignedString(this.Persuasion ?? 0)}");
            }

            if (this.Religion > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Religion {CreatureHelper.ConvertBonusToSignedString(this.Religion ?? 0)}");
            }

            if (this.SleightOfHand > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {CreatureHelper.ConvertBonusToSignedString(this.SleightOfHand ?? 0)}");
            }

            if (this.Stealth > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Stealth {CreatureHelper.ConvertBonusToSignedString(this.Stealth ?? 0)}");
            }

            if (this.Survival > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Survival {CreatureHelper.ConvertBonusToSignedString(this.Survival ?? 0)}");
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

            builder.AppendLine($"- Challenge: {CreatureHelper.ConvertChallengeRatingToString(this.ChallengeRating)} ({CreatureHelper.CalculateExperiencePoints(this.ChallengeRating)} XP)");
            builder.AppendLine($"- Proficiency Bonus: {CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateProficiencyBonus(this.ChallengeRating))}");
            if (this.SpecialAbilities != null && this.SpecialAbilities.Count > 0)
            {
                builder.AppendLine("traits:");
                foreach (Common.Action specialAbility in this.SpecialAbilities)
                {
                    builder.AppendLine($"- {specialAbility.Name}: >");
                    foreach (string line in (specialAbility.Description ?? string.Empty).Split("\n"))
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
                foreach (Common.Action action in this.Actions)
                {
                    builder.AppendLine($"- {action.Name}: >");
                    foreach (string line in (action.Description ?? string.Empty).Split("\n"))
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
                foreach (Common.Action reaction in this.Reactions)
                {
                    builder.AppendLine($"- {reaction.Name}: >");
                    foreach (string line in (reaction.Description ?? string.Empty).Split("\n"))
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
                foreach (Common.Action legendaryAction in this.LegendaryActions)
                {
                    builder.AppendLine($"-  {legendaryAction.Name}: >");
                    foreach (string line in (legendaryAction.Description ?? string.Empty).Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }

            builder.AppendLine($"```");

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                builder.AppendLine();
                builder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            return builder.ToString().Replace("\t", "     ");
        }

        /// <summary>
        /// Exports a simple textual description of this creature.
        /// </summary>
        /// <returns>string representation of creature.</returns>
        public override string ToString()
        {
            return $"LicenseName: {this.Name}, Size: {this.Size}, Type: {this.Type}";
        }

        /// <summary>
        /// Creates a text statblock for the this creature.
        /// </summary>
        /// <returns>Standard text statblock for the this creature..</returns>
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
                speeds.Add($"Fly {this.Fly} ft." + ((this.Hover ?? false) ? " (hover)" : string.Empty));
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
            builder.AppendLine($"STR {this.Strength} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Strength))})");
            builder.AppendLine($"DEX {this.Dexterity} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Dexterity))})");
            builder.AppendLine($"CON {this.Constitution} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Constitution))})");
            builder.AppendLine($"INT {this.Intelligence} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Intelligence))})");
            builder.AppendLine($"WIS {this.Wisdom} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Wisdom))})");
            builder.AppendLine($"CHA {this.Charisma} ({CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateAbilityBonus(this.Charisma))})");
            List<string> savingThrows = new ();
            if (this.StrengthSave > CreatureHelper.CalculateAbilityBonus(this.Strength))
            {
                savingThrows.Add($"STR {CreatureHelper.ConvertBonusToSignedString(this.StrengthSave ?? 0)}");
            }

            if (this.DexteritySave > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                savingThrows.Add($"DEX {CreatureHelper.ConvertBonusToSignedString(this.DexteritySave ?? 0)}");
            }

            if (this.ConstitutionSave > CreatureHelper.CalculateAbilityBonus(this.Constitution))
            {
                savingThrows.Add($"CON {CreatureHelper.ConvertBonusToSignedString(this.ConstitutionSave ?? 0)}");
            }

            if (this.IntelligenceSave > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                savingThrows.Add($"INT {CreatureHelper.ConvertBonusToSignedString(this.IntelligenceSave ?? 0)}");
            }

            if (this.WisdomSave > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                savingThrows.Add($"WIS {CreatureHelper.ConvertBonusToSignedString(this.WisdomSave ?? 0)}");
            }

            if (this.CharismaSave > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                savingThrows.Add($"CHA {CreatureHelper.ConvertBonusToSignedString(this.CharismaSave ?? 0)}");
            }

            if (savingThrows.Count > 0)
            {
                builder.AppendLine($"Saving Throws {string.Join(", ", savingThrows)}");
            }

            List<string> skillsList = new ();
            if (this.Acrobatics > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Acrobatics {CreatureHelper.ConvertBonusToSignedString(this.Acrobatics ?? 0)}");
            }

            if (this.AnimalHandling > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Animal Handling {CreatureHelper.ConvertBonusToSignedString(this.AnimalHandling ?? 0)}");
            }

            if (this.Arcana > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Arcana {CreatureHelper.ConvertBonusToSignedString(this.Arcana ?? 0)}");
            }

            if (this.Athletics > CreatureHelper.CalculateAbilityBonus(this.Strength))
            {
                skillsList.Add($"Athletics {CreatureHelper.ConvertBonusToSignedString(this.Athletics ?? 0)}");
            }

            if (this.Deception > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Deception {CreatureHelper.ConvertBonusToSignedString(this.Deception ?? 0)}");
            }

            if (this.History > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"History {CreatureHelper.ConvertBonusToSignedString(this.History ?? 0)}");
            }

            if (this.Insight > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Insight {CreatureHelper.ConvertBonusToSignedString(this.Insight ?? 0)}");
            }

            if (this.Intimidation > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Intimidation {CreatureHelper.ConvertBonusToSignedString(this.Intimidation ?? 0)}");
            }

            if (this.Investigation > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Investigation {CreatureHelper.ConvertBonusToSignedString(this.Investigation ?? 0)}");
            }

            if (this.Medicine > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Medicine {CreatureHelper.ConvertBonusToSignedString(this.Medicine ?? 0)}");
            }

            if (this.Nature > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Nature {CreatureHelper.ConvertBonusToSignedString(this.Nature ?? 0)}");
            }

            if (this.Perception > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Perception {CreatureHelper.ConvertBonusToSignedString(this.Perception ?? 0)}");
            }

            if (this.Performance > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Performance {CreatureHelper.ConvertBonusToSignedString(this.Performance ?? 0)}");
            }

            if (this.Persuasion > CreatureHelper.CalculateAbilityBonus(this.Charisma))
            {
                skillsList.Add($"Persuasion {CreatureHelper.ConvertBonusToSignedString(this.Persuasion ?? 0)}");
            }

            if (this.Religion > CreatureHelper.CalculateAbilityBonus(this.Intelligence))
            {
                skillsList.Add($"Religion {CreatureHelper.ConvertBonusToSignedString(this.Religion ?? 0)}");
            }

            if (this.SleightOfHand > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Sleight of Hand {CreatureHelper.ConvertBonusToSignedString(this.SleightOfHand ?? 0)}");
            }

            if (this.Stealth > CreatureHelper.CalculateAbilityBonus(this.Dexterity))
            {
                skillsList.Add($"Stealth {CreatureHelper.ConvertBonusToSignedString(this.Stealth ?? 0)}");
            }

            if (this.Survival > CreatureHelper.CalculateAbilityBonus(this.Wisdom))
            {
                skillsList.Add($"Survival {CreatureHelper.ConvertBonusToSignedString(this.Survival ?? 0)}");
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

            builder.AppendLine($"Challenge {CreatureHelper.ConvertChallengeRatingToString(this.ChallengeRating)} ({CreatureHelper.CalculateExperiencePoints(this.ChallengeRating)} XP)");
            builder.AppendLine($"Proficiency Bonus {CreatureHelper.ConvertBonusToSignedString(CreatureHelper.CalculateProficiencyBonus(this.ChallengeRating))}");
            if (this.SpecialAbilities != null && this.SpecialAbilities.Count > 0)
            {
                foreach (Common.Action specialAbility in this.SpecialAbilities)
                {
                    builder.AppendLine($"{specialAbility.Name}. {specialAbility.Description}");
                }
            }

            if (this.Actions != null && this.Actions.Count > 0)
            {
                builder.AppendLine("Actions");
                foreach (Action action in this.Actions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            if (this.LegendaryActions != null && this.LegendaryActions.Count > 0)
            {
                builder.AppendLine("Legendary Actions");
                builder.AppendLine($"{this.LegendaryActionDescription}");
                foreach (Common.Action action in this.LegendaryActions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }

            // Add Attribution
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                builder.AppendLine();
                builder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
            }

            return builder.ToString();
        }
    }
}
