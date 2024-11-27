using NUnit.Framework;
using Library.Clases;
using Library.Pokemons;
using System.Collections.Generic;
using System.Linq;
using System;
using Library;

namespace Ucu.Poo.DiscordBot.Domain.Tests.TestsGeneral.TestsSelectorPokemon
{
    /// @brief Clase de pruebas para la funcionalidad de SelectorPokemon.
    ///
    /// La clase <c>TestSelectorPokemon</c> contiene un conjunto de pruebas unitarias para verificar el correcto funcionamiento
    /// de la clase <c>SelectorPokemon</c>. Se asegura de que la selección de Pokémon, la inicialización de la lista de Pokémon
    /// disponibles y la presentación de información relacionada se realicen de manera adecuada.
    [TestFixture]
    public class TestSelectorPokemon
    {
        private SelectorPokemon selectorPokemon;

        /// @brief Configura el entorno necesario para las pruebas.
        ///
        /// Inicializa una nueva instancia de <c>SelectorPokemon</c> antes de ejecutar cada prueba.
        [SetUp]
        public void SetUp()
        {
            selectorPokemon = new SelectorPokemon();
        }

        /// @brief Prueba la selección de un Pokémon existente.
        ///
        /// Verifica que un Pokémon que existe en la lista pueda ser seleccionado correctamente.
        [Test]
        public void TestSeleccionarPokemonExistente()
        {
            string pokemonName = "Alakazam";

            Pokemon seleccionado = selectorPokemon.SeleccionarPokemon(pokemonName);

            Assert.IsNotNull(seleccionado, "El Pokémon seleccionado no debería ser null.");
            Assert.AreEqual(pokemonName, seleccionado.PokemonName, "El nombre del Pokémon seleccionado no coincide.");
        }

        /// @brief Prueba la selección de un Pokémon no existente.
        ///
        /// Verifica que se lance una excepción adecuada cuando se intenta seleccionar un Pokémon que no existe.
        [Test]
        public void TestSeleccionarPokemonNoExistente()
        {
            string pokemonName = "Inexistente";

            var ex = Assert.Throws<ArgumentException>(() => selectorPokemon.SeleccionarPokemon(pokemonName));
            Assert.AreEqual($"El Pokémon {pokemonName} no está disponible.", ex.Message, "El mensaje de excepción no coincide.");
        }

        /// @brief Prueba la selección de un Pokémon con nombre vacío.
        ///
        /// Verifica que se lance una excepción adecuada cuando se intenta seleccionar un Pokémon con un nombre vacío.
        [Test]
        public void TestSeleccionarPokemonNombreVacio()
        {
            string pokemonName = "";

            var ex = Assert.Throws<ArgumentException>(() => selectorPokemon.SeleccionarPokemon(pokemonName));
            Assert.AreEqual($"El Pokémon {pokemonName} no está disponible.", ex.Message, "El mensaje de excepción no coincide.");
        }

        /// @brief Prueba la selección de un Pokémon con nombre nulo.
        ///
        /// Verifica que se lance una excepción adecuada cuando se intenta seleccionar un Pokémon con un valor nulo como nombre.
        [Test]
        public void TestSeleccionarPokemonNombreNulo()
        {
            string pokemonName = null;

            var ex = Assert.Throws<ArgumentException>(() => selectorPokemon.SeleccionarPokemon(pokemonName));
            Assert.AreEqual($"El Pokémon {pokemonName} no está disponible.", ex.Message, "El mensaje de excepción no coincide.");
        }

        /// @brief Prueba la inicialización de la lista de Pokémon disponibles.
        ///
        /// Verifica que la lista de Pokémon disponibles se inicialice correctamente y contenga elementos.
        [Test]
        public void TestInicializarPokemonsDisponibles()
        {
            var pokemonsDisponibles = selectorPokemon.PokemonsDisponibles;

            Assert.IsNotNull(pokemonsDisponibles, "La lista de Pokémon disponibles no debería ser null.");
            Assert.IsTrue(pokemonsDisponibles.Count > 0, "La lista de Pokémon disponibles debería contener elementos.");
        }

        /// @brief Prueba la visualización de la lista de Pokémon disponibles cuando no hay Pokémon.
        ///
        /// Verifica que se muestre un mensaje adecuado cuando la lista de Pokémon disponibles está vacía.
        [Test]
        public void TestMostrarPokemonsDisponiblesSinPokemons()
        {
            selectorPokemon.PokemonsDisponibles.Clear();

            string resultado = selectorPokemon.MostrarPokemonsDisponibles();

            Assert.IsNotNull(resultado, "El resultado no debería ser null.");
            StringAssert.Contains("No hay Pokémon disponibles.", resultado, "El mensaje de 'No hay Pokémon disponibles.' no se encontró en la salida.");
        }

        /// @brief Prueba la visualización de la lista de Pokémon disponibles.
        ///
        /// Verifica que se muestre correctamente la lista de Pokémon disponibles cuando hay elementos.
        [Test]
        public void TestMostrarPokemonsDisponibles()
        {
            string resultado = selectorPokemon.MostrarPokemonsDisponibles();

            Assert.IsNotNull(resultado, "El resultado no debería ser null.");
            StringAssert.Contains("Por favor selecciona tus 6 Pokémon de la siguiente lista:", resultado, "El mensaje de selección no se encontró en la salida.");
            StringAssert.Contains("Alakazam", resultado, "El Pokémon 'Alakazam' no se encontró en la lista de disponibles.");
            StringAssert.Contains("Blastoise", resultado, "El Pokémon 'Blastoise' no se encontró en la lista de disponibles.");
        }

        /// @brief Prueba la obtención de la lista de Pokémon disponibles.
        ///
        /// Verifica que se obtengan correctamente los nombres de los Pokémon disponibles desde la lista inicializada.
        [Test]
        public void TestObtenerPokemonsDisponibles()
        {
            var pokemonsDisponibles = selectorPokemon.ObtenerPokemonsDisponibles();

            Assert.IsNotNull(pokemonsDisponibles, "La lista de Pokémon disponibles no debería ser null.");
            StringAssert.Contains("Alakazam", pokemonsDisponibles, "El Pokémon 'Alakazam' no se encontró en la lista de disponibles.");
            StringAssert.Contains("Blastoise", pokemonsDisponibles, "El Pokémon 'Blastoise' no se encontró en la lista de disponibles.");
        }

        /// @brief Prueba la obtención de la lista de nombres de Pokémon disponibles.
        ///
        /// Verifica que se obtenga correctamente la lista de nombres de Pokémon disponibles.
        [Test]
        public void TestObtenerListaDePokemons()
        {
            var listaPokemons = selectorPokemon.PokemonsDisponibles.Select(p => p.PokemonName).ToList();

            Assert.IsNotNull(listaPokemons, "La lista de nombres de Pokémon no debería ser null.");
            Assert.IsTrue(listaPokemons.Count > 0, "La lista de nombres de Pokémon debería contener elementos.");
        }
    }
}