using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class CitaModel
    {
        
        [Key] //Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public long Id { get; set; } //Identificador de la cita 

        public DateTime fechaHora { get; set; }  //La fecha y la hora de la cita

        public string motivoCita { get; set; } = string.Empty; //Motivo de la cita

        public int attribute11 { get; set; } //??


        //Relación one to many
        public long pacienteId { get; set; }

        public PacienteModel paciente { get; set; } 


        //Relación one to many
        public long medicoId { get; set; }

        public MedicoModel medico { get; set; }


        //Relación one to one
        public DiagnosticoModel diagnostico { get; set; }

    }
}
