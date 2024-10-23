using Library;
using Library.TiposPokemon;

public class Tierra : Itipo
{
    public string Nombre { get; }

    public Tierra()
    {
        this.Nombre = "Tierra";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Electrico;
    }
    
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Roca || otroTipo is Veneno;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Planta;
    }
}