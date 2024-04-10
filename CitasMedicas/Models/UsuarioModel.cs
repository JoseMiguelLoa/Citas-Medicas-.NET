using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class UsuarioModel
    {
        [Key] //Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public long Id { get; set; } //Identificador del usuario 
        public string nombre { get; set; } = string.Empty; //Nombre del usuario

        public string apellidos { get; set; } = string.Empty; //Apellidos del usuario

        public string usuario { get; set; } = string.Empty; // Nombre de usuario del usuario

        public string clave { get; set; } = string.Empty; //Clave/Contraseña del usuario



    }
}
