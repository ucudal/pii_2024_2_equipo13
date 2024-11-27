using Discord.Commands;
using Library.Clases;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'join' del bot.
     */
    public class JoinCommand : ModuleBase<SocketCommandContext>
    {
        private readonly SelectorPokemon _selectorPokemon = new SelectorPokemon();

        /**
         * @brief Une el usuario que envía el mensaje a la lista de espera.
         */
        [Command("join")]
        [Summary("Une el usuario que envía el mensaje a la lista de espera")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.AddTrainerToWaitingList(displayName);
            await ReplyAsync(result);

            Trainer trainer = Facade.Instance.GetTrainerByDisplayName(displayName);
            if (trainer != null && trainer.Pokemons.Count == 6)
            {
                await ReplyAsync("Ya tienes un equipo completo de 6 Pokémon.");
            }
            else
            {
                string pokemonList = _selectorPokemon.MostrarPokemonsDisponibles();
                await ReplyAsync(pokemonList);
            }
        }
    }
}