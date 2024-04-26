using AutoMapper;
using CitasMedicas.Dtos.Creation;
using CitasMedicas.Dtos.Obtain;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Service
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DiagnosticoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        //Método get que devuelve todos los diagnósticos que hay en la base de datos
        public IEnumerable<DiagnosticoDtoObtain> Get()
        {
            var diagnosticos = _mapper.Map<IEnumerable<DiagnosticoDtoObtain>>(_unitOfWork.Diagnostico.GetAll());
            return diagnosticos;
        }

        //Método Get que devuelve el diagnóstico con id pasado por la ruta
        public DiagnosticoDtoObtain GetById(long id)
        {
            var diagnostico = _mapper.Map<DiagnosticoDtoObtain>(_unitOfWork.Diagnostico.GetById(id));
            return diagnostico;
        }

        //Método post que realiza la inserción de un diagnóstico en la base de datos
        public void Post([FromBody] DiagnosticoDtoCreation diagnosticoDto)
        {
            var diagnostico = _mapper.Map<DiagnosticoModel>(diagnosticoDto);
            _unitOfWork.Diagnostico.Add(diagnostico);
            _unitOfWork.Save();
        }

        //Método que realiza la inserción de diagnósticos en la base de datos
        public void PostMultiple([FromBody] IEnumerable<DiagnosticoDtoCreation> diagnosticosDto)
        {
            var diagnosticos = _mapper.Map<IEnumerable<DiagnosticoModel>>(diagnosticosDto);
            _unitOfWork.Diagnostico.AddRange(diagnosticos);
            _unitOfWork.Save();
        }

        //Método que realiza la actualización de un diagnóstico con id pasado por la ruta
        public DiagnosticoDtoObtain Update([FromBody] DiagnosticoDtoCreation diagnosticoDto, long id)
        {
            var diagnostico = _unitOfWork.Diagnostico.GetById(id);


            if (diagnosticoDto.valoracionEspecialista != null && diagnosticoDto.valoracionEspecialista.Length != 0)
                diagnostico.valoracionEspecialista = diagnosticoDto.valoracionEspecialista;

            if (diagnosticoDto.enfermedad != null && diagnosticoDto.enfermedad.Length != 0)
                diagnostico.enfermedad = diagnosticoDto.enfermedad;


            _unitOfWork.Diagnostico.Update(diagnostico);
            _unitOfWork.Save();

            return _mapper.Map<DiagnosticoDtoObtain>(diagnostico);

        }

        //Método que realiza la eliminación del diagnóstico con id pasado por la ruta
        public void DeleteById(long id)
        {
            var diagnostico = _unitOfWork.Diagnostico.GetById(id);

            _unitOfWork.Diagnostico.Remove(diagnostico);
            _unitOfWork.Save();
        }

        //Método que realiza la eliminación de diagnósticos en la base de datos
        public void DeleteMult(string ids)
        {
            string[] idArrayS = ids.Split(',');
            List<DiagnosticoModel> diagnosticos = new List<DiagnosticoModel>();
            foreach (string id in idArrayS)
            {
                long idNum = Convert.ToInt64(id);
                diagnosticos.Add(_unitOfWork.Diagnostico.GetById(idNum));
            }

            _unitOfWork.Diagnostico.RemoveRange(diagnosticos);
            _unitOfWork.Save();
        }
    }
}
