using Library;
using Library.TiposPokemon;

public class Tierra : Itipo
{
    public string Nombre { get; }

    public Tierra()
    {
        this.Nombre = "Tierra";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Electrico || otroTipo is Veneno;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Planta;
    }
}