using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Ingrese el precio del producto: ");
        double precio = double.Parse(Console.ReadLine());

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser positivo.");
            return;
        }

        Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ");
        string formaPago = Console.ReadLine().ToLower();

        if (formaPago == "tarjeta")
        {
            Console.Write("Ingrese el número de cuenta (16 dígitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16 && long.TryParse(cuenta, out _))
            {
                Console.WriteLine($"Pago realizado con tarjeta. Precio: {precio:C}, Cuenta: {cuenta}");
            }
            else
            {
                Console.WriteLine("Número de cuenta inválido.");
            }
        }
        else if (formaPago == "efectivo")
        {
            Console.WriteLine($"Pago en efectivo realizado. Precio: {precio:C}");
        }
        else
        {
            Console.WriteLine("Forma de pago no válida.");
        }
    }
}
