using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoubleAlphaSapphire.Data
{
    [Table("trainers")]
    public class Trainer
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("trainer_id")]
        public Guid TrainerId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("trainer_name")]
        public string TrainerName { get; set; }
    }
}
