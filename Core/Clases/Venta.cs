using System;
using System.Collections.Generic;
using Core;

namespace Actividad_Clases.Clases
{
    public class Venta
    {
        public string CodigoVenta { get; set; }

        public List<VentaProductos> Productos { get; set; }

        public DateTime Fecha { get; set; }

        public Empleado Empleado { get; set; }

        public decimal Total { get; set; }

        public Venta(Empleado Usuario, string codigoVenta)
        {
            Productos = new List<VentaProductos>();
            Total = 0;
            CodigoVenta = codigoVenta;
            Empleado = Usuario;
            Fecha = DateTime.Now;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            decimal totalProducto = producto.Precio * cantidad;

            VentaProductos productoVendido = new VentaProductos();

            productoVendido.producto = producto;
            productoVendido.cantidad = cantidad;
            productoVendido.total = totalProducto;

            Productos.Add(productoVendido);

            Total += totalProducto;
        }
    }
}
