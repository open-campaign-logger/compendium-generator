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
            var promptMessages = new List<PromptMessage>();
            promptMessages.Add(new PromptMessage()
            {
                Message = "Generate a d20 rolltable in markdown format for the following:\nTopic: Mishaps due to a fumble (natural 1) on a melee attack\nGenre: {Genre}\nGame System: {GameSystem}\nSentiment: {Sentiment}",
                Heading = "Roll Table",
            });
            var prompt = new Prompt()
            {
                Genre = "Fantasy",
                Labels = new List<string>()
                {
                    "Rolltable",
                    "Fumble",
                    "D&D 5e",
                    "Melee"
                },
                Name = "Critical Fumble - Melee",
                OverwriteExisting = true,
                PromptMessages = promptMessages,
                Role = "You are a game master who helps other game masters develop rolltables to help them run their games.  When providing a response do not include introduction or closing text.  Responses should be limited to what was specifically asked for.",
                Sentiment = 2,
                Service = "ChatGPT 4",
                TagSymbol = "~",
            };
            var service = GetConfigurationService().GetService(prompt.Service);

            // Act
            if (service is null || !service.IsActive)
            {
                Assert.Fail("Service not defined, or is not active, in user secrets file: ChatGPT 4");
            }
            var campaignEntry = ChatGPTHelper.ParseCampaignEntries(service, prompt, GetConfigurationService().GetPrivateDataDirectory(), "Dungeons and Dragons 5e").Result;

            // Assert
            Assert.IsNotNull(campaignEntry);
            Assert.AreEqual(campaignEntry.TagValue, prompt.Name);
            Assert.AreEqual(campaignEntry.TagSymbol, prompt.TagSymbol);
            Assert.IsNotNull(campaignEntry.Labels);
            Assert.AreEqual(campaignEntry.Labels.Count, 4);
            Assert.IsTrue(campaignEntry.Labels.Contains("Rolltable"));
            Assert.IsTrue(campaignEntry.Labels.Contains("Fumble"));
            Assert.IsTrue(campaignEntry.Labels.Contains("D&D 5e"));
            Assert.IsTrue(campaignEntry.Labels.Contains("Melee"));
        }
    }
}
