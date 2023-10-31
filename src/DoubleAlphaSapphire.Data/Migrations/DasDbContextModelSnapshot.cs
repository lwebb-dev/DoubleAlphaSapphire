﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoubleAlphaSapphire.Data.Migrations
{
    [DbContext(typeof(DasDbContext))]
    partial class DasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DoubleAlphaSapphireApp.Data.Models.Battle", b =>
                {
                    b.Property<Guid>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("battle_id");

                    b.Property<int>("AttemptNumber")
                        .HasColumnType("integer")
                        .HasColumnName("player_name");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid")
                        .HasColumnName("player_id");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uuid")
                        .HasColumnName("trainer_id");

                    b.HasKey("BattleId");

                    b.ToTable("battles");
                });

            modelBuilder.Entity("DoubleAlphaSapphireApp.Data.Models.BattlePokemon", b =>
                {
                    b.Property<Guid>("BattlePokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("battle_pokemon_id");

                    b.Property<Guid>("BattleId")
                        .HasColumnType("uuid")
                        .HasColumnName("battle_id");

                    b.Property<int>("DexId")
                        .HasColumnType("integer")
                        .HasColumnName("dex_id");

                    b.Property<bool>("IsFainted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_fainted");

                    b.Property<bool>("IsLead")
                        .HasColumnType("boolean")
                        .HasColumnName("is_lead");

                    b.HasKey("BattlePokemonId");

                    b.ToTable("battle_pokemon");
                });

            modelBuilder.Entity("DoubleAlphaSapphireApp.Data.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("player_id");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("player_name");

                    b.HasKey("PlayerId");

                    b.ToTable("player");
                });

            modelBuilder.Entity("DoubleAlphaSapphireApp.Data.Models.Pokemon", b =>
                {
                    b.Property<int>("DexId")
                        .HasColumnType("integer")
                        .HasColumnName("dex_id");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("pokemon_name");

                    b.ToTable("pokemon");
                });

            modelBuilder.Entity("DoubleAlphaSapphireApp.Data.Models.Trainer", b =>
                {
                    b.Property<Guid>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("trainer_id");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("trainer_name");

                    b.HasKey("TrainerId");

                    b.ToTable("trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
