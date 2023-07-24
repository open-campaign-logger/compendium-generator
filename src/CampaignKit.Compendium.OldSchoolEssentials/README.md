# Old School Essentials Bestiary, Spells and Magic Items
A collection of monsters, spells, and magic items extracted from the [Old School Essentials SRD](https://oldschoolessentials.necroticgnome.com/srd/index.php/Main_Page)

The application is currently configured to create one compendium from this data:
* **OSE Compendiums.json**

## Configuration
At this time there is only one source data file for OSE.  It is embedded in the project itself so `SourceDataSets` configuration section is not required.
```json
{
    // DI service class to use for processing this compendium.
    "CompendiumService": "CampaignKit.Compendium.OldSchoolEssentials.Services.IOldSchoolEssentialsCompendiumService, CampaignKit.Compendium.OldSchoolEssentials.dll",
    // Description of the compendium.
    "Description": "OSE monsters, spells and magic items from the SRD.",
    // Image to use for the compendium.
    "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
    // Compendium title.
    "Title": "OSE Compendium"
}
```