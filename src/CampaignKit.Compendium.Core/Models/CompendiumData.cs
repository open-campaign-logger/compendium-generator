// <copyright file="CompendiumData.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Source compendium data to be parsed and formatted by the utility program.
    /// </summary>
    public class CompendiumData
    {
        /// <summary>
        /// Gets or sets primary key for monster.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of the source data set.  Example: Kobold Press - Tome of Beasts.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the source data set.
        /// </summary>
        public string URL { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the license description for the source data set.
        /// </summary>
        public string License { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the compendium data for the source data set.
        /// </summary>
        public byte[] Data { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Gets or sets the name of the parser to use for this data set.
        /// </summary>
        public string Parser { get; set; } = string.Empty;
    }
}
