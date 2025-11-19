namespace Listas;
using System;
using System.Runtime.Serialization.Formatters;

public class Restaurante
{

    private string nit;
    private string nombre;
    private string dueño;
    private string celular;
    private string direccion;
    private decimal acumuladoVentas = 0;


    public Restaurante(string nit, string nombre, string dueño, string celular, string direccion)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.dueño = dueño;
        this.celular = celular;
        this.direccion = direccion;
    }

    private Pila<decimal> ReporteVentas = new Pila<decimal>();

    private ListaEnlazada<Cliente> ListaCliente = new ListaEnlazada<Cliente>();
    private Cola<Pedido> ColaPedidos = new Cola<Pedido>();

        public void AgregarCliente(Cliente cliente)
        {
            if(ClienteExiste(cliente.Cedula))
            {
                Console.WriteLine("El cliente con cédula: " + cliente.Cedula + " ya existe.");
                return;
            }
            ListaCliente.Agregar(cliente);
            Console.WriteLine("Cliente creado: " + cliente.Nombre);
        }

        public void AgregarCliente(string cedula, string nombre, string celular, string email)
        {
            if(ClienteExiste(cedula))
            {
                Console.WriteLine("El cliente con cédula: " + cedula + " ya existe.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(celular) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Todos los campos son obligatorios para agregar un cliente.");
                return;
            }
            if (celular.Length != 10 || !celular.All(char.IsDigit))
            {
                Console.WriteLine("El número de celular debe tener 10 dígitos y solo contener números.");
                return;
            }
            if (!EmailValido(email))
            {
                Console.WriteLine("El email proporcionado no es válido.");
                return;
            }

            Cliente cliente = new Cliente(cedula, nombre, celular, email);
            ListaCliente.Agregar(cliente);
            Console.WriteLine("Cliente agregado: " + cliente.Nombre);
        }

        public void ListarClientes()
        {
            int contador = 0;
            Nodo<Cliente> actual = ListaCliente.Cabeza;
            while (actual != null)
            {
                contador++;
                Console.WriteLine("Cliente #" + contador);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Cédula: " + actual.Valor.Cedula);
                Console.WriteLine("Nombre: " + actual.Valor.Nombre);
                Console.WriteLine("Celular: " + actual.Valor.Celular);
                Console.WriteLine("Email: " + actual.Valor.Email);
                Console.WriteLine("-------------------------------------");
                actual = actual.Siguiente;
            }
        }

        public Nodo<Cliente> CabezaClientes()
        {
            return ListaCliente.Cabeza;
        }

        public void BorrarCliente(string identificador)
        {

            if (ListaCliente.Cabeza == null)
            {
                Console.WriteLine("No hay clientes para borrar.");
                return;
            }

            Nodo<Cliente> actual = ListaCliente.Cabeza;
            Nodo<Cliente> previo = null;

            while (actual != null)
            {
                if (actual.Valor.Cedula == identificador)
                {
                    if (previo == null)
                    {
                        ListaCliente.Cabeza = actual.Siguiente;
                    }
                    else
                    {
                        previo.Siguiente = actual.Siguiente;
                    }
                    Console.WriteLine("Cliente borrado: " + actual.Valor.Nombre);
                    return;
                }
                previo = actual;
                actual = actual.Siguiente;
            }
            Console.WriteLine("No se encontró el cliente con cédula: " + identificador);
        }

