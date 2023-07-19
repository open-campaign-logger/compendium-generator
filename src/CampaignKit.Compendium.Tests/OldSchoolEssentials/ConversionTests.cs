using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;

using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace CampaignKit.Compendium.Tests.OldSchoolEssentials
{
    [TestClass]
    public class ConversionTests
    {
        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_SRDMonster_AttributionCorrect()
        {
            // Arrange
            var campaignJSON = File.ReadAllText("OSE-SRD-v1.0.json");
            Assert.IsNotNull(campaignJSON);

            // Act
            var campaign = JsonConvert.DeserializeObject<Campaign>(campaignJSON);
            Assert.IsNotNull(campaign);
            Assert.IsNotNull(campaign.CampaignEntries);
            var campaignEntry = campaign.CampaignEntries.First(ce => ce.TagValue == "Golem, Amber");
            Assert.IsNotNull(campaignEntry);
            Assert.IsNotNull(campaignEntry.RawText);
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.RawText);

            // Assert
            Assert.IsTrue(convertedCampaignEntry.RawText.Contains($"[{creature.PublisherName}]({creature.LicenseURL})"));

        }
    }
}
