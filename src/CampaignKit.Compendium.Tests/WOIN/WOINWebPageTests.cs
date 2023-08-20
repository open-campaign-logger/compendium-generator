using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Markdown.Common;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using CampaignKit.Compendium.WebScraper.Common;
using CampaignKit.Compendium.WOIN.Common;

using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.WOIN
{
    [TestClass]
    public class WOINWebPageTests
    {

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\vehicle-combat.html")]
        public void WOINWebPageHelper_LoadHtmlDocumentNoStartingNode_NavigationSuccessful()
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
        public void WOINWebPageHelper_LoadHtmlDocumentSectionWithTable_TableParsedCorrectly()
        {
            // Arrange
            var html = File.ReadAllText("vehicle-combat.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//*[@id=\"h.5661394040d4f06b_527\"]");
            var sectionNode = WOINWebPageHelper.ParseSectionContent(document.DocumentNode);
            var table = sectionNode.SelectSingleNode(".//table");

            // Assert
            Assert.IsNotNull(document);
            Assert.IsNotNull(table);
            Assert.AreEqual(7, table.ChildNodes.Count);
            Assert.AreEqual(1, sectionNode.SelectNodes(".//table").Count);
            Assert.AreEqual(7, sectionNode.SelectNodes(".//tr").Count);
            Assert.AreEqual(2, sectionNode.SelectNodes(".//th").Count);
            Assert.AreEqual(12, sectionNode.SelectNodes(".//td").Count);
        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\vehicle-combat.html")]
        public void WOINWebPageHelper_LoadHtmlDocumentSectionWithUnorderedList_ListParsedCorrectly()
        {
            // Arrange
            var html = File.ReadAllText("vehicle-combat.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//*[@id=\"h.5661394040d4f06b_567\"]");
            var sectionNode = WOINWebPageHelper.ParseSectionContent(document.DocumentNode);
            var list = sectionNode.SelectSingleNode(".//ul");

            // Assert
            Assert.IsNotNull(document);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.ChildNodes.Count);
            Assert.AreEqual("ul", list.Name);
            Assert.AreEqual(4, list.SelectNodes(".//li").Count);
        }
    }
}
