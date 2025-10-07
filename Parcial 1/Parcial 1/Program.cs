using System;

namespace Parcial1;

class program
{
    static void Main(string[] args)
    {
        // Generacion de numeros
        Random rnd = new Random();
        int N;

        do
        {
            //Logica principal
            Console.Write("Ingrese los valores impares: ");
            N = int.Parse(Console.ReadLine());
        } while (N % 2 == 0);

        int[,] matriz = new int[N, N];
        int suma = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i == N/2 || j == N/2)
                {
                    matriz[i, j] = rnd.Next(1, 101);
                    suma += matriz[i, j];
                }
                else
                {
                    matriz[i, j] = 0;
                }
            }

        }

        //Visual
        Console.WriteLine("\nMatriz creada: \n");
        for (int i = 0;i < N; i++)
        {
            for (int j = 0;j < N; j++)
            {
                Console.Write($"{matriz[i,j],5}");
            }
            Console.WriteLine();//Salto de linea
        }
        Console.WriteLine($"\nLa suma de todos los numeros es: {suma}");
    }
}