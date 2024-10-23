using Library;
using Library.TiposPokemon;

public class Psiquico : Itipo
{
    public string Nombre { get; }

    public Psiquico()
    {
        this.Nombre = "Psiquico";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Veneno;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Fantasma;
    }
}