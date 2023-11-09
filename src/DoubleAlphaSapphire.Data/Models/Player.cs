using System;
using System.Collections.Generic;

namespace DoubleAlphaSapphire.Data
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }

        // Relational Data
        public List<Battle> Battles { get; set; }
    }
}
