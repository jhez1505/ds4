using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Guarderia.api.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        [Column("InvoiceID")]
        public int InvoiceID { get; set; }
        public int PagoID { get; set; }
        public int ParentID { get; set; }
        public int? ChildID { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
    }
}
