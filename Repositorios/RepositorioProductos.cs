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
        public void Actualizar(Producto producto)
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
        {//Registrar un producto en la base de datos
            MySqlConnection conection = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand("insert into productos (nombre, precio) values (@nombre, @precio);", conection);
            command.Parameters.AddWithValue("@nombre", producto.Nombre);
            command.Parameters.AddWithValue("@precio", producto.Precio);
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Producto registrado");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar producto: {ex.Message}");
            }
            finally
            {
                conection.Close();
            }
        }

        public void Eliminar(Producto producto)
        {//Eliminar un producto en la base de datos
            MySqlConnection conection = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand("delete from productos where ID=@ID", conection);
            command.Parameters.AddWithValue("@ID", producto.ID);

            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Producto Eliminado");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto");
            }
            finally
            {
                conection.Close();
            }


        }
        public List<Producto> Lista()
        {   //Listar los productos en la base de datos
            MySqlConnection conection = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand("select * from productos", conection);
            List<Producto> lista = new List<Producto>();

            try
            {
                conection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.ID = Convert.ToInt32(reader["id"].ToString());
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Precio = Convert.ToDecimal(reader["precio"].ToString());

                        lista.Add(producto);

                    }
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conection.Close();
            }
            return lista;
            
        }
        public List<Producto> Buscar(string nombre)
        {
            //Buscar los productos en la base de datos
            MySqlConnection conection = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand("select * from productos where nombre LIKE '%'@nombre'%'", conection);
            command.Parameters.AddWithValue("@nombre", $"%{nombre}%");
            List<Producto> lista = new List<Producto>();

            try
            {
                conection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.ID = Convert.ToInt32(reader["id"].ToString());
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Precio = Convert.ToDecimal(reader["precio"].ToString());

                        lista.Add(producto);

                    }
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conection.Close();
            }
            return lista;
        }
    }
}
