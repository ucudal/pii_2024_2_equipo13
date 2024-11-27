using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'ataqueespecial' del bot.
     */
    public class EspecialAttackComand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Usa un ataque especial.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Una tarea asincrónica.
         * @details Sintaxis: !ataqueespecial <número del ataque>
         */
        [Command("ataqueespecial")]
        [Summary("Usa un ataque especial. Sintaxis: !ataqueespecial <número del ataque>")]
        public async Task AtacarEspecialAsync(int ataqueSeleccionado)
        {
            // Obtener el nombre del atacante desde el contexto del comando
            string atacanteDisplayName = CommandHelper.GetDisplayName(Context);

            // Buscar el atacante y el oponente en la fachada
            Trainer atacante = Facade.Instance.GetTrainerByDisplayName(atacanteDisplayName);
            Trainer oponente = Facade.Instance.ObtenerTrainerRandom(atacanteDisplayName);

            // Verificar si hay oponente disponible
            if (oponente == null)
            {
                await ReplyAsync("No tienes un oponente para atacar.");
                return;
            }

            // Realizar el ataque especial llamando a la fachada
            string resultado = Facade.Instance.AtacarEspecial(atacante, oponente, ataqueSeleccionado);

            // Enviar el resultado al canal de Discord
            await ReplyAsync(resultado);
        }
    }
}