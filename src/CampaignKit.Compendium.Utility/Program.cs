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
    using CampaignKit.Compendium.Core.Services;
    using CampaignKit.Compendium.DungeonsAndDragons.Services;
    using CampaignKit.Compendium.OldSchoolEssentials.Services;
    using CampaignKit.Compendium.Utility.Services;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Creates a host with default configuration, adds required services, configures logging,
    /// gets the SourceHelper service from the host, and uses the downloader.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates a host builder and runs the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetRequiredService<IApplication>();
            if (app != null)
            {
                await app.RunAsync();
            }
            else
            {
                throw new Exception($"Unable to load application class: {nameof(DefaultApplication)}");
            }
        }

        /// <summary>
        /// Creates a host builder with default configuration, app configuration, services
        /// configuration, logging configuration and console lifetime.
        /// </summary>
        /// <param name="args">Arguments to pass to the host builder.</param>
        /// <returns>The created host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // Create a host builder using the default configuration
            return Host.CreateDefaultBuilder(args)

                // Configure the application configuration
                .ConfigureAppConfiguration(ConfigureAppConfiguration)

                // Configure the services
                .ConfigureServices(ConfigureServices)

                // Configure the logging
                .ConfigureLogging(ConfigureLogging)

                // Use the console lifetime
                .UseConsoleLifetime();
        }

        /// <summary>
        /// Configures the app configuration by clearing existing sources, setting the base path,
        /// adding appsettings.json,
        /// appsettings.hostingContext.HostingEnvironment.EnvironmentNamejson, environment
        /// variables, and user secrets.
        /// </summary>
        /// <param name="hostingContext">The hosting context.</param>
        /// <param name="configuration">The application configuration builder.</param>
        private static void ConfigureAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder configuration)
        {
            // Clear any existing sources from the configuration
            configuration.Sources.Clear();

            // Set the base path of the configuration to the current directory
            configuration.SetBasePath(Directory.GetCurrentDirectory());

            // Add the appsettings.json file to the configuration, making it non-optional and reloading it when it changes
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Add the appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json file to the configuration, making it optional
            configuration.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true);

            // Add environment variables to the configuration
            configuration.AddEnvironmentVariables();

            // Add user secrets to the configuration
            configuration.AddUserSecrets<Program>();
        }

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
        }

        /// <summary>
        /// Configures logging for the application by clearing existing providers, adding
        /// configuration from the hosting context, and adding console and debug logging providers.
        /// </summary>
        private static void ConfigureLogging(HostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            logging.AddDebug();

            // Clear any existing logging providers
            logging.ClearProviders();

            // Add configuration from the hosting context
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

            // Add console and debug logging providers
            logging.AddConsole();
            logging.AddDebug();
        }
    }
}