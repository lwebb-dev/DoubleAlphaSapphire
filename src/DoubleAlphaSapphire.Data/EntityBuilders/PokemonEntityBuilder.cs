using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal class PokemonEntityBuilder : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .ToTable("pokemon");

            modelBuilder.Entity<Pokemon>()
                .HasKey(e => e.DexId);

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.Property(e => e.DexId)
                    .HasColumnType("integer")
                    .HasColumnName("dex_id")
                    .IsRequired();

                entity.Property(e => e.PokemonName)
                    .HasColumnType("text")
                    .HasMaxLength(50)
                    .HasColumnName("pokemon_name")
                    .IsRequired();
            });

            modelBuilder.Entity<Pokemon>()
                .HasMany(p => p.BattlePokemon)
                .WithOne(bp => bp.Pokemon);
        }
    }
}
