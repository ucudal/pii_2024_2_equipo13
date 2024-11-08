using System.Net.Sockets;

namespace Library.Clases;

/**
 * @class WaitList
 * @brief Clase que gestiona la lista de espera de jugadores para una batalla.
 *
 * La clase WaitList permite agregar jugadores a una lista de espera, iniciar una batalla
 * cuando hay suficientes jugadores disponibles y mostrar la lista de espera actual.
 */
public class WaitList
{
    /**
     * @brief Lista de jugadores en espera.
     */
    private List<Jugador> waitListJugador;

    /**
     * @brief Obtiene la lista de jugadores en espera.
     */
    public List<Jugador> WaitListJugador
    {
        get { return waitListJugador; }
    }

    /**
     * @brief Constructor de la clase WaitList.
     *
     * Inicializa una nueva lista de espera vacía.
     */
    public WaitList()
    {
        waitListJugador = new List<Jugador>();
    }

    /**
     * @brief Agrega un jugador a la lista de espera.
     * 
     * @param jugador El jugador que se agregará a la lista de espera.
     * @return Un mensaje indicando que el jugador ha sido agregado a la lista de espera.
     */
    public string SalaDeEspera(Jugador jugador)
    {
        waitListJugador.Add(jugador);
        return $"{jugador.Nombre} ha sido agregado a la lista de espera.";
    }

    /**
     * @brief Inicia una batalla si hay suficientes jugadores en la lista de espera con equipos completos.
     * 
     * Selecciona dos jugadores con 6 Pokémon en sus equipos y comienza una nueva batalla, notificando a los jugadores.
     * 
     * @return Una lista de notificaciones sobre el estado de la batalla.
     */
    public List<string> StartBattle()
    {
        List<string> notificaciones = new List<string>();

        if (waitListJugador.Count < 2)
        {
            notificaciones.Add("No hay suficientes jugadores para iniciar una batalla.");
            return notificaciones;
        }

        // Filtra jugadores con 6 Pokémon
        var jugadoresCon6Pokemons = waitListJugador.Where(j => j.Pokemons.Count == 6).ToList();

        if (jugadoresCon6Pokemons.Count < 2)
        {
            notificaciones.Add("No hay suficientes jugadores con 6 Pokémon para iniciar una batalla.");
            return notificaciones;
        }

        // Selecciona los dos primeros jugadores con equipos completos
        Jugador primerJugadorSeleccionado = jugadoresCon6Pokemons[0];
        Jugador segundoJugadorSeleccionado = jugadoresCon6Pokemons[1];

        notificaciones.Add($"{primerJugadorSeleccionado.Nombre} y {segundoJugadorSeleccionado.Nombre} han sido seleccionados para la batalla.");

        // Inicia la batalla
        Turno gestionDeTurnos = new Turno(primerJugadorSeleccionado, segundoJugadorSeleccionado);
        gestionDeTurnos.CambiarTurno(); // Asegura que el primer jugador tenga el primer turno.

        notificaciones.Add($"{gestionDeTurnos.JugadorActual.Nombre} tiene el primer turno.");

        return notificaciones;
    }

    /**
     * @brief Imprime la lista de espera actual en la consola.
     *
     * Muestra el número total de jugadores en espera y los nombres de cada uno.
     */
    public void ImprimirLista()
    {
        Console.WriteLine($"La lista contiene un total de {waitListJugador.Count} elementos:\n");
        for (int i = 0; i < waitListJugador.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {waitListJugador[i].Nombre}");
        }
    }
}
