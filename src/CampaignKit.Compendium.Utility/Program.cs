// <copyright file="Program.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2021 Jochen Linnemann, Cory Gill.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace CampaignKit.Compendium.Utility
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Loader;
    using System.Text.RegularExpressions;
    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection; // Import the Microsoft.Extensions.DependencyInjection namespace
    using Microsoft.Extensions.Hosting; // Import the Microsoft.Extensions.Hosting namespace
    using Microsoft.Extensions.Logging; // Import the Microsoft.Extensions.Logging namespace
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;

    /// <summary>
    /// Creates a host with default configuration, adds required services, configures logging,
    /// gets the SourceHelper service from the host, and uses the downloader.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates a host with default configuration, adds required services, and
        /// configures logging.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            // Create a host with default configuration
            var host = Host.CreateDefaultBuilder()

                // Add Configuration to host
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    configuration.AddEnvironmentVariables();
                })

                // Configure services to add the SourceHelper class.
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<DownloadService>();
                })

                // Configure logging to clear existing providers and add the console provider.
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                })

                // Build the host.
                .Build();

            // Access services from the host
            var downloadService = host.Services.GetRequiredService<DownloadService>();
            var configuration = host.Services.GetRequiredService<IConfiguration>();
            var loggerFactory = host.Services.GetService<ILoggerFactory>() ?? new LoggerFactory();
            var logger = loggerFactory.CreateLogger(typeof(Program));
            var rootDataFolder = configuration.GetValue<string>("RootDataFolder") ?? Path.Combine(Path.GetTempPath(), "CompendiumGenerator");

            // Process each campaign entry
            var compendiums = new List<Compendium>();
            configuration.GetSection("Compendiums").Bind(compendiums);
            foreach (var compendium in compendiums)
            {
                logger.LogInformation("Processing Compendium: {campaign}.", compendium.Title);

                // Process campaign data sets
                if (compendium.SourceDataSets is not null)
                {
                    // Download data sets
                    foreach (var sourceDataSet in compendium.SourceDataSets)
                    {
                        // Setup local variables
                        downloadService.DerivePathAndFileNames(sourceDataSet.LicenseDataURI, out string licenseDirectory, out string licenseFile);
                        var licenseFilePath = Path.Combine(rootDataFolder, licenseDirectory, licenseFile);

                        logger.LogInformation("Downloading license data for data set: {SourceDataSetName}.", sourceDataSet.SourceDataSetName);
                        await downloadService.DownloadFile(
                            sourceDataSet.LicenseDataURI,
                            rootDataFolder,
                            sourceDataSet.OverwriteExisting);

                        logger.LogDebug("Reading local copy of license data from: {LicenseFilePath}.", licenseFilePath);
                        var licenseJSON = File.ReadAllText(Path.Combine(rootDataFolder, licenseDirectory, licenseFile))
                            ?? throw new Exception($"Unable to read license information from file: {licenseFilePath}.");

                        logger.LogDebug("Parsing local copy of license data using parser: {LicenseDataParser}.", sourceDataSet.LicenseDataParser);
                        string assemblyPath = AppDomain.CurrentDomain.BaseDirectory + "CampaignKit.Compendium.DungeonsAndDragons.dll";
                        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                        var licenseParserType = assembly.GetType(sourceDataSet.LicenseDataParser)
                            ?? throw new Exception($"Unable to recognize license parser class type: {sourceDataSet.LicenseDataParser}.");
                        var genericListType = typeof(List<>).MakeGenericType(licenseParserType)
                            ?? throw new Exception($"Unable to create list of license parser class type: {sourceDataSet.LicenseDataParser}.");
                        var license = JsonConvert.DeserializeObject(licenseJSON, genericListType);

                        //logger.LogInformation("Downloading source data for data set: {name}.", sourceDataSet.SourceDataSetName);
                        //await downloadService.DownloadFile(
                        //    sourceDataSet.SourceDataURI ?? string.Empty,
                        //    rootDataFolder,
                        //    sourceDataSet.OverwriteExisting ?? false);

                        //downloadService.DerivePathAndFileNames(sourceDataSet.SourceDataURI ?? string.Empty, out string sourceDataDirectory, out string sourceDataFile);
                    }
                }
            }
        }
    }
}