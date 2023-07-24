# Adding a New Module
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

# Deserializing JSON Files

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