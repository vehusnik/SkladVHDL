using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMaterialFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPridani",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Komentar",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MnozDoPal",
                table: "Materials",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MnozPoj",
                table: "Materials",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumPridani",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Komentar",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MnozDoPal",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MnozPoj",
                table: "Materials");
        }
    }
}
