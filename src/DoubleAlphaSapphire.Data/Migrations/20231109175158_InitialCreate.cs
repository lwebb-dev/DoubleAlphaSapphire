using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoubleAlphaSapphire.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    player_name = table.Column<string>(type: "text", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    dex_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pokemon_name = table.Column<string>(type: "text", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.dex_id);
                });

            migrationBuilder.CreateTable(
                name: "trainers",
                columns: table => new
                {
                    trainer_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    trainer_name = table.Column<string>(type: "text", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainers", x => x.trainer_id);
                });

            migrationBuilder.CreateTable(
                name: "battles",
                columns: table => new
                {
                    battle_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    trainer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_id = table.Column<Guid>(type: "uuid", nullable: false),
                    attempt_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_battles", x => x.battle_id);
                    table.ForeignKey(
                        name: "FK_battles_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_battles_trainers_trainer_id",
                        column: x => x.trainer_id,
                        principalTable: "trainers",
                        principalColumn: "trainer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "battle_pokemon",
                columns: table => new
                {
                    battle_pokemon_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    battle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dex_id = table.Column<int>(type: "integer", nullable: false),
                    is_lead = table.Column<bool>(type: "boolean", nullable: false),
                    is_fainted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_battle_pokemon", x => x.battle_pokemon_id);
                    table.ForeignKey(
                        name: "FK_battle_pokemon_battles_battle_id",
                        column: x => x.battle_id,
                        principalTable: "battles",
                        principalColumn: "battle_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_battle_pokemon_pokemon_dex_id",
                        column: x => x.dex_id,
                        principalTable: "pokemon",
                        principalColumn: "dex_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_battle_pokemon_battle_id",
                table: "battle_pokemon",
                column: "battle_id");

            migrationBuilder.CreateIndex(
                name: "IX_battle_pokemon_dex_id",
                table: "battle_pokemon",
                column: "dex_id");

            migrationBuilder.CreateIndex(
                name: "IX_battles_player_id",
                table: "battles",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_battles_trainer_id",
                table: "battles",
                column: "trainer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "battle_pokemon");

            migrationBuilder.DropTable(
                name: "battles");

            migrationBuilder.DropTable(
                name: "pokemon");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "trainers");
        }
    }
}
