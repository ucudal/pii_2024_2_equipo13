using Library.Clases;
using Ucu.Poo.DiscordBot.Commands;
using Discord.Commands;
using Library;
using Library.Items;
using Library.Pokemons;

namespace Ucu.Poo.DiscordBot.Domain
{
    /**
     * @brief La clase Facade proporciona métodos simplificados para manejar la lista de espera, iniciar batallas y realizar acciones durante una batalla.
     */
    public class Facade
    {
        private static Facade? _instance;

        private readonly WaitList _waitList;
        private Turno? _currentTurn;
        private readonly SelectorPokemon _selectorPokemon;
        private readonly PokemonNameCommand _pokemonNameCommand;
        public List<Pokemon> PokemonsDisponibles => _selectorPokemon.PokemonsDisponibles;

        /**
         * @brief Constructor privado para evitar instanciación externa.
         */
        private Facade()
        {
            _waitList = new WaitList();
            _selectorPokemon = new SelectorPokemon();
        }

        /**
         * @brief Obtiene la única instancia de la clase Facade.
         * @return La instancia única de Facade.
         */
        public static Facade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facade();
                }
                return _instance;
            }
        }

        /**
         * @brief Restablece la instancia para uso en pruebas u otras operaciones.
         */
        public static void Reset()
        {
            _instance = null;
        }

        /**
         * @brief Agrega un entrenador a la lista de espera.
         * @param displayName El nombre del entrenador.
         * @return Un mensaje indicando que el entrenador ha sido agregado a la lista de espera.
         */
        public string AddTrainerToWaitingList(string displayName)
        {
            Trainer jugador = new Trainer(displayName);
            return _waitList.AñadirTrainer(jugador);
        }

        /**
         * @brief Elimina un entrenador de la lista de espera.
         * @param displayName El nombre del entrenador.
         * @return Un mensaje indicando que el entrenador ha sido eliminado de la lista de espera.
         */
        public string RemoveTrainerFromWaitingList(string displayName)
        {
            return _waitList.RemoveTrainer(displayName) ? $"{displayName} removido de la lista de espera" : $"{displayName} no está en la lista de espera";
        }

        /**
         * @brief Obtiene todos los entrenadores en la lista de espera.
         * @return Una cadena con la lista de entrenadores en espera.
         */
        public string GetAllTrainersWaiting()
        {
            return _waitList.ImprimirLista();
        }

        /**
         * @brief Obtiene un entrenador por su nombre de pantalla.
         * @param displayName El nombre de pantalla del entrenador.
         * @return El entrenador encontrado o null si no se encuentra.
         */
        public Trainer GetTrainerByDisplayName(string displayName)
        {
            return _waitList.WaitListJugador.FirstOrDefault(t => t.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase));
        }

        /**
         * @brief Verifica si un entrenador está en la lista de espera.
         * @param displayName El nombre de pantalla del entrenador.
         * @return Un mensaje indicando si el entrenador está en la lista de espera.
         */
        public string TrainerIsWaiting(string displayName)
        {
            return _waitList.FindTrainerByDisplayName(displayName) != null ? $"{displayName} está en la lista de espera" : $"{displayName} no está en la lista de espera";
        }

        /**
         * @brief Muestra los Pokémon disponibles.
         */
        public void MostrarPokemonsDisponibles()
        {
            _selectorPokemon.MostrarPokemonsDisponibles();
        }

        /**
         * @brief Muestra los ataques disponibles para el Pokémon activo de un entrenador.
         * @param displayName El nombre de pantalla del entrenador.
         * @return Una cadena con los ataques disponibles.
         */
        public string MostrarAtaquesDisponibles(string displayName)
        {
            Trainer jugador = _waitList.FindTrainerByDisplayName(displayName);
            if (jugador != null)
            {
                string ataquesBasicos = jugador.PokemonActivo.GetAtaquesBasicos();
                string ataquesEspeciales = jugador.PokemonActivo.GetAtaqueEspecial();
                return $"Ataques disponibles para {displayName}:\n- Ataques básicos:\n{ataquesBasicos}\n- Ataques especiales:\n{ataquesEspeciales}";
            }
            return "No se pudo determinar los ataques disponibles";
        }

        /**
         * @brief Muestra los ítems disponibles para un entrenador.
         * @param displayName El nombre de pantalla del entrenador.
         * @return Una cadena con los ítems disponibles.
         */
        public string MostrarItemsDisponibles(string displayName)
        {
            Trainer jugador = _waitList.FindTrainerByDisplayName(displayName);
            if (jugador != null)
            {
                string items = jugador.GetItems();
                int superpociones = jugador.ItemsJugador.Count(item => item is Superpocion);
                int revivir = jugador.ItemsJugador.Count(item => item is Revivir);
                int curatotal = jugador.ItemsJugador.Count(item => item is CuraTotal);
                return $"\nItems disponibles para {displayName}:\n{items}" +
                       $"\nCantidad de superpociones: {superpociones}" +
                       $"\nCantidad de revivir: {revivir}" +
                       $"\nCantidad de cura total: {curatotal}";
            }
            return "No se pudo determinar los items disponibles";
        }

        /**
         * @brief Obtiene un oponente en batalla para un entrenador.
         * @param displayName El nombre de pantalla del entrenador.
         * @return El oponente encontrado o null si no se encuentra.
         */
        public Trainer? ObtenerOponenteEnBatalla(string displayName)
        {
            if (_currentTurn == null)
            {
                return null;
            }

            if (_currentTurn.JugadorActual.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase))
            {
                return _currentTurn.JugadorRival;
            }
            else if (_currentTurn.JugadorRival.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase))
            {
                return _currentTurn.JugadorActual;
            }

            return null;
        }

        /**
         * @brief Selecciona un Pokémon para un jugador.
         * @param displayName El nombre de pantalla del jugador.
         * @param pokemonName El nombre del Pokémon a seleccionar.
         * @param context El contexto del comando.
         * @return true si el Pokémon fue seleccionado exitosamente, false de lo contrario.
         */
        public async Task<bool> SelectPokemonForPlayer(string displayName, string pokemonName, ICommandContext context)
        {
            Trainer player = _waitList.FindTrainerByDisplayName(displayName);

            if (player != null)
            {
                try
                {
                    Pokemon clonedPokemon = _selectorPokemon.SeleccionarPokemon(pokemonName);

                    if (!player.Pokemons.Contains(clonedPokemon) && player.Pokemons.Count < 6)
                    {
                        player.pokebolasInventario(clonedPokemon);

                        if (player.Pokemons.Count == 1)
                        {
                            player.PokemonActivo = clonedPokemon;
                        }

                        return true;
                    }
                }
                catch (ArgumentException ex)
                {
                    await context.Channel.SendMessageAsync(ex.Message);
                }
            }

            return false;
        }

        /**
         * @brief Obtiene un entrenador aleatorio de la lista de espera.
         * @param excludeDisplayName El nombre de pantalla del entrenador a excluir.
         * @return Un entrenador aleatorio o null si la lista está vacía.
         */
        public Trainer? ObtenerTrainerRandom(string excludeDisplayName)
        {
            var trainersDisponibles = _waitList.WaitListJugador.Where(t => t.DisplayName != excludeDisplayName).ToList();
            if (trainersDisponibles.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int index = random.Next(trainersDisponibles.Count);
            return trainersDisponibles[index];
        }

        /**
         * @brief Inicia una batalla entre dos entrenadores.
         * @param displayName El nombre de pantalla del primer entrenador.
         * @param opponentDisplayName El nombre de pantalla del oponente (opcional).
         * @return Un mensaje indicando el estado de la batalla.
         */
        public string IniciarBatalla(string displayName, string? opponentDisplayName = null)
        {
            Trainer jugador1 = _waitList.FindTrainerByDisplayName(displayName);
            Trainer jugador2 = null;

            if (jugador1 == null || jugador1.Pokemons.Count != 6)
            {
                return "No tienes un equipo completo para iniciar una batalla.";
            }

            if (opponentDisplayName != null)
            {
                jugador2 = _waitList.FindTrainerByDisplayName(opponentDisplayName);
                if (jugador2 == null || jugador2.Pokemons.Count != 6)
                {
                    return "El oponente seleccionado no tiene un equipo completo para iniciar una batalla.";
                }
            }
            else
            {
                jugador2 = _waitList.WaitListJugador
                    .FirstOrDefault(t => t.DisplayName != displayName && t.Pokemons != null && t.Pokemons.Count == 6);

                if (jugador2 == null)
                {
                    return "No hay oponentes disponibles para iniciar una batalla.";
                }
            }

            if (_currentTurn != null && (_currentTurn.JugadorActual == jugador1 || _currentTurn.JugadorRival == jugador1 || _currentTurn.JugadorActual == jugador2 || _currentTurn.JugadorRival == jugador2))
            {
                return "Ya hay una batalla en curso.";
            }

            _currentTurn = new Turno(jugador1, jugador2);

            string batallaIniciada = $"¡Batalla iniciada entre {jugador1.DisplayName} y {jugador2.DisplayName}!\n";
            batallaIniciada += NotificarTurnoJugadorActual();
            batallaIniciada += "\n # Opciones disponibles:\n"
                               + "**!`ataques`**: Muestra los ataques disponibles para el Pokémon activo.\n" +
                               "\n" +
                               "**`!ataquebasico`**: Realiza el ataque básico seleccionado, con el Pokémon activo. " +
                               "\n**`Ejemplo`:** **`!ataquebasico 1`**\n" +
                               "\n" +
                               "**`!ataqueespecial`**: Realiza el ataque especial seleccionado, si es posible, con el Pokémon activo. " +
                               "\n**`Ejemplo`:** **`!ataqueespecial 1`**\n" +
                               "\n" +
                               "**`!Cambiar`**: Cambia el Pokémon activo por el ingresado. " +
                               "\n**`Ejemplo`:** **`!Cambiar Pikachu`**\n" +
                               "\n" +
                               "**!`items`**: Muestra los items del jugador disponibles.\n" +
                               "\n" +
                               "**!`item`**: Se usa el item seleccioando,(correspondiente al numero), para el pokemon seleccionado.\n" +
                               "**`Ejemplo`:** **`!item 1 Pikachu`**\n" +
                               "\n" +
                               "**!`vida`**: Verás la vida de tus Pokemon.\n" +
                               "\n" +
                               "**!`vidaoponente`**: Verás la vida de los Pokemon de tus oponentes.\n" +
                               "\n" +
                               "**!`rendir`**: Si quieres, puedes rendirte en la batalla.\n";

            return batallaIniciada;
        }

        /**
         * @brief Notifica el turno del jugador actual.
         * @return Un mensaje indicando el turno del jugador actual.
         */
        public string NotificarTurnoJugadorActual()
        {
            if (_currentTurn == null)
            {
                return "No hay una batalla en curso.";
            }

            Trainer jugadorActual = _currentTurn.JugadorActual;
            return $"Es el turno de {jugadorActual.DisplayName}.";
        }

        /**
         * @brief Realiza un ataque básico.
         * @param atacante El entrenador atacante.
         * @param oponente El entrenador oponente.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Un mensaje con el resultado del ataque.
         */
        public string AtacarBasico(Trainer atacante, Trainer oponente, int ataqueSeleccionado)
        {
            if (_currentTurn == null || _currentTurn.JugadorActual != atacante || _currentTurn.JugadorRival != oponente)
            {
                return "Uno o ambos jugadores no están disponibles para atacar.";
            }

            if (_currentTurn.JugadorActual != atacante)
            {
                return "No es tu turno.";
            }
            if (!atacante.PokemonActivo.AtaquesBasicosPublicos.ContainsKey(ataqueSeleccionado))
            {
                return "Ataque básico inválido. Por favor, selecciona un ataque válido.";
            }
            string resultado = atacante.AtacarBasico(oponente, ataqueSeleccionado);

            _currentTurn.FinalizarTurno();
            _currentTurn.CambiarTurno();
            string estadoBatalla = VerificarBatalla();
            if (estadoBatalla.Contains("La batalla ha terminado"))
            {
                _currentTurn = null;
                Reset();
                return resultado + "\n" + estadoBatalla;
            }
            resultado += $"\nEs el turno de {_currentTurn.JugadorActual.DisplayName}. Turnos del jugador {_currentTurn.JugadorActual.ContadorTurnos}." +
                         $"\nPokemon Actual de {_currentTurn.JugadorActual.DisplayName}: {_currentTurn.JugadorActual.PokemonActivo.PokemonName} - Vida: {_currentTurn.JugadorActual.PokemonActivo.VidaActual}/{_currentTurn.JugadorActual.PokemonActivo.VidaMax} HP";

            return resultado;
        }

        /**
         * @brief Realiza un ataque especial.
         * @param atacante El entrenador atacante.
         * @param oponente El entrenador oponente.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Un mensaje con el resultado del ataque.
         */
        public string AtacarEspecial(Trainer atacante, Trainer oponente, int ataqueSeleccionado)
        {
            if (!_currentTurn.ValidarAtaqueEspecial())
            {
                return "No puede usar un ataque especial en este Turno";
            }

            if (atacante == null || oponente == null)
            {
                return "Uno o ambos jugadores no están disponibles para atacar.";
            }
            if (_currentTurn == null || _currentTurn.JugadorActual.DisplayName != atacante.DisplayName)
            {
                return "No es tu turno.";
            }

            if (!atacante.PokemonActivo.AtaquesEspecialesPublicos.ContainsKey(ataqueSeleccionado))
            {
                return "Ataque especial inválido. Por favor, selecciona un ataque especial valido.";
            }
    
            string resultado = atacante.AtacarEspecial(oponente, ataqueSeleccionado);

            if (_currentTurn != null)
            {
                _currentTurn.FinalizarTurno();
                _currentTurn.CambiarTurno();
                string estadoBatalla = VerificarBatalla();
                if (estadoBatalla.Contains("La batalla ha terminado"))
                {
                    _currentTurn = null;
                    Reset();
                    return resultado + "\n" + estadoBatalla;
                }
                resultado += $"\nEs el turno de {_currentTurn.JugadorActual.DisplayName} Turnos del jugador {_currentTurn.JugadorActual.ContadorTurnos}." +
                             $"\nPokemon Actual de {_currentTurn.JugadorActual.DisplayName}: {_currentTurn.JugadorActual.PokemonActivo.PokemonName} - Vida: {_currentTurn.JugadorActual.PokemonActivo.VidaActual}/{_currentTurn.JugadorActual.PokemonActivo.VidaMax} HP";
            }

            return resultado;
        }

        /**
         * @brief Realiza una acción durante la batalla.
         * @param displayName El nombre de pantalla del entrenador.
         * @param accion La acción a realizar.
         * @param itemOpcion La opción del ítem a usar (opcional).
         * @param nombrePokemon El nombre del Pokémon (opcional).
         * @return Un mensaje con el resultado de la acción.
         */
        public string RealizarAccion(string displayName, string accion, string? itemOpcion = null, string? nombrePokemon = null)
        {
            if (_currentTurn == null || _currentTurn.JugadorActual.DisplayName != displayName)
            {
                return "No es tu turno.";
            }

            string resultadoAccion;

            switch (accion.ToLower())
            {
                case "cambiar":
                    if (nombrePokemon == null)
                    {
                        return "Debes especificar el nombre del Pokémon para cambiar.";
                    }

                    resultadoAccion = _currentTurn.JugadorActual.CambiarPokemonActivo(nombrePokemon, true);
                    if (resultadoAccion.Contains("no fue encontrado en la lista de Pokémon.") || resultadoAccion.Contains("ya es tu Pokémon activo") || resultadoAccion.Contains("no está apto para la batalla."))
                    {
                        return resultadoAccion + " Por favor, intenta de nuevo.";
                    }
                    break;
                case "item":
                    if (itemOpcion == null || nombrePokemon == null)
                    {
                        return "Debes especificar el ítem y el nombre del Pokémon para usar el ítem.";
                    }
                    resultadoAccion = _currentTurn.JugadorActual.UsarItem(itemOpcion, nombrePokemon);
                    if (resultadoAccion.Contains("No quedan") || resultadoAccion.Contains("Pokémon no encontrado") || resultadoAccion.Contains("no está apto para la batalla"))
                    {
                        return resultadoAccion + " Por favor, intenta de nuevo.";
                    }
                    break;
                default:
                    return "Acción inválida. Usa: atacar, cambiar o item.";
            }

            _currentTurn.FinalizarTurno();
            _currentTurn.CambiarTurno();

            if (_currentTurn.BatallaFinalizada())
            {
                _currentTurn = null;
                Reset();
                return $"La batalla ha terminado. Ganador: {_currentTurn.JugadorRival.DisplayName}";
            }

            return resultadoAccion + $"\nEs el turno de {_currentTurn.JugadorActual.DisplayName} Turnos del jugador {_currentTurn.JugadorActual.ContadorTurnos}.";
        }

        /**
         * @brief Marca la rendición de un entrenador.
         * @param displayName El nombre de pantalla del entrenador.
         * @return Un mensaje indicando que el entrenador se ha rendido.
         */
        public string Rendirse(string displayName)
        {
            if (_currentTurn == null || _currentTurn.JugadorActual.DisplayName != displayName)
            {
                return "No es tu turno.";
            }

            string rivalDisplayName = _currentTurn.JugadorRival.DisplayName;
            _currentTurn.Rendirse();
            _currentTurn = null;
            
            Reset();
            return $"El jugador {displayName} se ha rendido. Ganador: {rivalDisplayName}";
        }

        /**
         * @brief Verifica el estado de la batalla.
         * @return Un mensaje indicando el estado de la batalla.
         */
        public string VerificarBatalla()
        {
            Trainer jugador1 = _currentTurn.JugadorActual;
            Trainer jugador2 = _currentTurn.JugadorRival;
            bool jugador1SinOpciones = jugador1.Pokemons.All(p => !p.AptoParaBatalla) && jugador1.ItemsJugador.All(item => item is not Revivir);
            bool jugador2SinOpciones = jugador2.Pokemons.All(p => !p.AptoParaBatalla) && jugador2.ItemsJugador.All(item => item is not Revivir);
            
            if (jugador1SinOpciones && jugador2SinOpciones)
            {
                _currentTurn = null;
                Reset();
                return $"La batalla ha terminado. Ambos jugadores no tienen más opciones.";
            }
            if (jugador1SinOpciones)
            {
                _currentTurn = null;
                Reset();
                return $"La batalla ha terminado. Ganador: {jugador2.DisplayName}.";
            }
            if (jugador2SinOpciones)
            {
                _currentTurn = null;
                Reset();
                return $"La batalla ha terminado. Ganador: {jugador1.DisplayName}.";
            }

            return "La batalla continúa. Ambos jugadores tienen opciones.";
        }
    }
}