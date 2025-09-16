using System;

namespace Laboratorio21
{
    public class Program
    {
        public static void Main()
        {
            Myclass.Valor = 1;
            Console.WriteLine(Myclass.Valor);
        }
    }
    public class Myclass
    {
        public static int Valor;
    }
}
    