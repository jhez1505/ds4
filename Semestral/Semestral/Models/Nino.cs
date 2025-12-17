using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guarderia.api.Models
{
    [Table("Ninos")]
    public class Nino
    {
        [Key]
        [Column("ChildID")]
        public int ChildID { get; set; }

        public int ParentID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CondicionMedica { get; set; }
        public string Alergias { get; set; }
        public string Estado { get; set; }
    }
}
