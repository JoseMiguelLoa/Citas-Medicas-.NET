namespace CitasMedicas.Dtos.Obtain
{
    //Dto para la obtención de un paciente
    public class PacienteDtoObtain
    {
        public long Id { get; set; }
        public string NSS { get; set; } = string.Empty;
        public string numTarjeta { get; set; } = string.Empty;  
        public string telefono { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
    }
}