private ListaEnlazada<Plato> ListaPlato = new ListaEnlazada<Plato>();
   
        public void AgregarPlatos(Plato plato)
        {
            if(PlatoExiste(plato.Codigo))
            {
                Console.WriteLine("El plato con código: " + plato.Codigo + " ya existe.");
                return;
            }
            ListaPlato.Agregar(plato);
            Console.WriteLine("Plato creado: " + plato.Nombre);
        }

        public void AgregarPlatos(string codigo, string nombre, string descripcion, decimal precio)
        {
            if(PlatoExiste(codigo))
            {
                Console.WriteLine("El plato con código: " + codigo + " ya existe.");
                return;
            }
            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion) || precio <= 0)
            {
                Console.WriteLine("Todos los campos son obligatorios para agregar un plato y el precio debe ser mayor a cero.");
                return;
            }
            Plato plato = new Plato(codigo, nombre, descripcion, precio);
            ListaPlato.Agregar(plato);
            Console.WriteLine("Plato agregado: " + plato.Nombre);
        }

        public void ListarPlatos()
        {
            int contador = 0;
            Nodo<Plato> actual = ListaPlato.Cabeza;
            while (actual != null)
            {
                contador++;
                Console.WriteLine("Plato #" + contador);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Código: " + actual.Valor.Codigo);
                Console.WriteLine("Nombre: " + actual.Valor.Nombre);
                Console.WriteLine("Descripción: " + actual.Valor.Descripcion);
                Console.WriteLine("Precio: " + actual.Valor.Precio);
                Console.WriteLine("-------------------------------------");
                actual = actual.Siguiente;
            }
        }

        public Nodo<Plato> CabezaPlato()
        {
            return ListaPlato.Cabeza;
        }

        public void BorrarPlatos(string identificador)
        {

            if (ListaPlato.Cabeza == null)
            {
                Console.WriteLine("No hay platos para borrar.");
                return;
            }

            Nodo<Plato> actual = ListaPlato.Cabeza;
            Nodo<Plato> previo = null;

            while (actual != null)
            {
                if (actual.Valor.Codigo == identificador)
                {
                    if (previo == null)
                    {
                        ListaPlato.Cabeza = actual.Siguiente;
                    }
                    else
                    {
                        previo.Siguiente = actual.Siguiente;
                    }
                    Console.WriteLine("Plato borrado: " + actual.Valor.Codigo + " " + actual.Valor.Nombre);
                    return;
                }
                previo = actual;
                actual = actual.Siguiente;
            }
            Console.WriteLine("No se encontró el producto con código: " + identificador);
        }

            public void MostrarHistorialVentas()
    {
        Console.WriteLine("Historial de ventas (últimas arriba):");
        ReporteVentas.ImprimirPila(); // usa el método ya definido en la clase Pila
    }

        public decimal TotalVentas()
    {
        return acumuladoVentas;
    }


        public int CantidadVentas()
    {
        return ReporteVentas.Tamano;
    }



    private bool ClienteExiste(string cedula)
    {
        Nodo<Cliente> actual = ListaCliente.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Cedula == cedula)
            {
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }

        public Cliente BuscarCliente(string cedula)
    {
        Nodo<Cliente> actual = ListaCliente.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Cedula == cedula)
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

        public void EditarCliente(string cedula, string nuevoNombre, string nuevoCelular, string nuevoEmail)
    {
        Cliente cliente = BuscarCliente(cedula);
        if (cliente == null)
        {
            Console.WriteLine("No se encontró el cliente con cédula: " + cedula);
            return;
        }

        if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoCelular) || string.IsNullOrWhiteSpace(nuevoEmail))
        {
            Console.WriteLine("Todos los campos son obligatorios.");
            return;
        }

        if (nuevoCelular.Length != 10 || !nuevoCelular.All(char.IsDigit))
        {
            Console.WriteLine("El número de celular debe tener 10 dígitos y solo contener números.");
            return;
        }

        if (!EmailValido(nuevoEmail))
        {
            Console.WriteLine("El email proporcionado no es válido.");
            return;
        }

        cliente.Nombre = nuevoNombre;
        cliente.Celular = nuevoCelular;
        cliente.Email = nuevoEmail;

        Console.WriteLine("Cliente actualizado correctamente.");
    }


    private bool PlatoExiste(string codigo)
    {
        Nodo<Plato> actual = ListaPlato.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Codigo == codigo)
            {
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }   
    public Plato BuscarPlato(string codigo)
    {
        Nodo<Plato> actual = ListaPlato.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Codigo == codigo)
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

        public void EditarPlato(string codigo, string nuevoNombre, string nuevaDescripcion, decimal nuevoPrecio)
    {
        Plato plato = BuscarPlato(codigo);
        if (plato == null)
        {
            Console.WriteLine("No se encontró el plato con código: " + codigo);
            return;
        }

        if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevaDescripcion) || nuevoPrecio <= 0)
        {
            Console.WriteLine("Todos los campos son obligatorios y el precio debe ser mayor a cero.");
            return;
        }

        plato.Nombre = nuevoNombre;
        plato.Descripcion = nuevaDescripcion;
        plato.Precio = nuevoPrecio;

        Console.WriteLine("Plato actualizado correctamente.");
    }
    private bool EmailValido(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public void RegistrarVenta(decimal totalVenta)
    {
        if (totalVenta <= 0)
        {
            Console.WriteLine("El total de la venta debe ser mayor a cero.");
            return;
        }

        ReporteVentas.AgregarElemento(totalVenta);
        acumuladoVentas += totalVenta;
        Console.WriteLine("Venta registrada por $" + totalVenta);
    }

    public void CrearPedido()
    {
        Console.WriteLine("Ingrese la cédula del cliente: ");
        string cedulaCliente = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cedulaCliente))
        {
            Console.WriteLine("La cédula no puede estar vacía.");
            return;
        }
        if (!ClienteExiste(cedulaCliente))
        {
            Console.WriteLine("No se encontró un cliente con la cédula proporcionada.");
            return;
        }
        Pedido nuevoPedido = new Pedido(cedulaCliente);

        if (ListaPlato.Cabeza == null)
        {
            Console.WriteLine("No hay platos disponibles para agregar al pedido.");
            return;
        }

        Console.WriteLine("Platos disponibles:");
        Nodo<Plato> actualPlato = ListaPlato.Cabeza;
        int contador = 1;

        while (actualPlato != null)
        {
            Plato p = actualPlato.Valor;
            Console.WriteLine($"{contador}. Código: {p.Codigo}, Nombre: {p.Nombre}, Precio: {p.Precio}, Descripcion: {p.Descripcion}");
            actualPlato = actualPlato.Siguiente;
            contador++;    
        }
        while (true)
        {
            Console.WriteLine("Ingrese el código del plato a agregar al pedido (o 'salir' para finalizar): ");
            string codigoPlato = Console.ReadLine();

            Plato platoSeleccionado = BuscarPlato(codigoPlato);

            if (platoSeleccionado == null)
            {
                Console.WriteLine("No se encontró un plato con el código proporcionado.");
                continue;
            }

            Console.WriteLine("Ingrese la cantidad deseada: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad inválida. Debe ser un número entero positivo.");
                continue;
            }

            Platopedido nuevoPlatopedido = new Platopedido(platoSeleccionado.Codigo, cantidad, platoSeleccionado.Precio);
           
            nuevoPedido.AgregarPlato(nuevoPlatopedido);
            Console.WriteLine($"Plato {platoSeleccionado.Nombre} agregado al pedido.");

            Console.WriteLine("¿Desea agregar otro plato?: ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s" && respuesta.ToLower() != "si" && respuesta.ToLower() != "SÍ" && respuesta.ToLower() != "SI" && respuesta.ToLower() != "Sí" && respuesta.ToLower() != "sÍ")
            {
                break;
            }
            
            Console.WriteLine("Resumen del pedido:");
            nuevoPedido.MostrarResumen();

            Console.WriteLine("¿Desea guardar el pedido?");
            string guardarRespuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s" && respuesta.ToLower() != "si" && respuesta.ToLower() != "SÍ" && respuesta.ToLower() != "SI" && respuesta.ToLower() != "Sí" && respuesta.ToLower() != "sÍ")
            {
                ColaPedidos.Agregar(nuevoPedido);
                Console.WriteLine("Pedido guardado exitosamente.");
            }
            else
            {
                Console.WriteLine("Pedido no guardado.");
            }
        }
    }

    public void ListarPedidosPendientes()
    {
        if (ColaPedidos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes.");
            return;
        }
        Cola<Pedido> tempCola = new Cola<Pedido>();
        int contador = 1;

        int cantidad = ColaPedidos.Tamano();

        for (int i = 0; i < cantidad; i++)
        {
            Pedido pedidoActual = ColaPedidos.Primero();

            if (pedidoActual.Estado == "Pendiente")
            {
                Console.WriteLine($"Pedido #{contador}");
                pedidoActual.MostrarResumen();
                contador++;
            }
            tempCola.Agregar(pedidoActual);
            ColaPedidos.Eliminar();    
        }
        if (contador == 1)
        {
            Console.WriteLine("No hay pedidos pendientes.");
        }
        for (int i = 0; i < cantidad; i++)
        {
            ColaPedidos.Agregar(tempCola.Primero());
            tempCola.Eliminar();
        }
    }
    
    public void BuscarPedidoID(int id)
    {
        if (ColaPedidos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos en la cola.");
            return;
        }

        Cola<Pedido> tempCola = new Cola<Pedido>();
        Pedido pedidoEncontrado = null;
        int cantidad = ColaPedidos.Tamano();

        for (int i = 0; i < cantidad; i++)
        {
            Pedido pedidoActual = ColaPedidos.Primero();

            if (pedidoActual.IdPedido == id)
            {
                pedidoEncontrado = pedidoActual;
            }
            tempCola.Agregar(pedidoActual);
            ColaPedidos.Eliminar();
        }
        for (int i = 0; i < cantidad; i++)
        {
            ColaPedidos.Agregar(tempCola.Primero());
            tempCola.Eliminar();
        }
    }

    public Pedido BuscarPedidoPorID(int id)
    {
        if (ColaPedidos.EstaVacia())
        {
            return null;
        }

        Cola<Pedido> tempCola = new Cola<Pedido>();
        Pedido pedidoEncontrado = null;
        int cantidad = ColaPedidos.Tamano();

        for (int i = 0; i < cantidad; i++)
        {
            Pedido pedidoActual = ColaPedidos.Primero();

            if (pedidoActual.IdPedido == id)
            {
                pedidoEncontrado = pedidoActual;
            }
            tempCola.Agregar(pedidoActual);
            ColaPedidos.Eliminar();
        }
        for (int i = 0; i < cantidad; i++)
        {
            ColaPedidos.Agregar(tempCola.Primero());
            tempCola.Eliminar();
        }

        return pedidoEncontrado;
    }

    public void EditarPedido(int id)
    {
        Pedido pedido = BuscarPedidoPorID(id);
        if (pedido == null)
        {
            Console.WriteLine("No se encontró el pedido con ID: " + id);
            return;
        }

        if (pedido.Estado != "Pendiente")
        {
            Console.WriteLine("Solo se pueden editar pedidos en estado 'Pendiente'.");
            return;
        }

        Console.WriteLine("Resumen del pedido actual:");
        pedido.MostrarResumen();

        while (true)
        {
           Console.WriteLine("Opciones de edición:");
           Console.WriteLine("1. Cambiar cantidad de un plato");
           Console.WriteLine("2. Eliminar un plato");
           Console.WriteLine("3. Agregar un nuevo plato");
           Console.WriteLine("4. Salir");
           Console.Write("Seleccione una opción: ");
           string opcion = Console.ReadLine();   

           if (opcion == "1")
            {
                Console.WriteLine("Ingrese el código del plato a modificar:");
                string codigoPlato = Console.ReadLine();

                Cola<Platopedido> tempPlatos = new Cola<Platopedido>();
                bool platoEncontrado = false;
                int cantidadPlatos = pedido.Platos.Tamano();
                
                for (int i = 0; i < cantidadPlatos; i++)
                {
                    Platopedido platoActual = pedido.Platos.Primero();
                    pedido.Platos.Eliminar();

                    if (!platoEncontrado && platoActual.CodigoPedido == codigoPlato)
                    {
                        Console.WriteLine("Ingrese la nueva cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out int Cantidadmodificada) && Cantidadmodificada > 0)
                        {
                            platoActual.Cantidad = Cantidadmodificada;
                            platoEncontrado = true;
                            Console.WriteLine("Cantidad actualizada.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida. Debe ser un número mayor a 0.");
                        }
                    }
                    tempPlatos.Agregar(platoActual);
                }

                for (int i = 0; i < cantidadPlatos; i++)
                {
                    pedido.Platos.Agregar(tempPlatos.Primero());
                    tempPlatos.Eliminar();
                }

                if (!platoEncontrado)
                {
                    Console.WriteLine("No se encontró el plato con código: " + codigoPlato);
                }
                pedido.MostrarResumen();
            }

            else if (opcion == "2")
            {
                Console.WriteLine("Ingrese el código del plato a eliminar:");
                string codigoEliminar = Console.ReadLine();

                Cola<Platopedido> tempPlatos = new Cola<Platopedido>();
                bool platoEliminado = false;
                int cantidadPlatos = pedido.Platos.Tamano();

                for (int i = 0; i < cantidadPlatos; i++)
                {
                    Platopedido platoActual = pedido.Platos.Primero();
                    pedido.Platos.Eliminar();

                    if (!platoEliminado && platoActual.CodigoPedido == codigoEliminar)
                    {
                        platoEliminado = true;
                        Console.WriteLine("Plato eliminado del pedido.");
                        continue;
                    }
                    
                        tempPlatos.Agregar(platoActual);
                    }

                    for (int i = 0; i < cantidadPlatos; i++)
                    {
                        pedido.Platos.Agregar(tempPlatos.Primero());
                        tempPlatos.Eliminar();
                    }
                    if (!platoEliminado)
                    {
                        Console.WriteLine("No se encontró el plato con código: " + codigoEliminar);
                    }
                    pedido.MostrarResumen();
                
            }
            else if (opcion == "3")
            {
                if (ListaPlato.Cabeza == null)
                {
                    Console.WriteLine("No hay platos disponibles para agregar al pedido.");
                    return;
                }
                Console.WriteLine("Platos disponibles:");
                Nodo<Plato> actualPlato = ListaPlato.Cabeza;
                while (actualPlato != null)
                {
                    Plato plato = actualPlato.Valor;
                    Console.WriteLine($"Código: {plato.Codigo}, Nombre: {plato.Nombre}, Precio: {plato.Precio}, Descripcion: {plato.Descripcion}");
                    actualPlato = actualPlato.Siguiente;
                }

                Console.WriteLine("Ingrese el código del plato a agregar al pedido: ");
                string codigoPlato = Console.ReadLine();

                Plato platoSeleccionado = BuscarPlato(codigoPlato);
                if (platoSeleccionado == null)
                {
                    Console.WriteLine("No se encontró un plato con el código proporcionado.");
                    continue;
                }
                Console.WriteLine("Ingrese la cantidad deseada: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida. Debe ser un número mayor a 0.");
                    continue;
                }

                Platopedido nuevoPlatopedido = new Platopedido(platoSeleccionado.Codigo, cantidad, platoSeleccionado.Precio);
                pedido.AgregarPlato(nuevoPlatopedido);
                Console.WriteLine($"Plato {platoSeleccionado.Nombre} agregado al pedido.");
                pedido.MostrarResumen();
            }
            else if (opcion == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción invalida, intente nuevamente");
                continue;
            }

            decimal nuevoTotal = 0;
            Cola<Platopedido> recalculoPlatos = new Cola<Platopedido>();
            int nuevaCantidad = pedido.Platos.Tamano();

            for (int i = 0; i < nuevaCantidad; i++)
            {
                Platopedido platoParaRecalcular = pedido.Platos.Primero();
                nuevoTotal += platoParaRecalcular.PrecioTotal;
                recalculoPlatos.Agregar(platoParaRecalcular);
                pedido.Platos.Eliminar();
            }
                    
            for (int i = 0; i < nuevaCantidad; i++)
            {
                pedido.Platos.Agregar(recalculoPlatos.Primero());
                recalculoPlatos.Eliminar(); 
            }
            pedido.Total = nuevoTotal;
        }
    }

    
    public string Nit
    {
        get { return nit; }
        set { nit = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Dueño
    {
        get { return dueño; }
        set { dueño = value; }
    }

    public string Celular
    {
        get { return celular; }
        set { celular = value; }
    }

    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

}