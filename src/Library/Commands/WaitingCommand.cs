using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/**
 * @brief Clase que implementa el comando 'waitinglist' del bot.
 */
public class WaitingCommand : ModuleBase<SocketCommandContext>
{
    /**
     * @brief Muestra la lista de jugadores esperando para jugar.
     * @return Una tarea asincrónica.
     */
    [Command("waitinglist")]
    [Summary("Muestra los usuarios en la lista de espera")]
    public async Task ExecuteAsync()
    {
        string result = Facade.Instance.GetAllTrainersWaiting();
        await ReplyAsync(result);
    }
}
