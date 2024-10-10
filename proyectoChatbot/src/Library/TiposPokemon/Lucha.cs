namespace Library.TiposPokemon;

public class Lucha:Itipo
{
    public string Nombre { get; }
    
    public Lucha()
    {
        this.Nombre = "Lucha";
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