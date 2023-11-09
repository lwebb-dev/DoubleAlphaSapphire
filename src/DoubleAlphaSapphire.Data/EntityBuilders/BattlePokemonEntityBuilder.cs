using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal class BattlePokemonEntityBuilder : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattlePokemon>()
                .ToTable("battle_pokemon");

            modelBuilder.Entity<BattlePokemon>()
                .HasKey(e => e.BattlePokemonId);

            modelBuilder.Entity<BattlePokemon>(entity =>
            {
                entity.Property(e => e.BattlePokemonId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("battle_pokemon_id")
                    .IsRequired()
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.BattleId)
                    .HasColumnType("uuid")
                    .HasColumnName("battle_id")
                    .IsRequired();

                entity.Property(e => e.DexId)
                    .HasColumnType("integer")
                    .HasColumnName("dex_id")
                    .IsRequired();

                entity.Property(e => e.IsLead)
                    .HasColumnType("boolean")
                    .HasColumnName("is_lead")
                    .IsRequired();

                entity.Property(e => e.IsFainted)
                    .HasColumnType("boolean")
                    .HasColumnName("is_fainted")
                    .IsRequired();
            });

            modelBuilder.Entity<BattlePokemon>()
                .HasOne(bp => bp.Battle)
                .WithMany(b => b.BattlePokemon)
                .HasForeignKey(bp => bp.BattleId);

            modelBuilder.Entity<BattlePokemon>()
                .HasOne(bp => bp.Pokemon)
                .WithMany(p => p.BattlePokemon)
                .HasForeignKey(bp => bp.DexId);
        }
    }
}
