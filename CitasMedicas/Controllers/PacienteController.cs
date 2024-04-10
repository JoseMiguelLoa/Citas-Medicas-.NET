using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Paciente/")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private  readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        //Método get que devuelve todos los pacientes que hay en la base de datos
        [HttpGet]
        public ActionResult Get()
        {
            var pacientes = _pacienteService.Get();

            return Ok(pacientes);
        }

        //Método Get que devuelve el paciente con id pasado por la ruta
        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var paciente = _pacienteService.GetById(id);
            return Ok(paciente);
        }

        //Método post que realiza la inserción de un paciente en la base de datos
        [HttpPost]
        public ActionResult Post([FromBody] PacienteDtoCreation pacienteDto)
        {

            _pacienteService.Post(pacienteDto);
            return Ok("Realizado");
        }

        //Método que realiza la eliminación del paciente con id que le hayamos pasado por la ruta
        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _pacienteService.DeleteById(id);

            return Ok("Paciente eliminado");
        }

        //Método que realiza la actualización de un paciente con la id pasado por parametro
        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] PacienteDtoCreation pacienteDto, long id)
        {
                return Ok(_pacienteService.Update(pacienteDto,id));
        }
        
        //Método que realiza la inserción de pacientes en la base de datos
        [HttpPost("Mult")]
        public ActionResult PostMultiple([FromBody] IEnumerable<PacienteDtoCreation> pacientesDto)
        {
            _pacienteService.PostMultiple(pacientesDto);
            return Ok("Inserción realizada");
        }

        //Método que realiza la eliminación de pacientes en la base de datos
        [HttpDelete("Mult/{ids}")]
        public ActionResult DeleteMult(String ids)
        {
            _pacienteService.DeleteMult(ids);
            return Ok("Todo ha terminado");
        }

    }
}
