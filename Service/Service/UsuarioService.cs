using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Service.Service
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

        public IEnumerable<UsuarioDtoObtain> Get()
        {
            return _mapper.Map<IEnumerable<UsuarioDtoObtain>>(_unitOfWork.Usuario.GetAll());
        }

        public UsuarioDtoObtain GetById(long id)
        {
            return _mapper.Map<UsuarioDtoObtain>(_unitOfWork.Usuario.GetById(id));
        }

        public void Post([FromBody] UsuarioDtoCreation usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            _unitOfWork.Usuario.Add(usuario);
            _unitOfWork.Save();
        }

        public void PostMultiple([FromBody] IEnumerable<UsuarioDtoCreation> usuariosDto)
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioModel>>(usuariosDto);
            _unitOfWork.Usuario.AddRange(usuarios);
            _unitOfWork.Save();
        }

        public void Update([FromBody] UsuarioDtoCreation usuarioDto, long id)
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
        }

        public void DeleteById(long id)
        {
            var usuario = _unitOfWork.Usuario.GetById(id);

            _unitOfWork.Usuario.Remove(usuario);
            _unitOfWork.Save();
        }

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
