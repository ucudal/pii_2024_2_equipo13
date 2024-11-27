using Library;
using Library.Items;
using Ucu.Poo.DiscordBot.Commands;

namespace Ucu.Poo.DiscordBot.Domain
{
    /**
     * @brief Clase que representa un entrenador en el juego Pokémon.
     */
    public class Trainer
    {
        /**
         * @brief Lista de Pokémon del entrenador.
         */
        private List<Pokemon> pokemons;

        /**
         * @brief Lista de ítems del entrenador.
         */
        private List<IItem> itemsJugador;

        /**
         * @brief Pokémon activo del entrenador.
         */
        private Pokemon pokemonActivo;

        /**
         * @brief Nombre del entrenador.
         */
        public string DisplayName { get; }

        /**
         * @brief Obtiene o establece la lista de ítems del entrenador.
         */
        public List<IItem> ItemsJugador
        {
            get { return itemsJugador; }
            set { itemsJugador = value; }
        }

        /**
         * @brief Obtiene o establece la lista de Pokémon del entrenador.
         */
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        /**
         * @brief Obtiene o establece el Pokémon activo del entrenador.
         */
        public Pokemon PokemonActivo
        {
            get
            {
                if (pokemonActivo == null && pokemons.Any())
                {
                    pokemonActivo = pokemons.First();
                }
                return pokemonActivo;
            }
            set { pokemonActivo = value; }
        }

        /**
         * @brief Contador de turnos del entrenador.
         */
        private int contadorTurnos;
        public int ContadorTurnos
        {
        
            get { return contadorTurnos; }
            set { contadorTurnos = value; }
        }

        /**
         * @brief Constructor de la clase Trainer.
         * @param nombre El nombre del entrenador.
         */
        public Trainer(string nombre)
        {
            this.DisplayName = nombre;
            this.pokemons = new List<Pokemon>();
            this.PokemonActivo = this.pokemons.FirstOrDefault();
            this.contadorTurnos = 0;
            this.itemsJugador = new List<IItem>
            {
                new Superpocion(),
                new Superpocion(),
                new Superpocion(),
                new Superpocion(),
                new Revivir(),
                new CuraTotal(),
                new CuraTotal()
            };
        }

        /**
         * @brief Realiza un ataque básico al Pokémon activo del oponente.
         * @param oponente El entrenador oponente.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Un mensaje con el resultado del ataque.
         */
        public string AtacarBasico(Trainer oponente, int ataqueSeleccionado)
        {
            if (!PokemonActivo.AptoParaBatalla)
            {
                return $"{DisplayName} no tiene un Pokémon apto para atacar.";
            }
            if (!oponente.PokemonActivo.AptoParaBatalla)
            {
                return $"{oponente.DisplayName} no tiene un Pokémon apto para la batalla. No puede ser atacado.";
            }

            Pokemon objetivo = oponente.PokemonActivo;
            string mensaje;
            double daño = PokemonActivo.AtaqueBasico(objetivo, ataqueSeleccionado, out mensaje);

            if (!objetivo.AptoParaBatalla)
            {
                mensaje += $"\n{oponente.DisplayName} ha perdido a {objetivo.PokemonName}.";
                mensaje += $"\n{oponente.CambiarPokemon()}";
            }

            return mensaje;
        }

        /**
         * @brief Realiza un ataque especial al Pokémon activo del oponente.
         * @param oponente El entrenador oponente.
         * @param ataqueSeleccionado El número del ataque seleccionado.
         * @return Un mensaje con el resultado del ataque.
         */
        public string AtacarEspecial(Trainer oponente, int ataqueSeleccionado)
        {
            if (!PokemonActivo.AptoParaBatalla)
            {
                return $"{DisplayName} no tiene un Pokémon apto para atacar.";
            }
            if (!oponente.PokemonActivo.AptoParaBatalla)
            {
                return $"{oponente.DisplayName} no tiene un Pokémon apto para la batalla. No puede ser atacado.";
            }

            Pokemon objetivo = oponente.PokemonActivo;
            string mensaje;
            double daño = PokemonActivo.AtaqueEspecial(objetivo, ataqueSeleccionado, out mensaje);

            if (!objetivo.AptoParaBatalla)
            {
                mensaje += $"\n{oponente.DisplayName} ha perdido a {objetivo.PokemonName}.";
                mensaje += $"\n{oponente.CambiarPokemon()}";
            }

            return mensaje;
        }

