namespace Listas;

public class Cliente
{
    private string cedula;
    private string nombre;
    private string celular;
    private string email;

     public Cliente()
        {
            this.cedula = "";
            this.nombre = "";
            this.celular = "";
            this.email = "";
        }
    public Cliente(string cedula, string nombre, string celular, string email)
    {
        this.cedula = cedula;
        this.nombre = nombre;
        this.celular = celular;
        this.email = email;
    }

    public string Cedula
    {
        get { return cedula; }
        set { cedula = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Celular
    {
        get { return celular; }
        set { celular = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
}