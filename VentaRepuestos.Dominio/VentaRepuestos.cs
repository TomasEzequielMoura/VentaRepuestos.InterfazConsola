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
            //bool permitoAgregar = true;

            foreach (Repuesto r in _listaProducto)
            {
                _listaProducto.Add(repuesto);
            }

        }
        public void QuitarRepuesto(int codigo)
        {
            foreach (Repuesto r in _listaProducto)
            {
                if (r.Codigo == codigo) { _listaProducto.Remove(r);  }
            }
        }
        public void ModificarPrecio(int codigo, double nuevoPrecio)
        {
            try
            {
                foreach (Repuesto r in _listaProducto)
                {
                    if (r.Codigo == codigo) { r.Precio = nuevoPrecio; }
                }
            }
            catch (RepuestoInexistenteException ex)
            {
                Console.WriteLine("ERROR. El repuesto no existe");
                throw;
            }
        }
        public void AgregarStock(int codigo, int stockAgregado)
        {
            int stock = 0;
            if (stock < 100)
            {
                foreach (Repuesto r in _listaProducto)
                {
                    if (r.Codigo == codigo) { r.Stock = r.Stock + stockAgregado; }
                }
            }
            else
            {
                throw new StockCompletoException();
            }
        }
        public void QuitarStock(int codigo, int stockQuitado)
        {
            foreach (Repuesto r in _listaProducto)
            {
                if (r.Codigo == codigo) { r.Stock = r.Stock - stockQuitado; }
            }
        }
        public List<Repuesto> TrearPorCategoria(int value)
        {
            //foreach (Contacto c in agenda.Contactos)
            //{
            //    Console.WriteLine($"{c.Nombre} - {c.Telefono}");
            //}

            //for (int i = 0; value > Categoria.Length; i++)
            //{
            //    Console.WriteLine($"{c.Nombre} - {c.Telefono}");
            //}

            var retList = new List<Repuesto>();
            return retList;
        }
    }
}
