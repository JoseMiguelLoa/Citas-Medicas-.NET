using AutoMapper;
using CitasMedicas.Dtos.Creacion;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Dtos.Obtencion;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Service
{
    public class PacienteService : IPacienteService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        //Método get que devuelve todos los pacientes que hay en la base de datos
        public IEnumerable<PacienteDtoObtain> Get()
        {
            return _mapper.Map<IEnumerable<PacienteDtoObtain>>(_unitOfWork.Paciente.GetAll());
        }

        //Método Get que devuelve el paciente con id pasado por la ruta
        public PacienteDtoObtain GetById(long id)
        {
            return _mapper.Map<PacienteDtoObtain>(_unitOfWork.Paciente.GetById(id));
        }

        //Método post que realiza la inserción de un paciente en la base de datos
        public void Post([FromBody] PacienteDtoCreation pacienteDto)
        {
            var paciente = _mapper.Map<PacienteModel>(pacienteDto);
            _unitOfWork.Paciente.Add(paciente);
            _unitOfWork.Save();
        }

        //Método que realiza la inserción de pacientes en la base de datos
        public void PostMultiple([FromBody] IEnumerable<PacienteDtoCreation> pacientesDto)
        {
            var pacientes = _mapper.Map<IEnumerable<PacienteModel>>(pacientesDto);
            _unitOfWork.Paciente.AddRange(pacientes);
            _unitOfWork.Save();
        }

        //Método que realiza la actualización de un paciente con id pasado por la ruta
        public PacienteDtoObtain Update([FromBody] PacienteDtoCreation pacienteDto, long id)
        {
            var paciente = _unitOfWork.Paciente.GetById(id);

            if (pacienteDto.usuario != null && pacienteDto.usuario.Length != 0)
                paciente.usuario = pacienteDto.usuario;

            if (pacienteDto.apellidos != null && pacienteDto.apellidos.Length != 0)
                paciente.apellidos = pacienteDto.apellidos;

            if (pacienteDto.nombre != null && pacienteDto.nombre.Length != 0)
                paciente.nombre = pacienteDto.nombre;

            if (pacienteDto.clave != null && pacienteDto.clave.Length != 0)
                paciente.clave = pacienteDto.clave;

            if (pacienteDto.NSS != null && pacienteDto.NSS.Length != 0)
                paciente.NSS = pacienteDto.NSS;

            if (pacienteDto.direccion != null && pacienteDto.direccion.Length != 0)
                paciente.direccion = pacienteDto.direccion;

            if (pacienteDto.telefono != null && pacienteDto.telefono.Length != 0)
                paciente.telefono = pacienteDto.telefono;

            if (pacienteDto.numTarjeta != null && pacienteDto.numTarjeta.Length != 0)
                paciente.numTarjeta = pacienteDto.numTarjeta;

            _unitOfWork.Paciente.Update(paciente);
            _unitOfWork.Save();
            return _mapper.Map<PacienteDtoObtain>(paciente);
        }

        //Método que realiza la eliminación del paciente con id pasado por la ruta
        public void DeleteById(long id)
        {
            var paciente = _unitOfWork.Paciente.GetById(id);

            _unitOfWork.Paciente.Remove(paciente);
            _unitOfWork.Save();
        }

        //Método que realiza la eliminación de pacientes en la base de datos
        public void DeleteMult(string ids)
        {
            string[] idArrayS = ids.Split(',');
            List<PacienteModel> pacientes = new List<PacienteModel>();
            foreach (string id in idArrayS)
            {
                long idNum = Convert.ToInt64(id);

                pacientes.Add(_unitOfWork.Paciente.GetById(idNum));
            }

            _unitOfWork.Paciente.RemoveRange(pacientes);
            _unitOfWork.Save();
        }

    }
}
