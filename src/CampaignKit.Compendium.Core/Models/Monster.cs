using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Compendium.Core.Models
{

    public class Monster
    {
        // ************************************************************* //
        // ************************************************************* //
        //                    Part I - Constants
        // ************************************************************* //
        // ************************************************************* //
        public enum RuleSystems
        {
            Dungeons_And_Dragons_5e,
            Pathfinder_2e
        }

        public enum LicenseTypes
        {
            OGL1_0a
        }

        // ************************************************************* //
        // ************************************************************* //
        //                  Part II - Tombstone Info
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Primary key for monster.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Name of the monster.  Example: Aboleth
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Size of the monster.  Example: Large
        /// </summary>
        public string Size { get; set; } = String.Empty;

        /// <summary>
        /// Type of the monster.  Example: aberration
        /// </summary>
        public string Type { get; set; } = String.Empty;

        /// <summary>
        /// Alignment of the monster.  Example: lawful evil
        /// </summary>
        public string Alignment { get; set; } = String.Empty;

        /// <summary>
        /// Source document of the monster data.
        /// </summary>
        public string SourceDocumentTitle { get; set; } = String.Empty;

        /// <summary>
        /// Source document descrition associated with the monster data.
        /// </summary>
        public string SourceDocumentDescription { get; set; } = String.Empty;

        /// <summary>
        /// Version of the source document associated with the monster data.
        /// </summary>
        public string SourceDocumentVersion { get; set; } = String.Empty;

        /// <summary>
        /// Name of the license associated with the monster data.
        /// </summary>
        public string LicenseName { get; set; } = String.Empty;

        /// <summary>
        /// Author of the monster data.
        /// </summary>
        public string Author { get; set; } = String.Empty;

        /// <summary>
        /// Organization owning the content.
        /// </summary>
        public string Organization { get; set; } = String.Empty;

        /// <summary>
        /// Copyright associated with the monster data.
        /// </summary>
        public string Copyright { get; set; } = String.Empty;

        /// <summary>
        /// License URL associated with the monster data.
        /// </summary>
        public string LicenseURL { get; set; } = String.Empty;

        /// <summary>
        /// Rule system associated with the monster data.
        /// </summary>
        public string RuleSystem { get; set; } = String.Empty;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part III - AC, HP, Speed
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Armor class of the monster.  Example: 17
        /// </summary>
        public int ArmorClass;

        /// <summary>
        /// Type of armor worn by the monster.  Example: natural armor
        /// </summary>
        public string ArmorDesc { get; set; } = String.Empty;

        /// <summary>
        /// Average hit points of the monster.  Example 135
        /// </summary>
        public int HitPoints { get; set; } = 0;

        /// <summary>
        /// Hit dice calculation for the monster.  Example 18d10+36
        /// </summary>
        public string HitDice { get; set; } = String.Empty;

        /// <summary>
        /// Walking speed of the monster in feet per round.  Example 10
        /// </summary>
        public int Walk { get; set; } = 0;

        /// <summary>
        /// Swimming speed of the monster in feet per round.  Example 40
        /// </summary>
        public int Swim { get; set; } = 0;

        /// <summary>
        /// Swimming speed of the monster in feet per round.  Example 0
        /// </summary>
        public int Fly { get; set; } = 0;

        /// <summary>
        /// Swimming speed of the monster in feet per round.  Example 0
        /// </summary>
        public int Burrow { get; set; } = 0;

        /// <summary>
        /// Swimming speed of the monster in feet per round.  Example 0
        /// </summary>
        public int Climb { get; set; } = 0;

        /// <summary>
        /// Ability of the monster to hover.  Example: false
        /// </summary>
        public bool Hover { get; set; } = false;

        /// <summary>
        /// Light walking capability of the monster to hover.  Example: 80
        /// </summary>
        public int LightWalking { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part IV - Ability Scores
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Strength of the monster.  Example: 21
        /// </summary>
        public int Strength { get; set; } = 0;

        /// <summary>
        /// Dexterity of the monster.  Example: 9
        /// </summary>
        public int Dexterity { get; set; } = 0;

        /// <summary>
        /// Constitution of the monster.  Example: 15
        /// </summary>
        public int Constitution { get; set; } = 0;

        /// <summary>
        /// Intelligence of the monster.  Example: 18
        /// </summary>
        public int Intelligence { get; set; } = 0;

        /// <summary>
        /// Wisdom of the monster.  Example: 15
        /// </summary>
        public int Wisdom { get; set; } = 0;

        /// <summary>
        /// Charisma of the monster.  Example: 18
        /// </summary>
        public int Charisma { get; set; } = 0;

        // ************************************************************* //
        // ************************************************************* //
        //           Part V - Saving Throws, Senses, Language,
        //                 Challenge, Proficiency Bonus
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Strength saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 0
        /// </summary>
        public int StrengthSave { get; set; } = 0;

        /// <summary>
        /// Dexterity saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 0
        /// </summary>
        public int DexteritySave { get; set; } = 0;

        /// <summary>
        /// Constitution saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 15
        /// </summary>
        public int ConstitutionSave { get; set; } = 0;

        /// <summary>
        /// Intelligence saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 8
        /// </summary>
        public int IntelligenceSave { get; set; } = 0;

        /// <summary>
        /// Wisdom saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 6
        /// </summary>
        public int WisdomSave { get; set; } = 0;

        /// <summary>
        /// Charisma saving throw of the monster.  
        /// Leave zero if monster does not have the saving throw specified.  
        /// Example: 0
        /// </summary>
        public int CharismaSave { get; set; } = 0;

        /// <summary>
        /// Distance in feet that the monster can see with darkvision.  
        /// Leave 0 if not specified.
        /// Example 120
        /// </summary>
        public int Darkvision { get; set; } = 0;

        /// <summary>
        /// Distance in feet that the monster can see with blindsight.  
        /// Leave 0 if not specified.
        /// Example 0
        /// </summary>
        public int Blindsight { get; set; } = 0;

        /// <summary>
        /// Distance in feet that the monster can see with truesight.
        /// Leave 0 if not specified.
        /// Example 0
        /// </summary>
        public int Truesight { get; set; } = 0;

        /// <summary>
        /// Distance in feet that the monster can feel with tremorsense.
        /// Leave 0 if not specified.
        /// Example 0
        /// </summary>
        public int Tremorsense { get; set; } = 0;

        /// <summary>
        /// Passive perception is calculated as 10+all modifiers that would apply to a rolled 
        /// perception check for that character (such as the wisdom modifier and proficiency bonus).
        /// </summary>
        public int PassivePerception { get; set; } = 0;

        /// <summary>
        /// Languages the monster is able to speak or understand.  Example Deep Speech, telepathy 120 ft.
        /// </summary>
        public string Languages { get; set; } = String.Empty;

        /// <summary>
        /// The challenge rating of th monster.  Fractional CRs should be expressed as a decimal.  Example: 10
        /// </summary>
        public double ChallengeRating { get; set; } = 0.0;

        // ************************************************************* //
        // ************************************************************* //
        //      Part VI - Resistances, Vulnerabilities, and Immunities
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Damage vulnerabilities belonging to the monster.  Example: Thunder
        /// </summary>
        public string DamageVulnerabilities { get; set; } = String.Empty;

        /// <summary>
        /// Damage resistances belonging to the monster.  Example: Fire
        /// </summary>
        public string DamageResistances { get; set; } = String.Empty;

        /// <summary>
        /// Damage immunities belonging to the monster.  Example: Poison, Psychic; Bludgeoning, Piercing, and Slashing From Nonmagical Attacks That Aren't Adamantine
        /// </summary>
        public string DamageImmunities { get; set; } = String.Empty;

        /// <summary>
        /// Condition immunities belonging to the monster.  Example: Charmed, Exhaustion, Frightened, Paralyzed, Petrified, Poisoned
        /// </summary>
        public string ConditionImmunities { get; set; } = String.Empty;

        // ************************************************************* //
        // ************************************************************* //
        //                    Part VII - Skills
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// History skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int History { get; set; } = 0;

        /// <summary>
        /// Perception skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Perception { get; set; } = 0;

        /// <summary>
        /// Medicine skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Medicine { get; set; } = 0;

        /// <summary>
        /// Religion skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Religion { get; set; } = 0;

        /// <summary>
        /// Stealth skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Stealth { get; set; } = 0;

        /// <summary>
        /// Persuasion skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Persuasion { get; set; } = 0;

        /// <summary>
        /// Insight skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Insight { get; set; } = 0;

        /// <summary>
        /// Deception skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Deception { get; set; } = 0;

        /// <summary>
        /// Arcana skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Arcana { get; set; } = 0;

        /// <summary>
        /// Athletics skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Athletics { get; set; } = 0;

        /// <summary>
        /// Acrobatics skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Acrobatics { get; set; } = 0;

        /// <summary>
        /// Animal Handling skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int AnimalHandling { get; set; } = 0;

        /// <summary>
        /// Survival skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Survival { get; set; } = 0;

        /// <summary>
        /// Investigation skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Investigation { get; set; } = 0;

        /// <summary>
        /// Nature skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Nature { get; set; } = 0;

        /// <summary>
        /// Intimidation skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Intimidation { get; set; } = 0;

        /// <summary>
        /// Performance skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int Performance { get; set; } = 0;

        /// <summary>
        /// Sleight of hand skill bonus.
        /// Leave zero if monster does not have the skill specified.  
        /// Example: 0
        /// </summary>
        public int SleightOfHand { get; set; } = 0;


        // ************************************************************* //
        // ************************************************************* //
        //                 Part VIII - 1:many Properties
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// A collection of special abilities associated with the monster.
        /// </summary>
        public List<MonsterSpecialAbility> SpecialAbilities { get; set; } = new List<MonsterSpecialAbility> { };

        /// <summary>
        /// A collection of actions associated with the monster.
        /// </summary>
        public List<MonsterAction> Actions { get; set; } = new List<MonsterAction> { };

        /// <summary>
        /// A collection of reactions associated with the monster.
        /// </summary>
        public List<MonsterReaction> Reactions { get; set; } = new List<MonsterReaction> { };

        /// <summary>
        /// Legendary action description.
        /// </summary>
        public string LegendaryActionDescription { get; set; } = String.Empty;

        /// <summary>
        /// A collection of legendary actions associated with the monster.
        /// </summary>
        public List<MonsterLegendaryAction> LegendaryActions { get; set; } = new List<MonsterLegendaryAction> { };

        // ************************************************************* //
        // ************************************************************* //
        //                  Part IX - Rendered Statblocks
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Monster data formatted in standard text format
        /// </summary>
        [JsonIgnore]
        public string TextStatBlock { get; set; } = String.Empty;

        /// <summary>
        /// Monster data formatted in standard CL format
        /// </summary>
        [JsonIgnore]
        public string CLStatBlock { get; set; } = String.Empty;

        /// <summary>
        /// Monster data formatted in JSON format
        /// </summary>
        [JsonIgnore]
        public string JSONStatBlock { get; set; } = String.Empty;

        // ************************************************************* //
        // ************************************************************* //
        //                  Part X - Utility Methods
        // ************************************************************* //
        // ************************************************************* //

        /// <summary>
        /// Converts challenge ratings string to a double value.  Converts "1/4" to 0.25
        /// </summary>
        /// <param name="challengeRating">The string value of the monster's challenge rating.  Example: "1/4"</param>
        /// <returns>Double value of the challenge rating or null if it could not be converted.  Example: 0.25</returns>
        public static double? ConvertChallengeRatingToDouble(string challengeRating)
        {
            double result;
            string[] tokens = challengeRating.Split("/");
            if (tokens.Length > 1)
            {
                double numerator, denominator = 0.0;
                if (double.TryParse(tokens[0].Trim(), out numerator) && double.TryParse(tokens[1].Trim(), out denominator))
                {
                    return numerator / denominator;
                }
            }
            else
            {
                if (double.TryParse(challengeRating, out result))
                {
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Converts challenge ratings double to a string value.  Converts 0.25 to "1/4"
        /// </summary>
        /// <param name="challengeRating">The double value of the monster's challenge rating.  Example: 0.25</param>
        /// <returns>String value of the challenge rating or null if it could not be converted.  Example: "1/4"</returns>
        public static string? ConvertChallengeRatingToString(double challengeRating)
        {
            if (challengeRating == 0.125)
            {
                return "1/8";
            } else if (challengeRating == 0.25)
            {
                return "1/4";
            } else if (challengeRating == 0.5)
            {
                return "1/2";
            }
            return challengeRating.ToString();
        }

        /// <summary>
        /// Calculate the ability score bonus.
        /// </summary>
        /// <param name="abilityScore">The relevant ability score. Example: 17</param>
        /// <returns>Int representing ability bonus for the specified ability score. Example: 3</returns>
        public static int CalculateAbilityBonus(int? abilityScore)
        {
            return (int)Math.Floor(((abilityScore ?? 0) - 10) / 2.00);
        }

        /// <summary>
        /// Calculates the proficiency bonus for the moster based on its challenge rating.
        /// </summary>
        /// <param name="challengeRating">The double value of the monster's challenge rating.  Example: 0.25</param>
        /// <returns>Int value of the challenge rating.  Example: 2</returns>
        public static int CalculateProficiencyBonus(double challengeRating)
        {
            if (challengeRating <= 1) return 2;
            else if (challengeRating <= 4) return 3;
            else if (challengeRating <= 8) return 4;
            else if (challengeRating <= 12) return 5;
            else if (challengeRating <= 16) return 6;
            else if (challengeRating <= 20) return 7;
            else return 8;
        }

        /// <summary>
        /// Adds a "+" or "-" to the bonus value
        /// </summary>
        /// <param name="bonus">Bonus value.  e.g. 1 </param>
        /// <returns>Bonus value with "+" or "-" prepended to it.  e.g. "+1"</returns>
        public static string ConvertBonusToSignedString(int bonus)
        {
            if (bonus >= 0)
            {
                return "+" + bonus;
            } else
            {
                return "-" + Math.Abs(bonus);
            }
        }

        /// <summary>
        /// Calculate the XP of the monster based on its challenge rating.
        /// </summary>
        /// <param name="challengeRating">The double value of the monster's challenge rating.  Example: 0.25</param>
        /// <returns>Int value of experience points for the specified challenge rating.  Example: 50</returns>
        public static int CalculateExperiencePoints(double challengeRating)
        {
            if (challengeRating == 0) return 10;
            else if (challengeRating < 2) return (int)Math.Round(200 * challengeRating);
            else if (challengeRating == 2) return 450;
            else if (challengeRating == 3) return 700;
            else if (challengeRating == 4) return 1100;
            else if (challengeRating == 5) return 1800;
            else if (challengeRating == 6) return 2300;
            else if (challengeRating == 7) return 2900;
            else if (challengeRating == 8) return 3900;
            else if (challengeRating == 9) return 5000;
            else if (challengeRating == 10) return 5900;
            else if (challengeRating == 11) return 7200;
            else if (challengeRating == 12) return 8400;
            else if (challengeRating == 13) return 10000;
            else if (challengeRating == 14) return 11500;
            else if (challengeRating == 15) return 13000;
            else if (challengeRating == 16) return 15000;
            else if (challengeRating == 17) return 18000;
            else if (challengeRating == 18) return 20000;
            else if (challengeRating == 19) return 22000;
            else if (challengeRating == 20) return 25000;
            else if (challengeRating == 21) return 33000;
            else if (challengeRating == 22) return 41000;
            else if (challengeRating == 23) return 50000;
            else if (challengeRating == 24) return 62000;
            else if (challengeRating == 25) return 75000;
            else if (challengeRating == 26) return 90000;
            else if (challengeRating == 27) return 105000;
            else if (challengeRating == 28) return 120000;
            else if (challengeRating == 29) return 135000;
            else if (challengeRating == 30) return 155000;
            else return 0;
        }

        /// <summary>
        /// Implementation of Equals method.
        /// </summary>
        /// <param name="obj">Monster object to compare this to.</param>
        /// <returns>True if objects are equal, false otherwise.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Monster)
            {
                return false;
            }

            Monster other = (Monster)obj;
            return (Name ?? String.Empty).Equals(other.Name, StringComparison.OrdinalIgnoreCase)
                && (Size ?? String.Empty).Equals(other.Size, StringComparison.OrdinalIgnoreCase)
                && (Type ?? String.Empty).Equals(other.Type, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Implementation of GetHashCode method.
        /// </summary>
        /// <returns>int hashcode for this object</returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Name.ToLower().GetHashCode();
            hash = (hash * 7) + Size.ToLower().GetHashCode();
            hash = (hash * 7) + Type.ToLower().GetHashCode();
            return hash;
        }

        /// <summary>
        /// Exports a simple textual description of this monster.
        /// </summary>
        /// <returns>string representation of monster.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Size: {Size}, Type: {Type}";
        }

        /// <summary>
        /// Creates a text statblock for the monster.
        /// </summary>
        /// <returns>Standard text statblock for the monster.</returns>
        public string ToTextStatBlock()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Name}");
            builder.AppendLine($"{Size} {Type}, {Alignment}");
            builder.AppendLine($"Armor Class {ArmorClass} ({ArmorDesc})");
            builder.AppendLine($"Hit Points {HitPoints} ({HitDice})");
            var speeds = new List<string>();
            speeds.Add($"{Walk} ft.");
            if (Swim > 0)
            {
                speeds.Add($"Swim {Swim} ft.");
            }
            if (Fly > 0)
            {
                speeds.Add($"Fly {Fly} ft." + (Hover ? " (hover)" : String.Empty));
            }
            if (Burrow> 0)
            {
                speeds.Add($"Burrow {Burrow} ft.");
            }
            if (Climb > 0)
            {
                speeds.Add($"Climb {Climb} ft.");
            }
            if (LightWalking > 0)
            {
                speeds.Add($"Lightwalking {LightWalking} ft.");
            }
            builder.AppendLine($"Speed {string.Join(", ", speeds)}");
            builder.AppendLine($"STR {Strength} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Strength))})");
            builder.AppendLine($"DEX {Dexterity} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Dexterity))})");
            builder.AppendLine($"CON {Constitution} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Constitution))})");
            builder.AppendLine($"INT {Intelligence} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Intelligence))})");
            builder.AppendLine($"WIS {Wisdom} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Wisdom))})");
            builder.AppendLine($"CHA {Charisma} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Charisma))})");
            var savingThrows = new List<string>();
            if (StrengthSave > CalculateAbilityBonus(Strength))
            {
                savingThrows.Add($"STR {Monster.ConvertBonusToSignedString(StrengthSave)}");
            }
            if (DexteritySave > CalculateAbilityBonus(Dexterity))
            {
                savingThrows.Add($"DEX {Monster.ConvertBonusToSignedString(DexteritySave)}");
            }
            if (ConstitutionSave > CalculateAbilityBonus(Constitution))
            {
                savingThrows.Add($"CON {Monster.ConvertBonusToSignedString(ConstitutionSave)}");
            }
            if (IntelligenceSave > CalculateAbilityBonus(Intelligence))
            {
                savingThrows.Add($"INT {Monster.ConvertBonusToSignedString(IntelligenceSave)}");
            }
            if (WisdomSave > CalculateAbilityBonus(Wisdom))
            {
                savingThrows.Add($"WIS {Monster.ConvertBonusToSignedString(WisdomSave)}");
            }
            if (CharismaSave > CalculateAbilityBonus(Charisma))
            {
                savingThrows.Add($"CHA {Monster.ConvertBonusToSignedString(CharismaSave)}");
            }
            if (savingThrows.Count > 0) builder.AppendLine($"Saving Throws {string.Join(", ", savingThrows)}");
            var skillsList = new List<string>();
            if (Acrobatics > CalculateAbilityBonus(Dexterity)) { 
                skillsList.Add($"Acrobatics {Monster.ConvertBonusToSignedString(Acrobatics)}"); 
            }
            if (AnimalHandling > CalculateAbilityBonus(Wisdom)) { 
                skillsList.Add($"Animal Handling {Monster.ConvertBonusToSignedString(AnimalHandling)}");
            }
            if (Arcana > CalculateAbilityBonus(Intelligence)) { 
                skillsList.Add($"Arcana {Monster.ConvertBonusToSignedString(Arcana)}");
            }
            if (Athletics > CalculateAbilityBonus(Strength)) { 
                skillsList.Add($"Athletics {Monster.ConvertBonusToSignedString(Athletics)}");
            }
            if (Deception > CalculateAbilityBonus(Charisma)) { 
                skillsList.Add($"Deception {Monster.ConvertBonusToSignedString(Deception)}");
            }
            if (History > CalculateAbilityBonus(Intelligence)) { 
                skillsList.Add($"History {Monster.ConvertBonusToSignedString(History)}");
            }
            if (Insight > CalculateAbilityBonus(Wisdom)) { 
                skillsList.Add($"Insight {Monster.ConvertBonusToSignedString(Insight)}");
            }
            if (Intimidation > CalculateAbilityBonus(Charisma)) { 
                skillsList.Add($"Intimidation {Monster.ConvertBonusToSignedString(Intimidation)}");
            }
            if (Investigation > CalculateAbilityBonus(Intelligence)) { 
                skillsList.Add($"Investigation {Monster.ConvertBonusToSignedString(Investigation)}");
            }
            if (Medicine > CalculateAbilityBonus(Wisdom)) { 
                skillsList.Add($"Medicine {Monster.ConvertBonusToSignedString(Medicine)}");
            }
            if (Nature > CalculateAbilityBonus(Intelligence)) { 
                skillsList.Add($"Nature {Monster.ConvertBonusToSignedString(Nature)}");
            }
            if (Perception > CalculateAbilityBonus(Wisdom)) { 
                skillsList.Add($"Perception {Monster.ConvertBonusToSignedString(Perception)}");
            }
            if (Performance > CalculateAbilityBonus(Charisma)) { 
                skillsList.Add($"Performance {Monster.ConvertBonusToSignedString(Performance)}");
            }
            if (Persuasion > CalculateAbilityBonus(Charisma)) { 
                skillsList.Add($"Persuasion {Monster.ConvertBonusToSignedString(Persuasion)}");
            }
            if (Religion > CalculateAbilityBonus(Intelligence)) { 
                skillsList.Add($"Religion {Monster.ConvertBonusToSignedString(Religion)}");
            }
            if (SleightOfHand > CalculateAbilityBonus(Dexterity)) { 
                skillsList.Add($"Sleight of Hand {Monster.ConvertBonusToSignedString(SleightOfHand)}");
            }
            if (Stealth > CalculateAbilityBonus(Dexterity)) { 
                skillsList.Add($"Stealth {Monster.ConvertBonusToSignedString(Stealth)}");
            }
            if (Survival > CalculateAbilityBonus(Wisdom)) { 
                skillsList.Add($"Survival {Monster.ConvertBonusToSignedString(Survival)}");
            }
            if (skillsList.Count > 0) builder.AppendLine($"Skills {string.Join(", ", skillsList)}");
            if (!String.IsNullOrEmpty(DamageVulnerabilities))
            {
                builder.AppendLine($"Damage Vulnerabilities {DamageVulnerabilities}");
            }
            if (!String.IsNullOrEmpty(DamageResistances))
            {
                builder.AppendLine($"Damage Resistances {DamageResistances}");
            }
            if (!String.IsNullOrEmpty(DamageImmunities))
            {
                builder.AppendLine($"Damage Immunities {DamageImmunities}");
            }
            if (!String.IsNullOrEmpty(ConditionImmunities))
            {
                builder.AppendLine($"Condition Immunities {ConditionImmunities}");
            }
            var sensesList = new List<string>();
            if (Blindsight > 0)
            {
                sensesList.Add($"Blindsight {Blindsight} ft.");
            }
            if (Darkvision > 0)
            {
                sensesList.Add($"Darkvision {Darkvision} ft.");
            }
            if (Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {Tremorsense} ft.");
            }
            if (Truesight > 0)
            {
                sensesList.Add($"Truesight {Truesight} ft.");
            }
            sensesList.Add($"Passive Perception {PassivePerception}");
            builder.AppendLine($"Senses {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(Languages))
            {
                builder.AppendLine($"Languages {Languages}");
            }
            builder.AppendLine($"Challenge {Monster.ConvertChallengeRatingToString(ChallengeRating)} ({CalculateExperiencePoints(ChallengeRating)} XP)");
            builder.AppendLine($"Proficiency Bonus {Monster.ConvertBonusToSignedString(Monster.CalculateProficiencyBonus(ChallengeRating))}");
            if (SpecialAbilities!= null && SpecialAbilities.Count > 0)
            {
                foreach (var specialAbility in SpecialAbilities)
                {
                    builder.AppendLine($"{specialAbility.Name}. {specialAbility.Description}");
                }
            }
            if (Actions != null && Actions.Count > 0)
            {
                builder.AppendLine("Actions");
                foreach (var action in Actions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }
            if (LegendaryActions!= null && LegendaryActions.Count > 0)
            {
                builder.AppendLine("Legendary Actions");
                builder.AppendLine($"{LegendaryActionDescription}");
                foreach (var action in LegendaryActions)
                {
                    builder.AppendLine($"{action.Name}. {action.Description}");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Creates a Campaign-Logger statblock for the monster.
        /// </summary>
        /// <returns>Campaign-Logger statblock for the monster.</returns>
        public string ToCampaignLoggerStatBlock()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"```clyt");
            builder.AppendLine($"template: stat-block.5e");
            builder.AppendLine($"title: {Name}");
            builder.AppendLine($"description: {Size} {Type}, {Alignment}");
            builder.AppendLine($"stats:");
            builder.AppendLine($"- Armor Class: {ArmorClass} ({ArmorDesc})");
            builder.AppendLine($"- Hit Points: {HitPoints} ({HitDice})");
            var speeds = new List<string>();
            speeds.Add($"{Walk} ft.");
            if (Swim > 0)
            {
                speeds.Add($"Swim {Swim} ft.");
            }
            if (Fly > 0)
            {
                speeds.Add($"Fly {Fly} ft." + (Hover ? " (hover)" : String.Empty));
            }
            if (Burrow > 0)
            {
                speeds.Add($"Burrow {Burrow} ft.");
            }
            if (Climb > 0)
            {
                speeds.Add($"Climb {Climb} ft.");
            }
            if (LightWalking > 0)
            {
                speeds.Add($"Lightwalking {LightWalking} ft.");
            }
            builder.AppendLine($"- Speed: {string.Join(", ", speeds)}");
            builder.AppendLine($"- abilities:");
            builder.AppendLine($"     STR: {Strength} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Strength))})");
            builder.AppendLine($"     DEX: {Dexterity} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Dexterity))})");
            builder.AppendLine($"     CON: {Constitution} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Constitution))})");
            builder.AppendLine($"     INT: {Intelligence} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Intelligence))})");
            builder.AppendLine($"     WIS: {Wisdom} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Wisdom))})");
            builder.AppendLine($"     CHA: {Charisma} ({Monster.ConvertBonusToSignedString(CalculateAbilityBonus(Charisma))})");
            var savingThrows = new List<string>();
            if (StrengthSave > CalculateAbilityBonus(Strength))
            {
                savingThrows.Add($"STR {Monster.ConvertBonusToSignedString(StrengthSave)}");
            }
            if (DexteritySave > CalculateAbilityBonus(Dexterity))
            {
                savingThrows.Add($"DEX {Monster.ConvertBonusToSignedString(DexteritySave)}");
            }
            if (ConstitutionSave > CalculateAbilityBonus(Constitution))
            {
                savingThrows.Add($"CON {Monster.ConvertBonusToSignedString(ConstitutionSave)}");
            }
            if (IntelligenceSave > CalculateAbilityBonus(Intelligence))
            {
                savingThrows.Add($"INT {Monster.ConvertBonusToSignedString(IntelligenceSave)}");
            }
            if (WisdomSave > CalculateAbilityBonus(Wisdom))
            {
                savingThrows.Add($"WIS {Monster.ConvertBonusToSignedString(WisdomSave)}");
            }
            if (CharismaSave > CalculateAbilityBonus(Charisma))
            {
                savingThrows.Add($"CHA {Monster.ConvertBonusToSignedString(CharismaSave)}");
            }
            if (savingThrows.Count > 0) builder.AppendLine($"- Saving Throws: {string.Join(", ", savingThrows)}");
            var skillsList = new List<string>();
            if (Acrobatics > CalculateAbilityBonus(Dexterity))
            {
                skillsList.Add($"Acrobatics {Monster.ConvertBonusToSignedString(Acrobatics)}");
            }
            if (AnimalHandling > CalculateAbilityBonus(Wisdom))
            {
                skillsList.Add($"Animal Handling {Monster.ConvertBonusToSignedString(AnimalHandling)}");
            }
            if (Arcana > CalculateAbilityBonus(Intelligence))
            {
                skillsList.Add($"Arcana {Monster.ConvertBonusToSignedString(Arcana)}");
            }
            if (Athletics > CalculateAbilityBonus(Strength))
            {
                skillsList.Add($"Athletics {Monster.ConvertBonusToSignedString(Athletics)}");
            }
            if (Deception > CalculateAbilityBonus(Charisma))
            {
                skillsList.Add($"Deception {Monster.ConvertBonusToSignedString(Deception)}");
            }
            if (History > CalculateAbilityBonus(Intelligence))
            {
                skillsList.Add($"History {Monster.ConvertBonusToSignedString(History)}");
            }
            if (Insight > CalculateAbilityBonus(Wisdom))
            {
                skillsList.Add($"Insight {Monster.ConvertBonusToSignedString(Insight)}");
            }
            if (Intimidation > CalculateAbilityBonus(Charisma))
            {
                skillsList.Add($"Intimidation {Monster.ConvertBonusToSignedString(Intimidation)}");
            }
            if (Investigation > CalculateAbilityBonus(Intelligence))
            {
                skillsList.Add($"Investigation {Monster.ConvertBonusToSignedString(Investigation)}");
            }
            if (Medicine > CalculateAbilityBonus(Wisdom))
            {
                skillsList.Add($"Medicine {Monster.ConvertBonusToSignedString(Medicine)}");
            }
            if (Nature > CalculateAbilityBonus(Intelligence))
            {
                skillsList.Add($"Nature {Monster.ConvertBonusToSignedString(Nature)}");
            }
            if (Perception > CalculateAbilityBonus(Wisdom))
            {
                skillsList.Add($"Perception {Monster.ConvertBonusToSignedString(Perception)}");
            }
            if (Performance > CalculateAbilityBonus(Charisma))
            {
                skillsList.Add($"Performance {Monster.ConvertBonusToSignedString(Performance)}");
            }
            if (Persuasion > CalculateAbilityBonus(Charisma))
            {
                skillsList.Add($"Persuasion {Monster.ConvertBonusToSignedString(Persuasion)}");
            }
            if (Religion > CalculateAbilityBonus(Intelligence))
            {
                skillsList.Add($"Religion {Monster.ConvertBonusToSignedString(Religion)}");
            }
            if (SleightOfHand > CalculateAbilityBonus(Dexterity))
            {
                skillsList.Add($"Sleight of Hand {Monster.ConvertBonusToSignedString(SleightOfHand)}");
            }
            if (Stealth > CalculateAbilityBonus(Dexterity))
            {
                skillsList.Add($"Stealth {Monster.ConvertBonusToSignedString(Stealth)}");
            }
            if (Survival > CalculateAbilityBonus(Wisdom))
            {
                skillsList.Add($"Survival {Monster.ConvertBonusToSignedString(Survival)}");
            }
            if (skillsList.Count > 0) builder.AppendLine($"- Skills: {string.Join(", ", skillsList)}");
            if (!String.IsNullOrEmpty(DamageVulnerabilities))
            {
                builder.AppendLine($"- Damage Vulnerabilities: {DamageVulnerabilities}");
            }
            if (!String.IsNullOrEmpty(DamageResistances))
            {
                builder.AppendLine($"- Damage Resistances: {DamageResistances}");
            }
            if (!String.IsNullOrEmpty(DamageImmunities))
            {
                builder.AppendLine($"- Damage Immunities: {DamageImmunities}");
            }
            if (!String.IsNullOrEmpty(ConditionImmunities))
            {
                builder.AppendLine($"- Condition Immunities: {ConditionImmunities}");
            }
            var sensesList = new List<string>();
            if (Blindsight > 0)
            {
                sensesList.Add($"Blindsight {Blindsight} ft.");
            }
            if (Darkvision > 0)
            {
                sensesList.Add($"Darkvision {Darkvision} ft.");
            }
            if (Tremorsense > 0)
            {
                sensesList.Add($"Tremorsense {Tremorsense} ft.");
            }
            if (Truesight > 0)
            {
                sensesList.Add($"Truesight {Truesight} ft.");
            }
            sensesList.Add($"Passive Perception {PassivePerception}");
            builder.AppendLine($"- Senses: {string.Join(", ", sensesList)}");
            if (!string.IsNullOrEmpty(Languages))
            {
                builder.AppendLine($"- Languages: {Languages}");
            }
            builder.AppendLine($"- Challenge: {Monster.ConvertChallengeRatingToString(ChallengeRating)} ({CalculateExperiencePoints(ChallengeRating)} XP)");
            builder.AppendLine($"- Proficiency Bonus: {Monster.ConvertBonusToSignedString(Monster.CalculateProficiencyBonus(ChallengeRating))}");
            if (SpecialAbilities != null && SpecialAbilities.Count > 0)
            {
                builder.AppendLine("traits:");
                foreach (var specialAbility in SpecialAbilities)
                {
                    builder.AppendLine($"- {specialAbility.Name}: >");
                    foreach(var line in specialAbility.Description.Split("\n")){
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.StartsWith("•"))
                            {
                                builder.AppendLine($"- {line.Substring(2)}");
                            } else if (line.StartsWith("Cantrips") 
                                || line.StartsWith("1st level")
                                || line.StartsWith("2nd level")
                                || line.StartsWith("3rd level")
                                || line.StartsWith("4th level")
                                || line.StartsWith("5th level")
                                || line.StartsWith("6th level")
                                || line.StartsWith("7th level")
                                || line.StartsWith("8th level")
                                || line.StartsWith("9th level")
                                || line.StartsWith("10th level")
                                || line.StartsWith("11th level")
                                || line.StartsWith("12th level"))
                            {
                                builder.AppendLine($"- {line}");
                            }
                            else
                            {
                                builder.AppendLine($"    {line}");
                            }
                        }
                    }
                }
            }
            if (Actions != null && Actions.Count > 0)
            {
                builder.AppendLine("actions:");
                foreach (var action in Actions)
                {
                    builder.AppendLine($"- {action.Name}: >");
                    foreach (var line in action.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }
            if (Reactions != null && Reactions.Count > 0)
            {
                builder.AppendLine($"- Reactions: The {Name} has the following reactions.");
                foreach (var reaction in Reactions)
                {
                    builder.AppendLine($"- {reaction.Name}: >");
                    foreach (var line in reaction.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }
            if (LegendaryActions != null && LegendaryActions.Count > 0)
            {
                builder.AppendLine($"- Legendary Actions: {LegendaryActionDescription}");
                foreach (var legendaryAction in LegendaryActions)
                {
                    builder.AppendLine($"-  {legendaryAction.Name}: >");
                    foreach (var line in legendaryAction.Description.Split("\n"))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            builder.AppendLine($"    {line}");
                        }
                    }
                }
            }
            builder.AppendLine($"```");
            return builder.ToString();
        }
    }
}
