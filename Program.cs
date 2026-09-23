using Actividad_Clases.Clases;
using POO;
using POO.Repositorios;
//Hicimos un menu para que el usuario pueda elegir entre empleados y productos, y luego elegir entre registrar, actualizar o eliminar.
Console.WriteLine("Menu:");
Console.WriteLine("1. Empleados");
Console.WriteLine("2. Productos");
string o = Console.ReadLine();
Console.WriteLine("Que movimiento desea realizar?");
Console.WriteLine("R. Registrar");
Console.WriteLine("A. Actualizar");
Console.WriteLine("E. Eliminar");
Console.WriteLine("V. Ver lista");
Console.WriteLine("B. Buscar Empleado");
string m = Console.ReadLine().ToUpper();


// Validar que la opcion sea correcta
switch (o)
{
    case "1":
        Console.WriteLine("Empleados");
        RepositorioEmpleados repoempleados = new RepositorioEmpleados();
        Empleado empleado = new Empleado();
        empleado.Nombre = "";
        empleado.Edad = 0;
        empleado.Salario = 0;
        empleado.ID = 0;
        List<Empleado> listaempleados = repoempleados.Lista();

        switch (m)
        {
            case "R":
                Console.WriteLine("Ingrese el nombre del empleado:");
                empleado.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la edad del empleado:");
                empleado.Edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el salario del empleado:");
                empleado.Salario = Convert.ToDouble(Console.ReadLine());
               //Console.WriteLine("Ingrese el ID del empleado:");
               //empleado.ID = Convert.ToInt32(Console.ReadLine());
                repoempleados.Registro(empleado);
                break;
            case "A":
                Console.WriteLine("Ingrese el ID del empleado a actualizar:");
                empleado.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                empleado.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la nueva edad del empleado:");
                empleado.Edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo salario del empleado:");
                empleado.Salario = Convert.ToDouble(Console.ReadLine());
                repoempleados.Actualizar(empleado);
                break;
            case "E":
                Console.WriteLine("ID   |   Nombre   |     Edad    | Salario");
                
                foreach (Empleado emp in listaempleados)
                {
                    
                    Console.WriteLine($"{emp.ID}  |  {emp.Nombre}  |  {emp.Edad}  |  ${emp.Salario}");
                }
                Console.WriteLine("Ingrese el ID del empleado a eliminar:");
                empleado.ID = Convert.ToInt32(Console.ReadLine());
                repoempleados.Eliminar(empleado);
                break;
            default:
                Console.WriteLine("Opcion no valida");
                break;
            case "V":
                Console.WriteLine("ID   |   Nombre   |     Edad    | Salario");
                for(int i = 0; i < listaempleados.Count; i++)
                {
                    Empleado emp = listaempleados[i]; 
                    Console.WriteLine($"{emp.ID}  |  {emp.Nombre}  |  {emp.Edad}  |  ${emp.Salario}");
                }
                break;
            case "B":
                Console.WriteLine("Ingrese el nombre del empleado a buscar:");
                string nombre = Console.ReadLine();
                List<Empleado> empleadosEncontrados = repoempleados.Buscar(nombre);
                Console.WriteLine("ID   |   Nombre   |     Edad    | Salario");
                foreach (Empleado emp in empleadosEncontrados)
                {
                    Console.WriteLine($"{emp.ID}  |  {emp.Nombre}  |  {emp.Edad}  |  ${emp.Salario}");
                }
                break;
        }
   
 

        break;
    case "2":
        Console.WriteLine("Productos");
        RepositorioProductos repoproductos = new RepositorioProductos();
        Producto producto = new Producto();
        producto.Nombre = "";
        producto.Precio = 0;
        producto.ID = 0;

        switch (m)
        { 
            case "R":
                Console.WriteLine("Ingrese el nombre del producto:");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del producto:");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingrese el ID del producto:");
                producto.ID = Convert.ToInt32(Console.ReadLine());
                repoproductos.Registro(producto); 
                break;
            
            case "A":
                Producto productoActualizar = new Producto();
                Console.WriteLine("Ingrese el ID del producto a actualizar:");
               
                productoActualizar.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo nombre del producto:");
                productoActualizar.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo precio del producto:");
                productoActualizar.Precio = Convert.ToDecimal(Console.ReadLine());
                repoproductos.Actualizar(productoActualizar);
                break;
            
            case "E":
               
                Producto productoEliminar = new Producto();
                productoEliminar.ID = 0;
                repoproductos.Eliminar(productoEliminar);
                break;

        }


        break;
    default:
        Console.WriteLine("Opcion no valida");
        break;


        //DateTime nacimiento = Convert.ToDateTime("1990-05-15");
        //Persona persona = new Persona("Juan", "Perez", "Gomez", nacimiento);

        //cuando se asigna un objeto a otro, se crea una referencia al mismo objeto en memoria
        //Persona persona2 = new Persona("Maria", "Lopez", "Martinez", Convert.ToDateTime("1995-08-20"));

        //Mostrar en pantalla los datos de la persona asignados
        //Console.WriteLine($"{persona.Nombre} {persona.ApellidoP} {persona.ApellidoM} tiene la edad de: {persona.Edad} años");

        //Console.WriteLine($"{persona2.Nombre} {persona2.ApellidoP} {persona2.ApellidoM} tiene la edad de: {persona2.Edad} años");



}




