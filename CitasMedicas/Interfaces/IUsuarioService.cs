using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IUsuarioService
    {
        public IEnumerable<UsuarioDtoObtain> Get();  //Método get que devuelve todos los usuarios que hay en la base de datos

        public UsuarioDtoObtain GetById(long id); //Método Get que devuelve el usuario con id pasado por la ruta

        public void Post([FromBody] UsuarioDtoCreation usuarioDto); //Método post que realiza la inserción de un usuario en la base de datos

        public void DeleteById(long id); //Método que realiza la eliminación del usuario con id pasado por la ruta

        public UsuarioDtoObtain Update([FromBody] UsuarioDtoCreation usuarioDto, long id); //Método que realiza la actualización de un usuario con id pasado por la ruta

        public void PostMultiple([FromBody] IEnumerable<UsuarioDtoCreation> usuariosDto); //Método que realiza la inserción de usuarios en la base de datos

        public void DeleteMult(String ids); //Método que realiza la eliminación de usuarios en la base de datos

    }
}
