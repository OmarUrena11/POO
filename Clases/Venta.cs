using Org.BouncyCastle.Bcpg.OpenPgp;
using POO;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Actividad_Clases.Clases
{
    internal class Venta
    {
        public string CodigoVenta { get; set; }

        public List<VentaProductos> Productos { get; set; }

        public DateTime Fecha { get; set; }

        public Empleado Empleado { get; set; }

        public decimal Total { get; set; }

        public Venta(Empleado Usuario)
        {
            Productos = new List<VentaProductos>();
            Total = 0;
            CodigoVenta = GenerarCodigoVenta();
            Empleado = Usuario;
            Fecha = DateTime.Now;
            
        }
        private static int contadorVentas = 0;
        private static DateTime fechaUltimaVenta = DateTime.MinValue;

        private string GenerarCodigoVenta()
        {
            // Si es un nuevo día, reiniciamos el contador
            if (fechaUltimaVenta.Date != DateTime.Now.Date)
            {
                contadorVentas = 0;
                fechaUltimaVenta = DateTime.Now;
            }

            // Incrementamos el contador de ventas
            contadorVentas++;

            // Formato: YYYYMMDD + número de venta del día
            string codigo = DateTime.Now.ToString("yyyyMMdd") + contadorVentas.ToString("D3");

            return codigo;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            // Calculamos el total de este producto
            decimal totalProducto = producto.Precio * cantidad;

            // Creamos el detalle del producto vendido
            VentaProductos productoVendido = new VentaProductos();

            productoVendido.producto = producto;
            productoVendido.cantidad = cantidad;
            productoVendido.total = totalProducto;

            // Lo agregamos a la lista
            Productos.Add(productoVendido);

            // Actualizamos el total de la venta
            Total += totalProducto;
        }
    }
}
