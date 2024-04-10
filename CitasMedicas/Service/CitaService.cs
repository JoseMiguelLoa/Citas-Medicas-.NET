using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Service
{
    public class CitaService : ICitaService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CitaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //Método get que devuelve todos las citas que hay en la base de datos
        public IEnumerable<CitaDtoObtain> Get()
        {
            var citas = _mapper.Map<IEnumerable<CitaDtoObtain>>(_unitOfWork.Cita.GetAll());

            return citas;
        }

        //Método Get que devuelve el cita con id pasado por la ruta
        public CitaDtoObtain GetById(long id)
        {
            var cita = _mapper.Map<CitaDtoObtain>(_unitOfWork.Cita.GetById(id));
            return cita;
        }

        //Método post que realiza la inserción de una cita en la base de datos
        public void Post([FromBody] CitaDtoCreation citaDto)
        {
            _unitOfWork.Paciente.GetById(citaDto.pacienteId);
            _unitOfWork.Medico.GetById(citaDto.medicoId);
            var cita = _mapper.Map<CitaModel>(citaDto);
            _unitOfWork.Cita.Add(cita);
            _unitOfWork.Save();
        }

        //Método que realiza la inserción de las citas en la base de datos
        public void PostMultiple([FromBody] IEnumerable<CitaDtoCreation> citasDto)
        {
            var citas = _mapper.Map<IEnumerable<CitaModel>>(citasDto);
            _unitOfWork.Cita.AddRange(citas);
            _unitOfWork.Save();
        }

        //Método que realiza la actualización de una cita con la id pasado por parametro
        public CitaDtoObtain Update([FromBody] CitaDtoCreation citaDto, long id)
        {
            var cita = _unitOfWork.Cita.GetById(id);

            if (citaDto.motivoCita != null && citaDto.motivoCita.Length != 0)
                cita.motivoCita = citaDto.motivoCita;

            if (citaDto.attribute11 > 0)
                cita.attribute11 = citaDto.attribute11;

            _unitOfWork.Cita.Update(cita);
            _unitOfWork.Save();

            return _mapper.Map<CitaDtoObtain>(cita);

        }

        //Método que realiza la eliminación de la cita con id que le hayamos pasado por la ruta
        public void DeleteById(long id)
        {
            var cita = _unitOfWork.Cita.GetById(id);
            _unitOfWork.Cita.Remove(cita);
            _unitOfWork.Save();
        }

        //Método que realiza la eliminación de las citas en la base de datos
        public void DeleteMult(string ids)
        {
            string[] idArrayS = ids.Split(',');
            List<CitaModel> citas = new List<CitaModel>();
            foreach (string id in idArrayS)
            {
                long idNum = Convert.ToInt64(id);

                citas.Add(_unitOfWork.Cita.GetById(idNum));
            }

            _unitOfWork.Cita.RemoveRange(citas);
            _unitOfWork.Save();
        }
    }
}
