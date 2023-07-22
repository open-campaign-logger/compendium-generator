using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;
using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.OldSchoolEssentials
{
    [TestClass]
    public class MagicItemConversionTests
    {

        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_PotionOfControlUndead_LabelsCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Potion of Control Undead");

            // Act
            var magicItem = new SRDMagicItem(campaignEntry);
            var convertedCampaignEntry = magicItem.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.AreEqual(convertedCampaignEntry.TagSymbol, "+");
            Assert.IsTrue(convertedCampaignEntry.Labels.Count == 3);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Magic Items"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Potions"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("OSE"));

        }

        private static CampaignEntry GetCampaignEntry(string TagValue)
        {
            // Arrange
            var campaignJSON = File.ReadAllText("OSE-SRD-v1.0.json");
            Assert.IsNotNull(campaignJSON);

            // Act
            var campaign = JsonConvert.DeserializeObject<Campaign>(campaignJSON);
            Assert.IsNotNull(campaign);
            Assert.IsNotNull(campaign.CampaignEntries);
            var campaignEntry = campaign.CampaignEntries.First(ce => ce.TagValue == TagValue);
            Assert.IsNotNull(campaignEntry);
            Assert.IsNotNull(campaignEntry.RawText);

            return campaignEntry;
        }
    }

}
