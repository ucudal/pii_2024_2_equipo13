using Library;
using Library.TiposPokemon;

public class Electrico : Itipo
{
    public string Nombre { get; }

    public Electrico()
    {
        this.Nombre = "Electrico";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Volador;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra;
    }
}