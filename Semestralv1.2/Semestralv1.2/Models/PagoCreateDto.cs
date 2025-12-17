using System.Net.Http.Json;

namespace Semestralv1._2.Models
{
    public class PagoDto
    {
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
