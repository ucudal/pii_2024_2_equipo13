namespace Library.TiposPokemon;

public class Agua:Itipo
{
    public string Nombre { get; }
    
    public Agua()
    {
        this.Nombre = "Agua";
    }
    bool FuerteContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return otroTipo is Fuego || otroTipo is Tierra;
    }

    bool DebilContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return otroTipo is Planta || otroTipo is Electrico;
    }
}