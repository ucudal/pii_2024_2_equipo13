namespace Library.TiposPokemon;

public class Fantasma
{
    public string Nombre { get; }
    
    public Fantasma()
    {
        this.Nombre = "Fantasma";
    }
    public bool InmuneContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return otroTipo is Lucha || otroTipo is Normal;
    }

    public bool ResistenteContra(IList<Itipo> otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Veneno;
    }
    public bool DebilContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return otroTipo is Fantasma;
    }
}