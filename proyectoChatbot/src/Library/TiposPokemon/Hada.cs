namespace Library.TiposPokemon;

public class Hada:Itipo
{
    public string Nombre { get; }
    
    public Hada()
    {
        this.Nombre = "Hada";
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