using Library;
using Library.TiposPokemon;

public class Volador : Itipo
{
    public string Nombre { get; }

    public Volador()
    {
        this.Nombre = "Volador";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Tierra;
    }
    
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Normal || otroTipo is Bicho;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Electrico || otroTipo is Roca;
    }
}