        /**
         * @brief Obtiene los ítems del entrenador.
         * @return Una cadena con los ítems del entrenador.
         */
        public string GetItems()
        {
            HashSet<string> itemsSet = new HashSet<string>();
            string resultado = "";
            int itemNumber = 1;

            foreach (IItem item in this.ItemsJugador)
            {
                if (itemsSet.Add(item.Nombre))
                {
                    resultado += $"{itemNumber}. {item.Nombre} - {item.Descripcion}\n";
                    itemNumber++;
                }
            }

            return resultado;
        }

        /**
         * @brief Usa un ítem en un Pokémon del entrenador.
         * @param opcion La opción del ítem a usar.
         * @param nombrePokemon El nombre del Pokémon en el que se usará el ítem.
         * @return Un mensaje con el resultado del uso del ítem.
         */
        public string UsarItem(string opcion, string? nombrePokemon = null)
        {
            string resultado = "";
            Pokemon pokemonSeleccionado = nombrePokemon == null
                ? this.PokemonActivo
                : this.Pokemons.FirstOrDefault(p => p.PokemonName.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));

            if (opcion == "1")
            {
                IItem superPocion = this.ItemsJugador.FirstOrDefault(item => item is Superpocion);

                if (superPocion == null)
                {
                    resultado = "No quedan Super Pociones en la lista de ítems.";
                }
                else if (pokemonSeleccionado == null)
                {
                    resultado = "Pokémon no encontrado.";
                }
                else if (!pokemonSeleccionado.AptoParaBatalla)
                {
                    resultado = $"{pokemonSeleccionado.PokemonName} no está apto para la batalla. No se puede usar Superpoción.";
                }
                else
                {
                    pokemonSeleccionado.VidaActual += 70;
                    if (pokemonSeleccionado.VidaActual > pokemonSeleccionado.VidaMax)
                    {
                        pokemonSeleccionado.VidaActual = pokemonSeleccionado.VidaMax;
                    }
                    this.ItemsJugador.Remove(superPocion);
                    resultado = $"La superpoción fue usada en {pokemonSeleccionado.PokemonName}.";
                }
            }
            else if (opcion == "2")
            {
                IItem revivir = this.ItemsJugador.FirstOrDefault(item => item is Revivir);

                if (revivir == null)
                {
                    resultado = "No quedan ítems Revivir en la lista.";
                }
                else if (pokemonSeleccionado == null)
                {
                    resultado = "Pokémon no encontrado.";
                }
                else if (pokemonSeleccionado.AptoParaBatalla)
                {
                    resultado = $"{pokemonSeleccionado.PokemonName} está vivo, no es posible usar el ítem Revivir.";
                }
                else
                {
                    pokemonSeleccionado.AptoParaBatalla = true;
                    pokemonSeleccionado.VidaActual = pokemonSeleccionado.VidaMax * 0.5;
                    this.ItemsJugador.Remove(revivir);
                    resultado = $"El ítem Revivir ha sido usado para {pokemonSeleccionado.PokemonName}. Ahora está apto para la batalla.";
                }
            }
            else if (opcion == "3")
            {
                IItem curaTotal = this.ItemsJugador.FirstOrDefault(item => item is CuraTotal);

                if (curaTotal == null)
                {
                    resultado = "No quedan ítems Cura Total en la lista.";
                }
                else if (pokemonSeleccionado == null)
                {
                    resultado = "Pokémon no encontrado.";
                }
                else if (!pokemonSeleccionado.AptoParaBatalla)
                {
                    resultado = $"{pokemonSeleccionado.PokemonName} no está apto para la batalla. No se puede usar Cura Total.";
                }
                else if (pokemonSeleccionado.VidaActual >= 50)
                {
                    resultado = $"{pokemonSeleccionado.PokemonName} tiene 50 o más puntos de vida. No se puede usar Cura Total.";
                }
                else
                {
                    pokemonSeleccionado.VidaActual = pokemonSeleccionado.VidaMax;
                    pokemonSeleccionado.RemoverEfectos();
                    this.ItemsJugador.Remove(curaTotal);
                    resultado = $"El ítem Cura Total ha sido usado en {pokemonSeleccionado.PokemonName}.";
                }
            }
            else
            {
                resultado = "Opción inválida. Selecciona una opción válida: 1 (Superpoción), 2 (Revivir), o 3 (Cura Total).";
            }

