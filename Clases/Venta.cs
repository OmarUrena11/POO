using Org.BouncyCastle.Bcpg.OpenPgp;
using POO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_Clases.Clases
{
    internal class Venta
    {
        public string CodigoVenta { get; set; }//ticket de la venta
        public List<Producto> Productos { get; set; }// lista de productos vendidos
        public DateTime Fecha { get; set; }//fecha de la venta
        public Empleado Empleado { get; set; }//empleado que realizo la venta
        public decimal Total { get; set; }//total de la venta
        public void AgregarProducto(Producto producto, int cantidad)
        {
            //calculamos el total del producto  
            decimal totalProducto = producto.Precio * cantidad;

            //creamos instancia del producto a añadir a la lista 
            VentaProductos productoVendido = new VentaProductos();

            //asignamos sus valores
            productoVendido.producto = producto;
            productoVendido.cantidad = cantidad;
            productoVendido.total = totalProducto;

            //agregamos el producto a la lista de productos vendidos
            Productos.Add(productoVendido);

            //calculamos el total de la venta
            Total += totalProducto;

        }
    }
}
