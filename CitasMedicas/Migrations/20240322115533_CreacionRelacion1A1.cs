using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CreacionRelacion1A1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoModelPacienteModel",
                columns: table => new
                {
                    medicosId = table.Column<long>(type: "bigint", nullable: false),
                    pacientesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoModelPacienteModel", x => new { x.medicosId, x.pacientesId });
                    table.ForeignKey(
                        name: "FK_MedicoModelPacienteModel_Usuarios_medicosId",
                        column: x => x.medicosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicoModelPacienteModel_Usuarios_pacientesId",
                        column: x => x.pacientesId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoModelPacienteModel_pacientesId",
                table: "MedicoModelPacienteModel",
                column: "pacientesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoModelPacienteModel");
        }
    }
}
