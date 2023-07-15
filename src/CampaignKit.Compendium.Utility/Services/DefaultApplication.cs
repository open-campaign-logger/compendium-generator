using CampaignKit.Compendium.Core.Common;
using CampaignKit.Compendium.Core.Services;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CampaignKit.Compendium.Utility.Services
{
    public class DefaultApplication : IApplication
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultApplication(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task RunAsync()
        {
            // Process compendiums
            var configurationService = _serviceProvider.GetRequiredService<IConfigurationService>();
            var compendiums = configurationService.GetAllCompendiums();
            foreach (var comp in compendiums)
            {
                // Assume the assembly name is the part of the type name before the first dot.
                var classNameParts = comp.CompendiumService.Split(",");
                var className = classNameParts[0].Trim();
                var assemblyName = classNameParts[1].Trim();

                // Load the assembly.
                Assembly assembly = Assembly.Load(assemblyName);

                // Now try to get the type again.
                var serviceType = assembly.GetType(className) ?? throw new Exception($"Unable to load class: {className}");
                var t = Type.GetType(comp.CompendiumService) as Type;
                ICompendiumService compendiumService = (ICompendiumService)_serviceProvider.GetRequiredService(serviceType);
                await compendiumService.CreateCompendiums();
            }
        }

    }
}
