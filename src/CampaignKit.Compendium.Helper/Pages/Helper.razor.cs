// <copyright file="Helper.razor.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper.Pages
{
    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Helper.Services;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    using Radzen;

    public partial class Helper
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected DownloadService DownloadService { get; set; }

        [Inject]
        protected CompendiumService CompendiumService { get; set; }

        [Inject]
        protected HtmlService HtmlService { get; set; }

        [Inject]
        protected MarkdownService MarkdownService { get; set; }

        [Inject]
        protected ILogger<Helper> Logger { get; set; }

        // Create a string to hold the html source.
        protected string Html { get; set; } = string.Empty;

        // Create a string to hold the markdown extract.
        protected string Markdown { get; set; } = string.Empty;

        // Create a dictionary to store events and their associated timestamps
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        // Create a list of compendiums to store uploaded data
        protected List<PublicCompendium> PublicCompendiums = new List<PublicCompendium>();

        /// <summary>
        /// Logs an event with a given name and value.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="value">The value of the event.</param>
        protected void Log(string eventName, string value)
        {
            this.events.Add(DateTime.Now, $"{eventName}: {value}");
        }

        /// <summary>
        /// Logs a change event with the item text from the TreeEventArgs.
        /// </summary>
        /// <param name="args">The TreeEventArgs containing the item text.</param>
        protected void LogChange(TreeEventArgs args)
        {
            Log("Change", $"Item Text: {args.Text}");
        }

        /// <summary>
        /// Logs the expand event of a tree item.
        /// </summary>
        /// <param name="args">The tree expand event arguments.</param>
        protected void LogExpand(TreeExpandEventArgs args)
        {
            if (args.Text is string text)
            {
                Log("Expand", $"Item Text: {text}");
            }
        }

        /// <summary>
        /// Uploads a compendium and creates a tree from it.
        /// </summary>
        /// <returns>
        /// A tree created from the uploaded compendium.
        /// </returns>
        protected async Task UploadComplete(Radzen.UploadCompleteEventArgs args)
        {
            Logger.LogInformation($"Upload complete and converted to string of length {args.RawResponse.Length}.");
            var json = args.RawResponse;
            PublicCompendiums = CompendiumService.LoadCompendiums(json);
        }

        protected override async Task OnInitializedAsync()
        {
        }
    }
}