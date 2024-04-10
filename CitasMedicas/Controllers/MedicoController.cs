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
    [Route("Medico/")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        //Método get que devuelve todos los médicos que hay en la base de datos
        [HttpGet]
        public ActionResult Get()
        {
            var medicos = _medicoService.Get();

            return Ok(medicos);
        }

        //Método Get que devuelve el médico con id pasado por la ruta
        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var medico = _medicoService.GetById(id);
            return Ok(medico);
        }

        //Método post que realiza la inserción de un médico en la base de datos
        [HttpPost]
        public ActionResult Post([FromBody] MedicoDtoCreation medicoDto)
        {
            _medicoService.Post(medicoDto);

            return Ok("Guardado realizado");
        }

        //Método que realiza la eliminación del médico con id que le hayamos pasado por la ruta
        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _medicoService.DeleteById(id);

            return Ok("Medico eliminado");
        }

        //Método que realiza la actualización de un médico con la id pasado por parametro
        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] MedicoDtoCreation medicoDto, long id)
        {
                return Ok(_medicoService.Update(medicoDto,id));
        }

        //Método que realiza la inserción de médicos en la base de datos
        [HttpPost("Mult")]
        public ActionResult PostMultiple([FromBody] IEnumerable<MedicoDtoCreation> medicosDto)
        {
            _medicoService.PostMultiple(medicosDto);
            return Ok("Inserción realizada");
        }

        //Método que realiza la eliminación de médicos en la base de datos
        [HttpDelete("Mult/{ids}")]
        public ActionResult DeleteMult(String ids)
        {
            _medicoService.DeleteMult(ids);
            return Ok("Todo ha terminado");
        }
    }
}
