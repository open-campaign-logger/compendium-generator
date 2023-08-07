# Adding a New Module

## Work Management

### Create Work Item
Create a new project item to the [Campaign Compendium planning board](https://github.com/orgs/open-campaign-logger/projects/5) with this high level task list.
```
# Task List
 * [ ] Add New Project
 * [ ] Create/Update Configuration Classes
 * [ ] Create Service Interface and Default Service
 * [ ] Register Service with Program
 * [ ] Add Default Configuration
 * [ ] Create POCO for Requests and Responses
 * [ ] Create Unit Test for POCO
 * [ ] Create Project README.md
 * [ ] Update Solution README.md
 * [ ] Update CONTRIBUTING.md
 ```

 ### Create Code Branch
 All new features should be added as a branch off of the the `develop` branch.

## Service Setup

### Add New Project to Solution

1. Add a new **Class Library** project to the solution.  Make sure that the project is stored in the `/src/` directory like the other modules.
1. Add `CampaignKit.Compendium.Core` project reference (**right click project > Add > Project Reference...**)
1. Copy the `stylecop.json` settings file from another project and place it in your project's root directory.
1. Add the following NuGet packages (**right click project > Manage NuGet Packages...**)
    1. `Microsoft.Extensions.Configuration`
    1. `Microsoft.Extensions.Configuration.Binder`
    1. `Microsoft.Extensions.Logging`
    1. `Newtonsoft.Json`
    1. `StyleCop.Analyzers`
1. In the project properties ensure that the following properties are set:
    1. **Build > Output > Documentation File** - Check Generate a file containing API documentation.

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

            // YOUR SERVICE ADDED HERE
        }
```

## Business Logic

### Create a JSON Serialization/Deserialization Class

[json2csharp](https://json2csharp.com/) can be used to create C# classes for deserializing JSON source data sets.

Recommended json2csharp settings:
* Use Pascal Case

Once a JSON deserialization class has been created perform the following steps to customize the code:
* Add "?" nullable type operator for each property
* set a default value for each property.  Examples:
   * `public string? Alignment { get; set; } = string.Empty;`
   * `public int? AnimalHandling { get; set; } = int.MinValue;`
   * `public List<Action>? Actions { get; set; } = new List<Action>();`

```

You can also use a ChatGPT prompt like the following to automate these steps:

```
Please make the following changes to this class:

1. Convert each public field to a nullable property by adding {get; set;} and ensuring the property has the ? nullable operator.
2. Set a default value for each property. string.empty for strings, empty lists for lists and int.MinValue for ints.
3. Add XML summaries for each property.
4. Add XML summary to class.
public class Root
{
...
}

Inherit from `IGameComponent` and implement interface.  Generally this will involve the addition of the following:

```csharp
    /// <summary>
    /// Gets or sets the description of the game component.
    /// </summary>
    [JsonProperty("desc")] // This will be the field in the JSON that describes game component.
    public string? Desc { get; set; } = string.Empty;

    /// <inheritdoc/>
    public List<string>? Labels { get; set; } = new List<string> { };

    /// <summary>
    /// Gets or sets the name of the game component.
    /// </summary>
    [JsonProperty("name")] // This will be the field in the JSON that describes name component.
    public string? Name { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string? SourceTitle { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string? TagSymbol { get; set; } = string.Empty;

    /// <inheritdoc/>
    public List<string>? Labels { get; set; } = new List<string> { };

    /// <inheritdoc/>
    public CampaignEntry ToCampaignEntry()
    {
        // Create a markdown representation of the data.
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"# {this.Name}");
        stringBuilder.AppendLine(this.Desc);

        // Add other text generation steps here.

        // Add Attribution
        if (!string.IsNullOrEmpty(this.SourceTitle))
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Source: ~\"{this.SourceTitle}\"");
        }

        CampaignEntry campaignEntry = new ()
        {
            RawText = string.Empty,
            RawPublic = stringBuilder.ToString(),
            Labels = this.Labels,
            TagSymbol = this.TagSymbol,
            TagValue = this.Name,
        };

        return campaignEntry;
    }
```

### Encapsulate Business Logic
Ideally business logic should be encapsulated within an object that is used by the service and can be independently tested with a unit test.  
In most cases this all of the logic can be encapsulated within the JSON serialization/deserialization class.  See: `CampaignKit.Compendium.DungeonsAndDragons.SRD.SRDGear` for a simple example.
For more complex business logic, a helper class should be created that can be called from either the compendium
service or from the unit testing project.  See: `MarkdownHelper` and 'ChatGPTHelper` for examples.

## Quality Assurance

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


### Add Default Configuration
A default public compendium should be added to `appsettings.json` to demonstrate the basic use of the module.

### Create Project README.md
Every project must have a README.md file that explains the following:
1. Purpose of the module.
1. Basic configuration of the module.
1. In the project properties ensure that the following properties are set:
    1. **Package > General > README** - Select the README file you just created.

### Update Solution README.md
After each project this file should be reviewed to see if any additional changes need to be made.
At minimum the module should be added to the `## Modules` section.

## Update CONTRIBUTING.md
After each project this file should be reviewed to see if any additional changes need to be made.
