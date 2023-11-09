using System.Collections.Generic;

namespace DoubleAlphaSapphire.Data
{
    public class Pokemon
    {
        public int DexId { get; set; }
        public string PokemonName { get; set; }

        // Relational Data
        public List<BattlePokemon> BattlePokemon { get; set; }
    }
}
