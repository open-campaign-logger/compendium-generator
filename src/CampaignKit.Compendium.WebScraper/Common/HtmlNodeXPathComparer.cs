// <copyright file="HtmlNodeXPathComparer.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.WebScraper.Common
{
    using HtmlAgilityPack;

    /// <summary>
    /// Comparer class to use for HtmlAgilityPack HtmlNode objects.
    /// </summary>
    public class HtmlNodeXPathComparer : IEqualityComparer<HtmlNode>
    {
        /// <summary>
        /// The Equals method compares two HtmlNode objects based on their XPath values.If both
        /// objects are null, they are considered equal. If one of them is null, they are not equal.
        /// If both have non-null XPath values, their equality is determined by comparing those values.
        /// </summary>
        /// <param name="x">HtmlNode 1 to use for comparison.</param>
        /// <param name="y">HtmlNode 2 to use for comparison.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public bool Equals(HtmlNode? x, HtmlNode? y)
        {
            // If both nodes are null, they are equal
            if (x == null && y == null)
            {
                return true;
            }

            // If one of the nodes is null, they are not equal
            if (x == null || y == null)
            {
                return false;
            }

            // Compare the XPath values of the nodes
            return x.XPath == y.XPath;
        }

        /// <summary>
        /// The GetHashCode method returns a hash code for the HtmlNode object based on its XPath value.
        /// </summary>
        /// <param name="obj">The HtmlNode.</param>
        /// <returns>Hash code based on the HtmlNode's XPathvalue.</returns>
        public int GetHashCode(HtmlNode obj)
        {
            // If the node is null, return 0
            if (obj == null)
            {
                return 0;
            }

            // If the XPath is null, return 0, otherwise return the hash code of the XPath
            return obj.XPath?.GetHashCode() ?? 0;
        }
    }
}
