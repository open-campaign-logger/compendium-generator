// <copyright file="TomeOfBeasts3Creature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.TomeOfBeasts3
{
    using CampaignKit.Compendium.DungeonsAndDragons.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a creature from the Tome of Beasts 3, extending from the base class KoboldPressCreature.
    /// </summary>
    public class TomeOfBeasts3Creature : TomeOfBeasts.TomeOfBeastsCreature
    {
        /// <summary>
        /// Gets or sets the list of bonus actions associated with this object.
        /// </summary>
        /// <returns>The list of bonus actions associated with this object.</returns>
        [JsonProperty("bonus_actions")]
        public List<Common.Action>? BonusActions { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets the document slug.  The slug (short name used in URLs and similar places) of
        /// the document where the creature is described, deserialized from the 'document__slug'
        /// field in the JSON source.
        /// </summary>
        [JsonProperty("document__slug")]
        public string? DocumentSlug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the document where the creature is described, deserialized
        /// from the 'document__title' field in the JSON source.
        /// </summary>
        [JsonProperty("document__title")]
        public string? DocumentTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the page number in the document where the creature is described,
        /// deserialized from the 'page_no' field in the JSON source.
        /// </summary>
        [JsonProperty("page_no")]
        public int? PageNumber { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the skills the creature possesses, deserialized from the 'skills' field in
        /// the JSON source.
        /// </summary>
        [JsonProperty("skills")]
        public Skills Skills { get; set; } = new Skills();

        /// <summary>
        /// Gets or sets the unique identifier for the creature, deserialized from the 'slug' field
        /// in the JSON source.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's movement speeds, deserialized from the 'speed' field in the JSON source.
        /// </summary>
        [JsonProperty("speed")]
        public new Common.SpeedJson Speed { get; set; } = new Common.SpeedJson();

        /// <summary>
        /// Gets or sets the creature's movement speeds in a more detailed format, deserialized from
        /// the 'speed_json' field in the JSON source.
        /// </summary>
        [JsonProperty("speed_json")]
        public new Common.SpeedJson SpeedJson { get; set; } = new Common.SpeedJson();

        /// <summary>
        /// Creates a generic Creature object populated with values from this KoboldPressCreature object.
        /// </summary>
        /// <returns>Generic Creature object populated with values from this KoboldPressCreature object.</returns>
        public new Creature ToCreature()
        {
            var creature = new Creature()
            {
                Name = this.Name ?? string.Empty,
                Size = this.Size ?? string.Empty,
                Type = this.Type ?? string.Empty,
                Alignment = this.Alignment ?? string.Empty,
                ArmorClass = int.Parse(this.ArmorClass ?? "0"),
                ArmorDesc = this.ArmorDesc ?? string.Empty,
                HitPoints = int.Parse(this.HitPoints ?? "0"),
                HitDice = this.HitDice ?? string.Empty,
                Walk = this.SpeedJson?.Walk ?? 0,
                Swim = this.SpeedJson?.Swim ?? 0,
                Fly = this.SpeedJson?.Fly ?? 0,
                Burrow = this.SpeedJson?.Burrow ?? 0,
                Climb = this.SpeedJson?.Climb ?? 0,
                Hover = this.SpeedJson?.Hover ?? false,
                LightWalking = this.SpeedJson?.Lightwalking ?? 0,
                Strength = int.Parse(this.Strength ?? "0"),
                Dexterity = int.Parse(this.Dexterity ?? "0"),
                Constitution = int.Parse(this.Constitution ?? "0"),
                Intelligence = int.Parse(this.Intelligence ?? "0"),
                Wisdom = int.Parse(this.Wisdom ?? "0"),
                Charisma = int.Parse(this.Charisma ?? "0"),
                StrengthSave = this.StrengthSave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Strength ?? "0")),
                DexteritySave = this.DexteritySave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                ConstitutionSave = this.ConstitutionSave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Constitution ?? "0")),
                IntelligenceSave = this.IntelligenceSave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                WisdomSave = this.WisdomSave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                CharismaSave = this.CharismaSave ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                DamageImmunities = this.DamageImmunities ?? string.Empty,
                DamageResistances = this.DamageResistances ?? string.Empty,
                DamageVulnerabilities = this.DamageVulnerabilities ?? string.Empty,
                ConditionImmunities = this.ConditionImmunities ?? string.Empty,
                Languages = this.Languages ?? string.Empty,
                PassivePerception = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "passive perception") ?? 0,
                Darkvision = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "darkvision") ?? 0,
                Blindsight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "blindsight") ?? 0,
                Tremorsense = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "tremorsense") ?? 0,
                Truesight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "truesight") ?? 0,
                ChallengeRating = CreatureHelper.ConvertChallengeRatingToDouble(this.ChallengeRating ?? string.Empty) ?? 0.0,
                Acrobatics = this.Skills.Acrobatics ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                AnimalHandling = this.Skills.AnimalHandling ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Arcana = this.Skills.Arcana ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Athletics = this.Skills.Athletics ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Strength ?? "0")),
                Deception = this.Skills.Deception ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                History = this.Skills.History ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Insight = this.Skills.Insight ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Intimidation = this.Skills.Intimidation ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Investigation = this.Skills.Investigation ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Medicine = this.Skills.Medicine ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Nature = this.Skills.Nature ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Perception = this.Skills.Perception ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Performance = this.Skills.Performance ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Persuasion = this.Skills.Persuasion ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Religion = this.Skills.Religion ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                SleightOfHand = this.Skills.SleightOfHand ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                Stealth = this.Skills.Stealth ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                Survival = this.Skills.Survival ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
            };

            // Populate Special Abilities
            if (this.SpecialAbilities != null)
            {
                foreach (var specialAbility in this.SpecialAbilities)
                {
                    creature.SpecialAbilities ??= new List<Action> { };
                    creature.SpecialAbilities.Add(new Action()
                    {
                        Name = specialAbility.Name ?? string.Empty,
                        Description = specialAbility.Description ?? string.Empty,
                    });
                }
            }

            // Populate Actions
            if (this.Actions != null)
            {
                foreach (var action in this.Actions)
                {
                    creature.Actions ??= new List<Action> { };
                    creature.Actions.Add(new Action()
                    {
                        Name = action.Name ?? string.Empty,
                        Description = action.Description ?? string.Empty,
                    });
                }
            }

            // Populate Reactions
            if (this.Reactions != null)
            {
                foreach (var reaction in this.Reactions)
                {
                    creature.Reactions ??= new List<Action> { };
                    creature.Reactions.Add(new Action()
                    {
                        Name = reaction.Name ?? string.Empty,
                        Description = reaction.Description ?? string.Empty,
                    });
                }
            }

            // Populate LegendaryActions
            if (this.LegendaryActions != null)
            {
                creature.LegendaryActionDescription = this.LegendaryDesc ?? string.Empty;
                foreach (var legendaryAction in this.LegendaryActions)
                {
                    creature.LegendaryActions ??= new List<Action> { };
                    creature.LegendaryActions.Add(new Action()
                    {
                        Name = legendaryAction.Name ?? string.Empty,
                        Description = legendaryAction.Description ?? string.Empty,
                    });
                }
            }

            // Populate License
            creature.License = this.License;

            return creature;
        }
    }
}
