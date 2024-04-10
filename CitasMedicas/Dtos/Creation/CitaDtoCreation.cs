namespace CitasMedicas.Dtos.Creation
{
    //Dto para la creación de una cita
    public class CitaDtoCreation
    {
        public DateTime fechaHora { get; set; }

        public string motivoCita { get; set; } = string.Empty;

        public int attribute11 { get; set; }

        //Relación one to many
        public long pacienteId { get; set; }

        //Relación one to many
        public long medicoId { get; set; }
    }
}
