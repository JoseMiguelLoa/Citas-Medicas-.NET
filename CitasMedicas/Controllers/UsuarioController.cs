using AutoMapper;
using CitasMedicas.Context;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Usuario/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //Método get que devuelve todos los usuarios que hay en la base de datos
        [HttpGet]
        public ActionResult Get() 
        {
            var usuarios =_usuarioService.Get();

            return Ok(usuarios);
        }

        //Método Get que devuelve el usuario con id pasado por la ruta
        [HttpGet("{id}")]
        public ActionResult GetById(long id) 
        {
            var usuario = _usuarioService.GetById(id);
            return Ok(usuario);
        }

        //Método post que realiza la inserción de un usuario en la base de datos
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDtoCreation usuarioDto)
        {
            _usuarioService.Post(usuarioDto);

            return Ok("Guardado Realizado");  
        }
        //Método que realiza la eliminación del usuario con id pasado por la ruta
        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _usuarioService.DeleteById(id);
            return Ok("Usuario eliminado");
        }

        //Método que realiza la actualización de un usuario con id pasado por la ruta
        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] UsuarioDtoCreation usuarioDto, long id)
        {  
            return Ok(_usuarioService.Update(usuarioDto, id));

        }
        //Método que realiza la inserción de usuarios en la base de datos
        [HttpPost("Mult")]
        public ActionResult PostMultiple([FromBody] IEnumerable<UsuarioDtoCreation> usuariosDto)
        {
            _usuarioService.PostMultiple(usuariosDto);
            return Ok("Inserción realizada");
        }

        //Método que realiza la eliminación de usuarios en la base de datos
        [HttpDelete("Mult/{ids}")]
        public ActionResult DeleteMult(String ids) 
        {
            _usuarioService.DeleteMult(ids);
            return Ok("Todo ha terminado");
        }

    }
}
