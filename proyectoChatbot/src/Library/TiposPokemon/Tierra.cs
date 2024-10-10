namespace Library.TiposPokemon;

public class Tierra:Itipo
{
    public string Nombre { get; }
    
    public Tierra()
    {
        this.Nombre = "Tierra";
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