﻿// <copyright file="Program.cs" company="Jochen Linnemann - IT-Service">
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

    using CampaignKit.Compendium.Core.Common;
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;
    using CampaignKit.Compendium.DungeonsAndDragons.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
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
                    configuration.AddUserSecrets<Program>();
                })

                // Configure services to add the SourceHelper class.
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IDownloadService, DefaultDownloadService>();
                    services.AddTransient<IConfigurationService, DefaultConfigurationService>();
                    services.AddTransient<IDungeonsAndDragonsCompendiumService_5e, DefaultDungeonsAndDragonsCompendiumService_5e>();
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

            // Process compendiums
            var configurationService = host.Services.GetRequiredService<IConfigurationService>();
            var compendiums = configurationService.GetAllCompendiums();
            foreach (var comp in compendiums)
            {
                // Assume the assembly name is the part of the type name before the first dot.
                var classNameParts = comp.CompendiumService.Split(",");
                var className = classNameParts[0].Trim();
                var assemblyName = classNameParts[1].Trim();

                // Load the assembly.
                Assembly assembly = Assembly.Load(assemblyName);

                // Now try to get the type again.
                var serviceType = assembly.GetType(className) ?? throw new Exception($"Unable to load class: {className}");
                var t = Type.GetType(comp.CompendiumService) as Type;
                ICompendiumService compendiumService = (ICompendiumService) host.Services.GetRequiredService(serviceType);
                await compendiumService.CreateCompendiums();
            }
        }
    }
}