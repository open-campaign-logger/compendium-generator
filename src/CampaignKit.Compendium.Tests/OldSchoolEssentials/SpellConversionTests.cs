
using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;

using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.OldSchoolEssentials
{
    [TestClass]
    public  class SpellConversionTests
    {

        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_SpellOfInfravision_LabelsCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Spell of Infravision - MU3");

            // Act
            var spell = new SRDSpell(campaignEntry);
            var convertedCampaignEntry = spell.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Count == 4);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Level 3"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Magic User"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Spell"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("OSE"));

        }

        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_SpellOfFindTraps_TextIsNotBlank()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Spell of Find Traps - CL2");

            // Act
            var spell = new SRDSpell(campaignEntry);
            var convertedCampaignEntry = spell.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.RawText);
            Assert.IsTrue(convertedCampaignEntry.RawText.Contains("Trapped areas are caused to magically glow with a faint blue light."));

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
