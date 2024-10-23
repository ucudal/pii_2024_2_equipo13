using Library;
using Library.TiposPokemon;

public class Lucha : Itipo
{
    public string Nombre { get; }

    public Lucha()
    {
        this.Nombre = "Lucha";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Roca;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Volador || otroTipo is Psiquico || otroTipo is Hada;
    }
}