namespace Listas;

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