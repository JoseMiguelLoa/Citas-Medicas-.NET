namespace CitasMedicas.Dtos.Obtain
{
    //Dto para la obtención de un diagnóstico
    public class DiagnosticoDtoObtain
    {
        public long Id { get; set; }
        public string valoracionEspecialista { get; set; } = string.Empty;
        public string enfermedad { get; set; } = string.Empty;
        public long citaId { get; set; }
    }
}
