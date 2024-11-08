using Library.Pokemons;

namespace Library.Clases;

/**
 * @class SelectorPokemon
 * @brief Clase que gestiona la selección de Pokémon disponibles para los jugadores.
 * 
 * La clase SelectorPokemon proporciona una lista de Pokémon disponibles para que los jugadores puedan
 * seleccionar sus equipos de batalla.
 */
public class SelectorPokemon
{
    /**
     * @brief Lista de Pokémon disponibles para todos los jugadores.
     */
    public static List<Pokemon> PokemonsDisponibles { get; private set; }

    /**
     * @brief Constructor de la clase SelectorPokemon.
     * 
     * Inicializa la lista de Pokémon disponibles si aún no ha sido inicializada.
     */
    public SelectorPokemon()
    {
        InicializarPokemonsDisponibles();
    }

    /**
     * @brief Inicializa la lista de Pokémon disponibles.
     * 
     * Si la lista de Pokémon disponibles aún no fue inicializada, se crea una lista de Pokémon con instancias predefinidas.
     */
    private void InicializarPokemonsDisponibles()
    {
        if (PokemonsDisponibles == null) // Si la lista aún no fue inicializada
        {
            PokemonsDisponibles = new List<Pokemon>
            {
                new Alakazam(),
                new Marowak(),
                new Pikachu(),
                new Machamp(),
                new Snorlax(),
                new Arbok(),
                new Sandslash(),
                new Scyther(),
                new Blastoise(),
                new Arcanine()
            };
        }
    }

    /**
     * @brief Muestra la lista de Pokémon disponibles en la consola.
     */
    public void MostrarPokemonsDisponibles()
    {
        Console.WriteLine("Pokémon disponibles para seleccionar:");
        foreach (var pokemon in PokemonsDisponibles)
        {
            Console.WriteLine($"- {pokemon.Nombre}");
        }
    }

    /**
     * @brief Permite a un jugador seleccionar Pokémon para su equipo.
     * 
     * Muestra los Pokémon disponibles, solicita al jugador que seleccione sus Pokémon
     * y los añade a su equipo, verificando que no se repitan.
     * 
     * @param jugador El jugador que seleccionará sus Pokémon.
     */
    public void SeleccionarPokemonsParaJugador(Jugador jugador)
    {
        MostrarPokemonsDisponibles();
        Console.WriteLine($"Jugador {jugador.Nombre}, elige tus Pokémon.");

        int seleccionados = 0;
        while (seleccionados < 6)
        {
            Console.WriteLine("Ingresa el nombre del Pokémon que deseas agregar a tu equipo:");
            string nombrePokemon = Console.ReadLine();

            // Buscar el Pokémon en la lista de disponibles
            Pokemon pokemonSeleccionado = PokemonsDisponibles.FirstOrDefault(p => p.Nombre.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));

            // Validar que el Pokémon esté en la lista de disponibles y que no haya sido elegido antes
            if (pokemonSeleccionado != null && !jugador.Pokemons.Contains(pokemonSeleccionado))
            {
                jugador.Pokemons.Add(pokemonSeleccionado);
                seleccionados++;
                Console.WriteLine($"{pokemonSeleccionado.Nombre} ha sido añadido al equipo de {jugador.Nombre}.");
            }
            else
            {
                Console.WriteLine("El Pokémon no está disponible o ya ha sido seleccionado. Intenta nuevamente.");
            }

            // Mostrar la cantidad de Pokémon seleccionados
            Console.WriteLine($"Has seleccionado {seleccionados} de 6 Pokémon.");
        }

        Console.WriteLine($"¡{jugador.Nombre} ha seleccionado a todos sus Pokémon para la batalla!");
    }
}
