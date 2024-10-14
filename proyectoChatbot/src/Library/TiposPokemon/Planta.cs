using Library;
using Library.TiposPokemon;

public class Planta : Itipo
{
    public string Nombre { get; }

    public Planta()
    {
        this.Nombre = "Planta";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Tierra;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Bicho || otroTipo is Veneno || otroTipo is Volador;
    }
}