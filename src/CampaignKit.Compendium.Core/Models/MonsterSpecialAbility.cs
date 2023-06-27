using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Campaign.Compendium.Core.Models
{
    public class MonsterSpecialAbility {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int MonsterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public Monster? Monster { get; set; }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (obj is not MonsterSpecialAbility)) return false;
            var other = obj as MonsterSpecialAbility;
            if (other == null)
            {
                return false;
            } else
            {
                return this.Name.Equals(other.Name);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
