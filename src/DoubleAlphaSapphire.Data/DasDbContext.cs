using DoubleAlphaSapphire.Data.EntityBuilders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DoubleAlphaSapphire.Data
{
    public class DasDbContext : DbContext
    {
        private IList<IEntityBuilder> entityBuilders;
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattlePokemon> BattlePokemon { get; set; }

        public DasDbContext(DbContextOptions<DasDbContext> options)
            : base(options)
        {
            this.entityBuilders = new List<IEntityBuilder>
            {
                new TrainerEntityBuilder(),
                new PlayerEntityBuilder(),
                new PokemonEntityBuilder(),
                new BattleEntityBuilder(),
                new BattlePokemonEntityBuilder()
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IEntityBuilder entityBuilder in this.entityBuilders)
            {
                entityBuilder.Build(modelBuilder);
            }
        }
    }
}
