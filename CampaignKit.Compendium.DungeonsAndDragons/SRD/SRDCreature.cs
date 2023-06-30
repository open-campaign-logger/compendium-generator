// <copyright file="SRDCreature.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class representing a creature from the Dungeons &amp; Dragons System Reference Document (SRD).
    /// </summary>
    public class SRDCreature
    {
        /// <summary>
        /// Gets or sets the creature's Acrobatics skill, representing its ability to perform tasks
        /// requiring agility and balance.
        /// </summary>
        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; } = 0;

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
        public int? AnimalHandling { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Arcana skill, representing knowledge about magical matters.
        /// </summary>
        [JsonProperty("arcana")]
        public int? Arcana { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Armor Class (AC) of the creature which is the difficulty to hit it with
        /// an attack.
        /// </summary>
        [JsonProperty("armor_class")]
        public int? ArmorClass { get; set; } = 0;

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
        public int? Athletics { get; set; } = 0;

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
        public int? Charisma { get; set; } = 0;

        /// <summary>
        /// Gets or sets the modifier for the creature's Charisma saving throws, which is used to
        /// resist certain effects that require a force of personality.
        /// </summary>
        [JsonProperty("charisma_save")]
        public int? CharismaSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets the conditions that the creature is immune to.
        /// </summary>
        [JsonProperty("condition_immunities")]
        public string? ConditionImmunities { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Constitution score of the creature, determining its health and stamina.
        /// </summary>
        [JsonProperty("constitution")]
        public int? Constitution { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Constitution saving throw modifier of the creature, which is used to
        /// resist effects like poison or disease.
        /// </summary>
        [JsonProperty("constitution_save")]
        public int? ConstitutionSave { get; set; } = 0;

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
        public int? Deception { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Dexterity score of the creature, determining its agility, reflexes, and balance.
        /// </summary>
        [JsonProperty("dexterity")]
        public int? Dexterity { get; set; } = 0;

        /// <summary>
        /// Gets or sets the modifier for the creature's Dexterity saving throws, which is used to
        /// resist or avoid certain effects.
        /// </summary>
        [JsonProperty("dexterity_save")]
        public int? DexteritySave { get; set; } = 0;

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
        public int? History { get; set; } = 0;

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
        public int? HitPoints { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Insight skill, which is used to determine the true
        /// intentions of others.
        /// </summary>
        [JsonProperty("insight")]
        public int? Insight { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Intelligence score of the creature, determining its mental acuity,
        /// information recall, and analytical skill.
        /// </summary>
        [JsonProperty("intelligence")]
        public int? Intelligence { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Intelligence saving throw modifier of the creature, which is used to
        /// resist effects like illusions or certain mental attacks.
        /// </summary>
        [JsonProperty("intelligence_save")]
        public int? IntelligenceSave { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Intimidation skill, representing its ability to instill fear
        /// in others through overt threats, hostile actions, and physical prowess.
        /// </summary>
        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Investigation skill, representing its ability to deduce
        /// information, piece together clues, or notice things that might be hidden or obscured.
        /// </summary>
        [JsonProperty("investigation")]
        public int? Investigation { get; set; } = 0;

        /// <summary>
        /// Gets or sets the languages that the creature can speak.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of legendary actions that the creature can take.
        /// </summary>
        [JsonProperty("legendary_actions")]
        public List<LegendaryAction>? LegendaryActions { get; set; } = new List<LegendaryAction>();

        /// <summary>
        /// Gets or sets the description of the creature's legendary actions.
        /// </summary>
        [JsonProperty("legendary_desc")]
        public string? LegendaryDesc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creature's Medicine skill, which might be used for healing.
        /// </summary>
        [JsonProperty("medicine")]
        public int? Medicine { get; set; } = 0;

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
        public int? Nature { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Perception skill modifier of the creature, which is used for detecting
        /// hidden objects or subtle occurrences.
        /// </summary>
        [JsonProperty("perception")]
        public int? Perception { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Performance skill, which is used for entertaining others
        /// through dance, music, acting, storytelling, or other forms of expression.
        /// </summary>
        [JsonProperty("performance")]
        public int? Performance { get; set; } = 0;

        /// <summary>
        /// Gets or sets the creature's Persuasion skill, which could be used in social situations.
        /// </summary>
        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; } = 0;

        /// <summary>
        /// Gets or sets the list of reactions that the creature can take in response to certain
        /// events or triggers.
        /// </summary>
        [JsonProperty("reactions")]
        public List<Reaction>? Reactions { get; set; } = new List<Reaction>();

        /// <summary>
        /// Gets or sets the creature's Religion skill, representing knowledge about deities and
        /// religious practices.
        /// </summary>
        [JsonProperty("religion")]
        public int? Religion { get; set; } = 0;

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
        public int? SleightOfHand { get; set; } = 0;

        /// <summary>
        /// Gets or sets the list of special abilities the creature has.
        /// </summary>
        [JsonProperty("special_abilities")]
        public List<SpecialAbility>? SpecialAbilities { get; set; } = new List<SpecialAbility>();

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
        public int? Stealth { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Strength score of the creature, determining how physically powerful it is.
        /// </summary>
        [JsonProperty("strength")]
        public int? Strength { get; set; } = 0;

        /// <summary>
        /// Gets or sets the modifier for the creature's Strength saving throws, which is used to
        /// resist or avoid certain physical effects.
        /// </summary>
        [JsonProperty("strength_save")]
        public int? StrengthSave { get; set; } = 0;

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
        public int? Survival { get; set; } = 0;

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
        public int? Wisdom { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Wisdom saving throw modifier of the creature, which is used to resist
        /// effects like enchantments or certain mental attacks.
        /// </summary>
        [JsonProperty("wisdom_save")]
        public int? WisdomSave { get; set; } = 0;
    }
}
