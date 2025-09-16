using System;

namespace Laboratorio2;

    class Program
    {
        static void Main(String[] args)
        {
        Client client = new Client();
        client.Firstname = "Su_nombre";
        client.Lastname = "Su apellido";
        client.Age = 15;
        client.ID = 1;

        Console.WriteLine(client.GetFullName());
        }



public class Client
{
    public int ID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public ushort Age { get; set; }

    public string GetFullName()
    { 
        return Firstname + " " + Lastname;
    }
}

}