![CampaignGenerator](doc/Logo.png)
# CompendiumGenerator
> Bringing open source table top roleplaying game (TTRPG) compendiums to your favourite campaign management toolbox.

CompendiumGenerator is a utility designed to improve the gaming experience for the [CampaignLogger](https://campaign-logger.com/) application.  By leveraging open-sourced RPG data sets, CompendiumGenerator is able to produce rule set compendiums that can be imported into CampaignLogger.

You do not need to run the utility yourself to create the compendiums.  All generated compendiums can be found in the project's [data directory]("https://github.com/open-campaign-logger/compendium-generator/tree/main/data").

## Installing / Getting started

This application was developed in C# using the cross-platform .Net 7 SDK.

Visual Studio Community Edition was used for development work but you don't need to use Visual Studio.  The application can be built, tested and executed from the commandline using .Net CLI.

### Required Software
* [Git](https://git-scm.com/download/win)/[TortoiseGit](https://tortoisegit.org/)
* [Microsoft .Net 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Optional Softare
* [Microsoft Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/)
	* Install the ".Net Desktop Development" workload.
    * [CodeMaid](https://www.codemaid.net/) VS Extension - For reording and reformatting class elements.
    * [MarkdownEditor2022](https://github.com/MadsKristensen/MarkdownEditor2022) VS Extension - Facilitates the creation of Markdown files like this one.
    * [Visual chatGPT Studio](https://marketplace.visualstudio.com/items?itemName=jefferson-pires.VisualChatGPTStudio) VS Extension - Adds chatGPT functionality directly within Visual Studio.  OpenAI API key required.

### Workspace Setup
Execute the following
``` shell
git clone https://github.com/open-campaign-logger/compendium-generator.git
cd ./compendium-generator
dotnet build
dotnet test
dotnet run --project CampaignKit.Compendium.Utility
```

This will download the solution, install dependencies, perform a build, run automated unit tests then execute the utility.

### General Configuration

#### appsettings.json
A standard .Net `appsettings.json` file is used to configure the application.

The following configuration elements apply to all compendiums:

```json
  ...
  // Standard .Net environment and logging settings.
  "Environments": {
    ...
  },
  // This is where source data sets for private compendiums will be accessed
  // and where compendiums will be generated.  
  // 
  // If you leave this blank files will be stored in a temporary directory.
  // Windows Temporary Directory: `C:\Users\[Username]\AppData\Local\Temp\CampaignCompendium\Private`
  // LinuxTemporary Directory: Resolves to the value of the environment variable `TMPDIR`, which is usually set to `/tmp`.
  "PrivateDataFolder": "",
  // This is where source data sets for public compendiums will be downloaded
  // to and where compendiums will be generated.  
  // 
  // If you leave this blank files will be stored in a temporary directory.
  // Windows Temporary Directory: `C:\Users\[Username]\AppData\Local\Temp\CampaignCompendium\Public`
  // LinuxTemporary Directory: Resolves to the value of the environment variable `TMPDIR`, which is usually set to `/tmp`.
  "PublicDataFolder": ""
  ....
```

#### User Secrets
Visual Studio has built in support for user secrets that you can use to provide configuration overrides during development.

![User Secrets](doc/user-secrets.png)

This is especially helpful for the `PrivateCompendiums`, `PublicDataFolder`, and `PrivateDataFolder` configuration elements which will differ in each developer's environment
and should not be shared back to the repository.

```json
{
  // List of private compendiums to process.
  "PrivateCompendiums": [...]
  // Location to be used by the program for storage of downloaded open-source
  // TTRPG data files and for the generation of Campaign Logger compendium files.
  "PublicDataFolder": "D:\\source\\compendium-generator\\public",
  // Location to be used by the program for storage of private
  // TTRPG data files and for the generation of Campaign Logger compendium files.
  "PrivateDataFolder": "D:\\source\\compendium-generator\\private",
}
```


## Modules
* [Dungeons and Dragons 5th Editiion](src/CampaignKit.Compendium.DungeonsAndDragons)
* [Old School Essentials](src/CampaignKit.Compendium.OldSchoolEssentials)
* [Markdown](src/CampaignKit.Compendium.Markdown)

## Contributing

### Adding a New Module
1. Add a new **Class Library** project to the solution.  Make sure that the project is stored in the `/src/` directory like the other modules.
1. Add `CampaignKit.Compendium.Core` project reference (**right click project > Add > Project Reference...**)
1. Add a project reference to your new project to the following:
    1. `CampaignKit.Compendium.Tests`
    1. `CampaignKit.Compendium.Utility`
1. Add the following NuGet packages (**right click project > Manage NuGet Packages...**)
    1. `Microsoft.Extensions.Configuration`
    1. `Microsoft.Extensions.Configuration.Binder`
    1. `Microsoft.Extensions.Logging`
    1. `Newtonsoft.Json`
    1. `StyleCop.Analyzers`
1. Create a folder called `Services` and add the following:
    1. `I<YOUR SERVICE NAME>.cs` - interface inheriting from `ICompendiumService`.
    1. `Default<YOUR SERVICE NAME>.cs` - default implementation of the service.
1. Copy the `stylecop.json` settings file from another project and place it in your project's root directory.
1. Create a folder in `CampaignKit.Compendium.Tests` for your new module.  Add basic unit tests that can be run during the build pipeline to ensure that the overall application is working correctly.
1. Reigster your service in `CampaignKit.Compendium.Utility.Program`:

```csharp
        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="hostingContext">The hosting context.</param>
        /// <param name="services">The services.</param>
        private static void ConfigureServices(HostBuilderContext hostingContext, IServiceCollection services)
        {
            // Add transient services to the service collection
            // Add DefaultDownloadService to the service collection as an IDownloadService
            services.AddTransient<IDownloadService, DefaultDownloadService>();

            // Add DefaultConfigurationService to the service collection as an IConfigurationService
            services.AddTransient<IConfigurationService, DefaultConfigurationService>();

            // Add DefaultApplication to the service collection as an IApplication
            services.AddTransient<IApplication, DefaultApplication>();

            // Add DefaultDungeonsAndDragonsCompendiumService_5e to the service collection as an IDungeonsAndDragonsCompendiumService_5e
            services.AddTransient<IDungeonsAndDragonsCompendiumService_5e, DefaultDungeonsAndDragonsCompendiumService_5e>();

            // Add DefaultOldSchoolEssentialsCompendiumService to the service collection as an IOldSchoolEssentialsCompendiumService
            services.AddTransient<IOldSchoolEssentialsCompendiumService, DefaultOldSchoolEssentialsCompendiumService>();

            // YOUR SERVICE ADDED HERE
        }
```

### Deserializing JSON Files

[json2csharp](https://json2csharp.com/) can be used to create C# classes for deserializing JSON source data sets.

Recommended json2csharp settings:
* Use Nullable Types
* Add JsonProperty Attributes
* Use Pascal Case

Once a JSON deserialization class has been created perform the following steps to customize the code:
* Add "?" nullable type operator for each property
* set a default value for each property.  Examples:
   * `public string? Alignment { get; set; } = string.Empty;`
   * `public int? AnimalHandling { get; set; } = int.MinValue;`
   * `public List<Action>? Actions { get; set; } = new List<Action>();`

## Links

* [Campaign Logger](https://campaign-logger.com/)
* [Role Playing Tips](https://www.roleplayingtips.com/)
* [Campaign Community](https://campaign-community.com/)
* [Open5e API](https://github.com/open5e/open5e-api)

## Licensing

Copyright (c) 2017-2021 Jochen Linnemann, Cory Gill.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


