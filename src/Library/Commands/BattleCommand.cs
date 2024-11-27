using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /**
     * @brief Clase que implementa el comando 'battle' del bot.
     */
    public class BattleCommand : ModuleBase<SocketCommandContext>
    {
        /**
         * @brief Une al jugador que envía el mensaje con el oponente que se recibe como parámetro, si lo hubiera, en una batalla; si no se recibe un oponente, lo une con cualquiera que esté esperando para jugar.
         * @param opponentDisplayName Display name del oponente, opcional.
         */
        [Command("battle")]
        [Summary("Une al jugador que envía el mensaje con el oponente que se recibe como parámetro, si lo hubiera, en una batalla; si no se recibe un oponente, lo une con cualquiera que esté esperando para jugar.")]
        public async Task ExecuteAsync(
            [Remainder]
            [Summary("Display name del oponente, opcional")]
            string? opponentDisplayName = null)
        {
            string displayName = CommandHelper.GetDisplayName(Context);

            if (Facade.Instance.TrainerIsWaiting(displayName).Contains("no esta en la lista de espera"))
            {
                await ReplyAsync($"#{displayName} no está en la lista de espera.");
                return;
            }

            string result;

            if (!string.IsNullOrEmpty(opponentDisplayName))
            {
                if (displayName.Equals(opponentDisplayName, StringComparison.OrdinalIgnoreCase))
                {
                    await ReplyAsync("No puedes luchar contra ti mismo.");
                    return;
                }

                if (Facade.Instance.TrainerIsWaiting(opponentDisplayName).Contains("no esta en la lista de espera"))
                {
                    await ReplyAsync($"#{opponentDisplayName} no está en la lista de espera.");
                    return;
                }

                result = Facade.Instance.IniciarBatalla(displayName, opponentDisplayName);
            }
            else
            {
                Trainer? randomOpponent = Facade.Instance.ObtenerTrainerRandom(displayName);

                if (randomOpponent == null)
                {
                    result = "No hay oponentes disponibles en la lista de espera.";
                }
                else
                {
                    result = Facade.Instance.IniciarBatalla(displayName, randomOpponent.DisplayName);
                }
            }

            await ReplyAsync(result);
        }
    }
}