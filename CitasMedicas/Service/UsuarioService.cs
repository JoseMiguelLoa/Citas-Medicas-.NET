using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        //Método get que devuelve todos los usuarios que hay en la base de datos
        public IEnumerable<UsuarioDtoObtain> Get()
        {
            return _mapper.Map<IEnumerable<UsuarioDtoObtain>>(_unitOfWork.Usuario.GetAll());
        }

        //Método Get que devuelve el usuario con id pasado por la ruta
        public UsuarioDtoObtain GetById(long id)
        {
            return _mapper.Map<UsuarioDtoObtain>(_unitOfWork.Usuario.GetById(id));
        }

        //Método post que realiza la inserción de un usuario en la base de datos
        public void Post([FromBody] UsuarioDtoCreation usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            _unitOfWork.Usuario.Add(usuario);
            _unitOfWork.Save();
        }

        //Método que realiza la inserción de usuarios en la base de datos
        public void PostMultiple([FromBody] IEnumerable<UsuarioDtoCreation> usuariosDto)
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioModel>>(usuariosDto);
            _unitOfWork.Usuario.AddRange(usuarios);
            _unitOfWork.Save();
        }

        //Método que realiza la actualización de un usuario con id pasado por la ruta
        public UsuarioDtoObtain Update([FromBody] UsuarioDtoCreation usuarioDto, long id)
        {
            var usuario = _unitOfWork.Usuario.GetById(id);

            if (usuarioDto.usuario != null && usuarioDto.usuario.Length != 0)
                usuario.usuario = usuarioDto.usuario;

            if (usuarioDto.apellidos != null && usuarioDto.apellidos.Length != 0)
                usuario.apellidos = usuarioDto.apellidos;

            if (usuarioDto.nombre != null && usuarioDto.nombre.Length != 0)
                usuario.nombre = usuarioDto.nombre;

            if (usuarioDto.clave != null && usuarioDto.clave.Length != 0)
                usuario.clave = usuarioDto.clave;

            _unitOfWork.Usuario.Update(usuario);
            _unitOfWork.Save();
            return _mapper.Map<UsuarioDtoObtain>(usuario);
        }

        //Método que realiza la eliminación del usuario con id pasado por la ruta
        public void DeleteById(long id)
        {
            var usuario = _unitOfWork.Usuario.GetById(id);

            _unitOfWork.Usuario.Remove(usuario);
            _unitOfWork.Save();
        }

        //Método que realiza la eliminación de usuarios en la base de datos
        public void DeleteMult(string ids)
        {
            string[] idArrayS = ids.Split(',');
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            foreach (string id in idArrayS)
            {
                long idNum = Convert.ToInt64(id);

                usuarios.Add(_unitOfWork.Usuario.GetById(idNum));
            }

            _unitOfWork.Usuario.RemoveRange(usuarios);
            _unitOfWork.Save();
        }


    }
}
