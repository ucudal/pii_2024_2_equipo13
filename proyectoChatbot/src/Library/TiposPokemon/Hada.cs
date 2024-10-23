using Library;
using Library.TiposPokemon;

public class Hada : Itipo
{
    public string Nombre { get; }

    public Hada()
    {
        this.Nombre = "Hada";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Bicho;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Veneno;
    }
}