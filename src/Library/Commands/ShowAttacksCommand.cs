using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'ataques' del bot.
     */
    public class ShowAttacksCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Muestra todos los ataques del jugador para el Pokémon activo.
         */
        [Command("ataques")]
        [Summary("Muestra todos los ataques del jugador para el Pokémon activo.")]
        public async Task ExecuteAsync()
        {
            string result;
            string displayName = CommandHelper.GetDisplayName(Context);
            result = Facade.Instance.MostrarAtaquesDisponibles(displayName);
            await ReplyAsync(result);
        }
    }
}