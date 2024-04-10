using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<PacienteDtoCreation, PacienteModel>(); //Pasa de DtoCreation a Model
            CreateMap<PacienteModel, PacienteDtoObtain>();  //Pasa de Modelo a DtoObtain
        }
    }
}
