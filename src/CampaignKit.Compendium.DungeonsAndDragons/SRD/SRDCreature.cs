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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using CampaignKit.Compendium.Core.CampaignLogger;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.DungeonsAndDragons.Common;

    using Newtonsoft.Json;

    /// <summary>
    /// Class representing a creature from the Dungeons &amp; Dragons System Reference Document (SRD).
    /// </summary>
    public class SRDCreature : IGameComponent
    {
        /// <summary>
        /// Gets or sets the creature's Acrobatics skill, representing its ability to perform tasks
        /// requiring agility and balance.
        /// </summary>
        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the list of actions that the creature can take during a combat round.
        /// </summary>
        [JsonProperty("actions")]
        public List<Action>? Actions { get; set; } = new List<Action>();

        /// <summary>
        /// Gets or sets the alignment of the creature (e.g., chaotic evil, neutral).
        /// </summary>
        [JsonProperty("alignment")]
        public string? Alignment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Animal Handling skill, which is used for calming down,
        /// understanding, or controlling animals.
        /// </summary>
        [JsonProperty("animal_handling")]
        public int? AnimalHandling { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Arcana skill, representing knowledge about magical matters.
        /// </summary>
        [JsonProperty("arcana")]
        public int? Arcana { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Armor Class (AC) of the creature which is the difficulty to hit it with
        /// an attack.
        /// </summary>
        [JsonProperty("armor_class")]
        public int? ArmorClass { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the description of the creature's armor.
        /// </summary>
        [JsonProperty("armor_desc")]
        public string? ArmorDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Athletics skill, which is used for physical activities like
        /// climbing, swimming, or jumping.
        /// </summary>
        [JsonProperty("athletics")]
        public int? Athletics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the challenge rating of the creature, which is a measure of how dangerous
        /// it is.
        /// </summary>
        [JsonProperty("challenge_rating")]
        public string? ChallengeRating { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the charisma attribute of the creature. This might determine how it
        /// interacts with others.
        /// </summary>
        [JsonProperty("charisma")]
        public int? Charisma { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the modifier for the creature's Charisma saving throws, which is used to
        /// resist certain effects that require a force of personality.
        /// </summary>
        [JsonProperty("charisma_save")]
        public int? CharismaSave { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the conditions that the creature is immune to.
        /// </summary>
        [JsonProperty("condition_immunities")]
        public string? ConditionImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Constitution score of the creature, determining its health and stamina.
        /// </summary>
        [JsonProperty("constitution")]
        public int? Constitution { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Constitution saving throw modifier of the creature, which is used to
        /// resist effects like poison or disease.
        /// </summary>
        [JsonProperty("constitution_save")]
        public int? ConstitutionSave { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the types of damage that the creature is immune to.
        /// </summary>
        [JsonProperty("damage_immunities")]
        public string? DamageImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the types of damage that the creature is resistant to.
        /// </summary>
        [JsonProperty("damage_resistances")]
        public string? DamageResistances { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the types of damage that the creature is vulnerable to.
        /// </summary>
        [JsonProperty("damage_vulnerabilities")]
        public string? DamageVulnerabilities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Deception skill, which is used to mislead others.
        /// </summary>
        [JsonProperty("deception")]
        public int? Deception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Dexterity score of the creature, determining its agility, reflexes, and balance.
        /// </summary>
        [JsonProperty("dexterity")]
        public int? Dexterity { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the modifier for the creature's Dexterity saving throws, which is used to
        /// resist or avoid certain effects.
        /// </summary>
        [JsonProperty("dexterity_save")]
        public int? DexteritySave { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the group to which the creature belongs.
        /// </summary>
        [JsonProperty("group")]
        public string? Group { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the History skill modifier of the creature, which is used for recalling
        /// lore or recognizing historical significance.
        /// </summary>
        [JsonProperty("history")]
        public int? History { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the hit dice of the creature which determine its hit points.
        /// </summary>
        [JsonProperty("hit_dice")]
        public string? HitDice { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hit points of the creature which indicate how much damage it can take
        /// before it drops to 0 health.
        /// </summary>
        [JsonProperty("hit_points")]
        public int? HitPoints { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Insight skill, which is used to determine the true
        /// intentions of others.
        /// </summary>
        [JsonProperty("insight")]
        public int? Insight { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Intelligence score of the creature, determining its mental acuity,
        /// information recall, and analytical skill.
        /// </summary>
        [JsonProperty("intelligence")]
        public int? Intelligence { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Intelligence saving throw modifier of the creature, which is used to
        /// resist effects like illusions or certain mental attacks.
        /// </summary>
        [JsonProperty("intelligence_save")]
        public int? IntelligenceSave { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Intimidation skill, representing its ability to instill fear
        /// in others through overt threats, hostile actions, and physical prowess.
        /// </summary>
        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Investigation skill, representing its ability to deduce
        /// information, piece together clues, or notice things that might be hidden or obscured.
        /// </summary>
        [JsonProperty("investigation")]
        public int? Investigation { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the list of labels associated with the creature.
        /// </summary>
        public List<string>? Labels { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the languages that the creature can speak.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of legendary actions that the creature can take.
        /// </summary>
        [JsonProperty("legendary_actions")]
        public List<Common.Action>? LegendaryActions { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets the description of the creature's legendary actions.
        /// </summary>
        [JsonProperty("legendary_desc")]
        public string? LegendaryDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Medicine skill, which might be used for healing.
        /// </summary>
        [JsonProperty("medicine")]
        public int? Medicine { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the name of the creature.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Nature skill, representing knowledge about natural
        /// environments, animals, plants, and weather patterns.
        /// </summary>
        [JsonProperty("nature")]
        public int? Nature { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Perception skill modifier of the creature, which is used for detecting
        /// hidden objects or subtle occurrences.
        /// </summary>
        [JsonProperty("perception")]
        public int? Perception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Performance skill, which is used for entertaining others
        /// through dance, music, acting, storytelling, or other forms of expression.
        /// </summary>
        [JsonProperty("performance")]
        public int? Performance { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's Persuasion skill, which could be used in social situations.
        /// </summary>
        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the list of reactions that the creature can take in response to certain
        /// events or triggers.
        /// </summary>
        [JsonProperty("reactions")]
        public List<Common.Action>? Reactions { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets the creature's Religion skill, representing knowledge about deities and
        /// religious practices.
        /// </summary>
        [JsonProperty("religion")]
        public int? Religion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the types of senses the creature has and their range.
        /// </summary>
        [JsonProperty("senses")]
        public string? Senses { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the size of the creature (e.g., Small, Medium, Large).
        /// </summary>
        [JsonProperty("size")]
        public string? Size { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Sleight of Hand skill, representing its ability to perform
        /// tasks requiring manual dexterity, such as pickpocketing and lock picking.
        /// </summary>
        [JsonProperty("sleight_of_hand")]
        public int? SleightOfHand { get; set; } = int.MinValue;

        /// <inheritdoc/>
        public string? SourceTitle { get; set; }

        /// <summary>
        /// Gets or sets the list of special abilities the creature has.
        /// </summary>
        [JsonProperty("special_abilities")]
        public List<Common.Action>? SpecialAbilities { get; set; } = new List<Common.Action>();

        /// <summary>
        /// Gets or sets the speed of the creature indicating how far it can move.
        /// </summary>
        [JsonProperty("speed")]
        public string? Speed { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the speed of the creature in different conditions.
        /// </summary>
        [JsonProperty("speed_json")]
        public SpeedJson? SpeedJson { get; set; } = new SpeedJson();

        /// <summary>
        /// Gets or sets the list of spells known or usable by the creature.
        /// </summary>
        [JsonProperty("spells")]
        public List<string>? Spells { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the creature's Stealth skill, which is used for avoiding detection.
        /// </summary>
        [JsonProperty("stealth")]
        public int? Stealth { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Strength score of the creature, determining how physically powerful it is.
        /// </summary>
        [JsonProperty("strength")]
        public int? Strength { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the modifier for the creature's Strength saving throws, which is used to
        /// resist or avoid certain physical effects.
        /// </summary>
        [JsonProperty("strength_save")]
        public int? StrengthSave { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the subtype of the creature if any (e.g., elf, goblinoid).
        /// </summary>
        [JsonProperty("subtype")]
        public string? Subtype { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Survival skill, representing its ability to follow tracks,
        /// hunt wildlife, guide others through difficult terrain, and other wilderness tasks.
        /// </summary>
        [JsonProperty("survival")]
        public int? Survival { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the campaign tag symbol to use for this creature.
        /// </summary>
        public string? TagSymbol { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? TagValuePrefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the creature (e.g., beast, humanoid).
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Wisdom score of the creature, determining its attunement to its
        /// surroundings and insight.
        /// </summary>
        [JsonProperty("wisdom")]
        public int? Wisdom { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the Wisdom saving throw modifier of the creature, which is used to resist
        /// effects like enchantments or certain mental attacks.
        /// </summary>
        [JsonProperty("wisdom_save")]
        public int? WisdomSave { get; set; } = int.MinValue;

        /// <inheritdoc/>
        public CampaignEntry ToCampaignEntry()
        {
            return this.ToCreature().ToCampaignEntry();
        }

        /// <summary>
        /// Creates a generic Creature object populated with values from this SRDCreature object.
        /// </summary>
        /// <returns>Generic Creature object populated with values from this SRDCreature object.</returns>
        private Creature ToCreature()
        {
            var creature = new Creature()
            {
                Name = this.Name ?? string.Empty,
                Size = this.Size ?? string.Empty,
                Type = this.Type ?? string.Empty,
                Alignment = this.Alignment ?? string.Empty,
                ArmorClass = this.ArmorClass ?? 0,
                HitPoints = this.HitPoints ?? 0,
                HitDice = this.HitDice ?? string.Empty,
                Walk = this.SpeedJson?.Walk ?? 0,
                Swim = this.SpeedJson?.Swim ?? 0,
                Fly = this.SpeedJson?.Fly ?? 0,
                Burrow = this.SpeedJson?.Burrow ?? 0,
                Climb = this.SpeedJson?.Climb ?? 0,
                Hover = this.SpeedJson?.Hover ?? false,
                Strength = this.Strength ?? 0,
                Dexterity = this.Dexterity ?? 0,
                Constitution = this.Constitution ?? 0,
                Intelligence = this.Intelligence ?? 0,
                Wisdom = this.Wisdom ?? 0,
                Charisma = this.Charisma ?? 0,
                StrengthSave = this.StrengthSave ?? CreatureHelper.CalculateAbilityBonus(this.Strength),
                DexteritySave = this.DexteritySave ?? CreatureHelper.CalculateAbilityBonus(this.Dexterity),
                ConstitutionSave = this.ConstitutionSave ?? CreatureHelper.CalculateAbilityBonus(this.Constitution),
                IntelligenceSave = this.IntelligenceSave ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                WisdomSave = this.WisdomSave ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
                CharismaSave = this.CharismaSave ?? CreatureHelper.CalculateAbilityBonus(this.Charisma),
                DamageImmunities = this.DamageImmunities ?? string.Empty,
                DamageResistances = this.DamageResistances ?? string.Empty,
                DamageVulnerabilities = this.DamageVulnerabilities ?? string.Empty,
                ConditionImmunities = this.ConditionImmunities ?? string.Empty,
                Languages = this.Languages ?? string.Empty,
                ArmorDesc = this.ArmorDesc ?? string.Empty,
                PassivePerception = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "passive perception") ?? 0,
                Darkvision = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "darkvision") ?? 0,
                Blindsight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "blindsight") ?? 0,
                Tremorsense = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "tremorsense") ?? 0,
                Truesight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "truesight") ?? 0,
                ChallengeRating = CreatureHelper.ConvertChallengeRatingToDouble(this.ChallengeRating ?? string.Empty) ?? 0.0,
                Acrobatics = this.Acrobatics ?? CreatureHelper.CalculateAbilityBonus(this.Dexterity),
                AnimalHandling = this.AnimalHandling ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
                Arcana = this.Arcana ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                Athletics = this.Athletics ?? CreatureHelper.CalculateAbilityBonus(this.Strength),
                Deception = this.Deception ?? CreatureHelper.CalculateAbilityBonus(this.Charisma),
                History = this.History ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                Insight = this.Insight ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
                Intimidation = this.Intimidation ?? CreatureHelper.CalculateAbilityBonus(this.Charisma),
                Investigation = this.Investigation ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                Medicine = this.Medicine ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
                Nature = this.Nature ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                Perception = this.Perception ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
                Performance = this.Performance ?? CreatureHelper.CalculateAbilityBonus(this.Charisma),
                Persuasion = this.Persuasion ?? CreatureHelper.CalculateAbilityBonus(this.Charisma),
                Religion = this.Religion ?? CreatureHelper.CalculateAbilityBonus(this.Intelligence),
                SleightOfHand = this.SleightOfHand ?? CreatureHelper.CalculateAbilityBonus(this.Dexterity),
                Stealth = this.Stealth ?? CreatureHelper.CalculateAbilityBonus(this.Dexterity),
                Survival = this.Survival ?? CreatureHelper.CalculateAbilityBonus(this.Wisdom),
            };

            // Populate Special Abilities
            if (this.SpecialAbilities != null)
            {
                foreach (var specialAbility in this.SpecialAbilities)
                {
                    creature.SpecialAbilities ??= new List<Action> { };
                    creature.SpecialAbilities.Add(new Common.Action()
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
                    creature.Actions.Add(new Common.Action()
                    {
                        Name = action.Name ?? string.Empty,
                        Description = action.Description ?? string.Empty,
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
                    creature.LegendaryActions.Add(new Common.Action()
                    {
                        Name = legendaryAction.Name ?? string.Empty,
                        Description = legendaryAction.Description ?? string.Empty,
                    });
                }
            }

            // Populate License
            if (!string.IsNullOrEmpty(this.SourceTitle))
            {
                creature.SourceTitle = this.SourceTitle;
            }

            // Populate Tag Information
            creature.TagSymbol = this.TagSymbol;

            return creature;
        }
    }
}