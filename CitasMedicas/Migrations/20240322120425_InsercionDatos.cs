using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class InsercionDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuarios_medicosId",
                table: "MedicoModelPacienteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuarios_pacientesId",
                table: "MedicoModelPacienteModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Discriminator", "NSS", "apellidos", "clave", "Direccion", "nombre", "NumeroTarjeta", "Telefono", "usuario" },
                values: new object[] { -2L, "PacienteModel", "1234", "Casandra", "1234", "Mi casa", "Carlos", "1", "123456789", "" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuario_medicosId",
                table: "MedicoModelPacienteModel",
                column: "medicosId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuario_pacientesId",
                table: "MedicoModelPacienteModel",
                column: "pacientesId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuario_medicosId",
                table: "MedicoModelPacienteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuario_pacientesId",
                table: "MedicoModelPacienteModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuarios_medicosId",
                table: "MedicoModelPacienteModel",
                column: "medicosId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoModelPacienteModel_Usuarios_pacientesId",
                table: "MedicoModelPacienteModel",
                column: "pacientesId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
