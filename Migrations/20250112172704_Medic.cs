using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliclinicaHope.Migrations
{
    /// <inheritdoc />
    public partial class Medic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicId",
                table: "Procedura",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedura_MedicId",
                table: "Procedura",
                column: "MedicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedura_Medic_MedicId",
                table: "Procedura",
                column: "MedicId",
                principalTable: "Medic",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedura_Medic_MedicId",
                table: "Procedura");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropIndex(
                name: "IX_Procedura_MedicId",
                table: "Procedura");

            migrationBuilder.DropColumn(
                name: "MedicId",
                table: "Procedura");
        }
    }
}
