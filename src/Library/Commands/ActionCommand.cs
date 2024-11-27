using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa los comandos de acción del bot.
     */
    public class ActionCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Cambia el Pokémon activo.
         * @param nombrePokemon El nombre del Pokémon a cambiar.
         * @return Una tarea asincrónica.
         */
        [Command("cambiar")]
        public async Task CambiarPokeomonActivo(string nombrePokemon)
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string resultado = Facade.Instance.RealizarAccion(displayName, "cambiar", null, nombrePokemon);
            await ReplyAsync(resultado);
        }

        /**
         * @brief Usa un ítem en un Pokémon.
         * @param itemOpcion La opción del ítem a usar.
         * @param nombrePokemon El nombre del Pokémon en el que se usará el ítem.
         * @return Una tarea asincrónica.
         */
        [Command("item")]
        public async Task ItemCommand(string itemOpcion, [Remainder] string nombrePokemon)
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string resultado = Facade.Instance.RealizarAccion(displayName, "item", itemOpcion, nombrePokemon);
            await ReplyAsync(resultado);
        }
    }
}