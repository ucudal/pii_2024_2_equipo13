namespace Library;

public class Turno
{
    public int NumeroTurno { get;}
    public bool EsTurnoDelJugador { get;}

    public Turno()
    {
        this.NumeroTurno = 0;
        this.EsTurnoDelJugador=null;
    }
    public void CambiarTurno()
    {
        //Este metodo, maneja el flujo de los turnos, viendo a que jugador le toca jugar
    }

    public void InicarTurno()
    {
        //Este metodo, lo que hace es confirmar, que efectivamente se inicio el turno del jugador
    }

    public void FinalizarTurno()
    {
        //Este metodo, lo que hace es confirmar, que efectivamente termino  el turno del jugador
    }

    public bool ValidarAtaqueEspecial()
    {
        /*Este metodo, lo que hace es, usando el Numero Turno, se válida si se puede usar el ataque especial
        o el jugador tiene que esperar al siguiente turno*/
    }

    public bool BatallaFinalizada()
    {
        //Este método, lo que hace es verificar si la batalla termino , o si continua.
    }
}