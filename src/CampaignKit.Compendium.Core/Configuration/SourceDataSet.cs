// <copyright file="SourceDataSet.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Configuration
{
    /// <summary>
    /// Represents a set of source data for a Tabletop Role-Playing Game (TTRPG) system.
    /// </summary>
    public class SourceDataSet
    {
        /// <summary>
        /// Gets or sets the limit on the number of items to import into the compendium
        /// from the data source.  Generally this is only used for testing purposes
        /// to limit the size of the generated compendiums.
        /// </summary>
        public int? ImportLimit { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets a list of default labels to apply to all entries imported
        /// from this data source.
        /// </summary>
        public List<string> Labels { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the name of the parser to use for deserializing license data.
        /// </summary>
        public string LicenseDataParser { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Uniform Resource Identifier (URI) where the license data for the game source data is located.
        /// </summary>
        public string LicenseDataURI { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether new data should be downloaded to replace
        /// existing data.
        /// </summary>
        public bool OverwriteExisting { get; set; } = false;

        /// <summary>
        /// Gets or sets the name of the source data set. This is primarily used for identification purposes.
        /// </summary>
        public string SourceDataSetName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the parser to use for deserializing source data.
        /// </summary>
        public string SourceDataSetParser { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Uniform Resource Identifier (URI) where the actual game source data is located.
        /// </summary>
        public string SourceDataSetURI { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of XPath/HTML susbstitutions to use with for this data source.
        /// </summary>
        public List<Substitution> Substitutions { get; set; } = new List<Substitution> { };

        /// <summary>
        /// Gets or sets the tag entry to use for campaign entries derived from this source.
        /// </summary>
        public string TagSymbol { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tag value prefix for this game component.
        /// </summary>
        public string? TagValuePrefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the XPath of the starting element in the data set.
        /// </summary>
        public string? XPath { get; set; } = string.Empty;
    }
}