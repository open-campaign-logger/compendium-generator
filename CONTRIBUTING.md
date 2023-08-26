# Contributing to Campaign Compendium

Thank you for your interest in contributing to the Campaign Compendium project! This utility compiles tabletop roleplaying game compendiums from various online open-source game rules, and we appreciate your support in making it better. Here's how you can contribute:

## General Guidelines

### Submitting a Pull Request

1. **Fork the Repository:** Fork the repository to your own GitHub account.
2. **Create a Feature Branch:** Create a branch for the specific feature or module you are working on.
3. **Commit Your Changes:** Make regular, well-commented commits to your branch.
4. **Submit a Pull Request:** Once your feature is complete and tested, submit a pull request for review, referencing any related issues and providing a description of the changes.

### Additional Guidelines

- **Code Style:** Please follow the coding standards and guidelines of the project.
- **Testing:** Include unit tests for new features and modules, ensuring that they pass before submitting a pull request.
- **Documentation:** Update the documentation to reflect changes and new additions.
- **Communication:** Feel free to ask questions or communicate with the maintainers and other contributors via GitHub issues or other designated channels.

### Community and Support

We welcome contributions from everyone and encourage healthy discussion and collaboration. If you need help or have any questions, please reach out to the project maintainers or join our community channels:

* [Campaign Community](https://campaign-community.com/)

### Code of Conduct

By participating in this project, you agree to abide by our [Code of Conduct](link-to-code-of-conduct). Familiarize yourself with it to understand our community standards and expectations.

## Adding a New Module

### Create a Project Item

1. **Create a Project Item:** Start by creating a new project item in the [Campaign Compendium planning board](https://github.com/orgs/open-campaign-logger/projects/5) project plan with the following high-level task list:

```markdown
# Task List
* [ ] Add New Project
* [ ] Create/Update Configuration Classes
* [ ] Create Service Interface and Default Service
* [ ] Register Service with Program
* [ ] Add Default Configuration
* [ ] Create POCO for Requests and Responses
* [ ] Create Unit Tests
* [ ] Create Project README.md
* [ ] Update Solution README.md
* [ ] Update Solution CONTRIBUTING.md
```

2. Once the project item is created convert it into an Issue by using the `Convert to Issue` function in the project item's context menu.
3. Create a new repository branch for issue by clicking the `Create a branch` link in the `Development` section of the issue. Make sure that the branch is based off of the `develop` brnach not the default `main`.

### Add New Project to Solution

1. Add a new **Class Library** project to the solution.  Make sure that the project is stored in the `/src/` directory like the other modules.
1. Add `CampaignKit.Compendium.Core` project reference (`right click project > Add > Project Reference...`)
1. Copy the `stylecop.json` settings file from another project and place it in your project's root directory.
1. Add the following NuGet packages (**right click project > Manage NuGet Packages...**)
    1. `Microsoft.Extensions.Configuration`
    1. `Microsoft.Extensions.Configuration.Binder`
    1. `Microsoft.Extensions.Logging`
    1. `Newtonsoft.Json`
    1. `StyleCop.Analyzers`
1. In the project properties ensure that the following properties are set:
    1. `Build > Output > Documentation File` - Check Generate a file containing API documentation.

### Create Service Interface and Default Service
1. Create a folder called `Services` and add the following:
    1. `I<YOUR SERVICE NAME>.cs` - interface inheriting from `ICompendiumService`.
    1. `Default<YOUR SERVICE NAME>.cs` - default implementation of the service.

### Register Service with Program
1. Register your service in `CampaignKit.Compendium.Utility.Program`:
1. 1. 1. Add a project reference to your new project to the following:
    1. `CampaignKit.Compendium.Tests`
    1. `CampaignKit.Compendium.Utility`
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

            // Add DefaultMarkdownCompendiumService to the service collection as an IMarkdownCompendiumService
            services.AddTransient<IMarkdownCompendiumService, DefaultMarkdownCompendiumService>();

            // Add DefaultChatGPTCompendiumService to the service collection as an IChatGPTCompendiumService
            services.AddTransient<IChatGPTCompendiumService, DefaultChatGPTCompendiumService>();

            // Add DefaultWebScraperCompendiumService to the service collection as an IWebScraperCompendiumService
            services.AddTransient<IWebScraperCompendiumService, DefaultWebScraperCompendiumService>();

            // YOUR SERVICE ADDED HERE
        }
```

### Add Default Configuration
A default compendium should be added to `module_YOURMODULENAME.json` to demonstrate the basic use of the module.

`Program.cs` needs to be updated to read the module configuration at runtime.

```csharp
    // Add module configurations
    string[] jsonFiles = { "module_chatgpt.json", "module_dnd.json", "module_ose.json", "module_markdown.json", "module_woin.json", "module_YOURMODULENAME.json" };
    foreach (var jsonFile in jsonFiles)
    {
        configuration.AddJsonFile(jsonFile, optional: true, reloadOnChange: true);
    }
```

### Encapsulate Business Logic
Ideally business logic should be encapsulated within an object that is used by the service and can be independently tested with a unit test.  This class should inherit from `GameComponentBase`.

In most cases this all of the logic can be encapsulated within the JSON serialization/deserialization class.  See: `CampaignKit.Compendium.DungeonsAndDragons.SRD.SRDGear` for a simple example.

For more complex business logic, a helper class should be created that can be called from either the compendium
service or from the unit testing project.  See: `MarkdownHelper` and 'ChatGPTHelper` for examples.

### Create Unit Tests
A handful of basic unit tests should be created to ensure baseline testing of the module can be performed in the CI/CD pipeline.

Generally speaking, unit tests should be able to run in any setting without external dependencies.

Resource files should be provided to the test directly instead of requiring downloading at runtime.

This example shows how to make a data file in the `TestFiles` subfolder available to the test at runtime:
```csharp
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"Markdown\TestFiles\test.md")]
        public void ConvertToCampaign_TestFile_LabelsCorrect()
        {
            // Arrange
            ...

            // Act
            var campaignEntries = MarkdownHelper.ParseCampaignEntries(sourceDataSet, @"Markdown\TestFiles").Result.ToList();

            // Assert
            ...
        }
```
Note: In the baove example you also need to set the properties of the test file to:
* **Build Action**: Content
* **Copy to Output Directory**: Copy if Newer

There are cases, like with the ChatGPT module, where these guidelines had to be broken.
In those cases like this add an `[Ignore("REASON"]` property to the test to tell the test runner to skip the test by default.
Users wishing to have these tests run can comment out this attribute and run the test.

### Create Project README.md
Every project must have a README.md file that explains the following:
1. Purpose of the module.
1. Basic configuration of the module.
1. In the project properties ensure that the following properties are set:
    1. `Package > General > README` - Select the README file you just created.

### Update Solution README.md
After each project this file should be reviewed to see if any additional changes need to be made.
At minimum the module should be added to the `## Modules` section.

## Update CONTRIBUTING.md
After each project this file should be reviewed to see if any additional changes need to be made.
