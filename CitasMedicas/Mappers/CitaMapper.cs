using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class CitaMapper : Profile
    {
        //Mappper de Cita
        public CitaMapper() 
        {
            CreateMap<CitaDtoCreation, CitaModel>(); //Pasa de DtoCreation a Model
            CreateMap<CitaModel, CitaDtoObtain>(); //Pasa de Modelo a DtoObtain
        }
    }
}
