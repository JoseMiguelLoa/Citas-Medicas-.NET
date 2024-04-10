using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IPacienteService
    {


        public IEnumerable<PacienteDtoObtain> Get();  //Método get que devuelve todos los pacientes que hay en la base de datos


        public PacienteDtoObtain GetById(long id); //Método Get que devuelve el paciente con id pasado por la ruta

        public void Post([FromBody] PacienteDtoCreation pacienteDto); //Método post que realiza la inserción de un paciente en la base de datos

        public void DeleteById(long id); //Método que realiza la eliminación del paciente con id pasado por la ruta

        public PacienteDtoObtain Update([FromBody] PacienteDtoCreation pacienteDto, long id); //Método que realiza la actualización de un paciente con id pasado por la ruta

        public void PostMultiple([FromBody] IEnumerable<PacienteDtoCreation> pacientesDto); //Método que realiza la inserción de pacientes en la base de datos

        public void DeleteMult(String ids); //Método que realiza la eliminación de pacientes en la base de datos
    }
}
