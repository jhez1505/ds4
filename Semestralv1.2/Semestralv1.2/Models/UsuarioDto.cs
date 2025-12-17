namespace Semestralv1._2.Models
{
    public class UsuarioDto
    {
        public int UserID { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
        public int? ParentID { get; set; }
        public string Estado { get; set; } = "";
    }
}
