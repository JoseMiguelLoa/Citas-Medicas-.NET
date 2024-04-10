using CitasMedicas.Context;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implementation
{
    public class DiagnosticoRepository : GenericRepository<DiagnosticoModel> , IDiagnosticoRepository
    {
        public DiagnosticoRepository(CitasMedicasDbContext context) :base(context) 
        {
            
        }
    }
}
