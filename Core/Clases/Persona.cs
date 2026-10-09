using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_Clases.Clases
{
    public class Persona
    {
        public string Nombre { get; set; } //si no tiene set, no se puede modificar el valor de la propiedad desde fuera de la clase
        public int Edad { get; set; } //si no tiene get, no se puede obtener el valor de la propiedad desde fuera de la clase
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Constructor de la clase Persona
        public Persona(string nombre, string apellidoP, string apellidoM, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Edad = CalcularEdad(fechaNacimiento);
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
        }

        //Metodo para calcular la edad de la persona
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;

            int edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }

    }
}
