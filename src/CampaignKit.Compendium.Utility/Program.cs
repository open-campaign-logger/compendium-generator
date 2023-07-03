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
    using CampaignKit.Compendium.Core; // Import the CampaignKit.Compendium.Core namespace
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection; // Import the Microsoft.Extensions.DependencyInjection namespace
    using Microsoft.Extensions.Hosting; // Import the Microsoft.Extensions.Hosting namespace
    using Microsoft.Extensions.Logging; // Import the Microsoft.Extensions.Logging namespace

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
                    services.AddTransient<SourceHelper>();
                })

                // Configure logging to clear existing providers and add the console provider.
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })

                // Build the host.
                .Build();

            // Get the SourceHelper service from the host
            var downloader = host.Services.GetRequiredService<SourceHelper>();

            // Get configuration
            var configuration = host.Services.GetRequiredService<IConfiguration>();

            // Download Dungeons and Dragons source files
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            string rootDataFolder = "C:\\source\\compendium-generator\\data";
            await downloader.DownloadFile(sourceDataUri, rootDataFolder);
        }
    }
}