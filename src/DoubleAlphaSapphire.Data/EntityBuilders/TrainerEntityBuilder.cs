using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal class TrainerEntityBuilder : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>()
                .ToTable("trainers");

            modelBuilder.Entity<Trainer>()
                .HasKey(e => e.TrainerId);

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(x => x.TrainerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("trainer_id")
                    .IsRequired()
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(x => x.TrainerName)
                    .HasMaxLength(50)
                    .HasColumnType("text")
                    .HasColumnName("trainer_name")
                    .IsRequired();
            });

            modelBuilder.Entity<Trainer>()
                .HasMany(t => t.Battles)
                .WithOne(b => b.Trainer);
        }
    }
}
