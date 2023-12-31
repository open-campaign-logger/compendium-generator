﻿
# Dungeons and Dragons Module

This module supports the generation of compendiums for Dungeons & Dragons 5th Edition. It leverages open-source data from the following [open5e-api ](https://github.com/open5e/open5e-api) data sets:

* **Advanced 5th Edition**, EN Publishing
* **Creature Codex**, Kobold Press
* **Deep Magic Extended**, Kobold Press
* **Deep Magic**, Kobold Press
* **Monstrous Menagerie**, Kobold Press
* **Systems Reference Document**, Wizards of the Coast
* **Tome of Beasts 2**, Kobold Press
* **Tome of Beasts 3**, Kobold Press
* **Tome of Beasts**, Kobold Press
* **Vault of Magic**, Kobold Press
* **Warlock Archives**, Kobold Press

The application is configured to create two different compendiums from these data sets:

* **Dungeons and Dragons Compendium.json** - Full compendium of items, spells, classes, races, feats, backgrounds, conditions, items, and monsters.
* **Dungeons and Dragons Compendium - Test.json** - Subset of the above used for QA purposes.

## Configuration

A number of examples of how to configure the creation of compendiums using this module are included in the default application (`module_dnd.json`) configuration. 

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
    // If true, process this compendium.  If not, skip it.
    "IsActive": true,
    // If true, overwrite an existing compendium if it already exists.  If false, and compendium exists, skip processing.
    "OverwriteExisting": true,
    // List of source data sets to parse and compile into the compendium.
    "SourceDataSets": [
    {
        // Limits number of items to parse from the source data set. Useful for testing purposes.
        "ImportLimit": 5,
        // Default labels to apply to campaign entries derived from the source data.
        "Labels": [
            "D&D 5E",
            "Monster",
            "WOTC",
            "SRD"
        ],
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
        "SourceDataSetURI": "https://raw.githubusercontent.com/open5e/open5e-api/main/data/WOTC_5e_SRD_v5.1/monsters.json",
        // Symbol to use for campaign entries derived from the source data.
        "TagSymbol":  "~",
        // Optional prefix to append to the entry name.  This can be helpful for cases where name collisions occur between different items.  For example: an `Acolyte` is both a background and a monster.
        "TagValuePrefix": "Spell - "
    },
    // Other datasets...
    ],
    // Compendium title.
    "Title": "Dungeons and Dragons Compendium - Test"
}
```

