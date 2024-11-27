using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'rendir' del bot.
     */
    public class RendirCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief El jugador que envía el mensaje se rinde.
         */
        [Command("rendir")]
        [Summary("El jugador que envía el mensaje se rinde")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.Rendirse(displayName);
            await ReplyAsync(result);
        }
    }
}