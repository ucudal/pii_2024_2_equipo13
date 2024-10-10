namespace Library.TiposPokemon;

public class Agua:Itipo
{
    public string Nombre { get; }
    
    public Agua()
    {
        this.Nombre = "Agua";
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