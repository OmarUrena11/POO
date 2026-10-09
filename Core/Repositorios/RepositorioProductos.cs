using Actividad_Clases;
using Actividad_Clases.Clases;
using MySql.Data.MySqlClient;
using Core.Interfaces;
using Core.Clases;
using System;
using System.Collections.Generic;

namespace Core.Repositorios
{
    public class RepositorioProductos : IRepository<Producto>
    {
        public Response<Producto> Actualizar(Producto producto)
        {
            Response<Producto> response = new Response<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"UPDATE productos SET Nombre = @Nombre, Precio = @Precio WHERE ID = @ID";
                              
                              

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@ID", producto.ID);
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Producto actualizado correctamente";
                        response.Data = producto;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontró el producto para actualizar";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al actualizar producto: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Producto> Registro(Producto producto)
        {
            Response<Producto> response = new Response<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"INSERT INTO productos (nombre, precio) VALUES (@nombre, @precio)";
                               

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@precio", producto.Precio);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Producto registrado correctamente";
                        response.Data = producto;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se pudo registrar el producto";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al registrar producto: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Producto> Eliminar(Producto producto)
        {
            Response<Producto> response = new Response<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "DELETE FROM productos WHERE ID = @ID";

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@ID", producto.ID);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Producto eliminado correctamente";
                        response.Data = producto;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontró el producto para eliminar";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al eliminar producto: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<List<Producto>> Lista()
        {
            Response<List<Producto>> response =
                new Response<List<Producto>>();

            List<Producto> lista = new List<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "SELECT * FROM productos";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.ID = Convert.ToInt32(reader["id"]);
                            producto.Nombre = reader["nombre"].ToString();
                            producto.Precio =
                                Convert.ToDecimal(reader["precio"]);

                            lista.Add(producto);
                        }
                    }

                    if (lista.Count > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Productos encontrados";
                        response.Data = lista;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No hay productos registrados";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al listar productos: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<List<Producto>> Buscar(string nombre)
        {
            Response<List<Producto>> response =
                new Response<List<Producto>>();

            List<Producto> lista = new List<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"SELECT * FROM productos
                               WHERE nombre LIKE @nombre";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue(
                    "@nombre", "%" + nombre + "%");

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.ID = Convert.ToInt32(reader["id"]);
                            producto.Nombre = reader["nombre"].ToString();
                            producto.Precio =
                                Convert.ToDecimal(reader["precio"]);

                            lista.Add(producto);
                        }
                    }

                    if (lista.Count > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Productos encontrados";
                        response.Data = lista;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontraron productos";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al buscar productos: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Producto> Buscar(int id)
        {
            Response<Producto> response = new Response<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "SELECT * FROM productos WHERE ID = @ID";

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.ID = Convert.ToInt32(reader["id"]);
                            producto.Nombre = reader["nombre"].ToString();
                            producto.Precio =
                                Convert.ToDecimal(reader["precio"]);

                            response.Codigo = 1;
                            response.Mensaje = "Producto encontrado";
                            response.Data = producto;
                        }
                        else
                        {
                            response.Codigo = 2;
                            response.Mensaje = "No se encontró el producto";
                            response.Data = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al buscar producto: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }
    }
}
