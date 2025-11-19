namespace Listas;
using System;

public class Pedido
{
    private static int contadorID = 1;
    private int idPedido;
    private string cedulacliente;
    private string estado;
    private decimal total;
    private Cola<Platopedido> platos;
    private DateTime fechaHora;

    public Pedido(string cedulacliente)
    {
        this.idPedido = contadorID++;
        this.cedulacliente = cedulacliente;
        this.estado = "Pendiente";
        this.total = 0;
        this.platos = new Cola<Platopedido>();
        this.fechaHora = DateTime.Now;
    }

    public int IdPedido
    {
        get { return idPedido; }
    }

    public string CedulaCliente
    {
        get { return cedulacliente; }
        set { cedulacliente = value; }
    }  

    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public decimal Total
    {
        get { return total; }
        set { total = value; }
    }   

    public Cola<Platopedido> Platos
    {
        get { return platos; }
    }

    public void AgregarPlato(Platopedido platopedido)
    {
        platos.Agregar(platopedido);
        total += platopedido.PrecioTotal;
    }

    public void MostrarResumen()
    {
        if (platos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes.");
            return;
        }

        Console.WriteLine($"Pedido ID: {idPedido}");
        Console.WriteLine($"Cliente Cédula: {cedulacliente}");
        Console.WriteLine($"Estado: {estado}");
        Console.WriteLine($"Fecha y Hora: {fechaHora}");
        Console.WriteLine("Detalle del pedido: ");
       
        Cola<Platopedido> temp = new Cola<Platopedido>();
        int cantidad = platos.Tamano();

        for (int i = 0; i < cantidad; i++)
        {
            Platopedido plato = platos.Primero();
            Console.WriteLine($" - Código: {plato.CodigoPedido}, Cantidad: {plato.Cantidad}, Precio Unitario: {plato.PrecioUnitario}, Precio Total: {plato.PrecioTotal}");
            temp.Agregar(plato);
            platos.Eliminar();
        }

        for(int i = 0; i < cantidad; i++)
        {
            platos.Agregar(temp.Primero());
            temp.Eliminar();
        }
        Console.WriteLine($"Total del pedido: {total}");
    }
}

    public class Platopedido
{
    private string codigoPedido;
    private int cantidad;
    private decimal precioUnitario;
    private decimal precioTotal;

    public Platopedido(string codigoPedido, int cantidad, decimal precioUnitario)
    {
        this.codigoPedido = codigoPedido;
        this.cantidad = cantidad;
        this.precioUnitario = precioUnitario;
        this.precioTotal = cantidad * precioUnitario;
    }

    public string CodigoPedido
    {
        get { return codigoPedido; }
        set { codigoPedido = value; }
    }   

    public int Cantidad
    {
        get { return cantidad; }
        set { 
            cantidad = value; 
            precioTotal = cantidad * precioUnitario;
            }
    }

    public decimal PrecioUnitario
    {
        get { return precioUnitario; }
        set { 
            precioUnitario = value; 
            precioTotal = cantidad * precioUnitario;
            }
    }

    public decimal PrecioTotal
    {
        get { return precioTotal; }
    }

}