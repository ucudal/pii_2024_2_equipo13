using System.Collections.ObjectModel;
using Library.Clases;

namespace Ucu.Poo.DiscordBot.Domain
{
    /**
     * @brief Clase que representa la lista de jugadores esperando para jugar.
     */
    public class WaitList
    {
        /**
         * @brief Lista de jugadores en espera.
         */
        private List<Trainer> waitListJugador;

        /**
         * @brief Obtiene la lista de jugadores en espera.
         */
        public List<Trainer> WaitListJugador
        {
            get { return waitListJugador; }
        }

        /**
         * @brief Constructor de la clase WaitList.
         *
         * Inicializa una nueva lista de espera vacía.
         */
        public WaitList()
        {
            waitListJugador = new List<Trainer>();
        }

        /**
         * @brief Agrega un jugador a la lista de espera.
         * 
         * @param jugador El jugador que se agregará a la lista de espera.
         * @return Un mensaje indicando que el jugador ha sido agregado a la lista de espera.
         */
        public string AñadirTrainer(Trainer jugador)
        {
            if (waitListJugador.Any(jug => jug.DisplayName == jugador.DisplayName))
            {
                return $"{jugador.DisplayName} ya ha sido agregado a la lista de espera";
            }
            waitListJugador.Add(jugador);
            return $"{jugador.DisplayName} ha sido agregado a la lista de espera.";
        }

        /**
         * @brief Obtiene un jugador aleatorio de la lista de espera.
         * 
         * @return Un jugador aleatorio o `null` si la lista está vacía.
         */
        public Trainer? GetRandomTrainerWaiting()
        {
            if (waitListJugador.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int randomIndex = random.Next(waitListJugador.Count);
            return waitListJugador[randomIndex];
        }

        /**
         * @brief Imprime la lista de espera actual en la consola.
         *
         * Muestra el número total de jugadores en espera y los nombres de cada uno.
         */
        public string ImprimirLista()
        {
            if (waitListJugador.Count == 0)
            {
                return "No hay jugadores en espera.";
            }

            string result = "Jugadores en espera:\n";
            for (int i = 0; i < waitListJugador.Count; i++)
            {
                result += $"{i + 1}. {waitListJugador[i].DisplayName}\n";
            }
            return result;
        }

        /**
         * @brief Busca un jugador por su nombre de pantalla.
         * 
         * @param displayName El nombre de pantalla del jugador.
         * @return El jugador encontrado o `null` si no se encuentra.
         */
        public Trainer? FindTrainerByDisplayName(string displayName)
        {
            return waitListJugador.FirstOrDefault(jug => jug.DisplayName == displayName);
        }

        /**
         * @brief Elimina un jugador de la lista de espera.
         * 
         * @param displayName El nombre de pantalla del jugador a eliminar.
         * @return `true` si el jugador fue eliminado, `false` de lo contrario.
         */
        public bool RemoveTrainer(string displayName)
        {
            Trainer? trainer = FindTrainerByDisplayName(displayName);
            if (trainer == null) return false;
            waitListJugador.Remove(trainer);
            return true;
        }
    }
}