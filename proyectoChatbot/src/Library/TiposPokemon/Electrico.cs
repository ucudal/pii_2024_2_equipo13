namespace Library.TiposPokemon;

public class Electrico:Itipo
{
    public string Nombre { get; }
    
    public Electrico()
    {
        this.Nombre = "Electrico";
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