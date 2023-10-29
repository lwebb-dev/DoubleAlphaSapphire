using DoubleAlphaSapphireApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data
{
    public class DasDbContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattlePokemon> BattlePokemon { get; set; }

        public DasDbContext(DbContextOptions<DasDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasNoKey();
        }
    }
}
