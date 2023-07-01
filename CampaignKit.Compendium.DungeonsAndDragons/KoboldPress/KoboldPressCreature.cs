// <copyright file="KoboldPressCreature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.KoboldPress
{
    using CampaignKit.Compendium.DungeonsAndDragons.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Class representing a creature from the Dungeons &amp; Dragons materials published by Kobold Press.
    /// </summary>
    public class KoboldPressCreature
    {
        /// <summary>
        /// Gets or sets the creature's Acrobatics skill, representing its ability to perform tasks
        /// requiring agility and balance.
        /// </summary>
        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; }

        /// <summary>
        /// Gets or sets the list of actions that the creature can take during a combat round.
        /// </summary>
        [JsonProperty("actions")]
        public List<Action>? Actions { get; set; }

        /// <summary>
        /// Gets or sets the alignment of the creature (e.g., chaotic evil, neutral).
        /// </summary>
        [JsonProperty("alignment")]
        public string? Alignment { get; set; }

        /// <summary>
        /// Gets or sets the creature's Animal Handling skill, which is used for calming down,
        /// understanding, or controlling animals.
        /// </summary>
        [JsonProperty("handling")]
        public int? AnimalHandling { get; set; }

        /// <summary>
        /// Gets or sets the creature's Arcana skill, representing knowledge about magical matters.
        /// </summary>
        [JsonProperty("arcana")]
        public int? Arcana { get; set; }

        /// <summary>
        /// Gets or sets the Armor Class (AC) of the creature which is the difficulty to hit it with
        /// an attack.
        /// </summary>
        [JsonProperty("armor_class")]
        public string? ArmorClass { get; set; }

        /// <summary>
        /// Gets or sets the description of the creature's armor.
        /// </summary>
        [JsonProperty("armor_desc")]
        public string? ArmorDesc { get; set; }

        /// <summary>
        /// Gets or sets the creature's Athletics skill, which is used for physical activities like
        /// climbing, swimming, or jumping.
        /// </summary>
        [JsonProperty("athletics")]
        public int? Athletics { get; set; }

        /// <summary>
        /// Gets or sets the challenge rating of the creature, which is a measure of how dangerous
        /// it is.
        /// </summary>
        [JsonProperty("challenge_rating")]
        public string? ChallengeRating { get; set; }

        /// <summary>
        /// Gets or sets the charisma attribute of the creature. This might determine how it
        /// interacts with others.
        /// </summary>
        [JsonProperty("charisma")]
        public string? Charisma { get; set; }

        /// <summary>
        /// Gets or sets the modifier for the creature's Charisma saving throws, which is used to
        /// resist certain effects that require a force of personality.
        /// </summary>
        [JsonProperty("charisma_save")]
        public int? CharismaSave { get; set; }

        /// <summary>
        /// Gets or sets the conditions that the creature is immune to.
        /// </summary>
        [JsonProperty("condition_immunities")]
        public string? ConditionImmunities { get; set; }

        /// <summary>
        /// Gets or sets the Constitution score of the creature, determining its health and stamina.
        /// </summary>
        [JsonProperty("constitution")]
        public string? Constitution { get; set; }

        /// <summary>
        /// Gets or sets the Constitution saving throw modifier of the creature, which is used to
        /// resist effects like poison or disease.
        /// </summary>
        [JsonProperty("constitution_save")]
        public int? ConstitutionSave { get; set; }

        /// <summary>
        /// Gets or sets the types of damage that the creature is immune to.
        /// </summary>
        [JsonProperty("damage_immunities")]
        public string? DamageImmunities { get; set; }

        /// <summary>
        /// Gets or sets the types of damage that the creature is resistant to.
        /// </summary>
        [JsonProperty("damage_resistances")]
        public string? DamageResistances { get; set; }

        /// <summary>
        /// Gets or sets the types of damage that the creature is vulnerable to.
        /// </summary>
        [JsonProperty("damage_vulnerabilities")]
        public string? DamageVulnerabilities { get; set; }

        /// <summary>
        /// Gets or sets the creature's Deception skill, which is used to mislead others.
        /// </summary>
        [JsonProperty("deception")]
        public int? Deception { get; set; }

        /// <summary>
        /// Gets or sets the Dexterity score of the creature, determining its agility, reflexes, and balance.
        /// </summary>
        [JsonProperty("dexterity")]
        public string? Dexterity { get; set; }

        /// <summary>
        /// Gets or sets the modifier for the creature's Dexterity saving throws, which is used to
        /// resist or avoid certain effects.
        /// </summary>
        [JsonProperty("dexterity_save")]
        public int? DexteritySave { get; set; }

        /// <summary>
        /// Gets or sets the History skill modifier of the creature, which is used for recalling
        /// lore or recognizing historical significance.
        /// </summary>
        [JsonProperty("history")]
        public int? History { get; set; }

        /// <summary>
        /// Gets or sets the hit dice of the creature which determine its hit points.
        /// </summary>
        [JsonProperty("hit_dice")]
        public string? HitDice { get; set; }

        /// <summary>
        /// Gets or sets the hit points of the creature which indicate how much damage it can take
        /// before it drops to 0 health.
        /// </summary>
        [JsonProperty("hit_points")]
        public string? HitPoints { get; set; }

        /// <summary>
        /// Gets or sets the creature's Insight skill, which is used to determine the true
        /// intentions of others.
        /// </summary>
        [JsonProperty("insight")]
        public int? Insight { get; set; }

        /// <summary>
        /// Gets or sets the Intelligence score of the creature, determining its mental acuity,
        /// information recall, and analytical skill.
        /// </summary>
        [JsonProperty("intelligence")]
        public string? Intelligence { get; set; }

        /// <summary>
        /// Gets or sets the Intelligence saving throw modifier of the creature, which is used to
        /// resist effects like illusions or certain mental attacks.
        /// </summary>
        [JsonProperty("intelligence_save")]
        public int? IntelligenceSave { get; set; }

        /// <summary>
        /// Gets or sets the creature's Intimidation skill, representing its ability to instill fear
        /// in others through overt threats, hostile actions, and physical prowess.
        /// </summary>
        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; }

        /// <summary>
        /// Gets or sets the creature's Investigation skill, representing its ability to deduce
        /// information, piece together clues, or notice things that might be hidden or obscured.
        /// </summary>
        [JsonProperty("investigation")]
        public int? Investigation { get; set; }

        /// <summary>
        /// Gets or sets the languages that the creature can speak.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; }

        /// <summary>
        /// Gets or sets the list of legendary actions that the creature can take.
        /// </summary>
        [JsonProperty("legendary_actions")]
        public List<LegendaryAction>? LegendaryActions { get; set; }

        /// <summary>
        /// Gets or sets the description of the creature's legendary actions.
        /// </summary>
        [JsonProperty("legendary_desc")]
        public string? LegendaryDesc { get; set; }

        /// <summary>
        /// Gets or sets the creature's Medicine skill, which might be used for healing.
        /// </summary>
        [JsonProperty("medicine")]
        public int? Medicine { get; set; }

        /// <summary>
        /// Gets or sets the name of the creature.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the creature's Nature skill, representing knowledge about natural
        /// environments, animals, plants, and weather patterns.
        /// </summary>
        [JsonProperty("nature")]
        public int? Nature { get; set; }

        /// <summary>
        /// Gets or sets the Perception skill modifier of the creature, which is used for detecting
        /// hidden objects or subtle occurrences.
        /// </summary>
        [JsonProperty("perception")]
        public int? Perception { get; set; }

        /// <summary>
        /// Gets or sets the creature's Performance skill, which is used for entertaining others
        /// through dance, music, acting, storytelling, or other forms of expression.
        /// </summary>
        [JsonProperty("performance")]
        public int? Performance { get; set; }

        /// <summary>
        /// Gets or sets the creature's Persuasion skill, which could be used in social situations.
        /// </summary>
        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; }

        /// <summary>
        /// Gets or sets the list of reactions that the creature can take in response to certain
        /// events or triggers.
        /// </summary>
        [JsonProperty("reactions")]
        public List<Reaction>? Reactions { get; set; }

        /// <summary>
        /// Gets or sets the creature's Religion skill, representing knowledge about deities and
        /// religious practices.
        /// </summary>
        [JsonProperty("religion")]
        public int? Religion { get; set; }

        /// <summary>
        /// Gets or sets the types of senses the creature has and their range.
        /// </summary>
        [JsonProperty("senses")]
        public string? Senses { get; set; }

        /// <summary>
        /// Gets or sets the size of the creature (e.g., Small, Medium, Large).
        /// </summary>
        [JsonProperty("size")]
        public string? Size { get; set; }

        /// <summary>
        /// Gets or sets the creature's Sleight of Hand skill, representing its ability to perform
        /// tasks requiring manual dexterity, such as pickpocketing and lock picking.
        /// </summary>
        [JsonProperty("hand")]
        public int? SleightOfHand { get; set; }

        /// <summary>
        /// Gets or sets the list of special abilities the creature has.
        /// </summary>
        [JsonProperty("special_abilities")]
        public List<SpecialAbility>? SpecialAbilities { get; set; }

        /// <summary>
        /// Gets or sets the speed of the creature indicating how far it can move.
        /// </summary>
        [JsonProperty("speed")]
        public string? Speed { get; set; }

        /// <summary>
        /// Gets or sets the speed of the creature in different conditions.
        /// </summary>
        [JsonProperty("speed_json")]
        public SpeedJson? SpeedJson { get; set; }

        /// <summary>
        /// Gets or sets the creature's Stealth skill, which is used for avoiding detection.
        /// </summary>
        [JsonProperty("stealth")]
        public int? Stealth { get; set; }

        /// <summary>
        /// Gets or sets the Strength score of the creature, determining how physically powerful it is.
        /// </summary>
        [JsonProperty("strength")]
        public string? Strength { get; set; }

        /// <summary>
        /// Gets or sets the modifier for the creature's Strength saving throws, which is used to
        /// resist or avoid certain physical effects.
        /// </summary>
        [JsonProperty("strength_save")]
        public int? StrengthSave { get; set; }

        /// <summary>
        /// Gets or sets the subtype of the creature if any (e.g., elf, goblinoid).
        /// </summary>
        [JsonProperty("subtype")]
        public string? Subtype { get; set; }

        /// <summary>
        /// Gets or sets the creature's Survival skill, representing its ability to follow tracks,
        /// hunt wildlife, guide others through difficult terrain, and other wilderness tasks.
        /// </summary>
        [JsonProperty("survival")]
        public int? Survival { get; set; }

        /// <summary>
        /// Gets or sets the type of the creature (e.g., beast, humanoid).
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the Wisdom score of the creature, determining its attunement to its
        /// surroundings and insight.
        /// </summary>
        [JsonProperty("wisdom")]
        public string? Wisdom { get; set; }

        /// <summary>
        /// Gets or sets the Wisdom saving throw modifier of the creature, which is used to resist
        /// effects like enchantments or certain mental attacks.
        /// </summary>
        [JsonProperty("wisdom_save")]
        public int? WisdomSave { get; set; }

        /// <summary>
        /// Creates a generic Creature object populated with values from this KoboldPressCreature object.
        /// </summary>
        /// <returns>Generic Creature object populated with values from this KoboldPressCreature object.</returns>
        public Creature ToCreature()
        {
            var creature = new Creature()
            {
                Name = this.Name ?? string.Empty,
                Size = this.Size ?? string.Empty,
                Type = this.Type ?? string.Empty,
                SourceDocumentTitle = "Creature Codex OGL",
                SourceDocumentDescription = "Creature Codex Open-Gaming License Content by Kobold Press",
                SourceDocumentVersion = "1.0",
                LicenseName = "Open Gaming License",
                LicenseURL = "https://koboldpress.com/kpstore/product/creature-codex-for-5th-edition-dnd/",
                Author = "Wolfgang Baur, Dan Dillon, Richard Green, James Haeck, Chris Harris, Jeremy Hochhalter, James Introcaso, Chris Lockey, Shawn Merwin, and Jon Sawatsky",
                Organization = "Kobold Press",
                Copyright = "Creature Codex. © 2018 Open Design LLC; Authors Wolfgang Baur, Dan Dillon, Richard Green, James Haeck, Chris Harris, Jeremy Hochhalter, James Introcaso, Chris Lockey, Shawn Merwin, and Jon Sawatsky.",
                RuleSystem = "Dungeons & Dragons 5e",
                Alignment = this.Alignment ?? string.Empty,
                ArmorClass = int.Parse(this.ArmorClass ?? "0"),
                HitPoints = int.Parse(this.HitPoints ?? "0"),
                HitDice = this.HitDice ?? string.Empty,
                Walk = this.SpeedJson?.Walk ?? 0,
                Swim = this.SpeedJson?.Swim ?? 0,
                Fly = this.SpeedJson?.Fly ?? 0,
                Burrow = this.SpeedJson?.Burrow ?? 0,
                Climb = this.SpeedJson?.Climb ?? 0,
                Hover = this.SpeedJson?.Hover ?? false,
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
                ArmorDesc = this.ArmorDesc ?? string.Empty,
                PassivePerception = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "passive perception") ?? 0,
                Darkvision = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "darkvision") ?? 0,
                Blindsight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "blindsight") ?? 0,
                Tremorsense = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "tremorsense") ?? 0,
                Truesight = CreatureHelper.ParseAttributeValue(this.Senses ?? string.Empty, "truesight") ?? 0,
                ChallengeRating = CreatureHelper.ConvertChallengeRatingToDouble(this.ChallengeRating ?? string.Empty) ?? 0.0,
                Acrobatics = this.Acrobatics ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                AnimalHandling = this.AnimalHandling ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Arcana = this.Arcana ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Athletics = this.Athletics ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Strength ?? "0")),
                Deception = this.Deception ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                History = this.History ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Insight = this.Insight ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Intimidation = this.Intimidation ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Investigation = this.Investigation ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Medicine = this.Medicine ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Nature = this.Nature ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                Perception = this.Perception ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
                Performance = this.Performance ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Persuasion = this.Persuasion ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Charisma ?? "0")),
                Religion = this.Religion ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Intelligence ?? "0")),
                SleightOfHand = this.SleightOfHand ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                Stealth = this.Stealth ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Dexterity ?? "0")),
                Survival = this.Survival ?? CreatureHelper.CalculateAbilityBonus(int.Parse(this.Wisdom ?? "0")),
            };

            // Populate Special Abilities
            if (this.SpecialAbilities != null)
            {
                foreach (var specialAbility in this.SpecialAbilities)
                {
                    creature.SpecialAbilities.Add(new Generic.SpecialAbility()
                    {
                        Name = specialAbility.Name ?? string.Empty,
                        Description = specialAbility.Desc ?? string.Empty,
                        Creature = creature,
                        CreatureId = creature.Id,
                    });
                }
            }

            // Populate Actions
            if (this.Actions != null)
            {
                foreach (var action in this.Actions)
                {
                    creature.Actions.Add(new Generic.Action()
                    {
                        Name = action.Name ?? string.Empty,
                        Description = action.Desc ?? string.Empty,
                        Creature = creature,
                        CreatureId = creature.Id,
                    });
                }
            }

            // Populate Reactions
            if (this.Reactions != null)
            {
                foreach (var reaction in this.Reactions)
                {
                    creature.Reactions.Add(new Generic.Reaction()
                    {
                        Name = reaction.Name ?? string.Empty,
                        Description = reaction.Desc ?? string.Empty,
                        Creature = creature,
                        CreatureId = creature.Id,
                    });
                }
            }

            // Populate LegendaryActions
            if (this.LegendaryActions != null)
            {
                creature.LegendaryActionDescription = this.LegendaryDesc ?? string.Empty;
                foreach (var legendaryAction in this.LegendaryActions)
                {
                    creature.LegendaryActions.Add(new Generic.LegendaryAction()
                    {
                        Name = legendaryAction.Name ?? string.Empty,
                        Description = legendaryAction.Desc ?? string.Empty,
                        Creature = creature,
                        CreatureId = creature.Id,
                    });
                }
            }

            return creature;
        }
    }
}
