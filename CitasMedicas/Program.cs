using CitasMedicas.Context;
using CitasMedicas.Implementation;
using CitasMedicas.Interfaces;
using CitasMedicas.Repository;
using CitasMedicas.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CitasMedicasDbContext>(options => options.UseSqlServer("name=ConnectionStrings:connection"));//Conexión a la base de datos
builder.Services.AddScoped<IUsuarioService, UsuarioService>();//Servicio de Usuario
builder.Services.AddScoped<IPacienteService, PacienteService>(); //Servicio de Paciente  
builder.Services.AddScoped<IMedicoService, MedicoService>();//Servicio de Médico
builder.Services.AddScoped<ICitaService,CitaService>();//Servicio de Cita
builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>(); //Servicio de Diagnóstico

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<CitasMedicasDbContext>(opt => opt.UseInMemoryDatabase("CitasMedicas"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


