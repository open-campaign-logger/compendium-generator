namespace CampaignKit.Compendium.DungeonsAndDragons.TomeOfBeasts3
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the skillset of a creature in the Tome of Beasts 3.
    /// Each property represents a different skill and its proficiency level.
    /// </summary>
    public class Skills
    {
        /// <summary>
        /// Gets or sets the creature's proficiency in the Acrobatics skill.
        /// </summary>
        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Arcana skill.
        /// </summary>
        [JsonProperty("arcana")]
        public int? Arcana { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Athletics skill.
        /// </summary>
        [JsonProperty("athletics")]
        public int? Athletics { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Deception skill.
        /// </summary>
        [JsonProperty("deception")]
        public int? Seception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the History skill.
        /// </summary>
        [JsonProperty("history")]
        public int? History { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Insight skill.
        /// </summary>
        [JsonProperty("insight")]
        public int? Insight { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Intimidation skill.
        /// </summary>
        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Nature skill.
        /// </summary>
        [JsonProperty("nature")]
        public int? Nature { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Perception skill.
        /// </summary>
        [JsonProperty("perception")]
        public int? Perception { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Performance skill.
        /// </summary>
        [JsonProperty("performance")]
        public int? Performance { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Persuasion skill.
        /// </summary>
        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Religion skill.
        /// </summary>
        [JsonProperty("religion")]
        public int? Religion { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Sleight of Hand skill.
        /// </summary>
        [JsonProperty("slight_of_hand")]
        public int? Slight_of_hand { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Stealth skill.
        /// </summary>
        [JsonProperty("stealth")]
        public int? Stealth { get; set; } = int.MinValue;

        /// <summary>
        /// Gets or sets the creature's proficiency in the Survival skill.
        /// </summary>
        [JsonProperty("survival")]
        public int? Survival { get; set; } = int.MinValue;
    }
}
