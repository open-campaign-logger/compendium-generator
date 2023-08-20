using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Markdown.Common;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using CampaignKit.Compendium.WebScraper.Common;
using CampaignKit.Compendium.WOIN.Common;

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
    }
}
