using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'vidaoponente' del bot.
     */
    public class VidaOponenteCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Muestra el estado de vida de los Pokémon del oponente.
         */
        [Command("vidaoponente")]
        [Summary("Muestra el estado de vida de los Pokémon del oponente.")]
        public async Task MostrarVidaOponenteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string estadoPokemons = Facade.Instance.ObtenerOponenteEnBatalla(displayName).ObtenerEstadoPokemons();
            await ReplyAsync(estadoPokemons);
        }
    }
}