namespace Library.TiposPokemon;

public class Agua:Itipo
{
    public string Nombre { get; }
    
    public Agua()
    {
        this.Nombre = "Agua";
    }
    public bool InmuneContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return false;
    }

    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Tierra;
    }
    public bool DebilContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return otroTipo is Planta || otroTipo is Electrico;
    }
}