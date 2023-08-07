namespace CampaignKit.Compendium.DungeonsAndDragons.SRD
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an ability score increase in a Dugneons and Dragons campaign.
    /// </summary>
    public class SRDAbilityScoreIncrease
    {
        /// <summary>
        /// Gets or sets the attributes affected by this ability score increase.
        /// </summary>
        [JsonProperty("attributes")]
        public List<string> Attributes { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the value of the ability score increase.
        /// </summary>
        [JsonProperty("value")]
        public int? Value { get; set; } = int.MinValue;
    }
}
