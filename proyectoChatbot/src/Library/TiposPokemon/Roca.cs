namespace Library.TiposPokemon;

public class Roca : Itipo
{
    public string Nombre { get; }
    
    public Roca()
    {
        this.Nombre = "Roca";
    }
    public bool InmuneContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return false;
    }

    public bool ResistenteContra(IList<Itipo> otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Normal || otroTipo is Volador || otroTipo is Veneno;
    }
    public bool DebilContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return otroTipo is Agua || otroTipo is Tierra || otroTipo is Lucha || otroTipo is Planta;
    }
}