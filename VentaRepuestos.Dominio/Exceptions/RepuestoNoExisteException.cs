using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class RepuestoNoExisteException : Exception
    {
        public RepuestoNoExisteException() : base("Repuesto ya existe, por favor, agregar stock.") { }
        public RepuestoNoExisteException(string msg) : base(msg) { }
    }
}
