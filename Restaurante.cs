namespace Listas;

public class Restaurante
{

    private string nit;
    private string nombre;
    private string dueño;
    private string celular;
    private string direccion;

    public Restaurante(string nit, string nombre, string dueño, string celular, string direccion)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.dueño = dueño;
        this.celular = celular;
        this.direccion = direccion;
    }

    private ListaEnlazada<Cliente> ListaCliente = new ListaEnlazada<Cliente>();
   
        public void AgregarCliente(Cliente cliente)
        {
            ListaCliente.Agregar(cliente);
            Console.WriteLine("Cliente creado: " + cliente.Nombre);
        }

        public void AgregarCliente(string cedula, string nombre, string celular, string email)
        {
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

        public void BorrarCliente(int identificador)
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
                        ListarCliente.Cabeza = actual.Siguiente;
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

    public object ListaCliente { get; private set; }
}