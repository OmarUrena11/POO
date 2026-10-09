using Actividad_Clases.Clases;
using Core;
using Core.Clases;
using Core.Repositorios;
using System.Linq;

namespace TiendaWinforms
{
    public partial class Form1 : Form
    {
        Venta venta = new Venta(new Empleado { ID = 1 }, new RepositorioVentas().ObtenerNumeroVentaDelDia().Data);
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_guardar_venta_Click(object sender, EventArgs e)
        {
            RepositorioProductos repoProductos = new RepositorioProductos();
            int idProducto = Convert.ToInt32(tb_id_producto.Text);
            int cantidad = Convert.ToInt32(tb_cantidad.Text);

            var response = repoProductos.Buscar(idProducto);

            if (response.Codigo == 1)
            {
                Producto producInfo = response.Data;

                venta.AgregarProducto(producInfo, cantidad);

                dgv_lista.DataSource = venta.Productos.Select(producto => new
                {
                    producto = producto.producto.Nombre
                }).ToList();

                lb_total.Text = venta.Total.ToString();
                 
                return;
            }
            else if (response.Codigo == 2)
            {
                MessageBox.Show("El codigo del producto no se encontro");

            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }

            tb_id_producto.Text = "";
            tb_cantidad.Text = "";


        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            RepositorioVentas repoVenta = new RepositorioVentas();
            repoVenta.Registrar(venta);
            dgv_lista.DataSource = null;
            lb_total.Text = "";
            MessageBox.Show("Venta registrada correctamente");

        }
    }
}
