﻿
# Old School Essentials Bestiary, Spells, and Magic Items Module

This module contains a collection of monsters, spells, and magic items from the [Old School Essentials SRD](https://oldschoolessentials.necroticgnome.com/srd/index.php/Main_Page).

## Configuration

An OSE SRD text file is embedded within this module.  At runtime the module reads this embedded file into memory and process its contents.

A number of examples of how to configure the creation of compendiums using this module are included in the default application (`module_ose.json`) configuration. 

```json
    {
      // The Dependency Injection service class for processing this compendium.
      "CompendiumService": "CampaignKit.Compendium.OldSchoolEssentials.Services.IOldSchoolEssentialsCompendiumService, CampaignKit.Compendium.OldSchoolEssentials.dll",	  
      // Description of the compendium.
      "Description": "Preformatted monsters, items and spells from the Old School Essentials SRD.",
      // Name of the game system.  This name will be used for organizing generated files.  Make sure it's a path safe string.  (avoid special characters)
      "GameSystem": "Old School Essentials",
      // Image to use for the compendium.
      "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
      // If true, process this compendium.  If not, skip it.
      "IsActive": true,
      // If true, overwrite an existing compendium if it already exists.  If false, and compendium exists, skip processing.
      "OverwriteExisting": true,
      // Configurable parameters for each type of entity
      "SourceDataSets": [
        {
          // Limits number of items to parse from the source data set. Useful for testing purposes.
          "ImportLimit": 5,
          // Default labels to apply to campaign entries derived from the source data.
          "Labels": [
            "OSE",
            "Necrotic Gnome",
            "Monster"
          ],
          // Do not change this
          "SourceDataSetName": "Monsters"
          // Symbol to use for campaign entries derived from the source data.
          "TagSymbol":  "~"
        },
        {
          // Limits number of items to parse from the source data set. Useful for testing purposes.
          "ImportLimit": 5,
          // Default labels to apply to campaign entries derived from the source data.
          "Labels": [
            "OSE",
            "Necrotic Gnome",
            "Spell"
          ],
          // Do not change this
          "SourceDataSetName": "Spells"
          // Symbol to use for campaign entries derived from the source data.
          "TagSymbol":  "~",
          // Optional prefix to append to the entry name.  This can be helpful for cases where name collisions occur between different items.  For example: an `Acolyte` is both a background and a monster.
          "TagValuePrefix": "Spell - "
        },
        {
          // Limits number of items to parse from the source data set. Useful for testing purposes.
          "ImportLimit": 5,
          // Default labels to apply to campaign entries derived from the source data.
          "Labels": [
            "OSE",
            "Necrotic Gnome",
            "Magic Item"
          ],
          // Do not change this
          "SourceDataSetName": "Magic Items"
          // Symbol to use for campaign entries derived from the source data.
          "TagSymbol":  "+"
        }
      ],
      // Compendium title.
      "Title": "OSE Compendium - Test"
    }
```