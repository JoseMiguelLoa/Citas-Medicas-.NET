using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CreacionCitaConRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitaModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attribute11 = table.Column<int>(type: "int", nullable: false),
                    pacienteId = table.Column<long>(type: "bigint", nullable: false),
                    medicoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaModel_Usuario_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaModel_Usuario_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaModel_medicoId",
                table: "CitaModel",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaModel_pacienteId",
                table: "CitaModel",
                column: "pacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaModel");
        }
    }
}
