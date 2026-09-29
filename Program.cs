using Actividad_Clases.Clases;
using Org.BouncyCastle.Bcpg.OpenPgp;
using POO;
using POO.Repositorios;
//Hicimos un menu para que el usuario pueda elegir entre empleados y productos, y luego elegir entre registrar, actualizar o eliminar.
string[] codigosValidos =
{
    "483721",
    "915604",
    "267839",
    "731526",
    "594183",
    "826475",
    "350918",
    "648207"
};

bool acceso = false;

while (!acceso)
{
    Console.Clear();

    Console.WriteLine("===== ACCESO AL SISTEMA =====");
    Console.Write("Ingrese su código: ");

    string codigo = Console.ReadLine();

    if (codigosValidos.Contains(codigo))
    {
        acceso = true;

        Console.WriteLine("\nCódigo correcto.");
        Console.WriteLine("Acceso concedido.");

        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\nCódigo incorrecto.");
        Console.WriteLine("Intente nuevamente.");

        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }
}

bool salir = false;

while (!salir)
{
    // Limpia la pantalla cada vez que regresamos al menú
    Console.Clear();

    Console.WriteLine("===== MENÚ =====");
    Console.WriteLine("1. Empleados");
    Console.WriteLine("2. Productos");
    Console.WriteLine("3. Tienda");
    Console.WriteLine("0. Salir");

    Console.Write("Seleccione una opción: ");
    string o = Console.ReadLine();



    if (o == "0")
    {
        salir = true;
        Console.WriteLine("\nSaliendo del programa...");
        break;
    }



    Console.WriteLine("\n¿Qué movimiento desea realizar?");
    Console.WriteLine("R. Registrar");
    Console.WriteLine("A. Actualizar");
    Console.WriteLine("E. Eliminar");
    Console.WriteLine("V. Ver lista");
    Console.WriteLine("B. Buscar");

    string m = Console.ReadLine().ToUpper();


    switch (o)
    {


        case "1":

            Console.WriteLine("\n===== EMPLEADOS =====");

            RepositorioEmpleados repoempleados =
                new RepositorioEmpleados();

            Empleado empleado = new Empleado();

            empleado.Nombre = "";
            empleado.Edad = 0;
            empleado.Salario = 0;
            empleado.ID = 0;

            List<Empleado> listaempleados =
                repoempleados.Lista();

            switch (m)
            {


                case "R":

                    Console.WriteLine("Ingrese el nombre del empleado:");
                    empleado.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese la edad del empleado:");
                    empleado.Edad =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el salario del empleado:");
                    empleado.Salario =
                        Convert.ToDouble(Console.ReadLine());

                    repoempleados.Registro(empleado);

                    break;




                case "A":

                    Console.WriteLine(
                        "Ingrese el ID del empleado a actualizar:"
                    );

                    empleado.ID =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo nombre del empleado:"
                    );

                    empleado.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese la nueva edad del empleado:"
                    );

                    empleado.Edad =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo salario del empleado:"
                    );

                    empleado.Salario =
                        Convert.ToDouble(Console.ReadLine());

                    repoempleados.Actualizar(empleado);

                    break;



                case "E":

                    Console.WriteLine(
                        "ID   |   Nombre   |   Edad   | Salario"
                    );

                    foreach (Empleado emp in listaempleados)
                    {
                        Console.WriteLine(
                            $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario}"
                        );
                    }

                    Console.WriteLine(
                        "Ingrese el ID del empleado a eliminar:"
                    );

                    empleado.ID =
                        Convert.ToInt32(Console.ReadLine());

                    repoempleados.Eliminar(empleado);

                    break;




                case "V":

                    Console.WriteLine(
                        "ID   |   Nombre   |   Edad   | Salario"
                    );

                    for (int i = 0;
                         i < listaempleados.Count;
                         i++)
                    {
                        Empleado emp = listaempleados[i];

                        Console.WriteLine(
                            $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario}"
                        );
                    }

                    break;




                case "B":

                    Console.WriteLine(
                        "Ingrese el nombre del empleado a buscar:"
                    );

                    string nombre =
                        Console.ReadLine();

                    List<Empleado> empleadosEncontrados =
                        repoempleados.Buscar(nombre);

                    Console.WriteLine(
                        "ID   |   Nombre   |   Edad   | Salario"
                    );

                    foreach (Empleado emp in empleadosEncontrados)
                    {
                        Console.WriteLine(
                            $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario}"
                        );
                    }

                    break;


                default:

                    Console.WriteLine(
                        "Opción de movimiento no válida."
                    );

                    break;
            }

            break;



        case "2":

            Console.WriteLine("\n===== PRODUCTOS =====");

            RepositorioProductos repoproductos =
                new RepositorioProductos();

            Producto producto = new Producto();

            producto.Nombre = "";
            producto.Precio = 0;
            producto.ID = 0;

            List<Producto> listaproductos =
                repoproductos.Lista();

        case "3":
            Console.WriteLine("\n===== TIENDA =====");
            Console.WriteLine("V. Vender");
            Console.WriteLine("H. Historial");
            string mt = Console.ReadLine();

            

            
            switch (mt)
            {

                case "V":
                    string p = "P";
                    Venta venta = new Venta();
                    venta.CodigoVenta = DateTime.Now.ToString("yyyyMMddss");
                    venta.Fecha = DateTime.Now;
                    venta.Empleado = usuario;
                    while (p == "P")
                    {
                        Producto infoProduct = repoproductos.GetById(codigoProducto);


                        venta.AgregarProducto(infoProduct, cantidad);


                        //agregar productos a la venta
                        Console.WriteLine("Ingrese codigo de producto:");
                        int codigoProducto = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese cantidad de productos:");
                        int cantidad = Convert.ToInt32(Console.ReadLine());
                        VentaProductos ProductoVendido = new VentaProductos();
                        venta.Productos.Add();
                        Console.WriteLine("Desea agregar otro producto o cobrar?");
                        Console.WriteLine("P. Agregar otro producto");
                        Console.WriteLine("C. Cobrar");
                        p = Console.ReadLine().ToUpper();
                        Console.Clear();


                      
                    }
                    Console.WriteLine("Cobrando...");
                    Console.WriteLine("producto------cantidad-------total");
                    foreach(Producto prod in venta.Productos)
                    {
                        Console.WriteLine($" {prod.producto.Nombre}        {prod.producto.Precio}   {prod.cantidad}")          {prod.total}");
                    }
                    Console.WriteLine($"Total: {venta.Total}");

                    //mostrar en pantalla detalles de la venta
                    /* producto------precio unitario------cantidad-------total
                     * Manzanas          23.00               2            46.00
                     * Queso            100.00               1           100.00
                     * Total---------------------------------------------146.00
                     */


                    break;
            }

            break;

            switch (m)
            {


                case "R":

                    Console.WriteLine(
                        "Ingrese el nombre del producto:"
                    );

                    producto.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese el precio del producto:"
                    );

                    producto.Precio =
                        Convert.ToDecimal(
                            Console.ReadLine()
                        );

                    repoproductos.Registro(producto);

                    break;



                case "A":

                    Console.WriteLine(
                        "Ingrese el ID del producto a actualizar:"
                    );

                    producto.ID =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo nombre del producto:"
                    );

                    producto.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese el nuevo precio del producto:"
                    );

                    producto.Precio =
                        Convert.ToDecimal(
                            Console.ReadLine()
                        );

                    repoproductos.Actualizar(producto);

                    break;




                case "E":

                    Console.WriteLine(
                        "ID   |   Nombre   |   Precio"
                    );

                    foreach (Producto prod in listaproductos)
                    {
                        Console.WriteLine(
                            $"{prod.ID} | {prod.Nombre} | ${prod.Precio}"
                        );
                    }

                    Console.WriteLine(
                        "Ingrese el ID del producto a eliminar:"
                    );

                    producto.ID =
                        Convert.ToInt32(Console.ReadLine());

                    repoproductos.Eliminar(producto);

                    break;



                case "V":

                    Console.WriteLine(
                        "ID   |   Nombre   |   Precio"
                    );

                    for (int i = 0;
                         i < listaproductos.Count;
                         i++)
                    {
                        Producto prod =
                            listaproductos[i];

                        Console.WriteLine(
                            $"{prod.ID} | {prod.Nombre} | ${prod.Precio}"
                        );
                    }

                    break;



                case "B":

                    Console.WriteLine(
                        "Ingrese el nombre del producto a buscar:"
                    );

                    string nombre =
                        Console.ReadLine();

                    List<Producto> productosEncontrados =
                        repoproductos.Buscar(nombre);

                    Console.WriteLine(
                        "ID   |   Nombre   |   Precio"
                    );

                    foreach (Producto prod in productosEncontrados)
                    {
                        Console.WriteLine(
                            $"{prod.ID} | {prod.Nombre} | ${prod.Precio}"
                        );
                    }

                    break;


                default:

                    Console.WriteLine(
                        "Opción de movimiento no válida."
                    );

                    break;
            }

            break;




        default:

            Console.WriteLine(
                "\nOpción no válida."
            );

            break;
    }




    Console.WriteLine(
        "\n================================"
    );

    Console.WriteLine(
        "Presiona ENTER para regresar al menú..."
    );

    Console.ReadLine();

   
}




