using Actividad_Clases.Clases;
using POO;
using POO.Repositorios;


//codigos de acceso válidos


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
int idEmpleadoSesion = 0;

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


//menu principal

bool salir = false;

while (!salir)
{
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




    switch (o)
    {

        //Case 1 Empleados

        case "1":
            {
                Console.Clear();

                Console.WriteLine("\n===== EMPLEADOS =====");

                RepositorioEmpleados repoempleados =
                    new RepositorioEmpleados();

                Empleado empleado =
                    new Empleado();

                empleado.Nombre = "";
                empleado.Edad = 0;
                empleado.Salario = 0;
                empleado.ID = 0;

                List<Empleado> listaempleados =
                    repoempleados.Lista();


                Console.WriteLine("\n¿Qué movimiento desea realizar?");
                Console.WriteLine("R. Registrar");
                Console.WriteLine("A. Actualizar");
                Console.WriteLine("E. Eliminar");
                Console.WriteLine("V. Ver lista");
                Console.WriteLine("B. Buscar");

                string m =
                    Console.ReadLine().ToUpper();


                switch (m)
                {
                    //Registrar empleado

                    case "R":

                        Console.WriteLine(
                            "\n===== REGISTRAR EMPLEADO =====");

                        Console.WriteLine(
                            "Ingrese el nombre del empleado:");

                        empleado.Nombre =
                            Console.ReadLine();

                        Console.WriteLine(
                            "Ingrese la edad del empleado:");

                        empleado.Edad =
                            Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(
                            "Ingrese el salario del empleado:");

                        empleado.Salario =
                            Convert.ToDouble(Console.ReadLine());

                        repoempleados.Registro(empleado);

                        break;


                    //Actualizar empleado

                    case "A":

                        Console.WriteLine(
                            "\n===== ACTUALIZAR EMPLEADO =====");

                        Console.WriteLine(
                            "Ingrese el ID del empleado a actualizar:");

                        empleado.ID =
                            Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(
                            "Ingrese el nuevo nombre del empleado:");

                        empleado.Nombre =
                            Console.ReadLine();

                        Console.WriteLine(
                            "Ingrese la nueva edad del empleado:");

                        empleado.Edad =
                            Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(
                            "Ingrese el nuevo salario del empleado:");

                        empleado.Salario =
                            Convert.ToDouble(Console.ReadLine());

                        repoempleados.Actualizar(empleado);

                        break;


                    // Eliminar empleado

                    case "E":

                        Console.WriteLine(
                            "\n===== ELIMINAR EMPLEADO =====");

                        Console.WriteLine(
                            "ID   |   Nombre   |   Edad   | Salario");

                        Console.WriteLine(
                            "-----------------------------------------");

                        foreach (Empleado emp in listaempleados)
                        {
                            Console.WriteLine(
                                $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario:F2}");
                        }

                        Console.WriteLine();

                        Console.WriteLine(
                            "Ingrese el ID del empleado a eliminar:");

                        empleado.ID =
                            Convert.ToInt32(Console.ReadLine());

                        repoempleados.Eliminar(empleado);

                        break;


                    //Ver empleados

                    case "V":

                        Console.WriteLine(
                            "\n===== LISTA DE EMPLEADOS =====");

                        Console.WriteLine();

                        Console.WriteLine(
                            "ID   |   Nombre   |   Edad   | Salario");

                        Console.WriteLine(
                            "-----------------------------------------");

                        for (int i = 0;
                             i < listaempleados.Count;
                             i++)
                        {
                            Empleado emp =
                                listaempleados[i];

                            Console.WriteLine(
                                $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario:F2}");
                        }

                        break;


                    // BUscar empleado

                    case "B":

                        Console.WriteLine(
                            "\n===== BUSCAR EMPLEADO =====");

                        Console.WriteLine(
                            "Ingrese el nombre del empleado a buscar:");

                        string nombreEmpleado =
                            Console.ReadLine();

                        List<Empleado> empleadosEncontrados =
                            repoempleados.Buscar(nombreEmpleado);

                        Console.WriteLine();

                        Console.WriteLine(
                            "ID   |   Nombre   |   Edad   | Salario");

                        Console.WriteLine(
                            "-----------------------------------------");

                        foreach (Empleado emp in empleadosEncontrados)
                        {
                            Console.WriteLine(
                                $"{emp.ID} | {emp.Nombre} | {emp.Edad} | ${emp.Salario:F2}");
                        }

                        break;


                    default:

                        Console.WriteLine(
                            "\nOpción de movimiento no válida.");

                        break;
                }

                break;
            }


        //Case 2 Productos

        case "2":
            {
                Console.Clear();

                Console.WriteLine("\n===== PRODUCTOS =====");

                RepositorioProductos repoproductos =
                    new RepositorioProductos();

                Producto producto =
                    new Producto();

                producto.Nombre = "";
                producto.Precio = 0;
                producto.ID = 0;

                List<Producto> listaproductos =
                    repoproductos.Lista();


                Console.WriteLine("\n¿Qué movimiento desea realizar?");
                Console.WriteLine("R. Registrar");
                Console.WriteLine("A. Actualizar");
                Console.WriteLine("E. Eliminar");
                Console.WriteLine("V. Ver lista");
                Console.WriteLine("B. Buscar");

                string mProducto =
                    Console.ReadLine().ToUpper();


                switch (mProducto)
                {

                    //Registrar producto

                    case "R":

                        Console.WriteLine(
                            "\n===== REGISTRAR PRODUCTO =====");

                        Console.Write(
                            "Ingrese el nombre del producto: ");

                        producto.Nombre =
                            Console.ReadLine();

                        Console.Write(
                            "Ingrese el precio del producto: ");

                        producto.Precio =
                            Convert.ToDecimal(
                                Console.ReadLine());

                        repoproductos.Registro(producto);

                        break;


                    //Actualizar producto

                    case "A":

                        Console.WriteLine(
                            "\n===== ACTUALIZAR PRODUCTO =====");

                        Console.Write(
                            "Ingrese el ID del producto: ");

                        producto.ID =
                            Convert.ToInt32(
                                Console.ReadLine());

                        Console.Write(
                            "Ingrese el nuevo nombre: ");

                        producto.Nombre =
                            Console.ReadLine();

                        Console.Write(
                            "Ingrese el nuevo precio: ");

                        producto.Precio =
                            Convert.ToDecimal(
                                Console.ReadLine());

                        repoproductos.Actualizar(producto);

                        break;


                    //Eliminar producto

                    case "E":

                        Console.WriteLine(
                            "\n===== ELIMINAR PRODUCTO =====");

                        Console.WriteLine();

                        Console.WriteLine(
                            "ID   |   Nombre   |   Precio");

                        Console.WriteLine(
                            "--------------------------------");

                        foreach (Producto prod in listaproductos)
                        {
                            Console.WriteLine(
                                $"{prod.ID} | {prod.Nombre} | ${prod.Precio:F2}");
                        }

                        Console.WriteLine();

                        Console.Write(
                            "Ingrese el ID del producto a eliminar: ");

                        producto.ID =
                            Convert.ToInt32(
                                Console.ReadLine());

                        repoproductos.Eliminar(producto);

                        break;


                    //Ver lista de productos

                    case "V":

                        Console.WriteLine(
                            "\n===== LISTA DE PRODUCTOS =====");

                        Console.WriteLine();

                        Console.WriteLine(
                            "ID   |   Nombre   |   Precio");

                        Console.WriteLine(
                            "--------------------------------");

                        for (int i = 0;
                             i < listaproductos.Count;
                             i++)
                        {
                            Producto prod =
                                listaproductos[i];

                            Console.WriteLine(
                                $"{prod.ID} | {prod.Nombre} | ${prod.Precio:F2}");
                        }

                        break;


                    //Buscar producto

                    case "B":

                        Console.WriteLine(
                            "\n===== BUSCAR PRODUCTO =====");

                        Console.Write(
                            "Ingrese el nombre del producto a buscar: ");

                        string nombreProducto =
                            Console.ReadLine();

                        List<Producto> productosEncontrados =
                            repoproductos.Buscar(nombreProducto);

                        Console.WriteLine();

                        Console.WriteLine(
                            "ID   |   Nombre   |   Precio");

                        Console.WriteLine(
                            "--------------------------------");

                        foreach (Producto prod in productosEncontrados)
                        {
                            Console.WriteLine(
                                $"{prod.ID} | {prod.Nombre} | ${prod.Precio:F2}");
                        }

                        break;


                    default:

                        Console.WriteLine(
                            "\nOpción de movimiento no válida.");

                        break;
                }

                break;
            }


        //Case 3 Tienda

        case "3":
            {
                Console.Clear();

                Console.WriteLine("\n===== TIENDA =====");

                Console.WriteLine("V. Vender");
                Console.WriteLine("H. Historial");

                Console.Write("\nSeleccione una opción: ");

                string mt =
                    Console.ReadLine().ToUpper();


                switch (mt)
                {

                    //Vender productos

                    case "V":
                        {
                            RepositorioProductos repoproductos =
                                new RepositorioProductos();

                            string p = "P";

                            Venta venta =
                                new Venta();

                            // Generar automáticamente el código de venta
                            venta.CodigoVenta =
                                DateTime.Now.ToString("yyyyMMddHHmmss");

                            // Guardar fecha y hora
                            venta.Fecha =
                                DateTime.Now;


                            while (p == "P")
                            {
                                Console.Clear();

                                Console.WriteLine(
                                    "===== AGREGAR PRODUCTO =====");

                                Console.WriteLine();

                                Console.Write(
                                    "Ingrese código de producto: ");

                                int codigoProducto =
                                    Convert.ToInt32(
                                        Console.ReadLine());

                                Console.Write(
                                    "Ingrese cantidad: ");

                                int cantidad =
                                    Convert.ToInt32(
                                        Console.ReadLine());


                                // Buscar producto
                                Producto infoProduct =
                                    repoproductos.Buscar(
                                        codigoProducto);


                                if (infoProduct == null)
                                {
                                    Console.WriteLine(
                                        "\nProducto no encontrado.");

                                    Console.WriteLine(
                                        "\nPresiona ENTER para continuar...");

                                    Console.ReadLine();

                                    continue;
                                }


                                // Agregar producto a la venta
                                venta.AgregarProducto(
                                    infoProduct,
                                    cantidad);


                                Console.WriteLine();

                                Console.WriteLine(
                                    "Producto agregado correctamente.");

                                Console.WriteLine(
                                    $"Producto: {infoProduct.Nombre}");

                                Console.WriteLine(
                                    $"Precio: ${infoProduct.Precio:F2}");

                                Console.WriteLine(
                                    $"Cantidad: {cantidad}");

                                Console.WriteLine(
                                    $"Importe: ${(infoProduct.Precio * cantidad):F2}");


                                Console.WriteLine();

                                Console.WriteLine(
                                    "P. Agregar otro producto");

                                Console.WriteLine(
                                    "C. Cobrar");

                                Console.Write(
                                    "\nSeleccione una opción: ");

                                p =
                                    Console.ReadLine().ToUpper();
                            }



                            Console.Clear();

                            Console.WriteLine(
                                "==========================================");

                            Console.WriteLine(
                                "              TICKET DE VENTA");

                            Console.WriteLine(
                                "==========================================");

                            Console.WriteLine(
                                $"Código de venta: {venta.CodigoVenta}");

                            Console.WriteLine(
                                $"Fecha: {venta.Fecha}");

                            Console.WriteLine(
                                "------------------------------------------");

                            Console.WriteLine(
                                "{0,-18} {1,8} {2,6} {3,10}",
                                "Producto",
                                "Precio",
                                "Cant.",
                                "Total");

                            Console.WriteLine(
                                "------------------------------------------");


                            foreach (
                                VentaProductos vendido
                                in venta.Productos)
                            {
                                Console.WriteLine(
                                    "{0,-18} ${1,7:F2} {2,6} ${3,9:F2}",
                                    vendido.producto.Nombre,
                                    vendido.producto.Precio,
                                    vendido.cantidad,
                                    vendido.total);
                            }


                            Console.WriteLine(
                                "------------------------------------------");

                            Console.WriteLine(
                                $"TOTAL: ${venta.Total:F2}");

                            Console.WriteLine(
                                "==========================================");

                            Console.WriteLine(
                                "        ¡GRACIAS POR SU COMPRA!");

                            Console.WriteLine(
                                "==========================================");

                            break;
                        }



                    default:

                        Console.WriteLine(
                            "\nOpción no válida.");

                        break;
                }

                break;
            }



        default:

            Console.WriteLine(
                "\nOpción no válida.");

            break;
    }




    Console.WriteLine(
        "\n================================");

    Console.WriteLine(
        "Presiona ENTER para regresar al menú...");

    Console.ReadLine();
}




