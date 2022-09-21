using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class StockNegativoException : Exception
    {
        public StockNegativoException() : base("Stock NO puede ser negativo") { }
        public StockNegativoException(string msg) : base(msg) { }
    }
}
