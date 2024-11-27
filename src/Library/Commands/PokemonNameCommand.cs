using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa los comandos 'name' y 'ListaPokemon' del bot.
     */
    public class PokemonNameCommand : ModuleBase<SocketCommandContext>
    {
        private static readonly Dictionary<string, string> _availablePokemons = new Dictionary<string, string>
        {
            { "Alakazam", "Alakazam es un Pokémon de tipo psíquico conocido por su gran inteligencia." },
            { "Arbok", "Arbok es un Pokémon de tipo veneno conocido por su habilidad intimidatoria." },
            { "Arcanine", "Arcanine es un Pokémon de tipo fuego conocido por su velocidad y lealtad." },
            { "Blastoise", "Blastoise es un Pokémon de tipo agua conocido por los cañones en su caparazón." },
            { "Machamp", "Machamp es un Pokémon de tipo lucha famoso por su fuerza sobrehumana." },
            { "Marowak", "Marowak es un Pokémon de tipo tierra conocido por usar huesos como arma." },
            { "Pikachu", "Pikachu es un Pokémon de tipo eléctrico y la mascota oficial de Pokémon." },
            { "Sandslash", "Sandslash es un Pokémon de tipo tierra conocido por sus afiladas garras." },
            { "Scyther", "Scyther es un Pokémon de tipo bicho/volador conocido por sus cuchillas afiladas." },
            { "Snorlax", "Snorlax es un Pokémon de tipo normal conocido por su gran tamaño y apetito." }
        };

        /**
         * @brief Devuelve la información completa de un Pokémon dado su nombre.
         * @param pokemonName El nombre del Pokémon del que obtener la información.
         */
        [Command("name")]
        [Summary("Devuelve la información completa de un Pokémon dado su nombre.")]
        public async Task ExecuteAsync(
            [Summary("El nombre del Pokémon del que obtener la información.")] string pokemonName)
        {
            if (!_availablePokemons.ContainsKey(pokemonName))
            {
                await ReplyAsync($"No se encontró ningún Pokémon con el nombre {pokemonName}");
                return;
            }

            string pokemonInfo = _availablePokemons[pokemonName];
            await ReplyAsync($"Información de {pokemonName}: {pokemonInfo}");
        }

        /**
         * @brief Devuelve la lista de nombres de todos los Pokémon disponibles.
         */
        [Command("ListaPokemon")]
        [Summary("Devuelve la lista de nombres de todos los Pokémon disponibles.")]
        public async Task ListPokemonsAsync()
        {
            string pokemonList = string.Join(", ", _availablePokemons.Keys);
            await ReplyAsync($"Pokémon disponibles: {pokemonList}");
        }
    }
}