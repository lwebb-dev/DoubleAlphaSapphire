using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoubleAlphaSapphire.Data
{
    [Table("battle_pokemon")]
    public class BattlePokemon
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("battle_pokemon_id")]
        public Guid BattlePokemonId { get; set; }

        [Required]
        [Column("battle_id")]
        public Guid BattleId { get; set; }

        [Required]
        [Column("dex_id")]
        public int DexId { get; set; }

        [Required]
        [Column("is_lead")]
        public bool IsLead { get; set; }

        [Required]
        [Column("is_fainted")]
        public bool IsFainted { get; set; }
    }
}
