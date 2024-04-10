namespace CitasMedicas.Models
{
    public class MedicoModel:UsuarioModel //Médico hereda de Usuario
    {
        public string numColegiado { get; set; } = string.Empty; //Número de colegiado

        public List<CitaModel> citas { get; set; } //Lista de citas (Relación Many to One)

        public List<PacienteModel> pacientes { get; set; }//Lista de pacientes (Relación ManyToMany)
    }
}
