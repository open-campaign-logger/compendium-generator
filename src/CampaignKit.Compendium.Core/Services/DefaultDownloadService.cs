// <copyright file="DefaultDownloadService.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2023 Jochen Linnemann, Cory Gill.
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
    /// Default service for downloading source data for tabletop role-playing games.
    /// </summary>
    public class DefaultDownloadService : IDownloadService
    {
        // Create a private readonly field to store an ILogger instance.
        private readonly ILogger<DefaultDownloadService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDownloadService"/> class.
        /// </summary>
        /// <param name="logger">The logger for the service.</param>
        /// <returns>
        /// A CompendiumSourceDownloader instance.
        /// </returns>
        public DefaultDownloadService(ILogger<DefaultDownloadService> logger)
        {
            // Check if logger is null, if so throw an ArgumentNullException
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public virtual async Task<string> DownloadFile(
            string sourceDataUri,
            string rootDataDirectory,
            bool overwrite = false,
            string filenameOverride = "default",
            FilenameOverrideOptions filenameOverrideOption = FilenameOverrideOptions.ReplaceIfBlank)
        {
            try
            {
                this.DerivePathAndFileNames(sourceDataUri, out string path, out string file, filenameOverride, filenameOverrideOption);

                // If overwrite = false and the file already exists, return.
                var localFolderPath = Path.Combine(rootDataDirectory, path);
                var localFilePath = Path.Combine(localFolderPath, file);
                if (!overwrite && File.Exists(localFilePath))
                {
                    this.logger.LogInformation("Local file already exists: {localFilePath}.  Overwrite option set to false.  Skipping download.", localFilePath);
                    return localFilePath;
                }

                // Create data folder if required.
                if (!Directory.Exists(localFolderPath))
                {
                    this.logger.LogDebug("Creating directory for source files: {localDataFolder}.", localFolderPath);
                    Directory.CreateDirectory(localFolderPath);
                }

                // Create an HTTP client
                using var client = new HttpClient();

                // Set request headers
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("Pragma", "no-cache");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");

                // Request non-compressed output
                client.DefaultRequestHeaders.Add("Accept-Encoding", "identity");

                // Send a GET request to the URL
                this.logger.LogDebug("Starting to download file: {sourceDataUri}.", sourceDataUri);
                var response = await client.GetAsync(sourceDataUri);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response as a stream
                var responseBody = await response.Content.ReadAsStreamAsync();

                // Create a new file in the data folder
                using var fs = File.Create(localFilePath);

                // Write the response stream to the file
                await responseBody.CopyToAsync(fs);

                // Return the file location.
                return localFilePath;
            }
            catch (HttpRequestException e)
            {
                // If an error occurs, print the error message and re-throw the exception
                this.logger.LogError("Error downloading file: {e.Message}", e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Separates the given URI into components and assigns the path and file name to the out parameters.
        /// </summary>
        /// <param name="sourceDataUri">The URI to be separated.</param>
        /// <param name="path">The path component of the URI.</param>
        /// <param name="file">The file name component of the URI.</param>
        /// <param name="filenameOverride">Optional filename override for URIs from which deriving a filename is difficult.</param>
        /// <param name="filenameOverrideOption">The behaviour to use when deciding how (or if) to override the filename.</param>
        private void DerivePathAndFileNames(
            string sourceDataUri,
            out string path,
            out string file,
            string filenameOverride,
            FilenameOverrideOptions filenameOverrideOption)
        {
            // Separate the URI into components
            this.logger.LogDebug("Parsing components of URI: {sourceDataUri}.", sourceDataUri);
            var uri = new Uri(sourceDataUri);
            path = uri.AbsolutePath;
            file = Path.GetFileName(uri.AbsolutePath);

            // Check if the filenameOverrideOption is set to ReplaceAlways
            if (filenameOverrideOption == FilenameOverrideOptions.ReplaceAlways)
            {
                // If so, set the file to the filenameOverride
                file = filenameOverride;
            }

            // Check if the file is empty and the filenameOverrideOption is set to ReplaceIfBlank
            if (string.IsNullOrEmpty(file) && filenameOverrideOption == FilenameOverrideOptions.ReplaceIfBlank)
            {
                // If so, set the file to the filenameOverride
                file = filenameOverride;
            }

            // Check if the file is still empty
            if (string.IsNullOrEmpty(file))
            {
                // If so, throw an exception
                throw new Exception($"Unable to derive filename from URI: {sourceDataUri}");
            }

            // Trim the leading slash off the uriPath.
            if (path.StartsWith("/"))
            {
                path = path[1..];
            }

            // Remove the file name from the path.
            path = Path.GetDirectoryName(path) ?? path;
            this.logger.LogDebug("URI Path: {path}.", path);
            this.logger.LogDebug("URI Page: {file}.", file);
        }
    }
}