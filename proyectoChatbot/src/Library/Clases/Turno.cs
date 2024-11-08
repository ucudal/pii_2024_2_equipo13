using Library.Items;
using Library.Pokemons;

namespace Library.Clases
{
    /**
     * @class Turno
     * @brief Clase que gestiona el turno de cada jugador en una batalla.
     *
     * La clase Turno se encarga de alternar los turnos entre dos jugadores, gestionar
     * el estado de finalización del turno y verificar si la batalla ha terminado.
     */
    public class Turno
    {
        /** 
         * @brief Contador de turnos para el Jugador 1.
         */
        public int TurnosJugador1 { get; private set; }

        /**
         * @brief Contador de turnos para el Jugador 2.
         */
        public int TurnosJugador2 { get; private set; }

        /**
         * @brief Jugador al que le corresponde el turno actual.
         */
        public Jugador JugadorActual { get; private set; }

        /**
         * @brief Jugador que espera en este turno.
         */
        public Jugador JugadorRival { get; private set; }

        /**
         * @brief Estado de finalización del turno.
         */
        public bool Finalizado { get; private set; }

        /**
         * @brief Constructor de la clase Turno.
         *
         * Inicializa el turno con el Jugador 1 como el jugador inicial.
         * 
         * @param jugador1 El primer jugador.
         * @param jugador2 El segundo jugador.
         */
        public Turno(Jugador jugador1, Jugador jugador2)
        {
            this.TurnosJugador1 = 1;
            this.TurnosJugador2 = 1;
            this.JugadorActual = jugador1;
            this.JugadorRival = jugador2;
            this.Finalizado = false;
        }

        /**
         * @brief Cambia el turno entre los jugadores.
         *
         * Intercambia `JugadorActual` con `JugadorRival` y aumenta el número de turno del `JugadorActual`.
         * Lanza una excepción si los jugadores o sus Pokémon activos no están correctamente inicializados.
         */
        public void CambiarTurno()
        {
            if (JugadorActual == null || JugadorRival == null || JugadorActual.PokemonActivo == null || JugadorRival.PokemonActivo == null)
            {
                throw new InvalidOperationException("Los jugadores o sus Pokémon activos no están correctamente inicializados.");
            }

            if (Finalizado)
            {
                Jugador temp = JugadorActual;
                JugadorActual = JugadorRival;
                JugadorRival = temp;

                if (JugadorActual == temp)
                {
                    TurnosJugador1++;
                }
                else
                {
                    TurnosJugador2++;
                }

                Finalizado = false;

                Console.WriteLine($"Ahora es el turno de {JugadorActual.Nombre}. Turno del jugador: {GetNumeroTurnoActual()}");
            }
        }

        /**
         * @brief Marca el turno como finalizado.
         */
        public void FinalizarTurno()
        {
            Finalizado = true;
            Console.WriteLine($"Turno finalizado para {JugadorActual.Nombre}.");
        }

        /**
         * @brief Valida si el ataque especial es permitido.
         *
         * El ataque especial solo es válido en los turnos pares del jugador actual.
         * 
         * @return `true` si el ataque especial es válido, `false` de lo contrario.
         */
        public bool ValidarAtaqueEspecial()
        {
            int numeroTurno = GetNumeroTurnoActual();
            return numeroTurno % 2 == 0;
        }

        /**
         * @brief Obtiene el número de turno actual del `JugadorActual`.
         *
         * @return El número de turno correspondiente al `JugadorActual`.
         */
        private int GetNumeroTurnoActual()
        {
            return JugadorActual == JugadorRival ? TurnosJugador2 : TurnosJugador1;
        }

        /**
         * @brief Verifica si la batalla ha finalizado.
         *
         * La batalla termina si alguno de los jugadores no tiene más Pokémon aptos para la batalla.
         * 
         * @return `true` si la batalla ha finalizado, `false` de lo contrario.
         */
        public bool BatallaFinalizada()
        {
            bool jugadorActualSinPokemon = true;
            foreach (var pokemon in JugadorActual.Pokemons)
            {
                if (pokemon.AptoParaBatalla)
                {
                    jugadorActualSinPokemon = false;
                    break;
                }
            }

            bool jugadorRivalSinPokemon = true;
            foreach (var pokemon in JugadorRival.Pokemons)
            {
                if (pokemon.AptoParaBatalla)
                {
                    jugadorRivalSinPokemon = false;
                    break;
                }
            }

            return jugadorActualSinPokemon || jugadorRivalSinPokemon;
        }
    }
}
