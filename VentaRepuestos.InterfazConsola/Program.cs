using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using VentaRepuestos.Dominio;
using VentaRepuestos.Dominio.Exceptions;
//using VentaRepuestos.Dominio.Entidades;


namespace VentaRepuestos.InterfazConsola
{
    class Program
    {
        public static Dominio.VentaRepuestos InstanciaAgregarRepuesto;
        public static List<Categoria> ListaCategorias;

        static void Main(string[] args)
        {
            //List<Categoria> ListaCategorias = new List<Categoria>();
            List<Repuesto> ListaProductos = new List<Repuesto>();

            InstanciaAgregarRepuesto = new Dominio.VentaRepuestos(ListaProductos, "Audi", "San Martin 1");
            ListaCategorias = new List<Categoria>();

            Categoria generales = new Categoria(0001, "Repuestos Generales");
            Categoria autos = new Categoria(0002, "Repuestos autos");
            Categoria motos = new Categoria(0003, "Repuestos motos");
            Categoria triciclos = new Categoria(0004, "Repuestos triciclos");
            Categoria monopatin = new Categoria(0005, "Repuestos monopatin");

            ListaCategorias.Add(generales);
            ListaCategorias.Add(autos);
            ListaCategorias.Add(motos);
            ListaCategorias.Add(triciclos);
            ListaCategorias.Add(monopatin);

            Repuesto kitDistribucion = new Repuesto(20001, "Kit de Distibucion", 19901, 205, autos);
            Repuesto bombaAceite = new Repuesto(20002, "Bomba De Aceite", 13200, 190, autos);
            Repuesto bateriaBosch = new Repuesto(30001, "Bateria 12n5-3b", 5300, 10, motos);
            Repuesto conjuntoCambio = new Repuesto(40001, "Conjunto Cambio", 16036, 50, triciclos);
            Repuesto motorCurrus = new Repuesto(50001, "Motor Currus Panther", 65000, 5, monopatin);

            string tareaARealizar;
            bool flag = false;

            DesplegarBienvenida();

            try
            {
                do
                {
                    DesplegarOpcionesMenu();
                    tareaARealizar = Console.ReadLine();
                    //DesplegarOpcionesMenu();
                    //Categoria categoria = new Categoria(0001, "Repuestos Generales");
                    //Repuesto repuesto = new Repuesto(010101, "Tuerca", 550.15, 823, categoria);

                    switch (tareaARealizar.ToUpper())
                    {
                        case "1":
                            AgregarRepuesto();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            break;
                        case "2":
                            QuitarRepuesto();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            // code block
                            break;
                        case "3":
                            ModificarPrecio();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            // code block
                            break;
                        case "4":
                            AgregarStock();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            // code block
                            break;
                        case "5":
                            QuitarStock();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            // code block
                            break;
                        case "6":
                            TrearPorCategoria();
                            Console.Write("\r\n¡Tarea Exitosa!\r\n\r\n");
                            // code block
                            break;
                        case "X":
                            Console.Write("Fin del programa. Saludos!");
                            Thread.Sleep(2500);
                            // code block
                            break;
                        default:
                            // code block
                            Console.Write("\r\nERROR. Ingresaste un valor que no existe \r\n");
                            flag = true;
                            break;
                    }     
                } while (tareaARealizar.ToUpper() != "X");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general");
                //throw;
            }
        }

        public static void DesplegarBienvenida()
        {
            Console.Write("Bienvenido al Sistema de VentaRepuestos \r\n");
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.Write("Para continuar, presione un boton: \r\n");
            Console.Write("1. Agregar Repuesto \r\n2. Quitar Repuesto \r\n3. Modificar Precio \r\n4. Agregar Stock \r\n5. Quitar Stock \r\n6. Traer Por Categoria \r\nX. Para salir \r\n");
        }

        public static void AgregarRepuesto() {
            string codigo = IngresarNumero("int", "el numero del codigo del repuesto a agregar");
            Console.Write("Ingresar nombre del repuesto:\r\n");
            string nombre = Console.ReadLine();
            string precio = IngresarNumero("double", "el precio del repuesto a agregar");
            string stock = IngresarNumero("int", "el stock del repuesto a agregar");

            string codigoCategoria = IngresarNumero("int", "el numero del codigo del repuesto a agregar");

            try
            {
                Categoria categoriaElegida = getCategoriaByCode(Convert.ToInt32(codigoCategoria));
                Repuesto repuestoAgregado = new Repuesto(Convert.ToInt32(codigo), nombre, Convert.ToInt32(precio), Convert.ToInt32(stock), categoriaElegida);
                InstanciaAgregarRepuesto.AgregarRepuesto(repuestoAgregado);
            }
            catch (CategoriaInexistenteException ex)
            {
                Console.WriteLine("ERROR. Categoria Inexistente");
            }
        }

