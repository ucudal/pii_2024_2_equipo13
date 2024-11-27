using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'ataquebasico' del bot.
     */
    public class BasicAttackCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Usa un ataque básico.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Una tarea asincrónica.
         * @details Sintaxis: !ataquebasico <número del ataque>
         */
        [Command("ataquebasico")]
        [Summary("Usa un ataque básico. Sintaxis: !ataquebasico <número del ataque>")]
        public async Task AtacarBasicoAsync(int ataqueSeleccionado)
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

            // Realizar el ataque básico llamando a la fachada
            string resultado = Facade.Instance.AtacarBasico(atacante, oponente, ataqueSeleccionado);

            // Enviar el resultado al canal de Discord
            await ReplyAsync(resultado);
        }
    }
}