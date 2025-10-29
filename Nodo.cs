namespace Listas;

public class Nodo<T> {
    private T valor;
    private Nodo<T> siguiente;

    public Nodo(T valor) 
    {
        this.valor = valor;
        this.siguiente = null;
    }

    public T Valor
    {
		  get {return this.valor;}
		  set {this.valor = value;}
    }

    public Nodo<T> Siguiente
    {
		  get {return this.siguiente;}
		  set {this.siguiente = value;}
    }
}

