using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Cita/")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;
        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        //Método get que devuelve todos las citas que hay en la base de datos
        [HttpGet]
        public ActionResult Get()
        {
            var citas = _citaService.Get();
            return Ok(citas);
        }

        //Método Get que devuelve el cita con id pasado por la ruta
        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var cita = _citaService.GetById(id);
            return Ok(cita);
        }

        //Método post que realiza la inserción de una cita en la base de datos
        [HttpPost]
        public ActionResult Post([FromBody] CitaDtoCreation citaDto)
        {

            _citaService.Post(citaDto);

             return Ok("Guardado realizado");

            
        }

        //Método que realiza la eliminación de la cita con id que le hayamos pasado por la ruta
        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _citaService.DeleteById(id);

            return Ok("Cita eliminado");
        }
        
        //Método que realiza la actualización de una cita con la id pasado por parametro
        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] CitaDtoCreation citaDto, long id)
        {
            return Ok(_citaService.Update(citaDto,id));
        }
        
        //Método que realiza la inserción de las citas en la base de datos
        [HttpPost("Mult")]
        public ActionResult PostMultiple([FromBody] IEnumerable<CitaDtoCreation> citasDto)
        {
            _citaService.PostMultiple(citasDto);
            return Ok("Inserción realizada");
        }

        //Método que realiza la eliminación de las citas en la base de datos
        [HttpDelete("Mult/{ids}")]
        public ActionResult DeleteMult(String ids)
        {
            _citaService.DeleteMult(ids);
            return Ok("Todo ha terminado");
        }
    }
}
