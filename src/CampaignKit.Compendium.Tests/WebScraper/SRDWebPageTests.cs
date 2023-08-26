using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Markdown.Common;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using CampaignKit.Compendium.WebScraper.Common;
using CampaignKit.Compendium.WOIN.Common;

using HtmlAgilityPack;

using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.WebScraper
{
    [TestClass]
    public class SRDWebPageTests
    {

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\vehicle-combat.html")]
        public void SRDWebPageHelper_LoadHtmlDocumentNoStartingNode_NavigationSuccessful()
        {
            // Arrange
            var html = File.ReadAllText("vehicle-combat.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html);

            // Assert
            Assert.IsNotNull(document);
            Assert.AreEqual(document.DocumentNode.SelectNodes("//head").Count, 1);
        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\vehicle-combat.html")]
        public void SRDWebPageHelper_LoadHtmlDocumentStartingNode_NavigationSuccessful()
        {
            // Arrange
            var html = File.ReadAllText("vehicle-combat.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//div[@role='main'][1]");

            // Assert
            Assert.IsNotNull(document);
            Assert.AreEqual(document.DocumentNode.FirstChild.Name, "div");
        }

        [TestMethod]
        public void SRDWebPage_PostProcessMarkdown_BoldSyntaxReplaced()
        {
            // Arrange
            var markdown = "This is an **example of** text that has some of its elements **bold via markdown syntax**";

            // Act
            var postProcessedMarkdown = (new SRDWebPage()).PostProcessMarkdown(markdown);

            // Assert
            Assert.IsNotNull(postProcessedMarkdown);
            Assert.AreEqual(postProcessedMarkdown, "This is an {b|example of} text that has some of its elements {b|bold via markdown syntax}");
        }

        [TestMethod]
        public void SRDWebPage_PostProcessMarkdown_MisalignedListsFixed()
        {
            // Arrange
            var markdown = "- MAGIC (MAG)\n    - \n\nMagical power; its source can vary – it might be favours from a god, or a wellspring of internal arcane energy, but it is used to determine how powerful your spells are and which spells you are able to cast.";

            // Act
            var postProcessedMarkdown = (new SRDWebPage()).PostProcessMarkdown(markdown);

            // Assert
            Assert.IsNotNull(postProcessedMarkdown);
            Assert.AreEqual(postProcessedMarkdown, "- MAGIC (MAG)\n    - Magical power; its source can vary – it might be favours from a god, or a wellspring of internal arcane energy, but it is used to determine how powerful your spells are and which spells you are able to cast.");
        }

        [TestMethod]
        public void SRDWebPage_PostProcessMarkdown_MisalignedHeaders()
        {
            // Arrange
            var markdown = "# Future Careers\n\n## \n\nAcademy [3 years]";

            // Act
            var postProcessedMarkdown = (new SRDWebPage()).PostProcessMarkdown(markdown);

            // Assert
            Assert.IsNotNull(postProcessedMarkdown);
            Assert.AreEqual(postProcessedMarkdown, "# Future Careers\n\n## Academy [3 years]");
        }


    }
}
