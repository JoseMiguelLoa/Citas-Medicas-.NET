using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IMedicoService
    {

        public IEnumerable<MedicoDtoObtain> Get();  //Método get que devuelve todos los médicos que hay en la base de datos


        public MedicoDtoObtain GetById(long id); //Método Get que devuelve el médico con id pasado por la ruta

        public void Post([FromBody] MedicoDtoCreation medicoDto); //Método post que realiza la inserción de un médico en la base de datos

        public void DeleteById(long id); //Método que realiza la eliminación del médico con id pasado por la ruta

        public MedicoDtoObtain Update([FromBody] MedicoDtoCreation medicoDto, long id); //Método que realiza la actualización de un médico con id pasado por la ruta

        public void PostMultiple([FromBody] IEnumerable<MedicoDtoCreation> medicosDto); //Método que realiza la inserción de médicos en la base de datos

        public void DeleteMult(String ids); //Método que realiza la eliminación de médicos en la base de datos
    }
}
