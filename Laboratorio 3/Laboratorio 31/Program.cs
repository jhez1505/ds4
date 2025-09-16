using System;

namespace Ejercicio1
{
    class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculos = new CalculosMatematicos();

            Console.WriteLine("=== EJERCICIO 1: (a+b)*(a-b) ===");
            Console.Write("Ingrese el primer número (a): ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el segundo número (b): ");
            int b = int.Parse(Console.ReadLine());

            int resultado = calculos.Calcular(a, b);
            Console.WriteLine($"El resultado de la operación (a+b)*(a-b) es: {resultado}");

            Console.ReadKey();
        }
    }
}
