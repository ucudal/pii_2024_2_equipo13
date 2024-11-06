using Library.Clases;

namespace Library.Facade;

public class Facade
{
    protected Pokemon _arbok;
    protected Jugador joacoSerio;
    protected Turno batalla;
    protected WaitList listaBatalla;

    public Facade(Pokemon arbok, Jugador joacoSerio, Turno batalla,WaitList listaBatalla)
    {
        this._arbok = arbok;
        this.joacoSerio = joacoSerio;
        this.batalla = batalla;
        this.listaBatalla = listaBatalla;
    }
    
    
}