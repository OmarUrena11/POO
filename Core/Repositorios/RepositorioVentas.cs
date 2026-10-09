using Actividad_Clases;
using Actividad_Clases.Clases;
using Core;
using Core.Clases;
using Core.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Core.Repositorios
{
    public class RepositorioVentas : IVentaRepository
    {
        public Response<string> ObtenerNumeroVentaDelDia()
        {
            Response<string> response = new Response<string>();

            using (MySqlConnection conexion = new MySqlConnection(Utils.connStr))
            {
                string sql = "SELECT COUNT(*) + 1 FROM Ventas WHERE DATE(Fecha) = CURDATE()";
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                try
                {
                    conexion.Open();

                    int numeroVenta = Convert.ToInt32(comando.ExecuteScalar());

                    response.Codigo = 1;
                    response.Mensaje = "Código de venta generado correctamente";
                    response.Data = DateTime.Now.ToString("yyyyMMdd") + numeroVenta.ToString("D3");
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje = $"Error al generar el código de venta: {ex.Message}";
                    response.Data = "";
                }
            }

            return response;
        }

        public Response<Venta> Registrar(Venta venta)
        {
            Response<Venta> response = new Response<Venta>();

            using (MySqlConnection conexion = new MySqlConnection(Utils.connStr))
            {
                MySqlTransaction transaccion = null;

                try
                {
                    conexion.Open();
                    transaccion = conexion.BeginTransaction();

                    int idVenta = ObtenerSiguienteIDVenta(conexion, transaccion);

                    string sqlVenta = @"INSERT INTO Ventas(ID, CodigoVenta, Empleado, Fecha, Total)VALUES(@ID, @CodigoVenta, @Empleado, @Fecha, @Total)";

                    using (MySqlCommand comandoVenta =
                        new MySqlCommand(sqlVenta, conexion, transaccion))
                    {
                        comandoVenta.Parameters.AddWithValue("@ID", idVenta);
                        comandoVenta.Parameters.AddWithValue("@CodigoVenta", venta.CodigoVenta);
                        comandoVenta.Parameters.AddWithValue("@Empleado", venta.Empleado.ID);
                        comandoVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        comandoVenta.Parameters.AddWithValue("@Total", venta.Total);

                        comandoVenta.ExecuteNonQuery();
                    }

                    foreach (VentaProductos producto in venta.Productos)
                    {
                        int idProductoVenta =
                            ObtenerSiguienteIDProductoVenta(conexion, transaccion);

                        string sqlProducto = @"INSERT INTO Ventas_productos(ID, IDCuenta, IDProducto, Precio, Cantidad, Total) VALUES (@ID, @IDCuenta, @IDProducto, @Precio, @Cantidad, @Total)";                            
                                                       
                            
                        using (MySqlCommand comandoProducto =
                            new MySqlCommand(sqlProducto, conexion, transaccion))
                        {
                            comandoProducto.Parameters.AddWithValue("@ID", idProductoVenta);
                            comandoProducto.Parameters.AddWithValue("@IDCuenta", idVenta);
                            comandoProducto.Parameters.AddWithValue("@IDProducto", producto.producto.ID);
                            comandoProducto.Parameters.AddWithValue("@Precio", producto.producto.Precio);
                            comandoProducto.Parameters.AddWithValue("@Cantidad", producto.cantidad);
                            comandoProducto.Parameters.AddWithValue("@Total", producto.total);

                            comandoProducto.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();

                    response.Codigo = 1;
                    response.Mensaje = "Venta registrada correctamente";
                    response.Data = venta;
                }
                catch (Exception ex)
                {
                    if (transaccion != null)
                    {
                        transaccion.Rollback();
                    }

                    response.Codigo = 0;
                    response.Mensaje = $"Error al registrar la venta: {ex.Message}";
                    response.Data = null;
                }
                finally
                {
                    transaccion?.Dispose();
                }
            }

            return response;
        }

        private int ObtenerSiguienteIDVenta(
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = "SELECT COALESCE(MAX(ID), 0) + 1 FROM Ventas";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        private int ObtenerSiguienteIDProductoVenta(
            MySqlConnection conexion,
            MySqlTransaction transaccion)
        {
            string sql = "SELECT COALESCE(MAX(ID), 0) + 1 FROM Ventas_productos";

            using (MySqlCommand comando =
                new MySqlCommand(sql, conexion, transaccion))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public Response<List<Venta>> Lista()
        {
            Response<List<Venta>> response =
                new Response<List<Venta>>();

            List<Venta> ventas = new List<Venta>();

            using (MySqlConnection conexion = new MySqlConnection(Utils.connStr))
            {
                try
                {
                    conexion.Open();

                    string sql = @"
                        SELECT CodigoVenta, Fecha, Total
                        FROM Ventas
                        ORDER BY Fecha DESC";

                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta(null, reader["CodigoVenta"].ToString()


                            );

                            venta.CodigoVenta = reader["CodigoVenta"].ToString();
                            venta.Fecha = Convert.ToDateTime(reader["Fecha"]);
                            venta.Total = Convert.ToDecimal(reader["Total"]);

                            ventas.Add(venta);
                        }
                    }

                    response.Codigo = 1;
                    response.Mensaje = ventas.Count > 0
                        ? "Ventas encontradas"
                        : "No se encontraron ventas";

                    response.Data = ventas;
                }
                catch (Exception ex)
                {
                    response.Codigo = 0;
                    response.Mensaje = $"Error al listar ventas: {ex.Message}";
                    response.Data = null;
                }
            }

            return response;
        }
    }
}
