namespace CampaignKit.Compendium.Core.Configuration
{
    /// <summary>
    /// Represents a set of source data for a Tabletop Role-Playing Game (TTRPG) system.
    /// </summary>
    public class SourceDataSet
    {
        /// <summary>
        /// Gets or sets the name of the source data set. This is primarily used for identification purposes.
        /// </summary>
        public string? SourceDataSetName { get; set; }

        /// <summary>
        /// Gets or sets the Uniform Resource Identifier (URI) where the actual game source data is located.
        /// </summary>
        public string? SourceDataURI { get; set; }

        /// <summary>
        /// Gets or sets the Uniform Resource Identifier (URI) where the license data for the game source data is located.
        /// </summary>
        public string? LicenseDataURI { get; set; }

        /// <summary>
        /// Gets or sets the name of the parser that should be used to parse the source data. This should correspond to a specific parser implementation.
        /// </summary>
        public string? Parser { get; set; }
    }
}