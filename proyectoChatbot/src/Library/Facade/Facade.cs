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

        // Historia de usuario 2: Mostrar ataques disponibles
        public void MostrarAtaquesDisponibles(Jugador jugador)
        {
            Console.WriteLine("Ataques disponibles:");
            jugador.PokemonActivo.GetAtaquesBasicos();
            if (_currentTurn.ValidarAtaqueEspecial())
                jugador.PokemonActivo.GetAtaqueEspecial();
        }

        // Historia de usuario 3: Mostrar vida de los  de Pokémons
        public void MostrarVida()
        {
            Console.WriteLine($"{_currentTurn.JugadorActual.Nombre} HP: {_currentTurn.JugadorActual.PokemonActivo.VidaActual}/{_currentTurn.JugadorActual.PokemonActivo.VidaMax}");
            Console.WriteLine($"{_currentTurn.JugadorRival.Nombre} HP: {_currentTurn.JugadorRival.PokemonActivo.VidaActual}/{_currentTurn.JugadorRival.PokemonActivo.VidaMax}");
        }

        // Historia de usuario 4: Atacar
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

        // Historia de usuario 5: Mostrar turno actual
        public void MostrarTurnoActual()
        {
            Console.WriteLine($"Es el turno de {_currentTurn.JugadorActual.Nombre}.");
        }

        // Historia de usuario 6: Verificar si la batalla ha terminado
        public bool BatallaFinalizada() => _currentTurn == null;

        // Historia de usuario 7: Cambiar Pokémon activo
        public void CambiarPokemonActivo(string nombrePokemon)
        {
            if (_currentTurn != null)
            {
                _currentTurn.JugadorActual.CambiarPokemonActivo(_currentTurn.JugadorActual, nombrePokemon);
                CambiarTurno();
            }
        }

        // Historia de usuario 8: Usar ítem
        public void UsarItemDelJugador(string item, string nombrePokemon)
        {
            _currentTurn.JugadorActual.UsarItem(_currentTurn.JugadorActual);
            CambiarTurno();
        }

        // Historia de usuario 9: Agregar a la lista de espera
        public void AgregarJugadorALaListaDeEspera(Jugador jugador) => Console.WriteLine(_waitList.SalaDeEspera(jugador));

        // Historia de usuario 10: Mostrar lista de espera
        public void MostrarListaDeEspera() => _waitList.ImprimirLista();

        // Historia de usuario 11: Iniciar batalla con jugador en espera
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

        private void CambiarTurno()
        {
            _currentTurn.FinalizarTurno();
            _currentTurn.CambiarTurno();
            MostrarTurnoActual();
        }
    }
}
