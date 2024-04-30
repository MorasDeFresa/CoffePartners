using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeePartners.Migrations
{
    /// <inheritdoc />
    public partial class FixAssociations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultivationHarvests_Cultivations_IdCultivation1",
                table: "CultivationHarvests");

            migrationBuilder.DropForeignKey(
                name: "FK_CultivationHarvests_Harvests_IdHarvest1",
                table: "CultivationHarvests");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivations_Farms_IdFarm1",
                table: "Cultivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivations_StatesCultivations_IdStateCultivation1",
                table: "Cultivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Players_IdPlayer1",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_HarvestProcesss_CultivationHarvests_IdCultivationHarvest1",
                table: "HarvestProcesss");

            migrationBuilder.DropForeignKey(
                name: "FK_HarvestProcesss_TypeProcesss_IdTypeProcess1",
                table: "HarvestProcesss");

            migrationBuilder.DropForeignKey(
                name: "FK_Harvests_TypeQualitys_IdTypeQuality1",
                table: "Harvests");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Farms_IdFarm1",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Levels_IdLevel1",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProcesss_Machinerys_IdMachinery1",
                table: "TypeProcesss");

            migrationBuilder.RenameColumn(
                name: "IdMachinery1",
                table: "TypeProcesss",
                newName: "IdMachinery");

            migrationBuilder.RenameIndex(
                name: "IX_TypeProcesss_IdMachinery1",
                table: "TypeProcesss",
                newName: "IX_TypeProcesss_IdMachinery");

            migrationBuilder.RenameColumn(
                name: "IdLevel1",
                table: "Scores",
                newName: "IdLevel");

            migrationBuilder.RenameColumn(
                name: "IdFarm1",
                table: "Scores",
                newName: "IdFarm");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_IdLevel1",
                table: "Scores",
                newName: "IX_Scores_IdLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_IdFarm1",
                table: "Scores",
                newName: "IX_Scores_IdFarm");

            migrationBuilder.RenameColumn(
                name: "IdTypeQuality1",
                table: "Harvests",
                newName: "IdTypeQuality");

            migrationBuilder.RenameIndex(
                name: "IX_Harvests_IdTypeQuality1",
                table: "Harvests",
                newName: "IX_Harvests_IdTypeQuality");

            migrationBuilder.RenameColumn(
                name: "IdTypeProcess1",
                table: "HarvestProcesss",
                newName: "IdTypeProcess");

            migrationBuilder.RenameColumn(
                name: "IdCultivationHarvest1",
                table: "HarvestProcesss",
                newName: "IdCultivationHarvest");

            migrationBuilder.RenameIndex(
                name: "IX_HarvestProcesss_IdTypeProcess1",
                table: "HarvestProcesss",
                newName: "IX_HarvestProcesss_IdTypeProcess");

            migrationBuilder.RenameIndex(
                name: "IX_HarvestProcesss_IdCultivationHarvest1",
                table: "HarvestProcesss",
                newName: "IX_HarvestProcesss_IdCultivationHarvest");

            migrationBuilder.RenameColumn(
                name: "IdPlayer1",
                table: "Farms",
                newName: "IdPlayer");

            migrationBuilder.RenameIndex(
                name: "IX_Farms_IdPlayer1",
                table: "Farms",
                newName: "IX_Farms_IdPlayer");

            migrationBuilder.RenameColumn(
                name: "IdStateCultivation1",
                table: "Cultivations",
                newName: "IdStateCultivation");

            migrationBuilder.RenameColumn(
                name: "IdFarm1",
                table: "Cultivations",
                newName: "IdFarm");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivations_IdStateCultivation1",
                table: "Cultivations",
                newName: "IX_Cultivations_IdStateCultivation");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivations_IdFarm1",
                table: "Cultivations",
                newName: "IX_Cultivations_IdFarm");

            migrationBuilder.RenameColumn(
                name: "IdHarvest1",
                table: "CultivationHarvests",
                newName: "IdHarvest");

            migrationBuilder.RenameColumn(
                name: "IdCultivation1",
                table: "CultivationHarvests",
                newName: "IdCultivation");

            migrationBuilder.RenameIndex(
                name: "IX_CultivationHarvests_IdHarvest1",
                table: "CultivationHarvests",
                newName: "IX_CultivationHarvests_IdHarvest");

            migrationBuilder.RenameIndex(
                name: "IX_CultivationHarvests_IdCultivation1",
                table: "CultivationHarvests",
                newName: "IX_CultivationHarvests_IdCultivation");

            migrationBuilder.AddForeignKey(
                name: "FK_CultivationHarvests_Cultivations_IdCultivation",
                table: "CultivationHarvests",
                column: "IdCultivation",
                principalTable: "Cultivations",
                principalColumn: "IdCultivation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CultivationHarvests_Harvests_IdHarvest",
                table: "CultivationHarvests",
                column: "IdHarvest",
                principalTable: "Harvests",
                principalColumn: "IdHarvest",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivations_Farms_IdFarm",
                table: "Cultivations",
                column: "IdFarm",
                principalTable: "Farms",
                principalColumn: "IdFarm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivations_StatesCultivations_IdStateCultivation",
                table: "Cultivations",
                column: "IdStateCultivation",
                principalTable: "StatesCultivations",
                principalColumn: "IdStateCultivation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Players_IdPlayer",
                table: "Farms",
                column: "IdPlayer",
                principalTable: "Players",
                principalColumn: "IdPlayer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestProcesss_CultivationHarvests_IdCultivationHarvest",
                table: "HarvestProcesss",
                column: "IdCultivationHarvest",
                principalTable: "CultivationHarvests",
                principalColumn: "IdCultivationHarvest",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestProcesss_TypeProcesss_IdTypeProcess",
                table: "HarvestProcesss",
                column: "IdTypeProcess",
                principalTable: "TypeProcesss",
                principalColumn: "IdTypeProcess",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Harvests_TypeQualitys_IdTypeQuality",
                table: "Harvests",
                column: "IdTypeQuality",
                principalTable: "TypeQualitys",
                principalColumn: "IdTypeQuality",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Farms_IdFarm",
                table: "Scores",
                column: "IdFarm",
                principalTable: "Farms",
                principalColumn: "IdFarm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Levels_IdLevel",
                table: "Scores",
                column: "IdLevel",
                principalTable: "Levels",
                principalColumn: "IdLevel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProcesss_Machinerys_IdMachinery",
                table: "TypeProcesss",
                column: "IdMachinery",
                principalTable: "Machinerys",
                principalColumn: "IdMachinery",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultivationHarvests_Cultivations_IdCultivation",
                table: "CultivationHarvests");

            migrationBuilder.DropForeignKey(
                name: "FK_CultivationHarvests_Harvests_IdHarvest",
                table: "CultivationHarvests");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivations_Farms_IdFarm",
                table: "Cultivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivations_StatesCultivations_IdStateCultivation",
                table: "Cultivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Players_IdPlayer",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_HarvestProcesss_CultivationHarvests_IdCultivationHarvest",
                table: "HarvestProcesss");

            migrationBuilder.DropForeignKey(
                name: "FK_HarvestProcesss_TypeProcesss_IdTypeProcess",
                table: "HarvestProcesss");

            migrationBuilder.DropForeignKey(
                name: "FK_Harvests_TypeQualitys_IdTypeQuality",
                table: "Harvests");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Farms_IdFarm",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Levels_IdLevel",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProcesss_Machinerys_IdMachinery",
                table: "TypeProcesss");

            migrationBuilder.RenameColumn(
                name: "IdMachinery",
                table: "TypeProcesss",
                newName: "IdMachinery1");

            migrationBuilder.RenameIndex(
                name: "IX_TypeProcesss_IdMachinery",
                table: "TypeProcesss",
                newName: "IX_TypeProcesss_IdMachinery1");

            migrationBuilder.RenameColumn(
                name: "IdLevel",
                table: "Scores",
                newName: "IdLevel1");

            migrationBuilder.RenameColumn(
                name: "IdFarm",
                table: "Scores",
                newName: "IdFarm1");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_IdLevel",
                table: "Scores",
                newName: "IX_Scores_IdLevel1");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_IdFarm",
                table: "Scores",
                newName: "IX_Scores_IdFarm1");

            migrationBuilder.RenameColumn(
                name: "IdTypeQuality",
                table: "Harvests",
                newName: "IdTypeQuality1");

            migrationBuilder.RenameIndex(
                name: "IX_Harvests_IdTypeQuality",
                table: "Harvests",
                newName: "IX_Harvests_IdTypeQuality1");

            migrationBuilder.RenameColumn(
                name: "IdTypeProcess",
                table: "HarvestProcesss",
                newName: "IdTypeProcess1");

            migrationBuilder.RenameColumn(
                name: "IdCultivationHarvest",
                table: "HarvestProcesss",
                newName: "IdCultivationHarvest1");

            migrationBuilder.RenameIndex(
                name: "IX_HarvestProcesss_IdTypeProcess",
                table: "HarvestProcesss",
                newName: "IX_HarvestProcesss_IdTypeProcess1");

            migrationBuilder.RenameIndex(
                name: "IX_HarvestProcesss_IdCultivationHarvest",
                table: "HarvestProcesss",
                newName: "IX_HarvestProcesss_IdCultivationHarvest1");

            migrationBuilder.RenameColumn(
                name: "IdPlayer",
                table: "Farms",
                newName: "IdPlayer1");

            migrationBuilder.RenameIndex(
                name: "IX_Farms_IdPlayer",
                table: "Farms",
                newName: "IX_Farms_IdPlayer1");

            migrationBuilder.RenameColumn(
                name: "IdStateCultivation",
                table: "Cultivations",
                newName: "IdStateCultivation1");

            migrationBuilder.RenameColumn(
                name: "IdFarm",
                table: "Cultivations",
                newName: "IdFarm1");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivations_IdStateCultivation",
                table: "Cultivations",
                newName: "IX_Cultivations_IdStateCultivation1");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivations_IdFarm",
                table: "Cultivations",
                newName: "IX_Cultivations_IdFarm1");

            migrationBuilder.RenameColumn(
                name: "IdHarvest",
                table: "CultivationHarvests",
                newName: "IdHarvest1");

            migrationBuilder.RenameColumn(
                name: "IdCultivation",
                table: "CultivationHarvests",
                newName: "IdCultivation1");

            migrationBuilder.RenameIndex(
                name: "IX_CultivationHarvests_IdHarvest",
                table: "CultivationHarvests",
                newName: "IX_CultivationHarvests_IdHarvest1");

            migrationBuilder.RenameIndex(
                name: "IX_CultivationHarvests_IdCultivation",
                table: "CultivationHarvests",
                newName: "IX_CultivationHarvests_IdCultivation1");

            migrationBuilder.AddForeignKey(
                name: "FK_CultivationHarvests_Cultivations_IdCultivation1",
                table: "CultivationHarvests",
                column: "IdCultivation1",
                principalTable: "Cultivations",
                principalColumn: "IdCultivation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CultivationHarvests_Harvests_IdHarvest1",
                table: "CultivationHarvests",
                column: "IdHarvest1",
                principalTable: "Harvests",
                principalColumn: "IdHarvest",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivations_Farms_IdFarm1",
                table: "Cultivations",
                column: "IdFarm1",
                principalTable: "Farms",
                principalColumn: "IdFarm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivations_StatesCultivations_IdStateCultivation1",
                table: "Cultivations",
                column: "IdStateCultivation1",
                principalTable: "StatesCultivations",
                principalColumn: "IdStateCultivation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Players_IdPlayer1",
                table: "Farms",
                column: "IdPlayer1",
                principalTable: "Players",
                principalColumn: "IdPlayer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestProcesss_CultivationHarvests_IdCultivationHarvest1",
                table: "HarvestProcesss",
                column: "IdCultivationHarvest1",
                principalTable: "CultivationHarvests",
                principalColumn: "IdCultivationHarvest",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestProcesss_TypeProcesss_IdTypeProcess1",
                table: "HarvestProcesss",
                column: "IdTypeProcess1",
                principalTable: "TypeProcesss",
                principalColumn: "IdTypeProcess",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Harvests_TypeQualitys_IdTypeQuality1",
                table: "Harvests",
                column: "IdTypeQuality1",
                principalTable: "TypeQualitys",
                principalColumn: "IdTypeQuality",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Farms_IdFarm1",
                table: "Scores",
                column: "IdFarm1",
                principalTable: "Farms",
                principalColumn: "IdFarm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Levels_IdLevel1",
                table: "Scores",
                column: "IdLevel1",
                principalTable: "Levels",
                principalColumn: "IdLevel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProcesss_Machinerys_IdMachinery1",
                table: "TypeProcesss",
                column: "IdMachinery1",
                principalTable: "Machinerys",
                principalColumn: "IdMachinery",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
