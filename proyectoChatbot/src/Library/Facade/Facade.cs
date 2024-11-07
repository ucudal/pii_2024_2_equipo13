using System;
using System.Collections.Generic;
using Library.Clases; // Espacio de nombres donde están Jugador, Turno, WaitList
using Library.Items;  // Espacio de nombres donde están IItem y las implementaciones como Revivir, Superpocion

namespace Library
{
    public class BattleFacade
    {
        private WaitList _waitList = new WaitList();
        private Turno _currentTurn;
        private SelectorPokemon _selectorPokemon = new SelectorPokemon(); // Instancia de SelectorPokemon para manejar la selección de Pokémon

        // Historia de usuario 1: Seleccionar Pokémons
        public void MostrarPokemonsDisponibles()
        {
            _selectorPokemon.MostrarPokemonsDisponibles();
        }

        // Historia de usuario 1: Seleccionar Pokémons
        public void SeleccionarPokemonsParaJugador(Jugador jugador)
        {
            _selectorPokemon.SeleccionarPokemonsParaJugador(jugador);
        }

        // Historia de usuario 2: Como jugador, quiero ver los ataques disponibles de mis Pokémons para poder elegir cuál usar en cada turno.
        public void MostrarAtaquesDisponibles(Jugador jugador)
        {
            Console.WriteLine("Ataques disponibles:");
            jugador.PokemonActivo.GetAtaquesBasicos();
            if (_currentTurn.ValidarAtaqueEspecial())
                jugador.PokemonActivo.GetAtaqueEspecial();
        }

        // Historia de usuario 3:  Como jugador, quiero ver la cantidad de vida (HP) de mis Pokémons y de los Pokémons oponentes para saber cuánta salud tienen
        public void MostrarVida()
        {
            Console.WriteLine($"{_currentTurn.JugadorActual.Nombre} HP: {_currentTurn.JugadorActual.PokemonActivo.VidaActual}/{_currentTurn.JugadorActual.PokemonActivo.VidaMax}");
            Console.WriteLine($"{_currentTurn.JugadorRival.Nombre} HP: {_currentTurn.JugadorRival.PokemonActivo.VidaActual}/{_currentTurn.JugadorRival.PokemonActivo.VidaMax}");
        }

        // Historia de usuario 4: Como jugador, quiero atacar en mi turno y hacer daño basado en la efectividad de los tipos de Pokémon.
        public void EjecutarAtaque(bool esEspecial)
        {
            _currentTurn.JugadorActual.Atacar(_currentTurn.JugadorRival);
            MostrarVida();
            if (_currentTurn.BatallaFinalizada())
            {
                Console.WriteLine($"La batalla ha terminado. Ganador: {_currentTurn.JugadorActual.Nombre}");
                _currentTurn = null;
            }
        }

        // Historia de usuario 5: Como jugador, quiero saber de quién es el turno para estar seguro de cuándo atacar o esperar.
        public void MostrarTurnoActual()
        {
            Console.WriteLine($"Es el turno de {_currentTurn.JugadorActual.Nombre}.");
        }

        // Historia de usuario 6: Como jugador, quiero ganar la batalla cuando la vida de todos los Pokémons oponente llegue a cero.
        public bool BatallaFinalizada()
        {
            if (_currentTurn.BatallaFinalizada())
            {
                Console.WriteLine("La batalla ha finalizado");
                return true;
            }
            Console.WriteLine("La batalla aun no ha finalizado");
            return false;
        }

        // Historia de usuario 7: Cambiar Pokémon activo
        public void CambiarPokemonActivo(string nombrePokemon)
        {
            if (_currentTurn != null)
            {
                _currentTurn.JugadorActual.CambiarPokemonActivo( nombrePokemon);
                _currentTurn.CambiarTurno();
            }
        }

        // Historia de usuario 8: Como entrenador, quiero poder usar un ítem durante una batalla.
        public void UsarItemDelJugador(string item, string nombrePokemon)
        {
            _currentTurn.JugadorActual.UsarItem();
            _currentTurn.CambiarTurno();
        }

        // Historia de usuario 9: Como entrenador, quiero unirme a la lista de jugadores esperando por un oponente
        public void AgregarJugadorALaListaDeEspera(Jugador jugador) => Console.WriteLine(_waitList.SalaDeEspera(jugador));

        // Historia de usuario 10: Como entrenador, quiero ver la lista de jugadores esperando por un oponente.
        public void MostrarListaDeEspera() => _waitList.ImprimirLista();

        // Historia de usuario 11: Como entrenador, quiero iniciar una ballata con un jugador que está esperando por un oponente.
        public void IniciarBatalla()
        {
            _waitList.StartBattle();
            if (_waitList.WaitListJugador.Count >= 2)
            {
                var jugador1 = _waitList.WaitListJugador[0];
                var jugador2 = _waitList.WaitListJugador[1];
                _currentTurn = new Turno(jugador1, jugador2);
                MostrarTurnoActual();
            }
        }
    
        
    }
}
