namespace Library.TiposPokemon;

public class Volador:Itipo
{
    public string Nombre { get; }
    
    public Volador()
    {
        this.Nombre = "Volador";
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