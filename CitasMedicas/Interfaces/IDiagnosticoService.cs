using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IDiagnosticoService
    {
        public IEnumerable<DiagnosticoDtoObtain> Get();  //Método get que devuelve todos los diagnósticos que hay en la base de datos

        public DiagnosticoDtoObtain GetById(long id); //Método Get que devuelve el diagnóstico con id pasado por la ruta

        public void Post([FromBody] DiagnosticoDtoCreation diagnosticoDto); //Método post que realiza la inserción de un diagnóstico en la base de datos

        public void DeleteById(long id); //Método que realiza la eliminación del diagnóstico con id pasado por la ruta

        public DiagnosticoDtoObtain Update([FromBody] DiagnosticoDtoCreation diagnosticoDto, long id); //Método que realiza la actualización de un diagnóstico con id pasado por la ruta

        public void PostMultiple([FromBody] IEnumerable<DiagnosticoDtoCreation> diagnosticosDto); //Método que realiza la inserción de diagnósticos en la base de datos

        public void DeleteMult(String ids); //Método que realiza la eliminación de diagnósticos en la base de datos
    }
}
