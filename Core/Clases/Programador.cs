using System;
using System.Collections.Generic;
using System.Text;


namespace Core
{
    public class Programador : Empleado
    {
        public string LenguajeProgramacion { get; set; }

        static void Programar()
        {
            Console.WriteLine("Esta programando...");
        }
    }
}
