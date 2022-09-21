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
        public static Dominio.VentaRepuestos InstanciaVentaRepuestos;
        public static List<Categoria> ListaCategorias;
        public static List<Repuesto> ListaRepuestos;
        public static List<Repuesto> listPorCodigoCategoria;

        static void Main(string[] args)
        {
            //List<Categoria> ListaCategorias = new List<Categoria>();
            ListaRepuestos = new List<Repuesto>();

            InstanciaVentaRepuestos = new Dominio.VentaRepuestos(ListaRepuestos, "Tienda Tomas", "Av. Córdoba 2122, C1113 CABA");

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

            Repuesto kitDistribucion = new Repuesto(20001, "Kit de Distibucion", 19901, 20, autos);
            Repuesto bombaAceite = new Repuesto(20002, "Bomba De Aceite", 13200, 19, autos);
            Repuesto bateriaBosch = new Repuesto(30001, "Bateria 12n5-3b", 5300, 10, motos);
            Repuesto conjuntoCambio = new Repuesto(40001, "Conjunto Cambio", 16036, 50, triciclos);
            Repuesto motorCurrus = new Repuesto(50001, "Motor Currus Panther", 65000, 5, monopatin);

            ListaRepuestos.Add(kitDistribucion);
            ListaRepuestos.Add(bombaAceite);
            ListaRepuestos.Add(bateriaBosch);
            ListaRepuestos.Add(conjuntoCambio);
            ListaRepuestos.Add(motorCurrus);

            DesplegarBienvenida();

            string tareaARealizar = "";

            do
            {
                try
                {
                    bool flag = false;

                    DesplegarOpcionesMenu();
                    tareaARealizar = Console.ReadLine();

                    switch (tareaARealizar.ToUpper())
                    {
                        case "1":
                            AgregarRepuesto();
                            break;
                        case "2":
                            QuitarRepuesto();
                            break;
                        case "3":
                            ModificarPrecio();
                            break;
                        case "4":
                            AgregarStock();
                            break;
                        case "5":
                            QuitarStock();
                            break;
                        case "6":
                            TrearPorCategoria();
                            break;
                        case "X":
                            Console.Write("Fin del programa. Saludos!");
                            Thread.Sleep(2500);
                            break;
                        default:
                            Console.Write("\r\nERROR. Ingresaste un valor que no existe \r\n");
                            flag = true;
                            break;
                    }     
                }
                catch (ErrorAlHacerTareaException ex) {
                    Console.WriteLine("Volver a empezar");
                }
            } while (tareaARealizar.ToUpper() != "X");
        }

        public static void DesplegarBienvenida()
        {
            Console.Write("Bienvenido al Sistema de VentaRepuestos \r\n");
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.Write("\r\nPara continuar, presione el boton correspondiente y precione Enter: \r\n");
            Console.Write("1. Agregar Repuesto \r\n2. Quitar Repuesto \r\n3. Modificar Precio \r\n4. Agregar Stock \r\n5. Quitar Stock \r\n6. Traer Por Categoria \r\nX. Para salir \r\n");
        }

        public static void AgregarRepuesto() {
            int codigo = IngresarNumero<int>("el numero del codigo del repuesto a agregar");

            try
            {
                validarNoExistenciaRepuestosByCode(codigo);
            }
            catch (RepuestoYaExisteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Repuesto ya existente. Si quiere agregar stock presione 4 en las opciones principales");
                throw new ErrorAlHacerTareaException();
            }

            Console.Write("Ingresar nombre del repuesto:\r\n");
            string nombre = Console.ReadLine();

            double precio = IngresarNumero<double>("el precio del repuesto a agregar");

            int stock = IngresarNumero<int>("el stock del repuesto a agregar");
            try
            {
                ValidarStock(stock);
            }
            catch (StockCompletoException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Stock Sobrepasado.");
                throw new ErrorAlHacerTareaException();
            }

            int codigoCategoria = IngresarNumero<int>("el numero del codigo de la categoria del repuesto a agregar");

            try
            {
                Categoria categoriaElegida = getCategoriaByCode(codigoCategoria);

                Repuesto repuestoAAgregar = new Repuesto(codigo, nombre, precio, stock, categoriaElegida);

                InstanciaVentaRepuestos.AgregarRepuesto(repuestoAAgregar);

                Console.WriteLine($"\r\n\r\n¡Tarea Exitosa! Repuesto Agregado: {repuestoAAgregar.Codigo}  - {repuestoAAgregar.Nombre} - $ {repuestoAAgregar.Precio} - {repuestoAAgregar.Stock} - {repuestoAAgregar.Categoria.Nombre}\r\n\r\n");

            }
            catch (CategoriaInexistenteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Categoria Inexistente. Solo puede ingresar repuestos a categorias existentes");
                throw new ErrorAlHacerTareaException();
            }
        }

        public static void QuitarRepuesto() {

            int codigo = IngresarNumero<int>("el numero del codigo del repuesto a quitar");

            try
            {
                validarExistenciaRepuestosByCode(codigo);
            }
            catch (RepuestoNoExisteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Repuesto no existente. Si quiere quitar un repuesto, debe existir el repuesto");
                throw new ErrorAlHacerTareaException();
            }

            Repuesto repuestoAQuitar = getRepuestosByCode(codigo);

            InstanciaVentaRepuestos.QuitarRepuesto(codigo);

            Console.WriteLine($"\r\n\r\n¡Tarea Exitosa! Repuesto Quitado: {repuestoAQuitar.Codigo}  - {repuestoAQuitar.Nombre} - {repuestoAQuitar.Precio} - {repuestoAQuitar.Stock} - {repuestoAQuitar.Categoria.Nombre}\r\n\r\n");
        }

        public static void ModificarPrecio() {
            int codigo = IngresarNumero<int>("el numero del codigo del repuesto");

            try
            {
                validarExistenciaRepuestosByCode(codigo);
            }
            catch (RepuestoNoExisteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Repuesto no existente. Si quiere modificar el precio de un repuesto, debe existir el repuesto");
                throw new ErrorAlHacerTareaException();
            }

            double nuevoPrecio = IngresarNumero<double>("el nuevo precio");

            Repuesto repuestoAModificar = getRepuestosByCode(codigo);

            InstanciaVentaRepuestos.ModificarPrecio(codigo, nuevoPrecio);

            Console.WriteLine($"\r\n\r\n¡Tarea Exitosa!\r\n\r\nPrecio viejo:{repuestoAModificar.Precio} \r\nPrecio Nuevo: {nuevoPrecio} \r\n\r\nProducto modificado: {repuestoAModificar.Codigo}  - {repuestoAModificar.Nombre} - {nuevoPrecio} - {repuestoAModificar.Stock} - {repuestoAModificar.Categoria.Nombre}\r\n\r\n");
        }

        public static void AgregarStock() {
            int codigo = IngresarNumero<int>("el numero del codigo del repuesto");

            try
            {
                validarExistenciaRepuestosByCode(codigo);
            }
            catch (RepuestoNoExisteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Repuesto no existente. Si quiere agregar stock, debe existir el repuesto");
                throw new ErrorAlHacerTareaException();
            }

            int cantidad = IngresarNumero<int>("la cantidad agregada");

            try
            {
                Repuesto repuestoAModificar = getRepuestosByCode(codigo);

                InstanciaVentaRepuestos.AgregarStock(codigo, cantidad);

                Console.WriteLine($"\r\n\r\n¡Tarea Exitosa!\r\n\r\nStock viejo: {repuestoAModificar.Stock - cantidad} \r\nStock nuevo: {repuestoAModificar.Stock } \r\n\r\nProducto modificado: {repuestoAModificar.Codigo}  - {repuestoAModificar.Nombre} - {repuestoAModificar.Precio} - {repuestoAModificar.Stock} - {repuestoAModificar.Categoria.Nombre}\r\n\r\n");
            }
            catch (StockCompletoException ex)
            {
                Console.WriteLine("ERROR. Stock completo");
                throw new ErrorAlHacerTareaException();
            }
        }

        public static void QuitarStock() {
            int codigo = IngresarNumero<int>("el numero del codigo del repuesto");

            try
            {
                validarExistenciaRepuestosByCode(codigo);
            }
            catch (RepuestoNoExisteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Repuesto no existente. Si quiere agregar stock, debe existir el repuesto");
                throw new ErrorAlHacerTareaException();
            }

            int cantidad = IngresarNumero<int>("la cantidad quitada");

            try
            {
                Repuesto repuestoAModificar = getRepuestosByCode(codigo);

                InstanciaVentaRepuestos.QuitarStock(codigo, cantidad);

                Console.WriteLine($"\r\n\r\n¡Tarea Exitosa!\r\n\r\nStock viejo: {repuestoAModificar.Stock + cantidad} \r\nStock nuevo: {repuestoAModificar.Stock} \r\n\r\nProducto modificado: {repuestoAModificar.Codigo}  - {repuestoAModificar.Nombre} - {repuestoAModificar.Precio} - {repuestoAModificar.Stock} - {repuestoAModificar.Categoria.Nombre}\r\n\r\n");
            }
            catch (StockNegativoException ex)
            {
                Console.WriteLine("ERROR. Stock NO puede ser negativo");
                throw new ErrorAlHacerTareaException();
            }
        }

        public static void TrearPorCategoria() {
            int codigoCategoria = IngresarNumero<int>("el numero del codigo de la categoria");
            try
            {
                Categoria categoriaElegida = getCategoriaByCode(codigoCategoria);

                listPorCodigoCategoria = InstanciaVentaRepuestos.TrearPorCategoria(codigoCategoria);

                if (listPorCodigoCategoria.Count == 0) { Console.WriteLine("\r\nNo se encontro ningún repuesto para dicha categoria"); }
                else {
                    foreach (Repuesto r in listPorCodigoCategoria)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    Console.Write("\r\nSe logro traer los repuestos para dicho codigo ¡Tarea Exitosa!\r\n\r\n");
                }

            }
            catch (CategoriaInexistenteException ex)
            {
                Console.WriteLine("\r\n\r\nERROR. Categoria Inexistente. Solo puede ingresar repuestos a categorias existentes");
                throw new ErrorAlHacerTareaException();
            }

        }

        public static T IngresarNumero<T>(string input)
        {
            string value;
            int salidaCodigoInt = 0;
            double salidaCodigoDouble = 0;
            bool flag;

            do
            {
                Console.WriteLine($"Ingrese {input}");
                value = Console.ReadLine();

                if (typeof(T) == typeof(int))
                {
                    flag = ValidarEntero(value, ref salidaCodigoInt);
                }
                else if (typeof(T) == typeof(double)) flag = ValidarDouble(value, ref salidaCodigoDouble);
                else flag = true;
            } while (flag == false);

            T valueReturn = (T)Convert.ChangeType(value, typeof(T));

            return valueReturn;
        }

        public static void ValidarStock(int stock) {
            if (stock > 100)
            {
                throw new StockCompletoException();
            }
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

            if (registro.Contains("."))
            {
                Console.WriteLine("Utilice las ',' (comas) para los centavos. NO utilice puntos bajo ningun punto de vista");
            }
            else if (!double.TryParse(registro, out salida))
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

        private static void validarNoExistenciaRepuestosByCode(int codigoRepuesto)
        {
            Repuesto validarRepuesto = getRepuestosByCode(codigoRepuesto);

            if (validarRepuesto != null) throw new RepuestoYaExisteException();
        }

        private static void validarExistenciaRepuestosByCode(int codigoRepuesto)
        {
            Repuesto validarRepuesto = getRepuestosByCode(codigoRepuesto);

            if (validarRepuesto == null) throw new RepuestoNoExisteException();
        }

        private static Repuesto getRepuestosByCode(int codigoRepuesto)
        {
            Repuesto repuestoElegido = null;

            foreach (Repuesto r in ListaRepuestos)
            {
                if (r.Codigo == codigoRepuesto) { repuestoElegido = r; }
            }

            return repuestoElegido;
        }
    }
}
