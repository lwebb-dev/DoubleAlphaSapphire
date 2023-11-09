using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal class PlayerEntityBuilder : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .ToTable("players");

            modelBuilder.Entity<Player>()
                .HasKey(e => e.PlayerId);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(x => x.PlayerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("player_id")
                    .IsRequired()
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(x => x.PlayerName)
                    .HasMaxLength(50)
                    .HasColumnType("text")
                    .HasColumnName("player_name")
                    .IsRequired();
            });

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Battles)
                .WithOne(b => b.Player);
        }
    }
}
