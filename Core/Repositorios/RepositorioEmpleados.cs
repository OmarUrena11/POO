using Actividad_Clases;
using Actividad_Clases.Clases;
using MySql.Data.MySqlClient;
using Core.Interfaces;
using Core.Clases;
using System;
using System.Collections.Generic;

namespace Core.Repositorios
{
    public class RepositorioEmpleados : IRepository<Empleado>
    {
        public Response<Empleado> Actualizar(Empleado empleado)
        {
            Response<Empleado> response = new Response<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"UPDATE empleados SET Nombre = @Nombre,Edad = @Edad,Salario = @Salario WHERE ID = @ID";
                                                                                                  
                               
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@ID", empleado.ID);
                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Edad", empleado.Edad);
                comando.Parameters.AddWithValue("@Salario", empleado.Salario);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Empleado actualizado correctamente";
                        response.Data = empleado;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontró el empleado para actualizar";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al actualizar empleado: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Empleado> Registro(Empleado empleado)
        {
            Response<Empleado> response = new Response<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"INSERT INTO empleados(nombre, edad, salario) VALUES (@nombre, @edad, @salario)";
                               
                               

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@edad", empleado.Edad);
                comando.Parameters.AddWithValue("@salario", empleado.Salario);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Empleado registrado correctamente";
                        response.Data = empleado;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se pudo registrar el empleado";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al registrar empleado: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Empleado> Eliminar(Empleado empleado)
        {
            Response<Empleado> response = new Response<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "DELETE FROM empleados WHERE ID = @ID";

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@ID", empleado.ID);

                try
                {
                    conexion.Open();

                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Empleado eliminado correctamente";
                        response.Data = empleado;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontró el empleado para eliminar";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al eliminar empleado: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<List<Empleado>> Lista()
        {
            Response<List<Empleado>> response =
                new Response<List<Empleado>>();

            List<Empleado> lista = new List<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "SELECT * FROM empleados";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado();

                            empleado.ID = Convert.ToInt32(reader["ID"]);
                            empleado.Nombre = reader["Nombre"].ToString();
                            empleado.Edad = Convert.ToInt32(reader["Edad"]);
                            empleado.Salario =
                                Convert.ToDouble(reader["Salario"]);

                            lista.Add(empleado);
                        }
                    }

                    if (lista.Count > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Empleados encontrados";
                        response.Data = lista;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No hay empleados registrados";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al listar empleados: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<List<Empleado>> Buscar(string nombre)
        {
            Response<List<Empleado>> response =
                new Response<List<Empleado>>();

            List<Empleado> lista = new List<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = @"SELECT * FROM empleados
                               WHERE Nombre LIKE @Nombre";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue(
                    "@Nombre", "%" + nombre + "%");

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado();

                            empleado.ID = Convert.ToInt32(reader["ID"]);
                            empleado.Nombre = reader["Nombre"].ToString();
                            empleado.Edad = Convert.ToInt32(reader["Edad"]);
                            empleado.Salario =
                                Convert.ToDouble(reader["Salario"]);

                            lista.Add(empleado);
                        }
                    }

                    if (lista.Count > 0)
                    {
                        response.Codigo = 1;
                        response.Mensaje = "Empleados encontrados";
                        response.Data = lista;
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Mensaje = "No se encontraron empleados";
                        response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al buscar empleados: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Response<Empleado> Buscar(int id)
        {
            Response<Empleado> response = new Response<Empleado>();

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql = "SELECT * FROM empleados WHERE ID = @ID";

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Empleado empleado = new Empleado();

                            empleado.ID = Convert.ToInt32(reader["ID"]);
                            empleado.Nombre = reader["Nombre"].ToString();
                            empleado.Edad = Convert.ToInt32(reader["Edad"]);
                            empleado.Salario =
                                Convert.ToDouble(reader["Salario"]);

                            response.Codigo = 1;
                            response.Mensaje = "Empleado encontrado";
                            response.Data = empleado;
                        }
                        else
                        {
                            response.Codigo = 2;
                            response.Mensaje = "No se encontró el empleado";
                            response.Data = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje =
                        $"Error al buscar empleado: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }

        public Empleado BuscarPorCodigo(int codigo)
        {
            Empleado empleado = null;

            using (MySqlConnection conexion =
                new MySqlConnection(Utils.connStr))
            {
                string sql =
                    "SELECT * FROM empleados WHERE Codigo = @Codigo";

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Codigo", codigo);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleado = new Empleado();

                            empleado.ID = Convert.ToInt32(reader["ID"]);
                            empleado.Nombre = reader["Nombre"].ToString();
                            empleado.Edad = Convert.ToInt32(reader["Edad"]);
                            empleado.Salario =
                                Convert.ToDouble(reader["Salario"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Error al buscar empleado por código: {ex.Message}");
                }
            }

            return empleado;
        }
    }
}
