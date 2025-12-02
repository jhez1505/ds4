using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_3.Models
{
    [Table("JD_Casos")]
    public class Caso
    {
        [Key]
        public int CasoID { get; set; }
        public string CodigoCaso { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string EstadoCaso { get; set; }
        public string Prioridad { get; set; }

        public int AbogadoAsignadoID { get; set; }
        [ForeignKey("AbogadoAsignadoID")]
        public virtual Abogado AbogadoAsignado { get; set; }
    }
}
