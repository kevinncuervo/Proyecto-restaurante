namespace Listas;

public class SistemaRestaurante
{
    private ListaEnlazada<Restaurante> ListaRestaurante = new ListaEnlazada<Restaurante>();

    public void AgregarRestaurante(Restaurante restaurante)
    {
        if (RestauranteExiste(restaurante.Nit))
        {
            Console.WriteLine("El restaurante con NIT: " + restaurante.Nit + " ya existe.");
            return;
        }

        ListaRestaurante.Agregar(restaurante);
        Console.WriteLine("Restaurante creado: " + restaurante.Nombre);
    }

    public void AgregarRestaurante(string nit, string nombre, string dueño, string celular, string direccion)
    {
        if (RestauranteExiste(nit))
        {
            Console.WriteLine("El restaurante con NIT: " + nit + " ya existe.");
            return;
        }
        if (string.IsNullOrWhiteSpace(nit) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dueño) || string.IsNullOrWhiteSpace(celular) || string.IsNullOrWhiteSpace(direccion))
        {
            Console.WriteLine("Todos los campos son obligatorios para agregar un restaurante.");
            return;
        }
        if (celular.Length != 10 || !celular.All(char.IsDigit))
        {
            Console.WriteLine("El número de celular debe tener 10 dígitos y solo contener números.");
            return;
        }

        Restaurante restaurante = new Restaurante(nit, nombre, dueño, celular, direccion);
        ListaRestaurante.Agregar(restaurante);
        Console.WriteLine("Restaurante agregado: " + restaurante.Nombre);
    }
    private bool RestauranteExiste(string nit)
    {
        Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Nit == nit)
            {
                return true;
            }
        actual = actual.Siguiente;
        }
        return false;
    }
    public bool Lleno()
    {
        return ListaRestaurante.Cabeza != null;
    }
    public void ListarRestaurante()
    {
        int contador = 0;
        Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
        while (actual != null)
        {
            contador++;
            Console.WriteLine("Restaurante #" + contador);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("NIT: " + actual.Valor.Nit);
            Console.WriteLine("Nombre: " + actual.Valor.Nombre);
            Console.WriteLine("Dueño: " + actual.Valor.Dueño);
            Console.WriteLine("Celular: " + actual.Valor.Celular);
            Console.WriteLine("Dirección: " + actual.Valor.Direccion);
            Console.WriteLine("-------------------------------------");
            actual = actual.Siguiente;
        }
    }

    public void BorrarRestaurante(string identificador)
{
    if (ListaRestaurante.Cabeza == null)
    {
        Console.WriteLine("No hay restaurantes para borrar.");
        return;
    }

    Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
    Nodo<Restaurante> previo = null;

    while (actual != null)
    {
        if (actual.Valor.Nit == identificador)
        {
            if (previo == null)
            {
                ListaRestaurante.Cabeza = actual.Siguiente;
            }
            else
            {
                previo.Siguiente = actual.Siguiente;
            }
            Console.WriteLine("Restaurante eliminado: " + actual.Valor.Nombre);
            return;
        }
        previo = actual;
        actual = actual.Siguiente;
    }

    Console.WriteLine("No se encontró ningún restaurante con el Nit: " + identificador);
}
    public Restaurante EscogerRestaurante(string identificador)
    {
        Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Nombre == identificador || actual.Valor.Nit == identificador)
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("No se encontró ningún restaurante con el Nit: " + identificador);
        return null;
    }
    public Restaurante EscogerRestaurantePorIndice(int indice)
    {
        Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
        int contador = 1;

        while (actual != null)
        {
            if (contador == indice)
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
            contador++;
        }
        Console.WriteLine("No se encontró ningún restaurante en el índice: " + indice);
        return null;
    }
    public int CantidadRestaurantes()
    {
        int contador = 0;
        Nodo<Restaurante> actual = ListaRestaurante.Cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }
}