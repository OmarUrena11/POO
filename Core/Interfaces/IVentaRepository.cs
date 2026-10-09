using Actividad_Clases.Clases;
using Core.Clases;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IVentaRepository
    {
        Response<Venta> Registrar(Venta venta);

        Response<string> ObtenerNumeroVentaDelDia();

        Response<List<Venta>> Lista();
    }
}
