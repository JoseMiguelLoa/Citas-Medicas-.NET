namespace CitasMedicas.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuario { get; } //Repositorio del usuario
        IPacienteRepository Paciente{ get; } //Repositorio del paciente

        IMedicoRepository Medico{ get; } //Repositorio del médico

        ICitaRepository Cita{ get; } //Repositorio de la cita

        IDiagnosticoRepository Diagnostico{ get; } //Repositorio del diagnóstico

        int Save(); //
    }
}
