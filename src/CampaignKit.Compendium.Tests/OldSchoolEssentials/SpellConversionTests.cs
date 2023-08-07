
using CampaignKit.Compendium.Core.CampaignLogger;
using CampaignKit.Compendium.OldSchoolEssentials.SRD;

using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.OldSchoolEssentials
{
    [TestClass]
    public  class SpellConversionTests
    {

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests
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
            Assert.IsTrue(convertedCampaignEntry.Labels.Count == 2);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Level 3"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Magic User"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_SpellOfInfravisionConfigurationOverride_LabelsCorrect()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Spell of Infravision - MU3");

            // Act
            var spell = new SRDSpell(campaignEntry)
            {
                TagSymbol = "!",
                Labels = new List<string>() { "ABC", "123" }
            };
            var convertedCampaignEntry = spell.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.TagSymbol);
            Assert.AreEqual(convertedCampaignEntry.TagSymbol, "!");
            Assert.IsNotNull(convertedCampaignEntry.Labels);
            Assert.IsTrue(convertedCampaignEntry.Labels.Count == 4);
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("ABC"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("123"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Level 3"));
            Assert.IsTrue(convertedCampaignEntry.Labels.Contains("Magic User"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests
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
            Assert.IsNotNull(convertedCampaignEntry.RawPublic);
            Assert.IsTrue(convertedCampaignEntry.RawPublic.Contains("Trapped areas are caused to magically glow with a faint blue light."));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"OldSchoolEssentials\TestFiles\OSE-SRD-v1.0.json")]
        public void ConvertToCLStatBlock_SpellOfClairvoyance_PublicDescriptionNotNull()
        {
            // Arrange
            var campaignEntry = GetCampaignEntry("Spell of Clairvoyance - MU3");

            // Act
            var spell = new SRDSpell(campaignEntry);
            var convertedCampaignEntry = spell.ToCampaignEntry();

            // Assert
            Assert.IsNotNull(convertedCampaignEntry);
            Assert.IsNotNull(convertedCampaignEntry.RawPublic);
            Assert.IsNull(convertedCampaignEntry.RawText);

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
