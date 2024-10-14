using Library;
using Library.TiposPokemon;

public class Fuego : Itipo
{
    public string Nombre { get; }

    public Fuego()
    {
        this.Nombre = "Fuego";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Bicho;
    }
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Tierra;
    }
}