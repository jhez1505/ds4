using System;

namespace Ejercicio3
{
    class CalculosMatematicos
    {
        public int CalcularPerimetroRectangulo(int lado1, int lado2)
        {
            return 2 * (lado1 + lado2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculos = new CalculosMatematicos();

            Console.WriteLine("=== EJERCICIO 3: Perímetro de un rectángulo ===");
            Console.Write("Ingrese el valor del primer lado: ");
            int lado1 = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor del segundo lado: ");
            int lado2 = int.Parse(Console.ReadLine());

            int perimetro = calculos.CalcularPerimetroRectangulo(lado1, lado2);
            Console.WriteLine($"El perímetro del rectángulo es: {perimetro}");

            Console.ReadKey();
        }
    }
}
