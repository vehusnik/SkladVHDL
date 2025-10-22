using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class _04_Sklad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MerneJednotky_MernaJednotkaID",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MnoDoPal",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Materialy");

            migrationBuilder.RenameColumn(
                name: "MernaJednotkaID",
                table: "MerneJednotky",
                newName: "MernaJednotkaId");

            migrationBuilder.RenameColumn(
                name: "MernaJednotkaID",
                table: "Materialy",
                newName: "MernaJednotkaId");

            migrationBuilder.RenameColumn(
                name: "MaterialID",
                table: "Materialy",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "DatumPridani",
                table: "Materialy",
                newName: "DatumVytvoreni");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_MernaJednotkaID",
                table: "Materialy",
                newName: "IX_Materialy_MernaJednotkaId");

            migrationBuilder.AlterColumn<string>(
                name: "Popis",
                table: "MerneJednotky",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumVytvoreni",
                table: "MerneJednotky",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MerneJednotky",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazev",
                table: "Materialy",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Materialy",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MnozDoPal",
                table: "Materialy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Materialy",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materialy",
                table: "Materialy",
                column: "MaterialId");

            migrationBuilder.CreateTable(
                name: "Palety",
                columns: table => new
                {
                    PaletaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<int>(type: "int", nullable: false),
                    Stav = table.Column<int>(type: "int", nullable: false),
                    AdresaUlozeni = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Mnozstvi = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DatumVytvoreni = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palety", x => x.PaletaId);
                    table.ForeignKey(
                        name: "FK_Palety_Materialy_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materialy",
                        principalColumn: "MaterialId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palety_MaterialId",
                table: "Palety",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materialy_MerneJednotky_MernaJednotkaId",
                table: "Materialy",
                column: "MernaJednotkaId",
                principalTable: "MerneJednotky",
                principalColumn: "MernaJednotkaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materialy_MerneJednotky_MernaJednotkaId",
                table: "Materialy");

            migrationBuilder.DropTable(
                name: "Palety");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materialy",
                table: "Materialy");

            migrationBuilder.DropColumn(
                name: "DatumVytvoreni",
                table: "MerneJednotky");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MerneJednotky");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Materialy");

            migrationBuilder.DropColumn(
                name: "MnozDoPal",
                table: "Materialy");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Materialy");

            migrationBuilder.RenameTable(
                name: "Materialy",
                newName: "Materials");

            migrationBuilder.RenameColumn(
                name: "MernaJednotkaId",
                table: "MerneJednotky",
                newName: "MernaJednotkaID");

            migrationBuilder.RenameColumn(
                name: "MernaJednotkaId",
                table: "Materials",
                newName: "MernaJednotkaID");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Materials",
                newName: "MaterialID");

            migrationBuilder.RenameColumn(
                name: "DatumVytvoreni",
                table: "Materials",
                newName: "DatumPridani");

            migrationBuilder.RenameIndex(
                name: "IX_Materialy_MernaJednotkaId",
                table: "Materials",
                newName: "IX_Materials_MernaJednotkaID");

            migrationBuilder.AlterColumn<string>(
                name: "Popis",
                table: "MerneJednotky",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazev",
                table: "Materials",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "MnoDoPal",
                table: "Materials",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MerneJednotky_MernaJednotkaID",
                table: "Materials",
                column: "MernaJednotkaID",
                principalTable: "MerneJednotky",
                principalColumn: "MernaJednotkaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
