using System.Net.Sockets;

namespace Library.Clases;

public class WaitList
{
    private List<Jugador> waitListJugador;

    public List<Jugador> WaitListJugador
    {
        get { return waitListJugador; }
    }

    public WaitList()
    {
        waitListJugador = new List<Jugador>();
    }

    public string SalaDeEspera(Jugador jugador)
    {
        waitListJugador.Add(jugador);
        return $"{jugador.Nombre} ha sido agregado a la lista de espera.";
    }
    
    
    
    public List<string> StartBattle()
    {
        List<string> notificaciones = new List<string>();
        
        if (waitListJugador.Count < 2)
        {
            notificaciones.Add("No hay suficientes jugadores para iniciar una batalla.");
            return notificaciones;
        }
        
        //Solo filtra aquellos jugadores que seleccionaron 6 pokemons
        var jugadoresCon6Pokemons = waitListJugador.Where(j => j.Pokemons.Count == 6).ToList(); 

        if (jugadoresCon6Pokemons.Count < 2)
        {
            notificaciones.Add("No hay suficientes jugadores con 6 Pokémon para iniciar una batalla.");
            return notificaciones;
        }

        //Solo entran los dos primeros jugadores de la lista de espera
        Jugador primerJugadorSeleccionado = jugadoresCon6Pokemons[0]; 
        Jugador segundoJugadorSeleccionado = jugadoresCon6Pokemons[1]; 

        notificaciones.Add($"{primerJugadorSeleccionado.Nombre} y {segundoJugadorSeleccionado.Nombre} han sido seleccionados para la batalla.");

        //Inicia la batalla
        Turno gestionDeTurnos = new Turno(primerJugadorSeleccionado, segundoJugadorSeleccionado);

        gestionDeTurnos.CambiarTurno();  //Asegura que el primer jugador tenga el primer turno.

        notificaciones.Add($"{gestionDeTurnos.JugadorActual.Nombre} tiene el primer turno.");

        return notificaciones;
    }
    
    public void ImprimirLista()
    {
        Console.WriteLine($"La lista contiene un total de {waitListJugador.Count} elementos:\n");
        for (int i = 0; i < waitListJugador.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {waitListJugador[i]}");
        }
    }
    
}