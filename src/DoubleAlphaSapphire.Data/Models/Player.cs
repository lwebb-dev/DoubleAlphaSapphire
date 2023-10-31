using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoubleAlphaSapphire.Data
{
    [Table("player")]
    public class Player
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("player_id")]
        public Guid PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("player_name")]
        public string PlayerName { get; set; }
    }
}
