using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Dominio
{
    public class Repuesto
    {
        // constructor
        public Repuesto(int codigo, string nombre, double precio, int stock, Categoria categoria)
        {
            _codigo = codigo;
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
            _categoria = categoria;
        }

        // variables
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;

        // propiedades
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

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public Categoria Categoria
        {
            get { return _categoria; }
            //set { _nombre = value; }
        }

        // metodos
        public override string ToString()
        {
            return $"{Codigo} - {Nombre} - {Precio} - {Stock} - {Categoria.Nombre}";
        }
    }
}
