# Markdown File Conversion Module
The Markdown File Conversion module facilitates the conversion of documents in [Markdown](https://www.markdownguide.org/) format into compendiums importable into the Campaign Logger application. This module assumes that entries are introduced by a heading level 1 tag `# YOUR ENTRY TITLE`. All subsequent markdown text will be copied directly into the resulting Campaign Entry.

## Configuration
A number of examples of how to configure the creation of compendiums using this module are included in the default application (`module_markdown.json`) configuration. 

```json
{
    // The Dependency Injection service class for processing this compendium.
    "CompendiumService": "CampaignKit.Compendium.Markdown.Services.IMarkdownCompendiumService, CampaignKit.Compendium.Markdown.dll",
    // Description of the compendium.
    "Description": "A collection of loot options for Dungeons and Dragons monsters.",
    // Name of the game system.  This name will be used for organizing generated files.  Make sure it's a path safe string.  (avoid special characters)
    "GameSystem": "Dungeons and Dragons 5e",
    // Image to use for the compendium.
    "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
    // List of source data sets to parse and compile into the compendium.
    "SourceDataSets": [
    {
        // Limits number of items to parse from the source data set. Useful for testing purposes.
        "ImportLimit": 5,
        // Default labels to apply to campaign entries derived from the source data.
        "Labels": [
            "D&D 5E",
            "Monster",
            "Anne Gregersen",
            "Monster Manual"
        ],
        // Descriptive name of the source data set.
        "SourceDataSetName": "Monster Loot - Monster Manual",
        // Location of the file in the data directory.
        "SourceDataSetURI": "Monster Loot 1.md",
        // Symbol to use for campaign entries derived from the source data.
        "TagSymbol":  "~"
    },
    // Other datasets...
    ],
    "Title": "5e Bestiary - Loot"
}
```