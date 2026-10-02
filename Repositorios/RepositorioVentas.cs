using Actividad_Clases;
using Actividad_Clases.Clases;
using MySql.Data.MySqlClient;
using POO;
using System;
using System.Collections.Generic;

namespace POO.Repositorios
{
    internal class RepositorioVentas
    {
        public void Registrar(Venta venta)
        {
            MySqlConnection conexion = new MySqlConnection(Utils.connStr);

            try
            {
                conexion.Open();

                string sqlVenta = @"
                    INSERT INTO ventas
                    (CodigoVenta, Fecha, IDEmpleado, Total)
                    VALUES
                    (@CodigoVenta, @Fecha, @IDEmpleado, @Total)";

                MySqlCommand comandoVenta = new MySqlCommand(sqlVenta, conexion);

                comandoVenta.Parameters.AddWithValue("@CodigoVenta", venta.CodigoVenta);
                comandoVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                comandoVenta.Parameters.AddWithValue("@IDEmpleado", venta.Empleado.ID);
                comandoVenta.Parameters.AddWithValue("@Total", venta.Total);

                comandoVenta.ExecuteNonQuery();

                foreach (VentaProductos producto in venta.Productos)
                {
                    string sqlProducto = @"
                        INSERT INTO ventasproductos
                        (CodigoVenta, IDProducto, Cantidad, Total)
                        VALUES
                        (@CodigoVenta, @IDProducto, @Cantidad, @Total)";

                    MySqlCommand comandoProducto =
                        new MySqlCommand(sqlProducto, conexion);

                    comandoProducto.Parameters.AddWithValue(
                        "@CodigoVenta", venta.CodigoVenta);

                    comandoProducto.Parameters.AddWithValue(
                        "@IDProducto", producto.producto.ID);

                    comandoProducto.Parameters.AddWithValue(
                        "@Cantidad", producto.cantidad);

                    comandoProducto.Parameters.AddWithValue(
                        "@Total", producto.total);

                    comandoProducto.ExecuteNonQuery();
                }

                Console.WriteLine("Venta registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la venta: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Venta> Lista()
        {
            List<Venta> ventas = new List<Venta>();

            MySqlConnection conexion = new MySqlConnection(Utils.connStr);

            try
            {
                conexion.Open();

                string sql = @"
            SELECT CodigoVenta, Fecha, Total
            FROM ventas
            ORDER BY Fecha DESC";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta(null);

                    venta.CodigoVenta = reader["CodigoVenta"].ToString();
                    venta.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    venta.Total = Convert.ToDecimal(reader["Total"]);

                    ventas.Add(venta);
                }

                reader.Close();

                Console.WriteLine($"Ventas encontradas: {ventas.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }

            return ventas;
        }
    }
}