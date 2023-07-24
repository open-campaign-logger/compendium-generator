﻿// <copyright file="IApplication.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Utility.Services
{
    /// <summary>
    /// Interface defining the contract for an application runner service.
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Runs the application asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RunAsync();
    }
}