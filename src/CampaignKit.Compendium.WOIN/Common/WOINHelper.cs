// <copyright file="WOINHelper.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.WOIN.Common
{
    using HtmlAgilityPack;

    /// <summary>
    /// Utility class for WOIN content conversions.
    /// </summary>
    public class WOINHelper
    {
        /// <summary>
        /// Adds a new row to the specified HTML table. The row is created from the provided
        /// HtmlNode, and cells are extracted based on specific criteria. If the row is determined
        /// to be a header row, the cells will be created with the 'th' tag; otherwise, they will be
        /// created with the 'td' tag.
        /// </summary>
        /// <param name="table">The HtmlNode representing the table to which the row will be added.</param>
        /// <param name="row">
        /// The HtmlNode representing the row that will be added to the table. The row should
        /// contain span elements with class 'C9DxTc' and not contain nested span elements with
        /// class 'Apple-tab-span'.
        /// </param>
        public static void AddRowToTable(HtmlNode table, HtmlNode row)
        {
            // Create a new HTML node for the cell
            var newRow = HtmlNode.CreateNode("<tr></tr>");

            // Select all <span> elements within the row
            var cellNodes = row.SelectNodes(".//span[@class='C9DxTc ' and not(.//span[@class='Apple-tab-span '])]");

            // Iterate through each cell in the cellNodes collection
            var isHeaderRow = true;
            foreach (var cellNode in cellNodes)
            {
                // Determine if this is a header row, if so use the 'th' tag
                // for the content.  If not, use 'td'.
                var tagSymbol = isHeaderRow ? "th" : "td";
                isHeaderRow = false;

                // Create a new HTML node for the cell
                var newCellNode = HtmlNode.CreateNode($"<{tagSymbol}>{cellNode.InnerText}</{tagSymbol}>");

                // Append the cell to the cell node
                newCellNode.AppendChild(cellNode);

                // Append the cell node to the row
                newRow.AppendChild(cellNode);
            }

            // Add the row to the table
            table.AppendChild(newRow);
        }

        /// <summary>
        /// Determines if the provided HtmlNode contains table data.
        /// </summary>
        /// <param name="node">The HtmlNode to inspect.</param>
        /// <returns>True if the HtmlNod contains table data, false otherwise.</returns>
        public static bool ContainsTableData(HtmlNode node)
        {
            return node.SelectNodes(".//span[@class='Apple-tab-span ']") != null;
        }
    }
}
