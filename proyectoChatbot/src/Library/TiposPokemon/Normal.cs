namespace Library.TiposPokemon;

public class Normal:Itipo
{
    public string Nombre { get; }
    
    public Normal()
    {
        this.Nombre = "Normal";
    }
    
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Fantasma;
    }
    public bool FuerteContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return false;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return otroTipo is Lucha;
    }
}