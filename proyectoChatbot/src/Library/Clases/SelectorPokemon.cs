using Library.Pokemons;

namespace Library.Clases;

public class SelectorPokemon
{
    public static List<Pokemon> PokemonsDisponibles { get; private set; } // Lista de Pokémon disponible para todos los jugadores
    
    private void InicializarPokemonsDisponibles()
    {
        if (PokemonsDisponibles == null) // Si la lista aún no fue inicializada
        {
            PokemonsDisponibles = new List<Pokemon>
            {
                new Alakazam(),
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
    public void MostrarPokemonsDisponibles()
    {
        Console.WriteLine("Pokémon disponibles para seleccionar:");
        foreach (var pokemon in PokemonsDisponibles)
        {
            Console.WriteLine($"- {pokemon.Nombre}");
        }
    }
    
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