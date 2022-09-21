using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class RepuestoYaExisteException : Exception
    {
        public RepuestoYaExisteException() : base("Repuesto ya existe, por favor, agregar stock.") { }
        public RepuestoYaExisteException(string msg) : base(msg) { }
    }
}
