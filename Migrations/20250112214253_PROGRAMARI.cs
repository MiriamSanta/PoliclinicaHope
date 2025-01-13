using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliclinicaHope.Migrations
{
    /// <inheritdoc />
    public partial class PROGRAMARI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientId = table.Column<int>(type: "int", nullable: true),
                    ProceduraID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Pacient_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacient",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Procedura_ProceduraID",
                        column: x => x.ProceduraID,
                        principalTable: "Procedura",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_PacientId",
                table: "Programare",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ProceduraID",
                table: "Programare",
                column: "ProceduraID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Pacient");
        }
    }
}
