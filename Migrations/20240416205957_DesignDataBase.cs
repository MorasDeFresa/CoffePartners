using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeePartners.Migrations
{
    /// <inheritdoc />
    public partial class DesignDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    IdLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.IdLevel);
                });

            migrationBuilder.CreateTable(
                name: "Machinerys",
                columns: table => new
                {
                    IdMachinery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceMachine = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machinerys", x => x.IdMachinery);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailPlayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordPlayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NicknamePlayer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "StatesCultivations",
                columns: table => new
                {
                    IdStateCultivation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStateCultivation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatesCultivations", x => x.IdStateCultivation);
                });

            migrationBuilder.CreateTable(
                name: "TypeQualitys",
                columns: table => new
                {
                    IdTypeQuality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceByGr = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeQualitys", x => x.IdTypeQuality);
                });

            migrationBuilder.CreateTable(
                name: "TypeProcesss",
                columns: table => new
                {
                    IdTypeProcess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMachinery1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProcesss", x => x.IdTypeProcess);
                    table.ForeignKey(
                        name: "FK_TypeProcesss_Machinerys_IdMachinery1",
                        column: x => x.IdMachinery1,
                        principalTable: "Machinerys",
                        principalColumn: "IdMachinery",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    IdFarm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeFarm = table.Column<float>(type: "real", nullable: false),
                    NameFarm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPlayer1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.IdFarm);
                    table.ForeignKey(
                        name: "FK_Farms_Players_IdPlayer1",
                        column: x => x.IdPlayer1,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    IdHarvest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHarvest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTypeQuality1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.IdHarvest);
                    table.ForeignKey(
                        name: "FK_Harvests_TypeQualitys_IdTypeQuality1",
                        column: x => x.IdTypeQuality1,
                        principalTable: "TypeQualitys",
                        principalColumn: "IdTypeQuality",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultivations",
                columns: table => new
                {
                    IdCultivation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCultivation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    IdFarm1 = table.Column<int>(type: "int", nullable: false),
                    IdStateCultivation1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivations", x => x.IdCultivation);
                    table.ForeignKey(
                        name: "FK_Cultivations_Farms_IdFarm1",
                        column: x => x.IdFarm1,
                        principalTable: "Farms",
                        principalColumn: "IdFarm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivations_StatesCultivations_IdStateCultivation1",
                        column: x => x.IdStateCultivation1,
                        principalTable: "StatesCultivations",
                        principalColumn: "IdStateCultivation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    IdScore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<float>(type: "real", nullable: false),
                    IdLevel1 = table.Column<int>(type: "int", nullable: false),
                    IdFarm1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.IdScore);
                    table.ForeignKey(
                        name: "FK_Scores_Farms_IdFarm1",
                        column: x => x.IdFarm1,
                        principalTable: "Farms",
                        principalColumn: "IdFarm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Levels_IdLevel1",
                        column: x => x.IdLevel1,
                        principalTable: "Levels",
                        principalColumn: "IdLevel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CultivationHarvests",
                columns: table => new
                {
                    IdCultivationHarvest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivation1 = table.Column<int>(type: "int", nullable: false),
                    IdHarvest1 = table.Column<int>(type: "int", nullable: false),
                    WeightHarvest = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivationHarvests", x => x.IdCultivationHarvest);
                    table.ForeignKey(
                        name: "FK_CultivationHarvests_Cultivations_IdCultivation1",
                        column: x => x.IdCultivation1,
                        principalTable: "Cultivations",
                        principalColumn: "IdCultivation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CultivationHarvests_Harvests_IdHarvest1",
                        column: x => x.IdHarvest1,
                        principalTable: "Harvests",
                        principalColumn: "IdHarvest",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarvestProcesss",
                columns: table => new
                {
                    IdHarvestProcess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivationHarvest1 = table.Column<int>(type: "int", nullable: false),
                    IdTypeProcess1 = table.Column<int>(type: "int", nullable: false),
                    HeightWastedGrain = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestProcesss", x => x.IdHarvestProcess);
                    table.ForeignKey(
                        name: "FK_HarvestProcesss_CultivationHarvests_IdCultivationHarvest1",
                        column: x => x.IdCultivationHarvest1,
                        principalTable: "CultivationHarvests",
                        principalColumn: "IdCultivationHarvest",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestProcesss_TypeProcesss_IdTypeProcess1",
                        column: x => x.IdTypeProcess1,
                        principalTable: "TypeProcesss",
                        principalColumn: "IdTypeProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CultivationHarvests_IdCultivation1",
                table: "CultivationHarvests",
                column: "IdCultivation1");

            migrationBuilder.CreateIndex(
                name: "IX_CultivationHarvests_IdHarvest1",
                table: "CultivationHarvests",
                column: "IdHarvest1");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_IdFarm1",
                table: "Cultivations",
                column: "IdFarm1");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_IdStateCultivation1",
                table: "Cultivations",
                column: "IdStateCultivation1");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_IdPlayer1",
                table: "Farms",
                column: "IdPlayer1");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestProcesss_IdCultivationHarvest1",
                table: "HarvestProcesss",
                column: "IdCultivationHarvest1");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestProcesss_IdTypeProcess1",
                table: "HarvestProcesss",
                column: "IdTypeProcess1");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_IdTypeQuality1",
                table: "Harvests",
                column: "IdTypeQuality1");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_IdFarm1",
                table: "Scores",
                column: "IdFarm1");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_IdLevel1",
                table: "Scores",
                column: "IdLevel1");

            migrationBuilder.CreateIndex(
                name: "IX_TypeProcesss_IdMachinery1",
                table: "TypeProcesss",
                column: "IdMachinery1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarvestProcesss");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "CultivationHarvests");

            migrationBuilder.DropTable(
                name: "TypeProcesss");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Cultivations");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "Machinerys");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "StatesCultivations");

            migrationBuilder.DropTable(
                name: "TypeQualitys");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
