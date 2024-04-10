using CitasMedicas.Dtos.Creacion;

namespace CitasMedicas.Dtos.Creation
{
    //Dto para la creación de un paciente
    public class PacienteDtoCreation : UsuarioDtoCreation
    {
        public string NSS { get; set; } = string.Empty;
        public string numTarjeta { get; set; } = string.Empty;      
        public string telefono { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;   
    }
}

