![CampaignGenerator](doc/Logo.png)

# CompendiumGenerator

**CompendiumGenerator** enriches your gaming experience with [CampaignLogger](https://campaign-logger.com/) by producing importable rule set compendiums using open-source RPG datasets. It's not necessary to run this utility yourself as all generated compendiums are accessible in the project's [data directory]("https://github.com/open-campaign-logger/compendium-generator/tree/main/data").

## Requirements and Setup

This application is developed using .NET 7 SDK and C#. Although Visual Studio Community Edition was used for development, you can build, test, and execute the application using the .NET CLI.

### Required Software

* [Git](https://git-scm.com/download/win) or [TortoiseGit](https://tortoisegit.org/)
* [Microsoft .NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Optional Software

* [Microsoft Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/)
  * Ensure to install the ".NET Desktop Development" workload.
  * Recommended Extensions:
    * [CodeMaid](https://www.codemaid.net/)
    * [MarkdownEditor2022](https://github.com/MadsKristensen/MarkdownEditor2022)
    * [Visual chatGPT Studio](https://marketplace.visualstudio.com/items?itemName=jefferson-pires.VisualChatGPTStudio)

### Workspace Setup

Clone the repository and navigate to the project directory:

```shell
git clone https://github.com/open-campaign-logger/compendium-generator.git
cd ./compendium-generator
```

Build, test, and run the project:

```shell
dotnet build
dotnet test
dotnet run --project CampaignKit.Compendium.Utility
```

## Configuration

The application uses a standard .NET `appsettings.json` file for configuration. Notable settings include:

* `PrivateDataFolder`: Directory for accessing and storing **private** compendium source data sets. If left blank, files are stored in the OS's default temporary directory.
* `PublicDataFolder`: Directory for downloading and storing **public** compendium source data sets. If left blank, files are stored in the OS's default temporary directory.

Visual Studio's built-in support for user secrets can be used to override configuration during development. This is particularly helpful for `PrivateCompendiums`, `PublicDataFolder`, and `PrivateDataFolder` settings, which may vary in each developer's environment and should not be pushed back to the repository.

## Modules

* [Dungeons and Dragons 5th Edition](src/CampaignKit.Compendium.DungeonsAndDragons)
* [Old School Essentials](src/CampaignKit.Compendium.OldSchoolEssentials)
* [Markdown File Conversion Module](src/CampaignKit.Compendium.Markdown)

## Contributing

We welcome contributions! Instructions for adding a new module or deserializing JSON files are included in the repository. Please follow the established patterns for project structure and coding standards.

## Links

* [Campaign Logger](https://campaign-logger.com/)
* [Role Playing Tips](https://www.roleplayingtips.com/)
* [Campaign Community](https://campaign-community.com/)
* [Open5e API](https://github.com/open5e/open5e-api)

## Licensing

Copyright (c) 2017-2023 Jochen Linnemann, Cory Gill.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


