using System;

namespace Ejercicio2
{
    class CalculosMatematicos
    {
        public double CalculoArea(double radio)
        {
            return Math.PI * Math.Pow(radio, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculos = new CalculosMatematicos();

            Console.WriteLine("=== EJERCICIO 2: Área de un círculo ===");
            Console.Write("Ingrese el radio del círculo: ");
            double radio = double.Parse(Console.ReadLine());

            double area = calculos.CalculoArea(radio);
            Console.WriteLine($"El área del círculo con radio {radio} es: {area}");

            Console.ReadKey();
        }
    }
}
