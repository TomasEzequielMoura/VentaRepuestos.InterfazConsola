using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio
{
    public class Categoria
    {
        public Categoria(int codigo, string nombre) {
            _codigo = codigo;
            _nombre = nombre;
        }

        private int _codigo;
        private string _nombre;

        public int Codigo
        {
            get { return _codigo; }
            //set { _nombre = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            //set { _nombre = value; }
        }

    }
}
