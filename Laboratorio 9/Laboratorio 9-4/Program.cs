using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios ale = new Aleatorios();

        Console.WriteLine("Generar número entre 5 y 15:");
        Console.WriteLine(ale.GenerarNumero(5, 15));

        Console.WriteLine("\nGenerar arreglo de 5 números entre 1 y 20:");
        int[] arr = ale.GenerarArreglo(5, 1, 20);

        foreach (int n in arr)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}


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
