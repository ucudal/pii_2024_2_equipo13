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