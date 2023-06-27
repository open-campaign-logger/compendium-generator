using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Campaign.Compendium.Core.Models
{
    public class MonsterAction {
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
            if ((obj == null) || (obj is not MonsterAction)) return false;
            var other = obj as MonsterAction;
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
