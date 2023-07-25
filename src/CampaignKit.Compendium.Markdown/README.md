# Markdown File Conversion Module
The Markdown File Conversion module facilitates the conversion of documents in [Markdown](https://www.markdownguide.org/) format into compendiums importable into the Campaign Logger application. This module assumes that entries are introduced by a heading level 1 tag `# YOUR ENTRY TITLE`. All subsequent markdown text will be copied directly into the resulting Campaign Entry.

## Configuration
To configure this module, add the following to `PublicCompendiums` in `appsettings.json` or `PrivateCompendiums` in "secrets.json":

```json
{
    // The Dependency Injection service class for processing this compendium.
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