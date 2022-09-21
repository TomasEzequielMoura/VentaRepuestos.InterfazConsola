using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaRepuestos.Dominio.Exceptions;

namespace VentaRepuestos.Dominio
{
    public class VentaRepuestos
    {
        public VentaRepuestos(List<Repuesto> listaProducto, string nombreComercio, string direccion)
        {
            _listaProducto = listaProducto;
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

        public void AgregarRepuesto(Repuesto repuesto)
        {
            _listaProducto.Add(repuesto);

        }
        public void QuitarRepuesto(int codigo)
        {
            foreach (Repuesto r in _listaProducto.ToList())
            {
                if (r.Codigo == codigo) { _listaProducto.Remove(r);  }
            }
        }
        public void ModificarPrecio(int codigo, double nuevoPrecio)
        {
            foreach (Repuesto r in _listaProducto)
            {
                if (r.Codigo == codigo) { r.Precio = nuevoPrecio; }
            }

        }
        public void AgregarStock(int codigo, int stockAgregado)
        {
            // Politica del local, solamente se puede tener 100 productos de stock por producto
            foreach (Repuesto r in _listaProducto)
            {
                if (r.Codigo == codigo)
                {
                    if (r.Stock + stockAgregado <= 100)
                    {
                        r.Stock = r.Stock + stockAgregado;
                    }
                    else
                    {
                        throw new StockCompletoException();
                    }
                }
            }
        }

        public void QuitarStock(int codigo, int stockQuitado)
        {
            foreach (Repuesto r in _listaProducto)
            {
                if (r.Codigo == codigo) { 
                    r.Stock = r.Stock - stockQuitado; 
                    if (r.Stock < 0) throw new StockNegativoException();
                }

            }
        }
        public List<Repuesto> TrearPorCategoria(int value)
        {
            List<Repuesto> listPorCodigoCategoria = new List<Repuesto>();

            foreach (Repuesto r in _listaProducto)
            {
                if (r.Categoria.Codigo == value)
                {
                    listPorCodigoCategoria.Add(r);
                }
            }

            return listPorCodigoCategoria;
        }
    }
}
