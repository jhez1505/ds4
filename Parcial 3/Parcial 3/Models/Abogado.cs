using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_3.Models
{
    [Table("JD_Abogados")]
    public class Abogado
    {
        [Key]
        public int AbogadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool EsActivo { get; set; }
    }
}
