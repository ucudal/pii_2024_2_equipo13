using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'leave' del bot.
     */
    public class LeaveCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Remueve el usuario que envía el mensaje a la lista de espera.
         */
        [Command("leave")]
        [Summary("Remueve el usuario que envía el mensaje a la lista de espera")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.RemoveTrainerFromWaitingList(displayName);
            await ReplyAsync(result);
        }
    }
}