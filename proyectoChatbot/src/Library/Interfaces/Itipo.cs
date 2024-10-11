namespace Library;

public interface Itipo
{
    string Nombre { get; }//Este Getter, obtiene el nombre del Tipo de Pokemon, Ej:Fuego

    bool FuerteContra(List<Itipo>tiposAtacantes)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo.
        return true;
    }

    bool DebilContra(List<Itipo>tiposAtacantes)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil.
        return true;
    }

}