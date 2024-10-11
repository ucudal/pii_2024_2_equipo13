using Library;

public class Veneno : Itipo
{
    public string Nombre { get; }

    public Veneno()
    {
        this.Nombre = "Veneno";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Hada;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra || otroTipo is Psiquico;
    }
}