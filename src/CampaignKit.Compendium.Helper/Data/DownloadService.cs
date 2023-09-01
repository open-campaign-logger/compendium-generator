// <copyright file="CompendiumService.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper.Data
{
    /// <summary>
    /// CompendiumService provides methods for retrieving and manipulating compendium data.
    /// </summary>
    public class DownloadService
    {

        private readonly ILogger<DownloadService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadService"/> class.
        /// </summary>
        /// <param name="logger">Logger object for logging.</param>
        /// <returns>
        /// CompendiumService object.
        /// </returns>
        public DownloadService(ILogger<DownloadService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Asynchronously retrieves the contents of a web page from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the web page.</param>
        /// <returns>The contents of the web page.</returns>
        public async Task<string> GetWebPage(string url)
        {
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
            this.logger.LogDebug("Starting to download file: {sourceDataUri}.", url);
            var response = await client.GetAsync(url);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response as a string
            var content = await response.Content.ReadAsStringAsync();

            // Log the response
            this.logger.LogDebug("Downloaded file: {sourceDataUri}.", url);

            // Return the response
            return content;
        }
    }
}
