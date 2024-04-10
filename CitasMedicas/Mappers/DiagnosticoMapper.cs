using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class DiagnosticoMapper : Profile
    {
        public DiagnosticoMapper()
        {
            CreateMap<DiagnosticoDtoCreation, DiagnosticoModel>(); //Pasa de DtoCreation a Model
            CreateMap<DiagnosticoModel, DiagnosticoDtoObtain>(); //Pasa de Modelo a DtoObtain
        }
    }
}
