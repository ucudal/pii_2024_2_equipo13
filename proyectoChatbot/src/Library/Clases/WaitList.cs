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

    public void SalaDeEspera(Jugador jugador)
    {
        waitListJugador.Add(jugador);
        Console.WriteLine($"{jugador.Nombre} ha sido agregado a la lista de espera.");
    }

    public void StartBattle()
    {
        if (waitListJugador.Count < 2)
        {
            Console.WriteLine("No hay suficientes jugadores para iniciar una batalla.");
            return;
        }

        Console.WriteLine("Iniciando...");

        Random RandomMatch = new Random();
        Jugador primerJugadorSeleccionado = waitListJugador[RandomMatch.Next(waitListJugador.Count)];
        Jugador segundoJugadorSeleccionado = waitListJugador.Find(jugador => jugador != primerJugadorSeleccionado);

        Console.WriteLine(
            $"{primerJugadorSeleccionado.Nombre} y {segundoJugadorSeleccionado.Nombre} han sido seleccionados para la batalla.");

        Turno gestionDeTurnos = new Turno(primerJugadorSeleccionado, segundoJugadorSeleccionado);
        if (RandomMatch.Next(2) == 0)
        {
            gestionDeTurnos.CambiarTurno(); // Asigna el turno inicial al primer jugador seleccionado
        }

        Console.WriteLine($"{gestionDeTurnos.JugadorActual.Nombre} tiene el primer turno.");
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