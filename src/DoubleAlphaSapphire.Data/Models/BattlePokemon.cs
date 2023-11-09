using System;

namespace DoubleAlphaSapphire.Data
{
    public class BattlePokemon
    {
        public Guid BattlePokemonId { get; set; }
        public Guid BattleId { get; set; }
        public int DexId { get; set; }
        public bool IsLead { get; set; }
        public bool IsFainted { get; set; }

        // Relational Data
        public Battle Battle { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
