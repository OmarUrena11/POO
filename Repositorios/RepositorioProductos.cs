using POO.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;

namespace POO.Repositorios
{
    internal class RepositorioProductos : IRepository<Producto>

    {
        string connStr = "server=127.0.0.1;uid=root;pwd=1102;database=ProgramOO";
        public void Actualizar(Producto productos)
        {

            {   //Actualizar un prodcuto en la base de datos
                MySqlConnection conection = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand("UPDATE productos SET Nombre=@Nombre, Precio=@Precio WHERE ID=@ID", conection);
                command.Parameters.AddWithValue("@ID", producto.ID);
                command.Parameters.AddWithValue("@nombre", producto.Nombre);
                command.Parameters.AddWithValue("@precio", producto.Precio);

                try
                {
                    conection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Producto actualizado");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar producto");
                }
                finally
                {
                    conection.Close();
                }

            }
        }

        public void Registro(Producto producto)
        {
        }

        public void Eliminar(Producto producto)
        {
         
        }
        public List<Producto> Lista()
        {
            return new List<Producto>();
        }
        public List<Producto> Buscar(string nombre)
        {
            return new List<Producto>();
        }
    }
}
