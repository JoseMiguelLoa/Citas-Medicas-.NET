using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class DiagnosticoModel
    {
        [Key] //Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//AutoIncrement
        public long Id { get; set; } //Identificador del diagnóstico

        public  string valoracionEspecialista { get; set; } = string.Empty; //La valoración del especialista 

        public string enfermedad {  get; set; } = string.Empty; //Enfermedad diagnosticada



        //Relación one to one

        public long citaId { get; set; }

        public CitaModel cita { get; set; }
    }
}
