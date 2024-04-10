using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDiagnosticoConRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosticoModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    citaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticoModel_CitaModel_citaId",
                        column: x => x.citaId,
                        principalTable: "CitaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticoModel_citaId",
                table: "DiagnosticoModel",
                column: "citaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticoModel");
        }
    }
}
