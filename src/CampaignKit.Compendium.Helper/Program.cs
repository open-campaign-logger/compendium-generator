// <copyright file="Program.cs" company="Jochen Linnemann - IT-Service">
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

namespace CampaignKit.Compendium.Helper
{
    using CampaignKit.Compendium.Helper.Services;
    using Radzen;

    /// <summary>
    /// Default Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method for the application, configures the HTTP request pipeline and adds services
        /// to the container.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the builder
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddServerSideBlazor().AddHubOptions(o =>
            {
                o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
            });
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            // Add singleton services to the builder
            builder.Services.AddSingleton<DownloadService>();
            builder.Services.AddSingleton<MarkdownService>();
            builder.Services.AddSingleton<HtmlService>();
            builder.Services.AddSingleton<CompendiumService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Redirect all requests to HTTPS
            app.UseHttpsRedirection();

            // Serve static files from the wwwroot folder
            app.UseStaticFiles();

            // Set up routing
            app.UseRouting();

            // Add support for controllers
            app.MapControllers();

            // Map the Blazor Hub
            app.MapBlazorHub();

            // Map the fallback page to the _Host page
            app.MapFallbackToPage("/_Host");

            // Run the application
            app.Run();
        }
    }
}