            return resultado;
        }

        /**
         * @brief Cambia el Pokémon activo del entrenador.
         * @param nombreNuevoPokemon El nombre del nuevo Pokémon activo.
         * @param esTurno Indica si es el turno del entrenador.
         * @return Un mensaje con el resultado del cambio de Pokémon.
         */
        public string CambiarPokemonActivo(string nombreNuevoPokemon, bool esTurno)
        {
            if (!esTurno)
            {
                return "No es tu turno.";
            }

            Pokemon nuevoPokemon = this.Pokemons.FirstOrDefault(p => p != null && p.PokemonName != null && p.PokemonName.Equals(nombreNuevoPokemon, StringComparison.OrdinalIgnoreCase));

            if (nuevoPokemon == null)
            {
                return $"{nombreNuevoPokemon} no fue encontrado en la lista de Pokémon.";
            }
            if (nuevoPokemon.AptoParaBatalla && nuevoPokemon == this.PokemonActivo)
            {
                return $"{nuevoPokemon.PokemonName} ya es tu Pokémon activo.";
            }
            if (!nuevoPokemon.AptoParaBatalla)
            {
                return $"{nuevoPokemon.PokemonName} no está apto para la batalla.";
            }

            this.PokemonActivo = nuevoPokemon;
            return $"{this.DisplayName} ha cambiado a {nuevoPokemon.PokemonName} como su Pokémon activo. Vida {nuevoPokemon.VidaActual}/{nuevoPokemon.VidaMax}.";
        }

        /**
         * @brief Obtiene el estado de los Pokémon del entrenador.
         * @return Una cadena con el estado de los Pokémon.
         */
        public string ObtenerEstadoPokemons()
        {
            string resultado = "";
            foreach (Pokemon pokemon in this.Pokemons)
            {
                resultado += $"{pokemon.PokemonName} - Vida: {pokemon.VidaActual}/{pokemon.VidaMax} HP\n";
            }
            return resultado;
        }

        /**
         * @brief Agrega un Pokémon al inventario del entrenador.
         * @param pokemon El Pokémon a agregar.
         */
        public void pokebolasInventario(Pokemon pokemon)
        {
            if (!pokemons.Contains(pokemon))
            {
                pokemons.Add(pokemon);
            }
        }

        /**
         * @brief Cambia automáticamente al primer Pokémon apto para la batalla.
         * @return Un mensaje con el resultado del cambio de Pokémon.
         */
        public string CambiarPokemon()
        {
            var pokemonApto = this.Pokemons.FirstOrDefault(p => p.AptoParaBatalla);
            this.PokemonActivo = pokemonApto;
            return $"{this.DisplayName} ha cambiado automáticamente al Pokémon {pokemonApto.PokemonName} - Vida {pokemonApto.VidaActual}/{pokemonApto.VidaMax} HP.";
        }
    }
}