using Library;
using Library.TiposPokemon;

public class Bicho : Itipo
{
    public string Nombre { get; }

    public Bicho()
    {
        this.Nombre = "Bicho";
    }



    bool InmuneContra(IList<Itipo> otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo y el daño recibido, es nulo .
        return false;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Volador || otroTipo is Veneno;
    }

    public bool ResistenteContra(Itipo otroTipo)
    {
        //Este metdo, comprueba contra que otros de tipos de pokemon, el pokemon es resistente  y el daño recibido por 0.5
        return otroTipo is Lucha || otroTipo is Tierra || otroTipo is Planta;
    }
}
    