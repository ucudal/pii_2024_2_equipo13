using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'select' del bot.
     */
    public class SelectorCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Selecciona un Pokémon para el jugador. Usa el nombre del Pokémon en el mensaje.
         * @param pokemonName El nombre del Pokémon a seleccionar.
         */
        [Command("select")]
        [Summary("Selecciona un Pokémon para el jugador. Usa el nombre del Pokémon en el mensaje.")]
        public async Task ExecuteAsync([Remainder] string pokemonName)
        {
            string displayName = CommandHelper.GetDisplayName(Context);

            string[] pokemonNamesArray = pokemonName.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).ToArray();

            Trainer trainer = Facade.Instance.GetTrainerByDisplayName(displayName);

            if (trainer == null)
            {
                await ReplyAsync($"No se encontró al jugador {displayName}");
                return;
            }

            List<string> pokemonsSeleccionados = new List<string>();
            List<string> pokemonsInvalidos = new List<string>();

            foreach (string nombrePokemon in pokemonNamesArray)
            {
                if (trainer.Pokemons.Count >= 6)
                {
                    await ReplyAsync("Ya has seleccionado 6 Pokémon. No puedes seleccionar más.");
                    break;
                }

                var pokemonDisponible = Facade.Instance.PokemonsDisponibles.FirstOrDefault(p =>
                    p.PokemonName.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));

                if (pokemonDisponible != null && !trainer.Pokemons.Any(p =>
                        p.PokemonName.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase)))
                {
                    Pokemon pokemonClonado = pokemonDisponible.Clone();

                    trainer.pokebolasInventario(pokemonClonado);
                    pokemonsSeleccionados.Add(nombrePokemon);
                }
                else
                {
                    pokemonsInvalidos.Add(nombrePokemon);
                }
            }

            if (pokemonsInvalidos.Count > 0)
            {
                await ReplyAsync($"Los siguientes Pokémon no están disponibles: {string.Join(", ", pokemonsInvalidos)}");
            }

            if (trainer.Pokemons.Count < 6)
            {
                await ReplyAsync($"Has seleccionado {trainer.Pokemons.Count} Pokémon. Necesitas seleccionar {6 - trainer.Pokemons.Count} más.");
                string listaSeleccionados = "Pokémon seleccionados hasta ahora: \n";
                foreach (var pokemon in trainer.Pokemons)
                {
                    listaSeleccionados += $"{pokemon.PokemonName}\n";
                }
                await ReplyAsync(listaSeleccionados);
            }
            else
            {
                await ReplyAsync($"{displayName}, has completado tu equipo de 6 Pokémon.");
                await ReplyAsync($"Este es tu equipo:\n- {string.Join("\n- ", trainer.Pokemons.Select(p => p.PokemonName))}");

                trainer.PokemonActivo = trainer.Pokemons.First();
                await ReplyAsync($"Tu Pokémon activo es: {trainer.PokemonActivo.PokemonName}");
            }
        }
    }
}