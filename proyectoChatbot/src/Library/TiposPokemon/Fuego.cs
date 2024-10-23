using Library;
using Library.TiposPokemon;

public class Fuego : Itipo
{
    public string Nombre { get; }

    public Fuego()
    {
        this.Nombre = "Fuego";
    }

    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }
    public bool Resistentecontra(IList<Itipo> otroTipo)
    {
        return otroTipo is Planta || otroTipo is Bicho ||  otroTipo is Fuego;
    }
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Tierra || otroTipo is Roca;
    }
}