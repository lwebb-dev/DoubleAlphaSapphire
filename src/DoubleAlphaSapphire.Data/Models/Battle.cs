using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DoubleAlphaSapphire.Data
{
    [Table("battles")]
    public class Battle
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("battle_id")]
        public Guid BattleId { get; set; }

        [Required]
        [Column("trainer_id")]
        public Guid TrainerId { get; set; }

        [Required]
        [Column("player_id")]
        public Guid PlayerId { get; set; }

        [Required]
        [Column("player_name")]
        public int AttemptNumber { get; set; }
    }
}
