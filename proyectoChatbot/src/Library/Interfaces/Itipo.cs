namespace Library;

public interface Itipo
{
    string Nombre { get; }//Este Getter, obtiene el nombre del Tipo de Pokemon, Ej:Fuego

    bool InmuneContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es efectivo y el daño recibido, es nulo .
        return true;
    }

    bool ResistenteContra(Itipo otroTipo)
    {
        //Este metdo, comprueba contra que otros de tipos de pokemon, el pokemon es resistente  y el daño recibido por 0.5
        return true;
    }
    bool DebilContra(Itipo otroTipo)
    {
        // Este metodo, comprueba contra que otros tipos de pokemon, el pokemon es debil y el daño recibido, se multiplica por 2.
        return true;
    }

}