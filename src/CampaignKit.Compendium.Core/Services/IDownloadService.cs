// <copyright file="IDownloadService.cs" company="Jochen Linnemann - IT-Service">
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
    /// <summary>
    /// Interface for a service that downloads source data for tabletop role-playing games.
    /// </summary>
    public interface IDownloadService
    {
        /// <summary>
        /// Download the source data and source license.
        /// </summary>
        /// <param name="sourceDataUri">The URI of the source data to download.</param>
        /// <param name="rootDataFolder">The folder to download the data to.</param>
        /// <param name="overwrite">Set to true to overwrite previously downloaded files.  Default: false.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DownloadFile(string sourceDataUri, string rootDataFolder, bool overwrite = false);

        /// <summary>
        /// Separates the given source data URI into its path and file components.
        /// </summary>
        /// <param name="sourceDataUri">The source data URI to separate.</param>
        /// <param name="path">The path component of the URI.</param>
        /// <param name="file">The file component of the URI.</param>
        void DerivePathAndFileNames(string sourceDataUri, out string path, out string file);
    }
}
