using System;
using System.Collections.Generic;
using System.Text;

namespace POO
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Salario { get; set; }
        public int ID { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine("Información del empleado:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Salario: {Salario}");
        }

        static void Trabajar()
        {
            Console.WriteLine("El empleado está trabajando...");
        }
    }
}
  


