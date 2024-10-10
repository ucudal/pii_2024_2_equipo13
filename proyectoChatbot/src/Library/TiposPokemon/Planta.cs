namespace Library.TiposPokemon;

public class Planta:Itipo
{
    public string Nombre { get; }
    
    public Planta()
    {
        this.Nombre = "Planta";
    }
    bool FuerteContra()
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return true;
    }

    bool DebilContra()
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return true;
    }
}