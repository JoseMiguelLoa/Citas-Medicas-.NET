namespace CitasMedicas.Models
{
    public class PacienteModel:UsuarioModel
    {
        public string NSS { get; set; } = string.Empty; //Número de la seguridad social

        public string numTarjeta { get; set; } = string.Empty; //Número de la tarjera 

        public string telefono {  get; set; } = string.Empty; //Número de teléfono del paciente

        public string direccion {  get; set; } = string.Empty; //Dirección del paciente


        public List<CitaModel> citas { get; set; } //Lista de citas (Relación Many to One)

        public List<MedicoModel> medicos { get; set; } //Lista de médicos (Relación ManyToMany)   
    }
}
