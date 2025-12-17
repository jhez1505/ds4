using System.Text.Json.Serialization;

namespace Semestralv1._2.Models
{
    public class PadreDto
    {
        [JsonPropertyName("ParentID")]
        public int ParentID { get; set; }

        public string Cedula { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
