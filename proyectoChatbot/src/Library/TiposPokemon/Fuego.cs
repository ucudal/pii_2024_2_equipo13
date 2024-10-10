namespace Library.TiposPokemon;

public class Fuego:Itipo
{
    public string Nombre { get; }
    
    public Fuego()
    {
        this.Nombre = "Fuego";
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