
using Ucu.Poo.DiscordBot.Domain;

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
        public Trainer JugadorActual { get; private set; }

        /**
         * @brief Jugador que espera en este turno.
         */
        public Trainer JugadorRival { get; private set; }

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
        public Turno(Trainer jugador1, Trainer jugador2)
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
            if (JugadorActual.PokemonActivo.AptoParaBatalla==false)
            {
                JugadorActual.CambiarPokemon();
            }
            if (JugadorRival.PokemonActivo.EstaDormido)
            {
                JugadorActual.PokemonActivo.ReducirTurnoDormido();
            }
            if (JugadorActual.PokemonActivo.EstaQuemado)
            {
                JugadorActual.PokemonActivo.AplicarDañoQuemadura();
            }

            if (JugadorActual.PokemonActivo.EstaEnvenenado)
            {
                JugadorActual.PokemonActivo.AplicarDañoVeneno();
            }
            
            if (Finalizado)
            {
                Trainer temp = JugadorActual;
                JugadorActual.ContadorTurnos++;
                JugadorActual = JugadorRival;
                JugadorRival = temp;
                Finalizado = false;

                Console.WriteLine($"Ahora es el turno de {JugadorActual.DisplayName}. Turno del jugador: {JugadorActual.ContadorTurnos}");
            }
        }
       
        
        public void Rendirse()
        {
            Finalizado = true;
        }

        /**
         * @brief Marca el turno como finalizado.
         */
        public void FinalizarTurno()
        {
            Finalizado = true;
            Console.WriteLine($"Turno finalizado para {JugadorActual.DisplayName}.");
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
            int numeroTurno = JugadorActual.ContadorTurnos;
            return numeroTurno > 1 && numeroTurno % 2 == 0;;
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
            bool jugadorActualSinPokemons = JugadorActual.Pokemons.All(p => !p.AptoParaBatalla);
            bool jugadorRivalSinPokemons = JugadorRival.Pokemons.All(p => !p.AptoParaBatalla);
    
            return jugadorRivalSinPokemons || jugadorActualSinPokemons;
        }
    }
}
