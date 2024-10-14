using Library;
using Library.TiposPokemon;

public class Bicho : Itipo
{
    public string Nombre { get; }
    
    public Bicho()
    {
        this.Nombre = "Bicho";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Psiquico || otroTipo is Hada;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Volador || otroTipo is Veneno;
    }
}