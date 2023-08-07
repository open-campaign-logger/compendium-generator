using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.Core.Configuration;
using CampaignKit.Compendium.Markdown.Common;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.Markdown
{
    [TestClass]
    public class MarkdownConversionTests
    {

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"Markdown\TestFiles\test.md")]
        public void ConvertToCampaign_TestFile_LabelsCorrect()
        {
            // Arrange
            var sourceDataSet = new SourceDataSet()
            {
                ImportLimit = 100,
                LicenseDataParser = string.Empty,
                LicenseDataURI = string.Empty,
                Labels = new List<string>() { "ABC", "123" },
                OverwriteExisting = true,
                SourceDataSetName = string.Empty,
                SourceDataSetParser = string.Empty,
                SourceDataSetURI = "test.md",
                TagSymbol = "~",
            };

            // Act
            var campaignEntries = MarkdownHelper.ParseCampaignEntries(sourceDataSet, @"Markdown\TestFiles").Result.ToList();

            // Assert
            Assert.IsNotNull(campaignEntries);
            Assert.AreEqual(campaignEntries.Count, 2);
            var label1 = campaignEntries[0].Labels?[0] ?? string.Empty;
            var label2 = campaignEntries[0].Labels?[1] ?? string.Empty;
            Assert.AreEqual(label1, "ABC");
            Assert.AreEqual(label2, "123");

        }
    }
}
