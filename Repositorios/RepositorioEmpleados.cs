using Actividad_Clases;
//Conectar a la base de datos MySQL
using MySql.Data;
using MySql.Data.MySqlClient;
using POO.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace POO.Repositorios
{
    internal class RepositorioEmpleados : IRepository<Empleado>

    {
        //Cadena de conexión a la base de datos
        //string connStr = "server=127.0.0.1;uid=root;pwd=1102;database=ProgramOO";
        public void Actualizar(Empleado empleado)

        {   //Actualizar un empleado en la base de datos
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("UPDATE empleados SET Nombre=@Nombre, Edad=@Edad, Salario=@Salario WHERE ID=@ID", conection);
            command.Parameters.AddWithValue("@ID", empleado.ID);
            command.Parameters.AddWithValue("@nombre", empleado.Nombre);
            command.Parameters.AddWithValue("@edad", empleado.Edad);
            command.Parameters.AddWithValue("@salario", empleado.Salario);
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Empleado actualizado");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar empleado");
            }
            finally
            {
                conection.Close();
            }

        }
        public void Registro(Empleado empleado)
        {
            //Registrar un empleado en la base de datos
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("insert into empleados (nombre, edad, salario) values (@nombre, @edad, @salario);", conection);
            command.Parameters.AddWithValue("@nombre", empleado.Nombre);
            command.Parameters.AddWithValue("@edad", empleado.Edad);
            command.Parameters.AddWithValue("@salario", empleado.Salario);
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Empleado registrado");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar empleado: {ex.Message}");
            }
            finally
            {
                conection.Close();
            }


        }
        public void Eliminar(Empleado empleado)
        {
            //Eliminar un empleado en la base de datos
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("delete from empleados where ID=@ID", conection);
            command.Parameters.AddWithValue("@ID", empleado.ID);

            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Empleado Eliminado");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar empleado");
            }
            finally
            {
                conection.Close();
            }


        }
        public List<Empleado> Lista()
        {
            //Listar los empleados en la base de datos
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("select * from empleados", conection);
            List<Empleado> lista = new List<Empleado>();

            try
            {
                conection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado.ID = Convert.ToInt32(reader["id"].ToString());
                        empleado.Nombre = reader["nombre"].ToString();
                        empleado.Edad = Convert.ToInt32(reader["edad"].ToString());
                        empleado.Salario = Convert.ToDouble(reader["salario"].ToString());

                        lista.Add(empleado); 

                    }
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar empleados");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conection.Close();
            }
            return lista;
        }
        public List<Empleado> Buscar(string nombre)
        {
            //Buscar los empleados en la base de datos
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("select * from empleados where nombre LIKE '%'@nombre'%'", conection); 
            command.Parameters.AddWithValue("@nombre", $"%{nombre}%");
            List<Empleado> lista = new List<Empleado>();

            try
            {
                conection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado.ID = Convert.ToInt32(reader["id"].ToString());
                        empleado.Nombre = reader["nombre"].ToString();
                        empleado.Edad = Convert.ToInt32(reader["edad"].ToString());
                        empleado.Salario = Convert.ToDouble(reader["salario"].ToString());

                        lista.Add(empleado);

                    }
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar empleados");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conection.Close();
            }
            return lista;
        }
        public Empleado BuscarPorCodigo(int codigo)
        {
            MySqlConnection conection = new MySqlConnection(Utils.connStr);
            MySqlCommand command = new MySqlCommand("SELECT * FROM empleados WHERE Codigo=@Codigo", conection);

            command.Parameters.AddWithValue("@Codigo", codigo);

            Empleado empleado = null;

            try
            {
                conection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    empleado = new Empleado();

                    empleado.ID = Convert.ToInt32(reader["ID"].ToString());
                    empleado.Nombre = reader["Nombre"].ToString();
                    empleado.Edad = Convert.ToInt32(reader["Edad"].ToString());
                    empleado.Salario = Convert.ToDouble(reader["Salario"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar empleado por código");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conection.Close();
            }

            return empleado;
        }

    }

}
