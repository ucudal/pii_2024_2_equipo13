namespace Library.TiposPokemon;

public class Psiquico:Itipo
{
    public string Nombre { get; }
    
    public Psiquico()
    {
        this.Nombre = "Psiquico";
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