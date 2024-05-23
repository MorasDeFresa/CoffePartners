using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivements",
                columns: table => new
                {
                    IdArchivement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArchivement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionArchivement = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivements", x => x.IdArchivement);
                });

            migrationBuilder.CreateTable(
                name: "PlantStates",
                columns: table => new
                {
                    IdPlantState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePlantState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPlantState = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantStates", x => x.IdPlantState);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    IdScore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimunPoints = table.Column<float>(type: "real", nullable: false),
                    MaximunPoints = table.Column<float>(type: "real", nullable: false),
                    DescriptionScore = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.IdScore);
                });

            migrationBuilder.CreateTable(
                name: "TypeQualitys",
                columns: table => new
                {
                    IdTypeQuality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTypeQuality = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeQualitys", x => x.IdTypeQuality);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurnameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    IdFarmer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickNameFarmer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.IdFarmer);
                    table.ForeignKey(
                        name: "FK_Farmers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    IdPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPost = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.IdPost);
                    table.ForeignKey(
                        name: "FK_Posts_Admins_IdAdmin",
                        column: x => x.IdAdmin,
                        principalTable: "Admins",
                        principalColumn: "IdAdmin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    IdFarm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateFarm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateFarm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFarmer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.IdFarm);
                    table.ForeignKey(
                        name: "FK_Farms_Farmers_IdFarmer",
                        column: x => x.IdFarmer,
                        principalTable: "Farmers",
                        principalColumn: "IdFarmer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmerArchivements",
                columns: table => new
                {
                    IdFarmerArchivement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateArchivement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdArchivement = table.Column<int>(type: "int", nullable: false),
                    IdFarmer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerArchivements", x => x.IdFarmerArchivement);
                    table.ForeignKey(
                        name: "FK_FarmerArchivements_Archivements_IdArchivement",
                        column: x => x.IdArchivement,
                        principalTable: "Archivements",
                        principalColumn: "IdArchivement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmerArchivements_Farmers_IdFarmer",
                        column: x => x.IdFarmer,
                        principalTable: "Farmers",
                        principalColumn: "IdFarmer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmerScores",
                columns: table => new
                {
                    IdFarmerScore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurnameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFarmer = table.Column<int>(type: "int", nullable: false),
                    IdScore = table.Column<int>(type: "int", nullable: false),
                    DateScore = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerScores", x => x.IdFarmerScore);
                    table.ForeignKey(
                        name: "FK_FarmerScores_Farmers_IdFarmer",
                        column: x => x.IdFarmer,
                        principalTable: "Farmers",
                        principalColumn: "IdFarmer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmerScores_Scores_IdScore",
                        column: x => x.IdScore,
                        principalTable: "Scores",
                        principalColumn: "IdScore",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    IdPlant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionX = table.Column<float>(type: "real", nullable: false),
                    PositionZ = table.Column<float>(type: "real", nullable: false),
                    IdFarm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.IdPlant);
                    table.ForeignKey(
                        name: "FK_Plants_Farms_IdFarm",
                        column: x => x.IdFarm,
                        principalTable: "Farms",
                        principalColumn: "IdFarm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    IdHarvest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightHarvest = table.Column<float>(type: "real", nullable: false),
                    DateBasketProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    IdTypeQuality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.IdHarvest);
                    table.ForeignKey(
                        name: "FK_Harvests_Plants_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plants",
                        principalColumn: "IdPlant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Harvests_TypeQualitys_IdTypeQuality",
                        column: x => x.IdTypeQuality,
                        principalTable: "TypeQualitys",
                        principalColumn: "IdTypeQuality",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryPlants",
                columns: table => new
                {
                    IdHistoryPlant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePlantProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    IdPlantState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPlants", x => x.IdHistoryPlant);
                    table.ForeignKey(
                        name: "FK_HistoryPlants_PlantStates_IdPlantState",
                        column: x => x.IdPlantState,
                        principalTable: "PlantStates",
                        principalColumn: "IdPlantState",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryPlants_Plants_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plants",
                        principalColumn: "IdPlant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_IdPlant",
                table: "Harvests",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_IdTypeQuality",
                table: "Harvests",
                column: "IdTypeQuality");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdUser",
                table: "Admins",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_IdFarmer",
                table: "Farms",
                column: "IdFarmer");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPlants_IdPlant",
                table: "HistoryPlants",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPlants_IdPlantState",
                table: "HistoryPlants",
                column: "IdPlantState");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_IdFarm",
                table: "Plants",
                column: "IdFarm");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerArchivements_IdArchivement",
                table: "FarmerArchivements",
                column: "IdArchivement");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerArchivements_IdFarmer",
                table: "FarmerArchivements",
                column: "IdFarmer");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_IdUser",
                table: "Farmers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerScores_IdFarmer",
                table: "FarmerScores",
                column: "IdFarmer");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerScores_IdScore",
                table: "FarmerScores",
                column: "IdScore");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdAdmin",
                table: "Posts",
                column: "IdAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "HistoryPlants");

            migrationBuilder.DropTable(
                name: "FarmerArchivements");

            migrationBuilder.DropTable(
                name: "FarmerScores");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TypeQualitys");

            migrationBuilder.DropTable(
                name: "PlantStates");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Archivements");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
