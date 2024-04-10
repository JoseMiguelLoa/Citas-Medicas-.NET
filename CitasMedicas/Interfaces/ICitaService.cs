using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface ICitaService
    {

        public IEnumerable<CitaDtoObtain> Get();  //Método get que devuelve todos las citas que hay en la base de datos

        public CitaDtoObtain GetById(long id); //Método Get que devuelve el cita con id pasado por la ruta

        public void Post([FromBody] CitaDtoCreation citaDto); //Método post que realiza la inserción de una cita en la base de datos

        public void DeleteById(long id); //Método que realiza la eliminación de la cita con id pasado por la ruta

        public CitaDtoObtain Update([FromBody] CitaDtoCreation citaDto, long id); //Método que realiza la actualización de una cita con id pasado por la ruta

        public void PostMultiple([FromBody] IEnumerable<CitaDtoCreation> citasDto); //Método que realiza la inserción de las citas en la base de datos

        public void DeleteMult(String ids); //Método que realiza la eliminación de las citas en la base de datos
    }
}
