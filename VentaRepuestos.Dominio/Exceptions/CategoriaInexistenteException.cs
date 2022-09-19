using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio.Exceptions
{
    public class CategoriaInexistenteException : Exception
    {
        public CategoriaInexistenteException() : base("Categoria no existe") { }
        public CategoriaInexistenteException(string msg) : base(msg) { }
    }
}
