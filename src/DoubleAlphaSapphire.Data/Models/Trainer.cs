using System;
using System.Collections.Generic;

namespace DoubleAlphaSapphire.Data
{
    public class Trainer
    {
        public Guid TrainerId { get; set; }
        public string TrainerName { get; set; }

        // Relational Data
        public List<Battle> Battles { get; set; }
    }
}
