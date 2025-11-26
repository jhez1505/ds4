using Laboratorio_20_3.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace Laboratorio20_3.Controllers
{
    public class LaptopsController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["ProductosDB"].ConnectionString;

        // GET: api/laptops
        public List<Laptop> Get()
        {
            List<Laptop> lista = new List<Laptop>();

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from Laptops", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Laptop
                    {
                        id = (int)reader["id"],
                        nombre = reader["nombre"].ToString(),
                        precio = (decimal)reader["precio"],
                        stock = double.Parse(reader["stock"].ToString())
                    });
                }
            }

            return lista;
        }

        // GET api/laptops/5
        public Laptop Get(int id)
        {
            Laptop laptop = null;

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from Laptops where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    laptop = new Laptop
                    {
                        id = (int)r["id"],
                        nombre = r["nombre"].ToString(),
                        precio = (decimal)r["precio"],
                        stock = double.Parse(r["stock"].ToString())
                    };
                }
            }

            return laptop;
        }

        // POST api/laptops
        public string Post(Laptop laptop)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "insert into Laptops(nombre,precio,stock) values(@n,@p,@s)", conn);

                cmd.Parameters.AddWithValue("@n", laptop.nombre);
                cmd.Parameters.AddWithValue("@p", laptop.precio);
                cmd.Parameters.AddWithValue("@s", laptop.stock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Laptop guardada correctamente";
        }

        // PUT api/laptops/5
        public string Put(int id, Laptop laptop)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "update Laptops set nombre=@n, precio=@p, stock=@s where id=@id", conn);

                cmd.Parameters.AddWithValue("@n", laptop.nombre);
                cmd.Parameters.AddWithValue("@p", laptop.precio);
                cmd.Parameters.AddWithValue("@s", laptop.stock);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Laptop actualizada correctamente";
        }

        // DELETE api/laptops/5
        public string Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "delete from Laptops where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Laptop eliminada correctamente";
        }
    }
}
