using CitasMedicas.Context;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implementation
{
    public class MedicosRepository : GenericRepository<MedicoModel> ,IMedicoRepository
    {
        public MedicosRepository(CitasMedicasDbContext context) :base(context)
        {
            
        }
    }
}
