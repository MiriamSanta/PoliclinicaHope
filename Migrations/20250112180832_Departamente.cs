using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliclinicaHope.Migrations
{
    /// <inheritdoc />
    public partial class Departamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentProcedura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProceduraId = table.Column<int>(type: "int", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentProcedura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartamentProcedura_Departament_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentProcedura_Procedura_ProceduraId",
                        column: x => x.ProceduraId,
                        principalTable: "Procedura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentProcedura_DepartamentId",
                table: "DepartamentProcedura",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentProcedura_ProceduraId",
                table: "DepartamentProcedura",
                column: "ProceduraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentProcedura");

            migrationBuilder.DropTable(
                name: "Departament");
        }
    }
}
