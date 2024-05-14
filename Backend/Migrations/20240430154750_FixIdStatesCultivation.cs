using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeePartners.Migrations
{
    /// <inheritdoc />
    public partial class FixIdStatesCultivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdStateCultivation",
                table: "StatesCultivations",
                newName: "IdStatesCultivation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdStatesCultivation",
                table: "StatesCultivations",
                newName: "IdStateCultivation");
        }
    }
}
