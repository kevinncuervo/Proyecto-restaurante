public class Plato
{
    private string codigo;
    private string nombre;
    private string descripcion;
    private decimal precio;

    public Plato(string codigo, string nombre, string descripcion, decimal precio)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
    }

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }
    
}