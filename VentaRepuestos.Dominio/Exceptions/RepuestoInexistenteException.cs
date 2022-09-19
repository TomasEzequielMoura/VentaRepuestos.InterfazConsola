using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class RepuestoInexistenteException : Exception{
        public RepuestoInexistenteException() : base("El repuesto que estas solicitando no existe") { }
        public RepuestoInexistenteException(string msg) : base(msg) { }
    }
}
