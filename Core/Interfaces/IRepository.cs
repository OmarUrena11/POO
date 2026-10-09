using Core.Clases;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        Response<T> Registro(T producto);

        Response<T> Actualizar(T producto);

        Response<T> Eliminar(T producto);

        Response<List<T>> Lista();

        Response<List<T>> Buscar(string nombre);

        Response<T> Buscar(int id);
    }
}
