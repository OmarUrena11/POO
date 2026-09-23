using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Interfaces
{
    internal interface IRepository<T>
    {
        public void Registro(T empleado);
        public void Actualizar(T empleado);
        public void Eliminar(T empleado);
        public List<T> Lista();
        public List<T> Buscar(string nombre);
    }
}
