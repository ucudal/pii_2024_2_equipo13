namespace Library;

public interface Itipo
{
    string Nombre { get; }//Este Getter, obtiene el nombre del Tipo de Pokemon, Ej:Fuego

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