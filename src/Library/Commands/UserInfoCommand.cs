using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'userinfo', alias 'who' o 'whois' del bot.
     */
    public class UserInfoCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Devuelve información sobre el usuario que se indica como parámetro o sobre el usuario que envía el mensaje si no se indica otro usuario.
         * @param displayName El nombre de usuario de Discord a buscar.
         */
        [Command("who")]
        [Summary("Devuelve información sobre el usuario que se indica como parámetro o sobre el usuario que envía el mensaje si no se indica otro usuario.")]
        public async Task ExecuteAsync(
            [Remainder][Summary("El usuario del que tener información, opcional")]
            string? displayName = null)
        {
            if (displayName != null)
            {
                SocketGuildUser? user = CommandHelper.GetUser(Context, displayName);

                if (user == null)
                {
                    await ReplyAsync($"No puedo encontrar {displayName} en este servidor");
                }
            }

            string userName = displayName ?? CommandHelper.GetDisplayName(Context);

            string result = Facade.Instance.TrainerIsWaiting(userName);

            await ReplyAsync(result);
        }
    }
}