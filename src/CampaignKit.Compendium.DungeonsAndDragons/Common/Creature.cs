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

namespace CampaignKit.Compendium.DungeonsAndDragons.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to represent a creature.
    /// </summary>
    public class Creature
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
        /// Gets or sets the license information for the creature data.
        /// </summary>
        public License? License { get; set; } = new License();

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

        /// <summary>
        /// Gets or sets the SourceDataLicense object.
        /// </summary>
        /// <returns>The SourceDataLicense object.</returns>
        public string? Attribution { get; set; } = string.Empty;

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

        /// <summary>
        /// Exports a simple textual description of this creature.
        /// </summary>
        /// <returns>string representation of creature.</returns>
        public override string ToString()
        {
            return $"Name: {this.Name}, Size: {this.Size}, Type: {this.Type}";
        }
    }
}
