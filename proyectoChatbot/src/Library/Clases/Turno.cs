using Library.Items;
using Library.Pokemons;

namespace Library.Clases
{
    public class Turno
    {
        public int TurnosJugador1 { get; private set; } // Contador de turnos para el Jugador 1
        public int TurnosJugador2 { get; private set; } // Contador de turnos para el Jugador 2
        public Jugador JugadorActual { get; private set; } // Jugador al que le corresponde el turno actual
        public Jugador JugadorRival { get; private set; } // Jugador que espera en este turno
        public bool Finalizado { get; private set; } // Estado de finalización del turno

        // Constructor que recibe dos jugadores e inicializa el turno con el Jugador 1 como el inicial
        public Turno(Jugador jugador1, Jugador jugador2)
        {
            this.TurnosJugador1 = 1; // Turno inicial del Jugador 1
            this.TurnosJugador2 = 1; // Turno inicial del Jugador 2
            this.JugadorActual = jugador1;
            this.JugadorRival = jugador2;
            this.Finalizado = false;
            
            /*// previene excepcion de Test
            if (jugador1.PokemonActivo == null && jugador1.Pokemons.Any())
            {
                // Asignar el primer Pokémon del jugador si no se ha seleccionado uno aún
                jugador1.PokemonActivo = jugador1.Pokemons.First();
            }

            if (jugador2.PokemonActivo == null && jugador2.Pokemons.Any())
            {
                // Asignar el primer Pokémon del jugador si no se ha seleccionado uno aún
                jugador2.PokemonActivo = jugador2.Pokemons.First();
            }*/
        }

        public void CambiarTurno()
        {
            // Asegurarse de que los jugadores y sus Pokémon activos estén correctamente inicializados
            if (JugadorActual == null || JugadorRival == null || JugadorActual.PokemonActivo == null || JugadorRival.PokemonActivo == null)
            {
                throw new InvalidOperationException("Los jugadores o sus Pokémon activos no están correctamente inicializados.");
            }
            // Cambiar turno: Intercambia JugadorActual con JugadorRival y aumenta el número de turno del JugadorActual
            if (Finalizado)
            {
                // Intercambia las referencias entre los jugadores
                Jugador temp = JugadorActual;
                JugadorActual = JugadorRival;
                JugadorRival = temp;

                // Incrementa el número de turno del jugador actual
                if (JugadorActual == temp)
                {
                    TurnosJugador1++;
                }
                else
                {
                    TurnosJugador2++;
                }

                Finalizado = false; // Marca el nuevo turno como no finalizado

                Console.WriteLine($"Ahora es el turno de {JugadorActual.Nombre}. Turno del jugador: {GetNumeroTurnoActual()}");
            }
        }
        

        public void FinalizarTurno()
        {
            Finalizado = true; // Marca el turno como finalizado
            Console.WriteLine($"Turno finalizado para {JugadorActual.Nombre}.");
        } 
        public bool ValidarAtaqueEspecial()
        {
            // Determina si el ataque especial es válido basado en el número de turnos del jugador actual
            int numeroTurno = GetNumeroTurnoActual();
            return numeroTurno % 2 == 0;
        }

        private int GetNumeroTurnoActual()
        {
            // Devuelve el número de turno correspondiente al JugadorActual
            return JugadorActual == JugadorRival ? TurnosJugador2 : TurnosJugador1;
        }

        public bool BatallaFinalizada()
        {
            // La batalla finaliza si algún jugador no tiene más Pokémon con vida
            bool jugadorActualSinPokemon = true;
            foreach (var pokemon in JugadorActual.Pokemons)
            {
                if (pokemon.AptoParaBatalla)
                {
                    jugadorActualSinPokemon = false;
                    break; // Salir del bucle si se encuentra un Pokémon apto
                }
            }

            // Verificar si JugadorRival no tiene Pokémon aptos para la batalla
            bool jugadorRivalSinPokemon = true;
            foreach (var pokemon in JugadorRival.Pokemons)
            {
                if (pokemon.AptoParaBatalla)
                {
                    jugadorRivalSinPokemon = false;
                    break; // Salir del bucle si se encuentra un Pokémon apto
                }
            }

            // La batalla termina si uno de los jugadores no tiene Pokémon disponibles
            return jugadorActualSinPokemon || jugadorRivalSinPokemon;
        }
    }
}
