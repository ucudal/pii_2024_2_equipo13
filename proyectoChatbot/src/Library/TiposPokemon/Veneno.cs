namespace Library.TiposPokemon;

public class Veneno:Itipo
{
    public string Nombre { get; }
    
    public Veneno()
    {
        this.Nombre = "Veneno";
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