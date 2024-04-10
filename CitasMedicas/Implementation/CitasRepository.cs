using CitasMedicas.Context;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implementation
{
    
    public class CitasRepository : GenericRepository<CitaModel> , ICitaRepository
    {
        public CitasRepository(CitasMedicasDbContext context) :base(context)
        {
            
        }
    }
}
