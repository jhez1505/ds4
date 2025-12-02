using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_3.Models
{
    [Table("JD_Eventos")]
    public class Evento
    {
        [Key]
        public int EventoID { get; set; }
        public int CasoID { get; set; }
        public string TipoEvento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public string Ubicacion { get; set; }
        public bool EsPlazoLegal { get; set; }
        public string EstadoEvento { get; set; }
    }
}
