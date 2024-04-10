using CitasMedicas.Context;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implementation
{
    public class PacienteRepository : GenericRepository<PacienteModel> , IPacienteRepository
    {
        public PacienteRepository(CitasMedicasDbContext context) :base(context)
        {
            
        }
    }
}
