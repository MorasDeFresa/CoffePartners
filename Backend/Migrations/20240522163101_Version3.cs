using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Version3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateBorn",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "NameUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurnameUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PointScore",
                table: "FarmerScores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Farms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Farms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "NameFarm",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBorn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NameUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SurnameUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PointScore",
                table: "FarmerScores");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "NameFarm",
                table: "Farms");
        }
    }
}
