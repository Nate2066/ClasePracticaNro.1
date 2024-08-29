using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePracticaNro._1 {
    internal class Program{
        static void Main(string[] args) {
            Gestor gestorProductos = new Gestor();
            bool cerrarMenu = false;
            do { 
                try {
                    Console.Clear();
                    Console.WriteLine(" [0]-------------------------------- ");
                    Console.WriteLine("        - Elija una opcion -         ");
                    Console.WriteLine(" ----------------------------------- ");
                    Console.WriteLine(" |  1. |  gestionar productos        ");
                    Console.WriteLine(" |  2. |  realizar ventas            \n");
                    Console.WriteLine("                      salir  |  0. |");
                    Console.WriteLine(" ----------------------------------- ");
                    Console.Write(">>");
                    byte opcionMenuPrincipal = Convert.ToByte(Console.ReadLine());

                    switch (opcionMenuPrincipal) {
                        case 1:
                            bool regresar = false;
                            do {
                                try {
                                    Console.Clear();
                                    Console.WriteLine(" [1]-------------------------------- ");
                                    Console.WriteLine("      - Gestionar  productos -       ");
                                    Console.WriteLine(" ----------------------------------- ");
                                    Console.WriteLine(" |  1. |  registrar producto         ");
                                    Console.WriteLine(" |  2. |  actualizar producto        ");
                                    Console.WriteLine(" |  3. |  mostrar lista de productos \n");
                                    Console.WriteLine("                   regresar  |  0. |");
                                    Console.WriteLine(" ----------------------------------- ");
                                    Console.Write(">>");
                                    byte opcionMenuGestionDeProductos = Convert.ToByte(Console.ReadLine());

                                    switch (opcionMenuGestionDeProductos) {
                                        case 1:
                                            gestorProductos._RegistrarProducto();
                                            break;
                                        case 2:
                                            gestorProductos._ActualizarProductos();
                                            break;
                                        case 3:
                                            gestorProductos._MostrarListaDeProductos();
                                            break;
                                        case 0:
                                            Console.Clear();
                                            regresar = true;
                                            break;
                                        default:
                                            _MensajeError();
                                            break;
                                    }
                                }
                                catch (FormatException) { _MensajeError(); }
                                catch (IndexOutOfRangeException) { _MensajeError(); }
                            } while(!regresar);
                            break;

                        case 2:
                            gestorProductos._VenderProducto();
                            break;

                        case 0:
                            Console.Clear();
                            cerrarMenu = true;
                            break;

                        default:
                            _MensajeError();
                            break;
                    }
                }
                catch (FormatException) { _MensajeError(); }
                catch (IndexOutOfRangeException) { _MensajeError(); }
            } while (!cerrarMenu);
        }
        static void _MensajeError() {
            Console.Clear();
            Console.WriteLine("Error! Ingrese una opcion valida");
            Console.ReadKey();
        }
    }
}
