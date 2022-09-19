using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class StockCompletoException : Exception {   
        public StockCompletoException() : base("El stock esta completo") { }
        public StockCompletoException(string msg) : base(msg) { }
    }
}
