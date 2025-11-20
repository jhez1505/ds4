using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio121
{
    internal class Class1
    {
        public class CalculadorMovil
        {
            public double CalcularDistancia(double velocidad, double tiempo)
            {
                double distancia = velocidad * tiempo;
                return distancia;
            }
        }
    }
}
