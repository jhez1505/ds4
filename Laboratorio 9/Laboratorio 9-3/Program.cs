using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Ingrese lado 1: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Ingrese lado 2: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Ingrese lado 3: ");
        int c = int.Parse(Console.ReadLine());


        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Es un triángulo equilátero.");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Es un triángulo isósceles.");
            }
            else
            {
                Console.WriteLine("Es un triángulo escaleno.");
            }
        }
        else
        {
            Console.WriteLine("No se puede formar un triángulo.");
        }
    }
}
