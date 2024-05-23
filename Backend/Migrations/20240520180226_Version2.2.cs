using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Version22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAdmin",
                table: "FarmerScores");

            migrationBuilder.DropColumn(
                name: "SurnameAdmin",
                table: "FarmerScores");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Posts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "NameAdmin",
                table: "FarmerScores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurnameAdmin",
                table: "FarmerScores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
