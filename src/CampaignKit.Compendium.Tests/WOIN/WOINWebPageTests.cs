using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Markdown.Common;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using CampaignKit.Compendium.WebScraper.Common;
using CampaignKit.Compendium.WOIN.Common;

using Newtonsoft.Json;

using System.Reflection;

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
        [DeploymentItem(@"WOIN\TestFiles\fantasy-armor-customization.html")]
        public void SRDWebPage_PreProcessHtml_BoldSyntaxAdded()
        {
            // Arrange
            var html = File.ReadAllText("fantasy-armor-customization.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//div[@role='main'][1]");
            var sectionNode = WOINWebPageHelper.ParseSectionContent(document.DocumentNode);
            var definitionNodes = sectionNode.SelectNodes(".//dt");

            // Assert
            Assert.IsNotNull(document);
            Assert.IsNotNull(definitionNodes);
            Assert.AreEqual(17, definitionNodes.Count);;
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

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\countdowns.html")]
        public void WOINWebPageHelper_LoadHtmlDocumentSectionWithUnorderedList_BoldedCorrectly()
        {
            // Arrange
            var html = File.ReadAllText("countdowns.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//*[@id=\"h.6589faa7c235f063_1042\"]");
            var sectionNode = WOINWebPageHelper.ParseSectionContent(document.DocumentNode);
            var list = sectionNode.SelectSingleNode(".//ul");

            // Assert
            Assert.IsNotNull(document);
            Assert.IsNotNull(list);
            Assert.AreEqual(5, list.ChildNodes.Count);
            Assert.AreEqual("ul", list.Name);
            Assert.AreEqual(5, list.SelectNodes(".//li").Count);
            Assert.AreEqual(5, list.SelectNodes(".//b").Count);
        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"WOIN\TestFiles\countdowns.html")]
        public void WOINWebPageHelper_LoadHtmlDocumentSectionWithTableWithLineBreak_HeaderRowShowsOnTwoLines()
        {
            // Arrange
            var html = File.ReadAllText("countdowns.html");

            // Act
            var document = SRDWebPageHelper.LoadHtmlDocument(html, "//*[@id=\"h.5661394040d4f06b_494\"]");
            var sectionNode = WOINWebPageHelper.ParseSectionContent(document.DocumentNode);
            var table = sectionNode.SelectSingleNode(".//table");

            // Assert
            Assert.IsNotNull(document);
            Assert.IsNotNull(table);
            Assert.AreEqual(12, table.ChildNodes.Count);
            Assert.AreEqual("table", table.Name);
            Assert.AreEqual(12, table.SelectNodes(".//tr").Count);
            Assert.AreEqual(4, table.SelectNodes(".//th").Count);
            Assert.AreEqual(44, table.SelectNodes(".//td").Count);
        }
    }
}