        private static Categoria getCategoriaByCode(int codigoCategoria)
        {
            Categoria categoriaElegida = null;

            foreach (Categoria c in ListaCategorias)
            {
                if (c.Codigo == codigoCategoria) { categoriaElegida = c; }
            }
            if (categoriaElegida == null) { throw new CategoriaInexistenteException(); }

            return categoriaElegida;
        }

        public static void QuitarRepuesto() {

            string codigo = IngresarNumero("int", "el numero del codigo del repuesto a quitar");
            List<Repuesto> ListaRepuestos = new List<Repuesto>();

            Dominio.VentaRepuestos InstanciaQuitarRepuestos = new Dominio.VentaRepuestos(ListaRepuestos, "asd", "asd");

            InstanciaQuitarRepuestos.QuitarRepuesto(Convert.ToInt32(codigo));
        }

        public static void ModificarPrecio() {
            string codigo = IngresarNumero("int", "el numero del codigo del repuesto");
            string nuevoPrecio = IngresarNumero("double", "el nuevo precio");
            List<Repuesto> ListaRepuestos = new List<Repuesto>();

            Dominio.VentaRepuestos InstanciaModificarPrecio = new Dominio.VentaRepuestos(ListaRepuestos, "asd", "asd");

            InstanciaModificarPrecio.ModificarPrecio(Convert.ToInt32(codigo), Convert.ToDouble(nuevoPrecio));
        }

        public static void AgregarStock() {
            string codigo = IngresarNumero("int", "el numero del codigo del repuesto");
            string cantidad = IngresarNumero("int", "la cantidad agregada");
            List<Repuesto> ListaRepuestos = new List<Repuesto>();

            Dominio.VentaRepuestos InstanciaAgregarStock = new Dominio.VentaRepuestos(ListaRepuestos, "asd", "asd");
            try
            {
                InstanciaAgregarStock.AgregarStock(Convert.ToInt32(codigo), Convert.ToInt32(cantidad));
            }
            catch (StockCompletoException ex)
            {
                Console.WriteLine("ERROR. Stock completo");
            }
        }

        public static void QuitarStock() {
            string codigo = IngresarNumero("int", "el numero del codigo del repuesto");
            string cantidad = IngresarNumero("int", "la cantidad quitada");
            List<Repuesto> ListaRepuestos = new List<Repuesto>();

            Dominio.VentaRepuestos InstanciaQuitarStock = new Dominio.VentaRepuestos(ListaRepuestos, "asd", "asd");

            InstanciaQuitarStock.QuitarStock(Convert.ToInt32(codigo), Convert.ToInt32(cantidad));
        }

        public static void TrearPorCategoria() {
            string codigoCategoria = IngresarNumero("int", "el numero del codigo de la categoria");
            List<Repuesto> ListaRepuestos = new List<Repuesto>();

            Dominio.VentaRepuestos InstanciaTrearPorCategoria = new Dominio.VentaRepuestos(ListaRepuestos, "asd", "asd");

            InstanciaTrearPorCategoria.TrearPorCategoria(Convert.ToInt32(codigoCategoria));
        }

        public static string IngresarNumero(string tipo, string input) {
            string codigo;
            int salidaCodigoInt = 0;
            double salidaCodigoDouble = 0;
            bool flag;

            do
            {
                Console.WriteLine($"Ingrese {input}");
                codigo = Console.ReadLine();
                if (tipo == "int") flag = ValidarEntero(codigo, ref salidaCodigoInt);
                else if (tipo == "double") flag = ValidarDouble(codigo, ref salidaCodigoDouble);
                else flag = true;
            } while (flag == false);

            return codigo;
        }

        public static bool ValidarEntero(string numero, ref int salida){
            bool flag = false;

            if (!int.TryParse(numero, out salida))
            {
                Console.WriteLine("Usted debe ingresar un número entero.");
            }
            else if (salida <= 0)
            {
                Console.WriteLine("Usted debe ingresar un número mayor que cero.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        private static bool ValidarDouble(string registro, ref double salida)
        {
            bool flag = false;

            if (!double.TryParse(registro, out salida))
            {
                Console.WriteLine("Usted debe ingresar un valor numérico.");
            }
            else if (salida <= 0)
            {
                Console.WriteLine("Usted debe ingresar un numero positivo.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }


    }
}
