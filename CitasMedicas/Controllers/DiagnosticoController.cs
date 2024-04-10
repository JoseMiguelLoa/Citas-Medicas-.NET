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
    [Route("Diagnostico/")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;
        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        //Método get que devuelve todos los diagnósticos que hay en la base de datos
        [HttpGet]
        public ActionResult Get()
        {
            var diagnosticos = _diagnosticoService.Get();

            return Ok(diagnosticos);
        }

        //Método Get que devuelve el diagnóstico con id pasado por la ruta
        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var diagnostico = _diagnosticoService.GetById(id);
            return Ok(diagnostico);
        }

        //Método post que realiza la inserción de un diagnóstico en la base de datos
        [HttpPost]
        public ActionResult Post([FromBody] DiagnosticoDtoCreation diagnosticoDto)
        {
            _diagnosticoService.Post(diagnosticoDto);

            return Ok("Realizado");
        }
        //Método que realiza la eliminación del diagnóstico con id pasado por la ruta
        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _diagnosticoService.DeleteById(id);
            return Ok("diagnostico eliminado");
        }

        //Método que realiza la actualización de un diagnóstico con id pasado por la ruta
        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] DiagnosticoDtoCreation diagnosticoDto, long id)
        {
             return Ok(_diagnosticoService.Update(diagnosticoDto,id));
        }
        //Método que realiza la inserción de diagnósticos en la base de datos
        [HttpPost("Mult")]
        public ActionResult PostMultiple([FromBody] IEnumerable<DiagnosticoDtoCreation> diagnosticosDto)
        {
            _diagnosticoService.PostMultiple(diagnosticosDto);
            return Ok("Inserción realizada");
        }

        //Método que realiza la eliminación de diagnósticos en la base de datos
        [HttpDelete("Mult/{ids}")]
        public ActionResult DeleteMult(String ids)
        {
           _diagnosticoService.DeleteMult(ids);
            return Ok("Todo ha terminado");
        }
    }
}
