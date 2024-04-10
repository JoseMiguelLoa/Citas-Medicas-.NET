using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        //Método get que devuelve todos los médicos que hay en la base de datos
        public IEnumerable<MedicoDtoObtain> Get()
        {
            return _mapper.Map < IEnumerable <MedicoDtoObtain>>(_unitOfWork.Medico.GetAll());
        }

        //Método Get que devuelve el médico con id pasado por la ruta
        public MedicoDtoObtain GetById(long id)
        {
            return _mapper.Map<MedicoDtoObtain>(_unitOfWork.Medico.GetById(id));
        }

        //Método post que realiza la inserción de un médico en la base de datos
        public void Post([FromBody] MedicoDtoCreation medicoDto)
        {
            var medico = _mapper.Map<MedicoModel>(medicoDto);
            _unitOfWork.Medico.Add(medico);
            _unitOfWork.Save();
        }

        //Método que realiza la inserción de médicos en la base de datos
        public void PostMultiple([FromBody] IEnumerable<MedicoDtoCreation> medicosDto)
        {
            var medicos = _mapper.Map<IEnumerable<MedicoModel>>(medicosDto);
            _unitOfWork.Medico.AddRange(medicos);
            _unitOfWork.Save();
        }

        //Método que realiza la actualización de un médico con id pasado por la ruta
        public MedicoDtoObtain Update([FromBody] MedicoDtoCreation medicoDto, long id)
        {
            var medico = _unitOfWork.Medico.GetById(id);

            if (medicoDto.usuario != null && medicoDto.usuario.Length != 0)
                medico.usuario = medicoDto.usuario;

            if (medicoDto.apellidos != null && medicoDto.apellidos.Length != 0)
                medico.apellidos = medicoDto.apellidos;

            if (medicoDto.nombre != null && medicoDto.nombre.Length != 0)
                medico.nombre = medicoDto.nombre;

            if (medicoDto.clave != null && medicoDto.clave.Length != 0)
                medico.clave = medicoDto.clave;

            if (medicoDto.numColegiado != null && medicoDto.numColegiado.Length != 0)
                medico.numColegiado = medicoDto.numColegiado;


            _unitOfWork.Medico.Update(medico);
            _unitOfWork.Save();
            return _mapper.Map<MedicoDtoObtain>(medico);
        }

        //Método que realiza la eliminación del médico con id pasado por la ruta
        public void DeleteById(long id)
        {
            var medico = _unitOfWork.Medico.GetById(id);

            _unitOfWork.Medico.Remove(medico);
            _unitOfWork.Save();
        }

        //Método que realiza la eliminación de médicos en la base de datos
        public void DeleteMult(string ids)
        {
            string[] idArrayS = ids.Split(',');
            List<MedicoModel> medicos = new List<MedicoModel>();
            foreach (string id in idArrayS)
            {
                long idNum = Convert.ToInt64(id);

                medicos.Add(_unitOfWork.Medico.GetById(idNum));
            }

            _unitOfWork.Medico.RemoveRange(medicos);
            _unitOfWork.Save();
        }
    }
}
