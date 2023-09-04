// <copyright file="TreeNode.cs" company="Jochen Linnemann - IT-Service">
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
    using System.Collections.Generic;

    /// <summary>
    /// TreeNode represents a node in a tree.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        public TreeNode()
        {
            this.Children = new List<TreeNode>();
        }

        /// <summary>
        /// Gets or sets the tree node text.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tree node value.
        /// </summary> 
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of child nodes of the current TreeNode.
        /// </summary>
        public IEnumerable<TreeNode> Children { get; set; }
    }
}
