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