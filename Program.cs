namespace Listas;
using System;

class Program
    {
        static ListaEnlazada<Restaurante> ListaRestaurante = new ListaEnlazada<Restaurante>();
        static Restaurante restauranteActual = null;
        static SistemaRestaurante sistema = new SistemaRestaurante();

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

                if(!sistema.Lleno())
                {
                    Console.WriteLine("No hay restaurantes registrados.");
                    CrearRestaurante();
                }
                else
                {
                    Console.WriteLine("Restaurantes disponibles:");
                    sistema.ListarRestaurante();
                                      
                    Console.WriteLine("Seleccione un restaurante por número:");
                    string input = Console.ReadLine();

                    int cantidadRestaurantes = sistema.CantidadRestaurantes();
                    if (int.TryParse(input, out int opcion) && opcion >= 1 && opcion <= cantidadRestaurantes + 1)
                        
                    {
                        if (opcion == cantidadRestaurantes + 1)
                        {
                            CrearRestaurante();
                        }
                        else
                        {
                            restauranteActual = sistema.EscogerRestaurantePorIndice(opcion);

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

            sistema.AgregarRestaurante(nit, nombre, dueño, celular, direccion);
            restauranteActual = sistema.EscogerRestaurante(nit);

            Console.WriteLine($"Restaurante '{nombre}' creado exitosamente. Presione Enter para continuar.");
            Console.ReadLine();
        }
        static void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Restaurante: {restauranteActual.Nombre} -----");
                Console.WriteLine("0. Volver al menú de restaurantes");
                Console.WriteLine("1. Restaurante");
                Console.WriteLine("2. Cliente");
                Console.WriteLine("3. Plato");
                Console.WriteLine("4. Pedido");
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
                else if (opcion == "0")
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
                Console.WriteLine("0. Volver al menú anterior");
                Console.WriteLine("1. Editar restaurante");
                Console.WriteLine("2. Eliminar restaurante");
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
                        sistema.BorrarRestaurante(restauranteActual.Nit);
                        restauranteActual = null;
                        Console.WriteLine("Restaurante eliminado exitosamente. Presione Enter para continuar.");
                        Console.ReadLine();
                        return;
                    }
                }
                 else if (opcion == "0")
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
                Console.WriteLine("0. Volver al menú anterior");
                Console.WriteLine("1. Crear cliente");
                Console.WriteLine("2. Editar cliente");
                Console.WriteLine("3. Eliminar cliente");
                Console.WriteLine("4. Listar clientes");
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
                else if (opcion == "0")
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
        static void MostrarMenuPlato()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Gestión de Platos en: {restauranteActual.Nombre} -----");
                Console.WriteLine("0. Volver al menú anterior");
                Console.WriteLine("1. Crear plato");
                Console.WriteLine("2. Editar plato");
                Console.WriteLine("3. Eliminar plato");
                Console.WriteLine("4. Listar platos");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("----- Crear Plato -----");
                    Console.Write("Ingrese el código del plato: ");
                    string codigo = Console.ReadLine();
                    Console.Write("Ingrese el nombre del plato: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del plato: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                    {
                        Console.Write("Precio inválido. Ingrese un valor numérico para el precio: ");
                        Console.WriteLine("Presione enter para continuar.");
                        continue;
                    }
                    Console.Write("Ingrese la descripción del plato: ");
                    string descripcion = Console.ReadLine();

                    restauranteActual.AgregarPlatos(codigo, nombre, descripcion, precio);
                    Console.WriteLine("Plato creado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("----- Editar Plato -----");
                    Console.Write("Ingrese el código del plato a editar: ");
                    string codigoEditar = Console.ReadLine();
                    Console.Write("Ingrese el nuevo nombre del plato: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese el nuevo precio del plato: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                    {
                        Console.Write("Precio inválido. Ingrese un valor numérico para el precio: ");
                        Console.WriteLine("Presione enter para continuar.");
                        continue;
                    }
                    Console.Write("Ingrese la nueva descripción del plato: ");
                    string nuevaDescripcion = Console.ReadLine();

                    restauranteActual.EditarPlato(codigoEditar, nuevoNombre, nuevaDescripcion, nuevoPrecio);
                    Console.WriteLine("Plato editado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("----- Eliminar Plato -----");
                    Console.Write("Ingrese el código del plato a eliminar: ");
                    string codigoEliminar = Console.ReadLine();

                   restauranteActual.BorrarPlatos(codigoEliminar);
                    Console.WriteLine("Plato eliminado exitosamente. Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "4")
                {  
                    Console.WriteLine("----- Lista de Platos -----");
                    restauranteActual.ListarPlatos();
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "0")
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
        static void MostrarMenuPedido()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"----- Gestión de Pedidos en: {restauranteActual.Nombre} -----");
                Console.WriteLine("0. Volver al menú anterior");
                Console.WriteLine("1. Crear pedido");
                Console.WriteLine("2. Despachar pedido");
                Console.WriteLine("3. Cancelar pedido");
                Console.WriteLine("4. Editar pedido");
                Console.WriteLine("5. Reporte de ventas");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {  
                    restauranteActual.CrearPedido();
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if(opcion == "2")
                {
                    restauranteActual.DespacharPedido();
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("----- Cancelar Pedido -----");
                    Console.Write("Ingrese el ID del pedido a cancelar: ");
                    if (int.TryParse(Console.ReadLine(), out int idCancelar))
                    {
                        restauranteActual.CancelarPedido(idCancelar);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                else if (opcion == "4")
                {
                    Console.WriteLine("----- Editar Pedido -----");
                    Console.Write("Ingrese el ID del pedido a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEditar))
                    {
                        restauranteActual.EditarPedido(idEditar);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                }
                    else if (opcion == "5")
                    {
                        Console.Clear();
                        Console.WriteLine($"----- Reporte de Ventas en: {restauranteActual.Nombre} -----");
                        restauranteActual.MostrarHistorialVentas();
                        Console.WriteLine($"Total de ventas acumuladas: {restauranteActual.TotalVentas()}");
                        Console.WriteLine($"Cantidad de ventas realizadas: {restauranteActual.CantidadVentas()}");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                    }
                else if(opcion == "0")
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
