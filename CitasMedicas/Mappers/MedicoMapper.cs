using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class MedicoMapper : Profile
    {
        public MedicoMapper() 
        {
            CreateMap<MedicoDtoCreation, MedicoModel>(); //Pasa de DtoCreation a Model
            CreateMap<MedicoModel, MedicoDtoObtain>(); //Pasa de Modelo a DtoObtain
        }   
    }
}
