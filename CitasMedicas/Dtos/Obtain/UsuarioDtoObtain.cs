namespace CitasMedicas.Dtos.Obtencion
{
    //Dto para la obtención de un usuario
    public class UsuarioDtoObtain
    {
        public long Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
    }
}
