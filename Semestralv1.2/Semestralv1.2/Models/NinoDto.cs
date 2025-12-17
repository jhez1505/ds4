namespace Semestralv1._2.Models
{
    public class NinoDto
    {
        public int ChildID { get; set; }
        public int ParentID { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public DateTime FechaNacimiento { get; set; }
        public string CondicionMedica { get; set; } = "";
        public string Alergias { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
