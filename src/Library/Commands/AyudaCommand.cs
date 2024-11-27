using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'ayuda' del bot.
     */
    public class AyudaCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Muestra las opciones disponibles.
         */
        [Command("ayuda")]
        [Summary("Muestra las opciones disponibles")]
        public async Task ExecuteAsync()
        {
            string[] mensajes = new string[]
            {
                "Las opciones disponibles son:\n" +
                "**1. `!join`** Une al usuario que envía el mensaje a la lista de espera." +
                "\n**2. `!waitinglist`** Muestra los usuarios que están actualmente en la lista de espera. \n" +
                "**3. `!leave`** Remueve al usuario que envía el mensaje de la lista de espera. " +
                "\n**4. `!battle`** Inicia una batalla contra un jugador específico o un oponente aleatorio de la lista de espera. " +
                "\n- Ejemplo sin oponente: `!battle` " +
                "\n- Ejemplo con oponente: `!battle NombreDelOponente`",
                "\n**6. `!item`** Utiliza un item con un Pokémon. " +
                "\n**7. `!curar`** Cura un Pokémon. " +
                "\n**8. `!ListaPokemon`** Muestra la lista de nombres de todos los Pokémon disponibles. " +
                "\n**9. `!name NombreDelPokemon`** Muestra información detallada de un Pokémon. " +
                "\n- Ejemplo: `!name Pikachu`",
                "\n**10. `!who [NombreDeUsuario]`** Muestra información del usuario actual o de otro usuario si se proporciona un nombre. " +
                "\n- Ejemplo sin nombre: `!who` " +
                "\n- Ejemplo con nombre: `!who NombreDeUsuario`",
                "\n**11. `!ayuda`** Muestra todas las opciones disponibles. " +
                "\n**12. `!help`** Muestra un mensaje de ayuda general sobre cómo usar los comandos del bot. " +
                "\n**13. `!vida`** Muestra el estado de vida de los Pokémon del jugador." +
                "\n**14. `!vidaoponente`** Muestra el estado de vida de los Pokémon del oponente." +
                "\n**15. `!rendir`** El jugador que envía el mensaje se rinde." +
                "\n**16. `!cambiar`** Cambia el Pokémon activo por el ingresado." +
                "\n- Ejemplo: `!cambiar Pikachu`" +
                "\n**17. `!items`** Muestra los items del jugador disponibles." +
                "\n**18. `!ataques`** Muestra todos los ataques del jugador para el Pokémon activo." +
                "\n**19. `!select`** Selecciona un Pokémon para el jugador. Usa el nombre del Pokémon en el mensaje."
            };

            foreach (var mensaje in mensajes)
            {
                await ReplyAsync(mensaje);
            }
        }
    }
}