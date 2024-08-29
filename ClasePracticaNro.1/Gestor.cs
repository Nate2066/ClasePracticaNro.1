using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePracticaNro._1
{
    public class Gestor{
        private List<string> listaNombreProductos = new List<string>();
        private List<double> listaPrecioProductos = new List<double>();
        private List<int>    listaCantidadProductos = new List<int>();

        public virtual void _RegistrarProducto(){
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto");
            Console.Write(">>");
            listaNombreProductos.Add(Console.ReadLine());

            Console.WriteLine("Ingrese el precio del producto");
            Console.Write(">>");
            listaPrecioProductos.Add(Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("Ingrese la cantidad de productos");
            Console.Write(">>");
            listaCantidadProductos.Add(Convert.ToInt32(Console.ReadLine()));
        }
        public virtual void _MostrarListaDeProductos(){
            Console.Clear();
            for (int i = 0; i < listaNombreProductos.Count(); i++) {
                Console.WriteLine("Producto Nro.{0}:", (i + 1));
                Console.WriteLine("\n     {0}    ", listaNombreProductos[i]);
                Console.WriteLine("\n     Precio : {0}", listaPrecioProductos[i]);
                Console.WriteLine("     Cantidad disponible : {0}\n", listaCantidadProductos[i]);
            }
            Console.ReadKey();
        }
        public virtual void _ActualizarProductos(){
            Console.Clear();
            Console.WriteLine("Seleccione el producto que desee actualizar\n");
            for(int i = 0; i < listaNombreProductos.Count(); i++){
                Console.WriteLine("{0}. {1}", (i + 1), listaNombreProductos[i]);
            }
            int numeroDeElemento = Convert.ToInt32(Console.ReadLine());
            if(numeroDeElemento > 0 && numeroDeElemento <= listaNombreProductos.Count()) {
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo nombre");
                Console.Write(">>");
                listaNombreProductos[numeroDeElemento - 1] = Console.ReadLine();

                Console.WriteLine("Ingrese un nuevo precio");
                Console.Write(">>");
                listaPrecioProductos[numeroDeElemento - 1] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese la cantidad nueva de productos");
                Console.Write(">>");
                listaCantidadProductos[numeroDeElemento -1] = Convert.ToInt32(Console.ReadLine());
            }
            else {
                Console.WriteLine("Elemento no encontrado");
            }
        }
        public virtual void _VenderProducto() {
            bool eligiendoProducto = false;
            List<string> ticketNombres = new List<string>();
            List<int> ticketCantidad = new List<int>();
            List<double> ticketPrecio = new List<double>();
            do
            {
                try {

                    Console.Clear();
                    for (int i = 0; i < listaNombreProductos.Count(); i++)
                    {
                        Console.WriteLine("{0}. {1} [{2}]", (i + 1), listaNombreProductos[i], listaCantidadProductos[i]);
                    }
                    Console.WriteLine("\n\nSeleccione los producto");
                    Console.WriteLine("| 0. | Generar Ticket\n");
                    int productoVenta = Convert.ToInt32(Console.ReadLine());
                    if (productoVenta > 0 && productoVenta <= listaNombreProductos.Count())
                    {
                        if (listaCantidadProductos[productoVenta - 1] <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lo sentimos, el producto se encuentra agotado!");
                            Console.ReadKey();
                        }
                        else
                        {
                            ticketNombres.Add(listaNombreProductos[productoVenta - 1]);
                            ticketPrecio.Add(listaPrecioProductos[productoVenta - 1]);
                            Console.WriteLine("Agregue una cantidad disponible");
                            int cantidadProducto = Convert.ToInt32(Console.ReadLine());
                            if (cantidadProducto > 0 && cantidadProducto <= listaCantidadProductos[productoVenta - 1])
                            {
                                ticketCantidad.Add(cantidadProducto);
                                listaCantidadProductos[productoVenta - 1] -= cantidadProducto;
                            }
                            else if (cantidadProducto == 0)
                            {
                                Console.Clear();
                                _MostrarTicket(ticketNombres, ticketCantidad, ticketPrecio);
                                eligiendoProducto = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Agregue una cantidad disponible, porfavor");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (productoVenta == 0)
                    {
                        Console.Clear();
                        _MostrarTicket(ticketNombres, ticketCantidad, ticketPrecio);
                        eligiendoProducto = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Producto no encontrado!");
                        Console.ReadKey();
                    }
                }
                catch (FormatException) {
                    Console.Clear();
                    Console.WriteLine("Error! Ingrese una opcion valida");
                    Console.ReadKey();
                }
                catch (IndexOutOfRangeException) {
                    Console.Clear();
                    Console.WriteLine("Error! Ingrese una opcion valida");
                    Console.ReadKey();
                }
            } while (!eligiendoProducto);
        }
        private void _MostrarTicket(List<string> pTicketNombres, List<int> pTicketCantidad, List<double> pTicketPrecio){
            Console.Clear();
            double precioTotal = 0;
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine(".                              Ticket de venta                                       \n");
            Console.WriteLine("    Productos : ");

            for (int i = 0; i< pTicketNombres.Count(); i++) {
                Console.WriteLine(".           -{0}", pTicketNombres[i]);
                Console.WriteLine(".                [{0}", pTicketCantidad[i]);
                precioTotal += (pTicketPrecio[i] * pTicketCantidad[i]);
            }
            Console.WriteLine("\n                                                      Total : {0}", precioTotal);
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
