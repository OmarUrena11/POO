using Org.BouncyCastle.Bcpg.OpenPgp;
using POO;
using System;
using System.Collections.Generic;

namespace Actividad_Clases.Clases
{
    internal class Venta
    {
        public string CodigoVenta { get; set; }

        public List<VentaProductos> Productos { get; set; }

        public DateTime Fecha { get; set; }

        public Empleado Empleado { get; set; }

        public decimal Total { get; set; }

        public Venta()
        {
            Productos = new List<VentaProductos>();
            Total = 0;
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
