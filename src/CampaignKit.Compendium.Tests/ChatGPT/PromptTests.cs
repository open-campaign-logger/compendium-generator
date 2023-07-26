using CampaignKit.Compendium.ChatGPT.Common;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Core.Services;
using CampaignKit.Compendium.Markdown.Common;

using Microsoft.Extensions.Configuration;

namespace CampaignKit.Compendium.Tests.ChatGPT
{
    [TestClass]
    public class PromptTests
    {
        private IConfigurationService? configurationService;

        private IConfigurationService GetConfigurationService()
        {
            if (configurationService != null)
            {
                return configurationService;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<PromptTests>()
                .AddEnvironmentVariables();

            var configuration = builder.Build(); // Build the configuration

            return new DefaultConfigurationService(configuration);

        }

        [TestMethod]
        public void ChatGPT4Prompt_D100RollTable_ValidMarkdown()
        {
            // Arrange
            var prompt = new Prompt()
            {
                Genre = "Fantasy",
                Labels = new List<string>()
                {
                    "Rolltable",
                    "Cricial",
                    "D&D 5e",
                    "Melee"
                },
                Name = "Critical Fail - Melee",
                OverwriteExisting = true,
                PromptInput = "Mishaps associated with critical fails during a melee attack.",
                PromptTemplate = "rolltable-d100.txt",
                Sentiment = 2,
                Service = "ChatGPT 4",
                TagSymbol = "~",
            };
            var service = GetConfigurationService().GetService(prompt.Service);

            // Act
            var campaignEntry = ChatGPTHelper.ParseCampaignEntries(service, prompt, GetConfigurationService().GetPrivateDataDirectory(), "Dungeons and Dragons 5e").Result;

            // Assert
        }
    }
}
