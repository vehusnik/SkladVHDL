using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class _003_UpdateMaterialFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MnozDoPal",
                table: "Materials",
                newName: "MnoDoPal");

            migrationBuilder.AddColumn<int>(
                name: "MernaJednotkaID",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MerneJednotky",
                columns: table => new
                {
                    MernaJednotkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Popis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerneJednotky", x => x.MernaJednotkaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MernaJednotkaID",
                table: "Materials",
                column: "MernaJednotkaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MerneJednotky_MernaJednotkaID",
                table: "Materials",
                column: "MernaJednotkaID",
                principalTable: "MerneJednotky",
                principalColumn: "MernaJednotkaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MerneJednotky_MernaJednotkaID",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "MerneJednotky");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MernaJednotkaID",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MernaJednotkaID",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "MnoDoPal",
                table: "Materials",
                newName: "MnozDoPal");
        }
    }
}
