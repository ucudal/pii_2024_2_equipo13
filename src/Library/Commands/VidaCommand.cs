using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'vida' del bot.
     */
    public class VidaCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Muestra el estado de vida de los Pokémon del jugador.
         */
        [Command("vida")]
        [Summary("Muestra el estado de vida de los Pokémon del jugador.")]
        public async Task MostrarVidaAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string estadoPokemons = Facade.Instance.GetTrainerByDisplayName(displayName).ObtenerEstadoPokemons();
            await ReplyAsync(estadoPokemons);
        }
    }
}