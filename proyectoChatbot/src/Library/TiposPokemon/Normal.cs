namespace Library.TiposPokemon;

public class Normal:Itipo
{
    public string Nombre { get; }
    
    public Normal()
    {
        this.Nombre = "Normal";
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