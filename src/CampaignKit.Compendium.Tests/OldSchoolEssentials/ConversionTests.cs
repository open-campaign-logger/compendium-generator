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
        public void ConvertToCLStatBlock_AmberGolem_AttributionCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Amber Golem");

            // Act
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.RawText);
            Assert.IsTrue(convertedCampaignEntry.RawText.Contains($"Source: [{creature.PublisherName}]({creature.LicenseURL})"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_AirElemental_LabelsCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Air Elemental");

            // Act
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Alignment: Neutral"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Where(l => l.StartsWith("HD:")).Count() == 3);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("HD: 8"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("HD: 12"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("HD: 16"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Special Abilities"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Treasure Type: None"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_Harpy_HitDiceCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Harpy");

            // Act
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Where(l => l.StartsWith("HD:")).Count() == 1);

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_LizardMan_HitDiceCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Lizard Man");

            // Act
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Where(l => l.StartsWith("HD:")).Count() == 1);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("HD: 2"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_HillGiant_TreasureTypeCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Hill Giant");

            // Act
            var creature = new SRDCreature(campaignEntry);
            var convertedCampaignEntry = creature.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Where(l => l.StartsWith("HD:")).Count() == 1);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("HD: 8"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Where(l => l.StartsWith("Treasure Type:")).Count() == 1);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Treasure Type: E"));

        }

        private CampaignEntry GetCampaignEntry(string TagValue)
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
