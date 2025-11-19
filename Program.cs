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
        static void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Restaurante: {restauranteActual.Nombre} -----");
                Console.WriteLine("1. Restaurante");
                Console.WriteLine("2. Cliente");
                Console.WriteLine("3. Plato");
                Console.WriteLine("4. Pedido");
                Console.WriteLine("5. Volver al menú de restaurantes");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    MostrarMenuRestaurante();
                }
                else if (opcion == "2")
                {
                    MostrarMenuCliente();
                }
                else if (opcion == "3")
                {
                    MostrarMenuPlato();
                }
                else if (opcion == "4")
                {
                    MostrarMenuPedido();
                }
                else if (opcion == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione Enter para continuar.");
                    Console.ReadLine();
                }
            }
        }
        static void MostrarMenuRestaurante()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Gestión del Restaurante: {restauranteActual.Nombre} -----");
                Console.WriteLine("1. Editar restaurante");
                Console.WriteLine("2. Eliminar restaurante");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("----- Editar Restaurante -----");
                    Console.Write("Ingrese el nuevo nombre del restaurante: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese el nuevo nombre del dueño: ");
                    string nuevoDueño = Console.ReadLine();
                    Console.Write("Ingrese el nuevo celular del restaurante: ");
                    string nuevoCelular = Console.ReadLine(); 
                    Console.Write("Ingrese la nueva dirección del restaurante: ");
                    string nuevaDireccion = Console.ReadLine();

                    restauranteActual.Nombre = nuevoNombre;
                    restauranteActual.Dueño = nuevoDueño;
                    restauranteActual.Celular = nuevoCelular; 
                    restauranteActual.Direccion = nuevaDireccion;

                    Console.WriteLine("Restaurante actualizado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("----- Eliminar Restaurante -----");
                    Console.Write("¿Está seguro que desea eliminar este restaurante?: ");
                    string confirmacion = Console.ReadLine();

                    if (confirmacion.ToLower() == "sí" || confirmacion.ToLower() == "si" || confirmacion.ToLower() == "s" || confirmacion.ToLower() == "SÍ" || confirmacion.ToLower() == "SI" || confirmacion.ToLower() == "S")
                    {
                        ListaRestaurante.Eliminar(restauranteActual);
                        restauranteActual = null;
                        Console.WriteLine("Restaurante eliminado exitosamente. Presione Enter para continuar.");
                        Console.ReadLine();
                        return;
                    }
                }
                 else if (opcion == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione Enter para continuar.");
                    Console.ReadLine();
                }   
            }
        }
        static void MostrarMenuCliente()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Gestión de Clientes en: {restauranteActual.Nombre} -----");
                Console.WriteLine("1. Crear cliente");
                Console.WriteLine("2. Editar cliente");
                Console.WriteLine("3. Eliminar cliente");
                Console.WriteLine("4. Listar clientes");
                Console.WriteLine("5. Volver al menú anterior");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("----- Crear Cliente -----");
                    Console.Write("Ingrese la cédula del cliente: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el celular del cliente: ");
                    string celular = Console.ReadLine();
                    Console.Write("Ingrese el email del cliente: ");
                    string email = Console.ReadLine();

                    restauranteActual.AgregarCliente(cedula, nombre, celular, email);
                    Console.WriteLine("Cliente creado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("----- Editar Cliente -----");
                    Console.Write("Ingrese la cédula del cliente a editar: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el nuevo nombre del cliente: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese el nuevo celular del cliente: ");
                    string nuevoCelular = Console.ReadLine();
                    Console.Write("Ingrese el nuevo email del cliente: ");
                    string nuevoEmail = Console.ReadLine();

                    restauranteActual.EditarCliente(cedula, nuevoNombre, nuevoCelular, nuevoEmail);
                    Console.WriteLine("Cliente editado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("----- Eliminar Cliente -----");
                    Console.Write("Ingrese la cédula del cliente a eliminar: ");
                    string cedulaEliminar = Console.ReadLine();

                    restauranteActual.BorrarCliente(cedulaEliminar);
                    Console.WriteLine("Cliente eliminado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "4")
                {  
                    Console.WriteLine("----- Lista de Clientes -----");
                    restauranteActual.ListarClientes();
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione Enter para continuar.");
                    Console.ReadLine();
                }
            }
        }
    }
