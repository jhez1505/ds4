using System;

public class Aleatorios
{
    private Random rnd;

    public Aleatorios()
    {
        rnd = new Random();
    }

    public int GenerarNumero(int min, int max)
    {
        return rnd.Next(min, max + 1);
    }

    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = rnd.Next(min, max + 1);
        }
        return arreglo;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios ale = new Aleatorios();

        Console.WriteLine("Ingrese el valor mínimo:");
        int min = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el valor máximo:");
        int max = int.Parse(Console.ReadLine());

        Console.WriteLine("¿Cuántos números desea generar (sin repetir)?");
        int cantidad = int.Parse(Console.ReadLine());

        if (cantidad > (max - min + 1))
        {
            Console.WriteLine("No se pueden generar tantos números sin repetición en ese rango.");
            return;
        }

        int[] numeros = GenerarNoRepetidos(ale, cantidad, min, max);

        Console.WriteLine("\nNúmeros generados sin repetición:");
        foreach (int n in numeros)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }

    private static int[] GenerarNoRepetidos(Aleatorios ale, int cantidad, int min, int max)
    {
        HashSet<int> conjunto = new HashSet<int>();
        while (conjunto.Count < cantidad)
        {
            int num = ale.GenerarNumero(min, max);
            conjunto.Add(num); 
        }
        int[] resultado = new int[cantidad];
        conjunto.CopyTo(resultado);
        return resultado;
    }
}
