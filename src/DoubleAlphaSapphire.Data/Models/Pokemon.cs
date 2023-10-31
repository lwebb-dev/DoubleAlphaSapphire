using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoubleAlphaSapphire.Data
{
    [Table("pokemon")]
    public class Pokemon
    {
        [Required]
        [Column("dex_id")]
        public int DexId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("pokemon_name")]
        public string PokemonName { get; set; }
    }
}
