// <copyright file="CompendiumSourceDownloader.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Base
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a downloader for TTRPG (Tabletop Role-Playing Games) source data.
    /// </summary>
    public class CompendiumSourceDownloader
    {
        // The folder to download the data to.
        private readonly string dataFolder;

        // The URL to download the source data from.
        private readonly string sourceDataUrl;

        // The URL to download the source license from.
        private readonly string sourceLicenseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompendiumSourceDownloader"/> class.
        /// </summary>
        /// <param name="sourceDataUrl">The URL of the source data to download.</param>
        /// <param name="sourceLicenseUrl">The URL of the source license to download.</param>
        /// <param name="dataFolder">The folder to download the data to.</param>
        public CompendiumSourceDownloader(string? sourceDataUrl, string? sourceLicenseUrl, string? dataFolder)
        {
            this.sourceDataUrl = sourceDataUrl ?? throw new ArgumentNullException(nameof(sourceDataUrl));
            this.sourceLicenseUrl = sourceLicenseUrl ?? throw new ArgumentNullException(nameof(sourceLicenseUrl));
            this.dataFolder = dataFolder ?? throw new ArgumentNullException(nameof(dataFolder));
        }

        /// <summary>
        /// Download the source data and source license.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task GetSourceData()
        {
            // Download the source data and save it as sourceData.json
            await this.DownloadFile(this.sourceDataUrl, "sourceData.json");

            // Download the source license and save it as sourceLicense.txt
            await this.DownloadFile(this.sourceLicenseUrl, "sourceLicense.txt");
        }

        /// <summary>
        /// Download a file from a URL and save it to a local file.
        /// </summary>
        /// <param name="url">The URL to download the file from.</param>
        /// <param name="fileName">The name of the file to save the data to.</param>
        private async Task DownloadFile(string url, string fileName)
        {
            try
            {
                // Create an HTTP client
                using var client = new HttpClient();

                // Send a GET request to the URL
                var response = await client.GetAsync(url);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response as a stream
                var responseBody = await response.Content.ReadAsStreamAsync();

                // Create data folder if required
                if (!Directory.Exists(this.dataFolder)) {
                    Directory.CreateDirectory(this.dataFolder);
                }

                // Create a new file in the data folder
                using var fs = File.Create(Path.Combine(this.dataFolder, fileName));

                // Write the response stream to the file
                await responseBody.CopyToAsync(fs);
            }
            catch (HttpRequestException e)
            {
                // If an error occurs, print the error message and re-throw the exception
                Console.WriteLine($"Error downloading file: {e.Message}");
                throw;
            }
        }
    }
}