# Markdown File Conversion
The intent of this module is provide support for converting document in [Markdown](https://www.markdownguide.org/) format to a compendium that can be imported into the Campaign Logger application. 
The module assumes that any line that starts all entries are denoted by a heading level 1 tag `# YOUR ENTRY TITLE`.
All subsequent markdown will be copied directly into the resulting Campaign Entry.

## Configuration
Add the following to `PublicCompendiums` in `appsettings.json` or 'PrivateCompendiums` in "secrets.json".
```json
{
    // DI service class to use for processing this compendium.
    "CompendiumService": "CampaignKit.Compendium.Markdown.Services.IMarkdownCompendiumService, CampaignKit.Compendium.Markdown.dll",
    // Description of the compendium.
    "Description": "A collection of loot options for Dungeons and Dragons monsters.",
    // Image to use for the compendium.
    "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
    // List of source data sets to parse and compile into the compendium.
    "SourceDataSets": [
    {
        // Descriptive name of the source data set.
        "SourceDataSetName": "Monster Loot - Monster Manual",
        // Location of the file in the data directory
        "SourceDataSetURI": "Monster Loot 1.md",
        // Symbol to use for campaign entries derived from the source data.
        "TagSymbol":  "~"
    },
    ...
    ],
    "Title": "5e Bestiary - Loot"
}
```