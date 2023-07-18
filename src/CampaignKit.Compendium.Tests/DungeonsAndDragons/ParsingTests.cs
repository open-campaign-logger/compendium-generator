using CampaignKit.Compendium.DungeonsAndDragons.Common;
using CampaignKit.Compendium.DungeonsAndDragons.TomeOfBeasts2;

using Newtonsoft.Json;

namespace CampaignKit.Compendium.Tests.DungeonsAndDragons
{
    [TestClass]
    public class ParsingTests
    {

        [TestMethod]
        public void CalculateAbilityBonus_Score10_Returns0()
        {
            // Arrange
            int expected = 0;
            int? abilityScore = 10;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score11_Returns0()
        {
            // Arrange
            int expected = 0;
            int? abilityScore = 11;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score12_Returns1()
        {
            // Arrange
            int expected = 1;
            int? abilityScore = 12;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score13_Returns1()
        {
            // Arrange
            int expected = 1;
            int? abilityScore = 13;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score14_Returns2()
        {
            // Arrange
            int expected = 2;
            int? abilityScore = 14;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score15_Returns2()
        {
            // Arrange
            int expected = 2;
            int? abilityScore = 15;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score16_Returns3()
        {
            // Arrange
            int expected = 3;
            int? abilityScore = 16;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score17_Returns3()
        {
            // Arrange
            int expected = 3;
            int? abilityScore = 17;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_ScoreNull_ReturnsExpected()
        {
            // Arrange
            int expected = -5;
            int? abilityScore = null;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_ScoreLessThan10_ReturnsExpected()
        {
            // Arrange
            int expected = -1; // This is for score 9. Update as per your calculation for scores less than 10
            int? abilityScore = 9;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score19_ReturnsExpected()
        {
            // Arrange
            int expected = 4; // Update as per your calculation for score 19
            int? abilityScore = 19;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score20_ReturnsExpected()
        {
            // Arrange
            int expected = 5; // Update as per your calculation for score 20
            int? abilityScore = 20;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score21_ReturnsExpected()
        {
            // Arrange
            int expected = 5; // Update as per your calculation for score 21
            int? abilityScore = 21;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAbilityBonus_Score22_ReturnsExpected()
        {
            // Arrange
            int expected = 6; // Update as per your calculation for score 22
            int? abilityScore = 22;

            // Act
            int actual = CreatureHelper.CalculateAbilityBonus(abilityScore);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingZero_ReturnsTen()
        {
            // Arrange
            double challengeRating = 0;
            int expected = 10;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingOne_ReturnsTwoHundred()
        {
            // Arrange
            double challengeRating = 1;
            int expected = 200;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwo_ReturnsFourHundredFifty()
        {
            // Arrange
            double challengeRating = 2;
            int expected = 450;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingThree_ReturnsSevenHundred()
        {
            // Arrange
            double challengeRating = 3;
            int expected = 700;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingFour_ReturnsElevenHundred()
        {
            // Arrange
            double challengeRating = 4;
            int expected = 1100;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingFive_ReturnsEighteenHundred()
        {
            // Arrange
            double challengeRating = 5;
            int expected = 1800;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingSix_ReturnsTwentyThreeHundred()
        {
            // Arrange
            double challengeRating = 6;
            int expected = 2300;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingSeven_ReturnsTwentyNineHundred()
        {
            // Arrange
            double challengeRating = 7;
            int expected = 2900;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingEight_ReturnsThirtyNineHundred()
        {
            // Arrange
            double challengeRating = 8;
            int expected = 3900;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingNine_ReturnsFiveThousand()
        {
            // Arrange
            double challengeRating = 9;
            int expected = 5000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTen_ReturnsFiveThousandNineHundred()
        {
            // Arrange
            double challengeRating = 10;
            int expected = 5900;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingEleven_ReturnsSevenThousandTwoHundred()
        {
            // Arrange
            double challengeRating = 11;
            int expected = 7200;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwelve_ReturnsEightThousandFourHundred()
        {
            // Arrange
            double challengeRating = 12;
            int expected = 8400;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingThirteen_ReturnsTenThousand()
        {
            // Arrange
            double challengeRating = 13;
            int expected = 10000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingFourteen_ReturnsElevenThousandFiveHundred()
        {
            // Arrange
            double challengeRating = 14;
            int expected = 11500;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingFifteen_ReturnsThirteenThousand()
        {
            // Arrange
            double challengeRating = 15;
            int expected = 13000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingSixteen_ReturnsFifteenThousand()
        {
            // Arrange
            double challengeRating = 16;
            int expected = 15000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingSeventeen_ReturnsEighteenThousand()
        {
            // Arrange
            double challengeRating = 17;
            int expected = 18000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingEighteen_ReturnsTwentyThousand()
        {
            // Arrange
            double challengeRating = 18;
            int expected = 20000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingNineteen_ReturnsTwentyTwoThousand()
        {
            // Arrange
            double challengeRating = 19;
            int expected = 22000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwenty_ReturnsTwentyFiveThousand()
        {
            // Arrange
            double challengeRating = 20;
            int expected = 25000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyOne_ReturnsThirtyThreeThousand()
        {
            // Arrange
            double challengeRating = 21;
            int expected = 33000;

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyTwo_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 22;
            int expected = 41000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyThree_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 23;
            int expected = 50000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyFour_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 24;
            int expected = 62000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyFive_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 25;
            int expected = 75000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentySix_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 26;
            int expected = 90000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentySeven_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 27;
            int expected = 105000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyEight_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 28;
            int expected = 120000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingTwentyNine_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 29;
            int expected = 135000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExperiencePoints_ChallengeRatingThirty_ReturnsExpectedValue()
        {
            // Arrange
            double challengeRating = 30;
            int expected = 155000; //Update as per your D&D XP chart

            // Act
            int actual = CreatureHelper.CalculateExperiencePoints(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_1_Returns_2()
        {
            // Arrange
            double challengeRating = 1;
            int expected = 2;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_4_Returns_3()
        {
            // Arrange
            double challengeRating = 4;
            int expected = 3;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_8_Returns_4()
        {
            // Arrange
            double challengeRating = 8;
            int expected = 4;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_12_Returns_5()
        {
            // Arrange
            double challengeRating = 12;
            int expected = 5;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_16_Returns_6()
        {
            // Arrange
            double challengeRating = 16;
            int expected = 6;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_20_Returns_7()
        {
            // Arrange
            double challengeRating = 20;
            int expected = 7;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateProficiencyBonus_ChallengeRating_25_Returns_8()
        {
            // Arrange
            double challengeRating = 25;
            int expected = 8;

            // Act
            int actual = CreatureHelper.CalculateProficiencyBonus(challengeRating);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ConvertBonusToSignedString_PositiveBonus_ReturnsPlusSign()
        {
            // Arrange
            int bonus = 1;

            // Act
            string result = CreatureHelper.ConvertBonusToSignedString(bonus);

            // Assert
            Assert.AreEqual("+1", result);
        }

        [TestMethod]
        public void ConvertBonusToSignedString_NegativeBonus_ReturnsMinusSign()
        {
            // Arrange
            int bonus = -1;

            // Act
            string result = CreatureHelper.ConvertBonusToSignedString(bonus);

            // Assert
            Assert.AreEqual("-1", result);
        }


        [TestMethod]
        public void ConvertChallengeRatingToDouble_ValidInput_ReturnsCorrectValue()
        {
            // Arrange
            string challengeRating = "1/4";

            // Act
            double? result = CreatureHelper.ConvertChallengeRatingToDouble(challengeRating);

            // Assert
            Assert.AreEqual(0.25, result);
        }

        [TestMethod]
        public void ConvertChallengeRatingToDouble_InvalidInput_ReturnsNull()
        {
            // Arrange
            string challengeRating = "invalid";

            // Act
            double? result = CreatureHelper.ConvertChallengeRatingToDouble(challengeRating);

            // Assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void ConvertChallengeRatingToString_ReturnsCorrectString()
        {
            // Arrange
            double challengeRating = 0.25;

            // Act
            string? result = CreatureHelper.ConvertChallengeRatingToString(challengeRating);

            // Assert
            Assert.AreEqual("1/4", result);
        }

        [TestMethod]
        public void ConvertChallengeRatingToString_ReturnsNullForInvalidInput()
        {
            // Arrange
            double challengeRating = 0.33;

            // Act
            string? result = CreatureHelper.ConvertChallengeRatingToString(challengeRating);

            // Assert
            Assert.AreEqual("1/3", result);
        }


        [TestMethod]
        public void ParseAttributeValue_NullInput_ReturnsNull()
        {
            // Arrange
            string? csv = null;
            string? attributeName = null;

            // Act
            int? result = CreatureHelper.ParseAttributeValue(csv, attributeName);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseAttributeValue_EmptyInput_ReturnsNull()
        {
            // Arrange
            string csv = string.Empty;
            string attributeName = string.Empty;

            // Act
            int? result = CreatureHelper.ParseAttributeValue(csv, attributeName);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseAttributeValue_AttributeNameLongerThanCsv_ReturnsNull()
        {
            // Arrange
            string csv = "darkvision 120 ft.";
            string attributeName = "passive perception";

            // Act
            int? result = CreatureHelper.ParseAttributeValue(csv, attributeName);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseAttributeValue_AttributeNotFound_ReturnsNull()
        {
            // Arrange
            string csv = "darkvision 120 ft., Passive Perception 20";
            string attributeName = "speed";

            // Act
            int? result = CreatureHelper.ParseAttributeValue(csv, attributeName);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseAttributeValue_AttributeFound_ReturnsValue()
        {
            // Arrange
            string csv = "darkvision 120 ft., Passive Perception 20";
            string attributeName = "passive perception";

            // Act
            int? result = CreatureHelper.ParseAttributeValue(csv, attributeName);

            // Assert
            Assert.AreEqual(20, result);
        }
    }
}