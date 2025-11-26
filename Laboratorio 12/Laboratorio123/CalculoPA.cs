using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio123
{
    internal class CalculoPA
    {
        public class CalculadorPerimetroA
        {
            public double CalculoSPerimetro(double ladoA, double ladoB, double ladoC)
            {
                double sPerimetro = (ladoA + ladoB + ladoC)/2;
                return sPerimetro;
            }

            public double CalculoArea(double sPerimetro, double ladoA, double ladoB, double ladoC) { 
                double area = Math.Sqrt(sPerimetro * (sPerimetro - ladoA) * (sPerimetro - ladoB) * (sPerimetro - ladoC));
                return area;
            }
        }
    }
}
