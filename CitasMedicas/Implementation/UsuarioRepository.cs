using CitasMedicas.Context;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implementation
{
    public class UsuarioRepository : GenericRepository<UsuarioModel> , IUsuarioRepository
    {
        
        public UsuarioRepository(CitasMedicasDbContext context) :base(context)
        {
            
        }
    }
}
