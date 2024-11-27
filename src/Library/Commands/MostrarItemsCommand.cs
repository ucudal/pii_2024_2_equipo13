using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'items' del bot.
     */
    public class MostrarItemsCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Muestra los items del jugador.
         */
        [Command("items")]
        [Summary("Muestra los items del jugador.")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.MostrarItemsDisponibles(displayName);
            await ReplyAsync(result);
        }
    }
}