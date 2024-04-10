using CitasMedicas.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Context
{
    public class CitasMedicasDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<CitaModel> Cita { get; set; } 
        public DbSet<DiagnosticoModel> Diagnostico { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<PacienteModel>()
                .HasBaseType<UsuarioModel>();

            modelBuilder.Entity<MedicoModel>()
                .HasBaseType<UsuarioModel>();

            // Mapeo de columnas específicas de Paciente

            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.NSS)
                .HasColumnName("NSS");

            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.numTarjeta)
                .HasColumnName("NumeroTarjeta");

            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.telefono)
                .HasColumnName("Telefono");

            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.direccion)
                .HasColumnName("Direccion");

            // Mapeo de columnas específicas de Medico
            modelBuilder.Entity<MedicoModel>()
                .Property(m => m.numColegiado)
                .HasColumnName("NumeroColegiado");

            modelBuilder.Entity<MedicoModel>().HasData(
                new MedicoModel { Id = -1, nombre = "Sixam", apellidos = "Camboya", clave = "1234", numColegiado = "1234", usuario = "Pepitos"});
            modelBuilder.Entity<PacienteModel>().HasData(
                new PacienteModel { Id = -2, nombre = "Carlos", apellidos = "Casandra", clave = "1234", NSS = "1234", numTarjeta = "1", telefono = "123456789", direccion = "Mi casa" });
                
        }
        public CitasMedicasDbContext(DbContextOptions<CitasMedicasDbContext> options) : base(options) { }
    }
}
