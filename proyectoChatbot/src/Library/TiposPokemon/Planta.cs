using Library;
using Library.TiposPokemon;

public class Planta : Itipo
{
    public string Nombre { get; }

    public Planta()
    {
        this.Nombre = "Planta";
    }

    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Electrico || otroTipo is Tierra || otroTipo is Planta;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Bicho || otroTipo is Veneno || otroTipo is Volador;
    }
}