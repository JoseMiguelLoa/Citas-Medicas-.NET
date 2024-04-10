using CitasMedicas.Dtos.Creacion;

namespace CitasMedicas.Dtos.Creation
{
    //Dto para la creación de un médico
    public class MedicoDtoCreation : UsuarioDtoCreation
    {

        public string numColegiado { get; set; } = string.Empty;
    }
}
