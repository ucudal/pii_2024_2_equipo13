using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using Library.Pokemons;
using Ucu.Poo.DiscordBot.Domain;
using Discord.WebSocket;

namespace Library.Clases
{
    /**
     * @brief Clase que maneja la selección de Pokémon para los jugadores.
     */
    public class SelectorPokemon : ModuleBase<SocketCommandContext>
    {
        /// \brief Lista de Pokémon disponibles para todos los jugadores.
        public List<Pokemon> PokemonsDisponibles { get; private set; }

        /**
         * @brief Constructor de la clase SelectorPokemon.
         */
        public SelectorPokemon()
        {
            InicializarPokemonsDisponibles();
        }
        
        /**
         * @brief Inicializa la lista de Pokémon disponibles.
         */
        private void InicializarPokemonsDisponibles()
        {
            if (PokemonsDisponibles == null)
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
         * @brief Obtiene la lista de Pokémon disponibles.
         * @return Una cadena con los nombres de los Pokémon disponibles.
         */
        public string ObtenerPokemonsDisponibles()
        {
            Console.WriteLine("Obteniendo lista de Pokémon disponibles...");
            var listaPokemons = string.Join("\n", Facade.Instance.PokemonsDisponibles.Select(p => p.PokemonName));
            Console.WriteLine("Pokemons disponibles: " + listaPokemons);
            return listaPokemons;
        }

        /**
         * @brief Obtiene una lista de nombres de Pokémon disponibles.
         * @return Una lista de cadenas con los nombres de los Pokémon disponibles.
         */
        private List<string> ObtenerListaDePokemons()
        {
            return PokemonsDisponibles.Select(p => p.PokemonName).ToList();
        }

        /**
         * @brief Muestra los Pokémon disponibles.
         * @return Una cadena con los nombres de los Pokémon disponibles.
         */
        public string MostrarPokemonsDisponibles()
        {
            List<string> pokemons = ObtenerListaDePokemons();
            if (pokemons == null || pokemons.Count == 0)
            {
                return "No hay Pokémon disponibles.";
            }

            string resultado = "Por favor selecciona tus 6 Pokémon de la siguiente lista:\n";
            foreach (var pokemon in pokemons)
            {
                resultado += $"- {pokemon}\n";
            }

            return resultado;
        }

        /**
         * @brief Selecciona un Pokémon de la lista de disponibles.
         * @param pokemonName El nombre del Pokémon a seleccionar.
         * @return Una copia del Pokémon seleccionado.
         * @throws ArgumentException Si el Pokémon no está disponible.
         */
        public Pokemon SeleccionarPokemon(string pokemonName)
        {
            Pokemon pokemonOriginal = PokemonsDisponibles.FirstOrDefault(p => p.PokemonName.Equals(pokemonName, StringComparison.OrdinalIgnoreCase));

            if (pokemonOriginal != null)
            {
                return pokemonOriginal.Clone();
            }

            throw new ArgumentException($"El Pokémon {pokemonName} no está disponible.");
        }
    }
}