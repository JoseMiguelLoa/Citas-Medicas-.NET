using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper() { 
            CreateMap<UsuarioDtoCreation, UsuarioModel>(); //Pasa de DtoCreation a Model
            CreateMap<UsuarioModel, UsuarioDtoObtain>(); //Pasa de Modelo a DtoObtain
        }
    }
}
