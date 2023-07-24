// <copyright file="DefaultApplication.cs" company="Jochen Linnemann - IT-Service">
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
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using CampaignKit.Compendium.Core.Configuration;
    using CampaignKit.Compendium.Core.Services;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Provides the default implementation of the <see cref="IApplication"/> interface.
    /// This class is responsible for retrieving all compendiums from the configuration,
    /// ensuring that each compendium has an associated service, and running each
    /// compendium service to create compendiums.
    /// </summary>
    /// <remarks>
    /// This class depends on an <see cref="IServiceProvider"/> to retrieve dependencies,
    /// an <see cref="ILogger"/> to log messages, and an <see cref="IConfigurationService"/>
    /// to retrieve the configuration for the compendiums. Each of these dependencies is
    /// provided through dependency injection.
    /// </remarks>
    public class DefaultApplication : IApplication
    {
        /// <summary>
        /// Stores a reference to the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Create a private readonly field to store an ILogger instance.
        /// </summary>
        private readonly ILogger<DefaultApplication> logger;

        /// <summary>
        /// Create a private readonly field to store an IConfigurationService instance.
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApplication"/> class.
        /// Constructor for DefaultApplication class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configurationService">The configuration service.</param>
        /// <returns>
        /// An instance of DefaultApplication.
        /// </returns>
        public DefaultApplication(IServiceProvider serviceProvider, ILogger<DefaultApplication> logger, IConfigurationService configurationService)
        {
            // Check if serviceProvider is null, if so throw an ArgumentNullException
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            // Check if logger is null, if so throw an ArgumentNullException
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Check if configurationService is null, if so throw an ArgumentNullException
            this.configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }

        /// <summary>
        /// Asynchronously runs the application. It retrieves all compendiums from the
        /// configuration, ensures that compendiums are available and each has an associated
        /// service. For each compendium, it loads the assembly containing the compendium service,
        /// retrieves an instance of the compendium service, and then calls the CreateCompendiums
        /// method on the compendium service.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the configuration service is not provided.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown when no compendiums are found in the configuration, a compendium does not have an
        /// associated service, the service type could not be retrieved, or the compendium service
        /// could not be retrieved from the service provider.
        /// </exception>
        public async Task RunAsync()
        {
            this.logger.LogDebug("Starting application : {application}.", nameof(DefaultApplication));

            // Ensure that the configuration service has been provided
            if (this.configurationService == null)
            {
                throw new ArgumentNullException(nameof(this.configurationService), "The configuration service cannot be null.");
            }

            // Retrieve all compendiums from the configuration
            var publicCompendiums = this.configurationService.GetAllPublicCompendiums();

            // Process each public compendium
            foreach (var comp in publicCompendiums)
            {
                await this.ProcessCompendium(comp, this.configurationService.GetPublicDataDirectory());
            }

            // Retrieve all private compendiums from the configuration
            var privateCompendiums = this.configurationService.GetAllPrivateCompendiums();

            // Process each private compendium
            foreach (var comp in privateCompendiums)
            {
                await this.ProcessCompendium(comp, this.configurationService.GetPrivateDataDirectory());
            }

            this.logger.LogDebug("Stopping application : {application}.", nameof(DefaultApplication));
        }

        private async Task ProcessCompendium(ICompendium comp, string rootDataDirectory)
        {
            // Ensure that a service name has been provided for the compendium
            if (string.IsNullOrWhiteSpace(comp.CompendiumService))
            {
                throw new Exception($"Compendium {comp.Title} does not have an associated service.");
            }

            // Split the CompendiumService string into class name and assembly name
            var classNameParts = comp.CompendiumService.Split(",");

            // Ensure that class and package have both been provided.
            if (classNameParts.Length != 2)
            {
                throw new Exception($"Wrong number of elements specified for {nameof(comp.CompendiumService)} parameter.  Expecting \"class name, assembly name\".");
            }

            // Load the assembly containing the compendium service
            var className = classNameParts[0].Trim();
            var assemblyName = classNameParts[1].Trim();
            Assembly assembly = Assembly.LoadFrom(assemblyName);

            // Get the type of the compendium service
            var serviceType = assembly.GetType(className)
                ?? throw new Exception($"Unable to load class: {className}");

            // Retrieve an instance of the compendium service from the service provider
            ICompendiumService compendiumService = (ICompendiumService)this.serviceProvider.GetRequiredService(serviceType)
                ?? throw new Exception($"Unable to retrieve service: {serviceType.FullName}");

            // Create the compendiums
            await compendiumService.CreateCompendiums(comp, rootDataDirectory);
        }
    }
}
