using System;
using System.Collections.Generic;

namespace DoubleAlphaSapphire.Data
{
    public class Battle
    {
        public Guid BattleId { get; set; }
        public Guid TrainerId { get; set; }
        public Guid PlayerId { get; set; }
        public int AttemptNumber { get; set; }

        // Relational Data
        public Trainer Trainer { get; set; }
        public Player Player { get; set; }
        public List<BattlePokemon> BattlePokemon { get; set; }
    }
}
