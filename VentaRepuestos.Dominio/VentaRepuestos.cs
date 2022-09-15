using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio
{
    public class VentaRepuestos
    {
        public VentaRepuestos(List<Repuesto> listaProducto, string nombreComercio, string direccion)
        {
            _listaProducto= listaProducto;
            _nombreComercio = nombreComercio;
            _direccion = direccion;
        }

        private List<Repuesto> _listaProducto;
        private string _nombreComercio;
        private string _direccion;


        public List<Repuesto> listaProducto
        {
            get { return _listaProducto; }
            set { _listaProducto = value; }
        }

        public string NombreComercio
        {
            get { return _nombreComercio; }
            //set { _nombre = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            //set { _nombre = value; }
        }

        public void AgregarRepuesto(Repuesto value)
        {
        }
        public void QuitarRepuesto(int value)
        {
        }
        public void ModificarPrecio(int value, double value2)
        {
        }
        public void AgregarStock(int value, int value2)
        {
        }
        public void QuitarStock(int value, int value2)
        {
        }
        public List<Repuesto> TrearPorCategoria(int value)
        {
            var retList = new List<Repuesto>();
            return retList;
        }
    }
}
