using Library;
using Library.TiposPokemon;

public class Electrico : Itipo
{
    public string Nombre { get; }

    public Electrico()
    {
        this.Nombre = "Electrico";
    }

    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Electrico;
    }
    public bool ResitenteContra(IList<Itipo> otroTipo)
    {
        return otroTipo is Volador;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra;
    }
}