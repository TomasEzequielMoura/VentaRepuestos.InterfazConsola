using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class ErrorAlHacerTareaException : Exception
    {
        public ErrorAlHacerTareaException() : base("Categoria no existe") { }
        public ErrorAlHacerTareaException(string msg) : base(msg) { }
    }
}
