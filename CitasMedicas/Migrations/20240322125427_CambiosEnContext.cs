using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CambiosEnContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitaModel_Usuario_medicoId",
                table: "CitaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaModel_Usuario_pacienteId",
                table: "CitaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosticoModel_CitaModel_citaId",
                table: "DiagnosticoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosticoModel",
                table: "DiagnosticoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitaModel",
                table: "CitaModel");

            migrationBuilder.RenameTable(
                name: "DiagnosticoModel",
                newName: "Diagnostico");

            migrationBuilder.RenameTable(
                name: "CitaModel",
                newName: "Cita");

            migrationBuilder.RenameIndex(
                name: "IX_DiagnosticoModel_citaId",
                table: "Diagnostico",
                newName: "IX_Diagnostico_citaId");

            migrationBuilder.RenameIndex(
                name: "IX_CitaModel_pacienteId",
                table: "Cita",
                newName: "IX_Cita_pacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_CitaModel_medicoId",
                table: "Cita",
                newName: "IX_Cita_medicoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnostico",
                table: "Diagnostico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cita",
                table: "Cita",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_medicoId",
                table: "Cita",
                column: "medicoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_pacienteId",
                table: "Cita",
                column: "pacienteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Cita_citaId",
                table: "Diagnostico",
                column: "citaId",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Usuario_medicoId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Usuario_pacienteId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Cita_citaId",
                table: "Diagnostico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnostico",
                table: "Diagnostico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cita",
                table: "Cita");

            migrationBuilder.RenameTable(
                name: "Diagnostico",
                newName: "DiagnosticoModel");

            migrationBuilder.RenameTable(
                name: "Cita",
                newName: "CitaModel");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnostico_citaId",
                table: "DiagnosticoModel",
                newName: "IX_DiagnosticoModel_citaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_pacienteId",
                table: "CitaModel",
                newName: "IX_CitaModel_pacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_medicoId",
                table: "CitaModel",
                newName: "IX_CitaModel_medicoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosticoModel",
                table: "DiagnosticoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitaModel",
                table: "CitaModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitaModel_Usuario_medicoId",
                table: "CitaModel",
                column: "medicoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaModel_Usuario_pacienteId",
                table: "CitaModel",
                column: "pacienteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosticoModel_CitaModel_citaId",
                table: "DiagnosticoModel",
                column: "citaId",
                principalTable: "CitaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
