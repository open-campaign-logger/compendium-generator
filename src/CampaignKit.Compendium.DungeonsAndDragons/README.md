
# Dungeons and Dragons Module

This module supports the generation of compendiums for Dungeons & Dragons 5th Edition Bestiary. It leverages open-source, 5e compatible monsters derived from the following [open5e-api ](https://github.com/open5e/open5e-api) data sets:

* **Systems Reference Document** (Wizards of the Coast)
* **Tome of Beasts**, (Kobold Press)
* **Tome of Beasts 2**, (Kobold Press)
* **Tome of Beasts 3**, (Kobold Press)
* **Creature Codex**, (Kobold Press)
* **Monstrous Menagerie**, (Kobold Press)

The application is configured to create two different compendiums from these data sets:

* **5e Bestiary.json** - Full set of 2,136 monsters.
* **5e Bestiary Test.json** - Subset of monsters from each set, used for quick testing and validation.

## Configuration

Configure the module in `appsettings.json` or `secrets.json` as follows:

```json
{
    // The Dependency Injection service class for processing this compendium.
    "CompendiumService": "CampaignKit.Compendium.DungeonsAndDragons.Services.IDungeonsAndDragonsCompendiumService_5e, CampaignKit.Compendium.DungeonsAndDragons.dll",
    // Description of the compendium.
    "Description": "Preformatted 5e monsters from the SRD and Kobold Press.",
    // Name of the game system.  This name will be used for organizing generated files.  Make sure it's a path safe string.  (avoid special characters)
    "GameSystem": "Dungeons and Dragons 5e",
    // Image to use for the compendium.
    "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
    // List of source data sets to parse and compile into the compendium.
    "SourceDataSets": [
    {
        // Limits number of items to parse from the source data set. Useful for testing purposes.
        "ExportLimit": 5,
        // Class to use for parsing license information.
        "LicenseDataParser": "CampaignKit.Compendium.DungeonsAndDragons.Common.License",
        // URI of license information.
        "LicenseDataURI": "https://raw.githubusercontent.com/open5e/open5e-api/main/data/WOTC_5e_SRD_v5.1/document.json",
        // Controls whether to always download source data files or to only download once.
        "OverwriteExisting": false,
        // Descriptive name of the source data set.
        "SourceDataSetName": "Dungeons & Dragons SRD - Monsters",
        // Class to use for parsing source data information.
        "SourceDataSetParser": "CampaignKit.Compendium.DungeonsAndDragons.SRD.SRDCreature",
        // URI of source data set.
        "SourceDataSetURI": "https://raw.githubusercontent.com/open5e/open5e-api/main/data/WOTC_5e_SRD_v5.1/monsters.json"
    },
    // Other datasets...
    ],
    // Compendium title.
    "Title": "5e Bestiary - Test"
}
```

