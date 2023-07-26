
# Old School Essentials Bestiary, Spells, and Magic Items Module

This module contains a collection of monsters, spells, and magic items from the [Old School Essentials SRD](https://oldschoolessentials.necroticgnome.com/srd/index.php/Main_Page).

## Configuration

An OSE SRD text file is embedded within this module.  At runtime the module reads this embedded file into memory and process its contents.

Use the following configuration guide below to setup the module.

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
      // Configurable parameters for each type of entity
      "SourceDataSets": [
        {
          // Can be used to limit the number of entries of this type.
          // Generally used for testing purposes.
          "ImportLimit": 5,
          "SourceDataSetName": "Monsters"  // Do not change this
        },
        {
          "ImportLimit": 5,
          "SourceDataSetName": "Spells"  // Do not change this
        },
        {
          "ImportLimit": 5,
          "SourceDataSetName": "Items"  // Do not change this
        }
      ],
      // Compendium title.
      "Title": "OSE Compendium - Test"
    }
```