using Library;

public class Volador : Itipo
{
    public string Nombre { get; }

    public Volador()
    {
        this.Nombre = "Volador";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Lucha || otroTipo is Bicho;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Electrico;
    }
}