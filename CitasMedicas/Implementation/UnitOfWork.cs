using CitasMedicas.Context;
using CitasMedicas.Repository;

namespace CitasMedicas.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private CitasMedicasDbContext _context;
        public UnitOfWork(CitasMedicasDbContext context) {
            _context = context;
            Usuario = new UsuarioRepository(_context);
            Paciente = new PacienteRepository(_context);
            Medico = new MedicosRepository(_context);
            Cita = new CitasRepository(_context);
            Diagnostico = new DiagnosticoRepository(_context);  
        }

        public IUsuarioRepository Usuario { get; private set; }
        public IPacienteRepository Paciente { get; private set; }
        public IMedicoRepository Medico { get; private set; }   
        public ICitaRepository Cita { get; private set; }
        public IDiagnosticoRepository Diagnostico { get; private set; }

        public int Save()
        {
            return  _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
