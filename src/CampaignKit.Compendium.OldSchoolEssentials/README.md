
# Old School Essentials Bestiary, Spells, and Magic Items Module

This module contains a collection of monsters, spells, and magic items extracted from the [Old School Essentials SRD](https://oldschoolessentials.necroticgnome.com/srd/index.php/Main_Page).

## Configuration

Since there is only one source data file for OSE, which is embedded in the project, the `SourceDataSets` configuration section is not required. Here is an example configuration:

```json
{
    // The Dependency Injection service class for processing this compendium.
    "CompendiumService": "CampaignKit.Compendium.OldSchoolEssentials.Services.IOldSchoolEssentialsCompendiumService, CampaignKit.Compendium.OldSchoolEssentials.dll",
    // Description of the compendium.
    "Description": "OSE monsters, spells, and magic items from the SRD.",
    // Image to use for the compendium.
    "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
    // Compendium title.
    "Title": "OSE Compendium"
}
```

