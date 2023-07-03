// <copyright file="DownloadService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Represents a downloader for TTRPG (Tabletop Role-Playing Games) source data.
    /// </summary>
    public class DownloadService
    {
        // Create a private readonly field to store an ILogger instance
        // with the type CompendiumSourceDownloader
        private readonly ILogger<DownloadService> logger;

        // Create a private readonly field to store an IConfiguration instance.
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the downloader.</param>
        /// <param name="configuration">Application configuration information.</param>
        /// <returns>
        /// A CompendiumSourceDownloader instance.
        /// </returns>
        public DownloadService(ILogger<DownloadService> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Download the source data and source license.
        /// </summary>
        /// <param name="sourceDataUri">The URI of the source data to download.</param>
        /// <param name="rootDataFolder">The folder to download the data to.</param>
        /// <param name="overwrite">Set to true to overwrite previously downloaded files.  Default: false.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task DownloadFile(string sourceDataUri, string rootDataFolder, bool overwrite = false)
        {
            try
            {
                string path, page;
                DerivePathAndFileNames(sourceDataUri, out path, out page);

                // If overwrite = false and the file already exists, return.
                var localFolderPath = Path.Combine(rootDataFolder, path);
                var localFilePath = Path.Combine(localFolderPath, page);
                if (!overwrite && File.Exists(localFilePath))
                {
                    logger.LogInformation("Local file already exists: {localFilePath}.  Overwrite option set to false.  Skipping download.", localFilePath);
                    return;
                }

                // Create data folder if required.
                if (!Directory.Exists(localFolderPath))
                {
                    logger.LogDebug("Creating directory for source files: {localDataFolder}.", localFolderPath);
                    Directory.CreateDirectory(localFolderPath);
                }

                // Create an HTTP client
                using var client = new HttpClient();

                // Send a GET request to the URL
                logger.LogDebug("Starting to download file: {sourceDataUri}.", sourceDataUri);
                var response = await client.GetAsync(sourceDataUri);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response as a stream
                var responseBody = await response.Content.ReadAsStreamAsync();

                // Create a new file in the data folder
                using var fs = File.Create(localFilePath);

                // Write the response stream to the file
                await responseBody.CopyToAsync(fs);
            }
            catch (HttpRequestException e)
            {
                // If an error occurs, print the error message and re-throw the exception
                logger.LogError("Error downloading file: {e.Message}", e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Separates the given source data URI into its path and file components.
        /// </summary>
        /// <param name="sourceDataUri">The source data URI to separate.</param>
        /// <param name="path">The path component of the URI.</param>
        /// <param name="file">The file component of the URI.</param>
        public void DerivePathAndFileNames(string sourceDataUri, out string path, out string file)
        {
            // Separate the URI into components
            logger.LogDebug("Parsing components of URI: {sourceDataUri}.", sourceDataUri);
            var uri = new Uri(sourceDataUri);
            path = uri.AbsolutePath;
            file = Path.GetFileName(uri.AbsolutePath);

            // Trim the leading slash off the uriPath.
            if (path.StartsWith("/"))
            {
                path = path[1..];
            }

            // Remove the page name from the path.
            path = Path.GetDirectoryName(path) ?? path;
            logger.LogDebug("URI Path: {path}.", path);
            logger.LogDebug("URI Page: {page}.", file);
        }
    }
}