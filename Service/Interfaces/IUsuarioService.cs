using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Interfaces
{
    internal interface IUsuarioService
    {
        public IEnumerable<UsuarioDtoObtain> Get();

        public UsuarioDtoObtain GetById(long id);

        public void Post([FromBody] UsuarioDtoCreation usuarioDto);

        public void DeleteById(long id);

        public void Update([FromBody] UsuarioDtoCreation usuarioDto, long id);

        public void PostMultiple([FromBody] IEnumerable<UsuarioDtoCreation> usuariosDto);

        public void DeleteMult(String ids);

    }
}
