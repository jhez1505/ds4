namespace Semestralv1._2.Models
{
    public class FacturaDto
    {
        public int InvoiceID { get; set; }
        public int ParentID { get; set; }
        public string NumeroFactura { get; set; } = "";
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; } = "";
        public string? DescripcionGeneral { get; set; }
    }
}
