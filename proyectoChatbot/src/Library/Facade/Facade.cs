using System;
using System.Collections.Generic;
using Library.Clases; // Espacio de nombres donde están Jugador, Turno, WaitList
using Library.Items;  // Espacio de nombres donde están IItem y las implementaciones como Revivir, Superpocion

namespace Library
{
    /**
     * @class BattleFacade
     * @brief Clase que actúa como una interfaz simplificada para manejar las operaciones de la batalla.
     *
     * La clase BattleFacade proporciona métodos para gestionar la selección de Pokémon, ataques, 
     * uso de ítems, y otros elementos necesarios en el flujo de la batalla.
     */
    public class BattleFacade
    {
        private WaitList _waitList = new WaitList();
        private Turno _currentTurn;
        private SelectorPokemon _selectorPokemon = new SelectorPokemon(); // Instancia de SelectorPokemon para manejar la selección de Pokémon

        /**
         * @brief Muestra los Pokémon disponibles para seleccionar.
         *
         * Historia de usuario 1: Seleccionar Pokémons.
         */
        public void MostrarPokemonsDisponibles()
        {
            _selectorPokemon.MostrarPokemonsDisponibles();
        }

        /**
         * @brief Permite a un jugador seleccionar sus Pokémon.
         *
         * @param jugador El jugador que seleccionará sus Pokémon.
         * Historia de usuario 1: Seleccionar Pokémons.
         */
        public void SeleccionarPokemonsParaJugador(Jugador jugador)
        {
            _selectorPokemon.SeleccionarPokemonsParaJugador(jugador);
        }

        /**
         * @brief Muestra los ataques disponibles del Pokémon activo del jugador.
         *
         * @param jugador El jugador cuyos ataques se mostrarán.
         * Historia de usuario 2: Ver ataques disponibles de los Pokémon.
         */
        public void MostrarAtaquesDisponibles(Jugador jugador)
        {
            Console.WriteLine("Ataques disponibles:");
            jugador.PokemonActivo.GetAtaquesBasicos();
            Console.WriteLine("Ataques Especiales:");
            jugador.PokemonActivo.GetAtaqueEspecial();
        }

        /**
         * @brief Muestra la cantidad de vida (HP) de los Pokémon activos de ambos jugadores.
         *
         * Historia de usuario 3: Ver la cantidad de vida (HP) de los Pokémon.
         */
        public void MostrarVida()
        {
            Console.WriteLine($"{_currentTurn.JugadorActual.Nombre} HP: {_currentTurn.JugadorActual.PokemonActivo.VidaActual}/{_currentTurn.JugadorActual.PokemonActivo.VidaMax}");
            Console.WriteLine($"{_currentTurn.JugadorRival.Nombre} HP: {_currentTurn.JugadorRival.PokemonActivo.VidaActual}/{_currentTurn.JugadorRival.PokemonActivo.VidaMax}");
        }

        /**
         * @brief Realiza un ataque del jugador actual al jugador rival.
         *
         * Historia de usuario 4: Atacar en el turno y hacer daño.
         */
        public void Atacar()
        {
            _currentTurn.JugadorActual.Atacar(_currentTurn.JugadorRival);
            if (_currentTurn.BatallaFinalizada())
            {
                Console.WriteLine($"La batalla ha terminado. Ganador: {_currentTurn.JugadorActual.Nombre}");
                _currentTurn = null;
            }
        }

        /**
         * @brief Muestra de quién es el turno actual.
         *
         * Historia de usuario 5: Conocer de quién es el turno.
         */
        public void MostrarTurnoActual()
        {
            Console.WriteLine($"Es el turno de {_currentTurn.JugadorActual.Nombre}.");
        }

        /**
         * @brief Verifica si la batalla ha finalizado.
         *
         * @return `true` si la batalla ha terminado, `false` de lo contrario.
         * Historia de usuario 6: Ganar la batalla cuando la vida de todos los Pokémon oponentes llegue a cero.
         */
        public bool BatallaFinalizada()
        {
            if (_currentTurn.BatallaFinalizada())
            {
                Console.WriteLine("La batalla ha finalizado");
                return true;
            }
            Console.WriteLine("La batalla aún no ha finalizado");
            return false;
        }

        /**
         * @brief Cambia el Pokémon activo del jugador actual.
         *
         * @param nombrePokemon El nombre del nuevo Pokémon activo.
         * Historia de usuario 7: Cambiar Pokémon activo.
         */
        public void CambiarPokemonActivo(string nombrePokemon)
        {
            if (_currentTurn != null)
            {
                _currentTurn.JugadorActual.CambiarPokemonActivo(nombrePokemon);
                Console.WriteLine($"{_currentTurn.JugadorActual.Nombre} ha cambiado su pokemon activo a {_currentTurn.JugadorActual.PokemonActivo.Nombre} ");
                _currentTurn.CambiarTurno();
            }
        }

        /**
         * @brief Permite al jugador actual usar un ítem.
         *
         * Historia de usuario 8: Usar un ítem durante una batalla.
         */
        public void UsarItemDelJugador()
        {
            _currentTurn.JugadorActual.UsarItem();
            _currentTurn.CambiarTurno();
        }

        /**
         * @brief Agrega un jugador a la lista de espera para encontrar oponente.
         *
         * @param jugador El jugador que se agregará a la lista de espera.
         * Historia de usuario 9: Unirse a la lista de jugadores esperando por un oponente.
         */
        public void AgregarJugadorALaListaDeEspera(Jugador jugador) => Console.WriteLine(_waitList.SalaDeEspera(jugador));

        /**
         * @brief Muestra la lista de jugadores en espera.
         *
         * Historia de usuario 10: Ver la lista de jugadores esperando por un oponente.
         */
        public void MostrarListaDeEspera() => _waitList.ImprimirLista();

        /**
         * @brief Inicia una batalla entre dos jugadores en la lista de espera.
         *
         * Historia de usuario 11: Iniciar una batalla con un jugador en espera.
         */
        public void IniciarBatalla()
        {
            _waitList.StartBattle();
            if (_waitList.WaitListJugador.Count >= 2)
            {
                var jugador1 = _waitList.WaitListJugador[0];
                var jugador2 = _waitList.WaitListJugador[1];
                _currentTurn = new Turno(jugador1, jugador2);
                Console.WriteLine("¡Batalla iniciada!");
                MostrarTurnoActual();
            }
        }
    }
}
