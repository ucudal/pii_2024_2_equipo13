using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class DeleteCommand : ModuleBase<SocketCommandContext>
    {
        private const string SpecificGifUrl = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNzFpYzcyc2s3d2NxOXNoNDd0Nmo2cnQ5ZHR3M3QxMnEzc3ZuMWo5NCZlcD12MV9naWZzX3NlYXJjaCZjdD1n/U2nN0ridM4lXy/giphy.gif"; // Replace with your specific GIF URL

        [Command("borrar")]
        [Summary("Borra una cantidad específica de mensajes en el canal actual.")]
        public async Task BorrarMensajesAsync(int cantidadMensajes)
        {
            // Obtener los mensajes del canal actual
            var messages = await Context.Channel.GetMessagesAsync(cantidadMensajes + 1).FlattenAsync();

            // Borrar los mensajes
            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);

            // Enviar un mensaje de confirmación
            await ReplyAsync($"{cantidadMensajes} mensajes han sido borrados.");

            // Enviar el GIF específico
            await ReplyAsync(SpecificGifUrl);
        }
    }
}