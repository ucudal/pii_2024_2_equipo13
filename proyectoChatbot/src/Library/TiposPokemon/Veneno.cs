using Library;

public class Veneno : Itipo
{
    public string Nombre { get; }

    public Veneno()
    {
        this.Nombre = "Veneno";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    public bool FuerteContra(IList<Itipo> otroTipo)
    {
        return otroTipo is Planta || otroTipo is Hada || otroTipo is Bicho || otroTipo is Veneno;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra || otroTipo is Psiquico;
    }
}