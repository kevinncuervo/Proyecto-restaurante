namespace Listas;
using System;

class Program
    {
        static ListaEnlazada<Restaurante> ListaRestaurante = new ListaEnlazada<Restaurante>();
        static Restaurante restauranteActual = null;

        static void Main(string[] args)
        {
            MostrarMenuInicio();
        }

        static void MostrarMenuInicio()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- Sistema de Gestión de Restaurantes -----");

                if(ListaRestaurante.Cabeza == null)
                {
                    Console.WriteLine("No hay restaurantes registrados.");
                    CrearRestaurante();
                }
                else
                {
                   Console.WriteLine("Restaurantes disponibles:");
                   Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
                   int indice = 1;
                   while (actual != null)
                {
                    Console.WriteLine($"{indice}. {actual.Valor.Nombre}");
                    actual = actual.Siguiente;
                    indice++;
                } 
                    Console.WriteLine($"{indice}. Crear nuevo restaurante");

                    Console.WriteLine("Seleccione un restaurante por número:");
                    string input = Console.ReadLine();

                    int cantidadRestaurantes = indice - 1;
                    if (int.TryParse(input, out int opcion) && opcion >= 1 && opcion <= cantidadRestaurantes + 1)
                        
                    {
                        if (opcion == cantidadRestaurantes + 1)
                        {
                            CrearRestaurante();
                        }
                        else
                        {
                            Nodo<Restaurante> nodoSeleccionado = ListaRestaurante.Cabeza;
                            for (int i = 1; i < opcion && nodoSeleccionado != null; i++)
                            {
                                nodoSeleccionado = nodoSeleccionado.Siguiente;
                            }
                            restauranteActual = nodoSeleccionado.Valor;
                            MostrarMenuPrincipal();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Presione Enter para continuar.");
                        Console.ReadLine();
                    }
                }
            
            }
            
        }
        static void CrearRestaurante()
        {
            Console.WriteLine("----- Crear Nuevo Restaurante -----");
            Console.Write("Ingrese el NIT del restaurante: ");
            string nit = Console.ReadLine();
            Console.Write("Ingrese el nombre del restaurante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el nombre del dueño: ");
            string dueño = Console.ReadLine();
            Console.Write("Ingrese el celular del restaurante: ");
            string celular = Console.ReadLine();
            Console.Write("Ingrese la dirección del restaurante: ");
            string direccion = Console.ReadLine();

            Restaurante restaurante = new Restaurante(nit, nombre, dueño, celular, direccion);
            ListaRestaurante.Agregar(restaurante);
            restauranteActual = restaurante;

            Console.WriteLine($"Restaurante '{nombre}' creado exitosamente. Presione Enter para continuar.");
            Console.ReadLine();
        }
    }
