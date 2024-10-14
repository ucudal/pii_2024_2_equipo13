using Library;
using Library.TiposPokemon;

public class Hada : Itipo
{
    public string Nombre { get; }

    public Hada()
    {
        this.Nombre = "Hada";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Veneno;
    }
}