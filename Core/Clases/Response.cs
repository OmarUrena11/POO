using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Clases
{
    public class Response<T>
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }
    }
}
