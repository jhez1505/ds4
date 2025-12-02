using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_3.Models
{
    [Table("JD_CasoCliente")]
    public class CasoCliente
    {
        [Key, Column(Order = 0)]
        public int CasoID { get; set; }

        [Key, Column(Order = 1)]
        public int ClienteID { get; set; }

        public string RolCliente { get; set; }
    }
}
