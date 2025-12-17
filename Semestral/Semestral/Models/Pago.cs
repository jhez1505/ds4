using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guarderia.api.Models
{
    [Table("Pagos")]
    public class Pago
    {
       
            [Key]
            [Column("PagoID")]
            public int PagoID { get; set; }
        public int ParentID { get; set; }
        public int? ChildID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string? Referencia { get; set; }
        public string? Observacion { get; set; }
    }
}
