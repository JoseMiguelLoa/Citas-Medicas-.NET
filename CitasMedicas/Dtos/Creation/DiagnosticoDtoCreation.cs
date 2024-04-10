namespace CitasMedicas.Dtos.Creation
{
    //Dto para la creación de un diagnóstico
    public class DiagnosticoDtoCreation
    {

        public string valoracionEspecialista { get; set; } = string.Empty;
        public string enfermedad { get; set; } = string.Empty;
        public long citaId { get; set; }

    }
}
