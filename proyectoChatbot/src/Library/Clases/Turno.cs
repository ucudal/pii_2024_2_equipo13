namespace Library;

public class Turno
{
    public int NumeroTurno { get; set; } //Getter del Numero de Turno, para manejar el flujo del juego, ataques especiales,etc.
    public bool EsTurnoDelJugador { get;} //Getter que es un bool, que devuelve si es un turno del jugador
    
    //Constructor

    public Turno()
    {
        this.NumeroTurno = 0;
        this.EsTurnoDelJugador=false; 
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
    public void Atacar(Jugador atacante, Jugador defensor)
    {
        Console.WriteLine($"¿Que ataque deseas realizar\n 1-Ataque Basico\n2-Ataque Especial");
        string opcion = Console.ReadLine();
        if (opcion=="1")
        {
            IPokemon objetivo = defensor.PokemonActivo;

            // Aquí llamamos al ataque básico del Pokémon activo del jugador atacante
            double dañoReal = atacante.PokemonActivo.AtaqueBasico(objetivo);

            // Imprimir el daño infligido
            Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre} y le inflige {dañoReal} de daño.");

            // Aquí podrías agregar lógica para manejar la salud del Pokémon objetivo, etc.
            defensor.PokemonActivo.DañoRecibido(dañoReal);
            // Al finalizar el ataque, incrementar el número de turno
            NumeroTurno++;
        }

        if (opcion =="2")
        {
            if (!ValidarAtaqueEspecial())
            {
                Console.WriteLine("No puedes usar un ataque especial en este turno.");
            }
            else
            {
                IPokemon objetivo = defensor.PokemonActivo;

                // Aquí llamamos al ataque básico del Pokémon activo del jugador atacante
                double dañoReal = atacante.PokemonActivo.AtaqueEspecial(objetivo);

                // Imprimir el daño infligido
                Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre} y le inflige {dañoReal} de daño.");

                // Aquí podrías agregar lógica para manejar la salud del Pokémon objetivo, etc.
                defensor.PokemonActivo.DañoRecibido(dañoReal);
                // Al finalizar el ataque, incrementar el número de turno
                NumeroTurno++; 
            }
        }
        
    }
    public bool ValidarAtaqueEspecial()
    {
        bool valido = false;
        if (NumeroTurno/2==0)
        {
            valido =true;
        }
        else
        {
            valido = valido;
        }

        return valido;
        /*Este metodo, lo que hace es, usando el Numero Turno, se válida si se puede usar el ataque especial
        o el jugador tiene que esperar al siguiente turno*/

    }

    public bool BatallaFinalizada()
    {
        //Este método, lo que hace es verificar si la batalla termino , o si continua.
        return false;
    }
}