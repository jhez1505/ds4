using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio_20_3.Models
{
    public class Laptop
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public double stock { get; set; }
    }
}