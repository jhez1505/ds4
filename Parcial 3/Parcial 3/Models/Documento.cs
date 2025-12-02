using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_3.Models
{
    [Table("JD_Documentos")]
    public class Documento
    {
        [Key]
        public int DocumentoID { get; set; }
        public int CasoID { get; set; }
        public string NombreDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public string Notas { get; set; }
    }
}
