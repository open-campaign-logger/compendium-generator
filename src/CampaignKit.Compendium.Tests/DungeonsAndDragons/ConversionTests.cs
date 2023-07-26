using CampaignKit.Compendium.DungeonsAndDragons.SRD;
using CampaignKit.Compendium.DungeonsAndDragons.TomeOfBeasts2;

using Newtonsoft.Json;
namespace CampaignKit.Compendium.Tests.DungeonsAndDragons
{
    [TestClass]
    public class ConversionTests
    {
        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"DungeonsAndDragons\TestFiles\backup_holler_spider.json")]
        public void ConvertToCLStatBlock_EmptyArmorDescription_ParenthesisExcluded()
        {
            // Arrange
            var creatureJSON = File.ReadAllText("backup_holler_spider.json");
            Assert.IsNotNull(creatureJSON);

            // Act
            var creature = JsonConvert.DeserializeObject<TomeOfBeasts2Creature>(creatureJSON);
            Assert.IsNotNull(creature);
            var creatureStatBlock = creature.ToCampaignEntry();
            Assert.IsNotNull(creatureStatBlock);
            Assert.IsNotNull(creatureStatBlock.RawText);
            var creatureStatBlockLines = creatureStatBlock.RawText.Split(Environment.NewLine);

            // Assert
            Assert.IsFalse(creatureStatBlockLines.Contains("- Armor Class: 12 ()"));
            Assert.IsTrue(creatureStatBlockLines.Contains("- Armor Class: 12"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"DungeonsAndDragons\TestFiles\sulsha.json")]
        public void ConvertToCLStatBlock_NonEmptyArmorDescription_ParenthesisAndDescriptionIncluded()
        {
            // Arrange
            var creatureJSON = File.ReadAllText("sulsha.json");
            Assert.IsNotNull(creatureJSON);

            // Act
            var creature = JsonConvert.DeserializeObject<TomeOfBeasts2Creature>(creatureJSON);
            Assert.IsNotNull(creature);
            var creatureStatBlock = creature.ToCampaignEntry();
            Assert.IsNotNull(creatureStatBlock);
            Assert.IsNotNull(creatureStatBlock.RawText);
            var creatureStatBlockLines = creatureStatBlock.RawText.Split(Environment.NewLine);

            // Assert
            Assert.IsTrue(creatureStatBlockLines.Contains("- Armor Class: 16 (natural armor)"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"DungeonsAndDragons\TestFiles\aboleth.json")]
        public void ConvertToCLStatBlock_SRDMonster_AttributionCorrect()
        {
            // Arrange
            var creatureJSON = File.ReadAllText("aboleth.json");
            Assert.IsNotNull(creatureJSON);

            // Act
            var creature = JsonConvert.DeserializeObject<SRDCreature>(creatureJSON);
            Assert.IsNotNull(creature);
            var creatureStatBlock = creature.ToCampaignEntry();
            Assert.IsNotNull(creatureStatBlock);
            Assert.IsNotNull(creatureStatBlock.RawText);
            var creatureStatBlockLines = creatureStatBlock.RawText.Split(Environment.NewLine);

            // Assert
            Assert.IsFalse(creatureStatBlockLines.Contains($"[Wizards of the Coast](http://dnd.wizards.com/articles/features/systems-reference-document-srd)"));

        }

        /// <summary>
        /// See: https://community.dataminer.services/unit-testing-using-files-in-unit-tests/
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"DungeonsAndDragons\TestFiles\aboleth.json")]
        public void ConvertToCLStatBlock_KoboldPressMonster_AttributionCorrect()
        {
            // Arrange
            var creatureJSON = File.ReadAllText("sulsha.json");
            Assert.IsNotNull(creatureJSON);

            // Act
            var creature = JsonConvert.DeserializeObject<TomeOfBeasts2Creature>(creatureJSON);
            Assert.IsNotNull(creature);
            var creatureStatBlock = creature.ToCampaignEntry();
            Assert.IsNotNull(creatureStatBlock);
            Assert.IsNotNull(creatureStatBlock.RawText);
            var creatureStatBlockLines = creatureStatBlock.RawText.Split(Environment.NewLine);

            // Assert
            Assert.IsFalse(creatureStatBlockLines.Contains($"[Kobold Press](https://koboldpress.com/kpstore/product/tome-of-beasts-2-for-5th-edition/)"));

        }
    }
}
