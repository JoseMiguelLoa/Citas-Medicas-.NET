namespace CitasMedicas.Dtos.Obtain
{
    //Dto para la obtención de una cita
    public class CitaDtoObtain
    {
        public long Id { get; set; }

        public DateTime fechaHora { get; set; }

        public string motivoCita { get; set; } = string.Empty;

        public int attribute11 { get; set; }

        //Relación one to many
        public long pacienteId { get; set; }

        //Relación one to many
        public long medicoId { get; set; }
    }
}
