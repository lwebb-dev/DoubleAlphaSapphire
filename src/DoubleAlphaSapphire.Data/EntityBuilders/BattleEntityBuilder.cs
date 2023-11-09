using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal class BattleEntityBuilder : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battle>()
                .ToTable("battles");

            modelBuilder.Entity<Battle>()
                .HasKey(x => x.BattleId);

            modelBuilder.Entity<Battle>(entity =>
            {
                entity.Property(e => e.BattleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("battle_id")
                    .IsRequired()
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.TrainerId)
                    .HasColumnType("uuid")
                    .HasColumnName("trainer_id")
                    .IsRequired();

                entity.Property(e => e.PlayerId)
                    .HasColumnType("uuid")
                    .HasColumnName("player_id")
                    .IsRequired();

                entity.Property(e => e.AttemptNumber)
                    .HasColumnType("integer")
                    .HasColumnName("attempt_number")
                    .IsRequired();
            });

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Trainer)
                .WithMany(t => t.Battles)
                .HasForeignKey(b => b.TrainerId);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Player)
                .WithMany(p => p.Battles)
                .HasForeignKey(b => b.PlayerId);

            modelBuilder.Entity<Battle>()
                .HasMany(b => b.BattlePokemon)
                .WithOne(bp => bp.Battle);
        }
    }
}
