namespace Library.TiposPokemon;

public class Bicho:Itipo
{
    public string Nombre { get; }
    
    public Bicho()
    {
        this.Nombre = "Bicho";
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