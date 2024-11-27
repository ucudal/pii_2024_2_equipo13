using Library;
using NUnit.Framework;
using Library.EfectosAtaque;
using Library.Pokemons;

namespace Ucu.Poo.DiscordBot.Domain.Tests.TestsEfectosAtaque
{
    /**
     * @class TestEfectosAtaque
     * @brief Clase para probar varios efectos de ataque en los Pokemon.
     *
     * Esta clase proporciona pruebas unitarias para efectos de ataque, como Dormir, Paralizar,
     * Envenenar y Quemar. Cada prueba valida la aplicación, eliminación y estado de activación
     * de estos efectos en un Pokemon.
     */
    [TestFixture]
    public class TestEfectosAtaque
    {
        private Pokemon pokemon;

        /**
         * @brief Método de configuración para inicializar objetos antes de cada prueba.
         *
         * Este método crea una instancia de un Pokemon (Alakazam) que se utilizará en las pruebas.
         */
        [SetUp]
        public void SetUp()
        {
            pokemon = new Alakazam();
        }

        // DORMIR (Efecto de Dormir)

        /**
         * @test TestDormirAplicarEfecto
         * @brief Prueba para verificar que el efecto de dormir se aplique correctamente a un Pokemon.
         */
        [Test]
        public void TestDormirAplicarEfecto()
        {
            var dormir = new Dormir(1.0); 

            dormir.AplicarEfecto(pokemon);

            Assert.IsTrue(pokemon.EstaDormido, "El Pokémon debería estar dormido.");
        }

        /**
         * @test TestDormirRemoverEfecto
         * @brief Prueba para verificar que el efecto de dormir se elimine correctamente de un Pokemon.
         */
        [Test]
        public void TestDormirRemoverEfecto()
        {
            var dormir = new Dormir(1.0);
            dormir.AplicarEfecto(pokemon);

            dormir.RemoverEfecto(pokemon);

            Assert.IsFalse(pokemon.EstaDormido, "El Pokémon no debería estar dormido después de remover el efecto.");
        }

        /**
         * @test TestDormirEstaActivo
         * @brief Prueba para verificar si el efecto de dormir está activo en un Pokemon.
         */
        [Test]
        public void TestDormirEstaActivo()
        {
            var dormir = new Dormir(1.0);
            dormir.AplicarEfecto(pokemon);

            bool estaActivo = dormir.EstaActivo(pokemon);

            Assert.IsTrue(estaActivo, "El efecto de dormir debería estar activo.");
        }

        /**
         * @test TestDormirProbabilidadEfecto
         * @brief Prueba para verificar la probabilidad de aplicar el efecto de dormir.
         */
        [Test]
        public void TestDormirProbabilidadEfecto()
        {
            var probabilidad = 0.75;
            var dormir = new Dormir(probabilidad);
            Assert.AreEqual(probabilidad, dormir.ProbabilidadEfecto, "La probabilidad del efecto de dormir no es la esperada.");
        }

        // PARALIZAR (Efecto de Parálisis)

        /**
         * @test TestParalizarEstaActivo
         * @brief Prueba para verificar si el efecto de parálisis está activo en un Pokemon.
         */
        [Test]
        public void TestParalizarEstaActivo()
        {
            var paralizar = new Paralizar(1.0);
            paralizar.AplicarEfecto(pokemon);

            bool estaActivo = paralizar.EstaActivo(pokemon);

            Assert.IsTrue(estaActivo, "El efecto de paralizar debería estar activo.");
        }

        /**
         * @test TestParalizarAplicarEfecto
         * @brief Prueba para verificar que el efecto de parálisis se aplique correctamente a un Pokemon.
         */
        [Test]
        public void TestParalizarAplicarEfecto()
        {
            var paralizar = new Paralizar(1.0); 

            paralizar.AplicarEfecto(pokemon);

            Assert.IsTrue(pokemon.EstaParalizado, "El Pokémon debería estar paralizado.");
        }

        /**
         * @test TestParalizarRemoverEfecto
         * @brief Prueba para verificar que el efecto de parálisis se elimine correctamente de un Pokemon.
         */
        [Test]
        public void TestParalizarRemoverEfecto()
        {
            var paralizar = new Paralizar(1.0);
            paralizar.AplicarEfecto(pokemon);

            paralizar.RemoverEfecto(pokemon);

            Assert.IsFalse(pokemon.EstaParalizado, "El Pokémon no debería estar paralizado después de remover el efecto.");
        }

        /**
         * @test TestParalizarProbabilidadEfecto
         * @brief Prueba para verificar la probabilidad de aplicar el efecto de parálisis.
         */
        [Test]
        public void TestParalizarProbabilidadEfecto()
        {
            var probabilidad = 0.75;
            var paralizar = new Paralizar(probabilidad);
            Assert.AreEqual(probabilidad, paralizar.ProbabilidadEfecto, "La probabilidad del efecto de parálisis no es la esperada.");
        }

        // ENVENENAR (Efecto de Envenenamiento)

        /**
         * @test TestEnvenenarEstaActivo
         * @brief Prueba para verificar si el efecto de envenenamiento está activo en un Pokemon.
         */
        [Test]
        public void TestEnvenenarEstaActivo()
        {
            var envenenar = new Envenenar(1.0);
            envenenar.AplicarEfecto(pokemon);

            bool estaActivo = envenenar.EstaActivo(pokemon);

            Assert.IsTrue(estaActivo, "El efecto de envenenar debería estar activo.");
        }

        /**
         * @test TestEnvenenarAplicarEfecto
         * @brief Prueba para verificar que el efecto de envenenamiento se aplique correctamente a un Pokemon.
         */
        [Test]
        public void TestEnvenenarAplicarEfecto()
        {
            var envenenar = new Envenenar(1.0); 

            envenenar.AplicarEfecto(pokemon);

            Assert.IsTrue(pokemon.EstaEnvenenado, "El Pokémon debería estar envenenado.");
        }

        /**
         * @test TestEnvenenarDañoVeneno
         * @brief Prueba para verificar que el daño por envenenamiento se aplique correctamente a un Pokemon.
         */
        [Test]
        public void TestEnvenenarDañoVeneno()
        {
            var envenenar = new Envenenar(1.0);
            envenenar.AplicarEfecto(pokemon);
            double vidaInicial = pokemon.VidaActual;

            envenenar.DañoVeneno(pokemon);

            Assert.That(pokemon.VidaActual, Is.EqualTo(vidaInicial * 0.95), "El Pokémon debería recibir daño por envenenamiento.");
        }

        /**
         * @test TestEnvenenarRemoverEfecto
         * @brief Prueba para verificar que el efecto de envenenamiento se elimine correctamente de un Pokemon.
         */
        [Test]
        public void TestEnvenenarRemoverEfecto()
        {
            var envenenar = new Envenenar(1.0);
            envenenar.AplicarEfecto(pokemon);

            envenenar.RemoverEfecto(pokemon);

            Assert.IsFalse(pokemon.EstaEnvenenado, "El Pokémon no debería estar envenenado después de remover el efecto.");
        }

        /**
         * @test TestEnvenenarProbabilidadEfecto
         * @brief Prueba para verificar la probabilidad de aplicar el efecto de envenenamiento.
         */
        [Test]
        public void TestEnvenenarProbabilidadEfecto()
        {
            var probabilidad = 0.75;
            var envenenar = new Envenenar(probabilidad);
            Assert.AreEqual(probabilidad, envenenar.ProbabilidadEfecto, "La probabilidad del efecto de envenenamiento no es la esperada.");
        }

        // QUEMAR (Efecto de Quemadura)

        /**
         * @test TestQuemarProbabilidadEfecto
         * @brief Prueba para verificar la probabilidad de aplicar el efecto de quemadura.
         */
        [Test]
        public void TestQuemarProbabilidadEfecto()
        {
            var probabilidad = 0.75;
            var quemar = new Quemar(probabilidad);

            Assert.AreEqual(probabilidad, quemar.ProbabilidadEfecto, "La probabilidad del efecto de quemadura no es la esperada.");
        }

        /**
         * @test TestQuemarAplicarEfecto
         * @brief Prueba para verificar que el efecto de quemadura se aplique correctamente a un Pokemon.
         */
        [Test]
        public void TestQuemarAplicarEfecto()
        {
            var quemar = new Quemar(1.0); 

            quemar.AplicarEfecto(pokemon);

            Assert.IsTrue(pokemon.EstaQuemado, "El Pokémon debería estar quemado.");
        }

        /**
         * @test TestQuemarRemoverEfecto
         * @brief Prueba para verificar que el efecto de quemadura se elimine correctamente de un Pokemon.
         */
        [Test]
        public void TestQuemarRemoverEfecto()
        {
            var quemar = new Quemar(1.0);
            quemar.AplicarEfecto(pokemon);

            quemar.RemoverEfecto(pokemon);

            Assert.IsFalse(pokemon.EstaQuemado, "El Pokémon no debería estar quemado después de remover el efecto.");
        }

        /**
         * @test TestQuemarEstaActivo
         * @brief Prueba para verificar si el efecto de quemadura está activo en un Pokemon.
         */
        [Test]
        public void TestQuemarEstaActivo()
        {
            var quemar = new Quemar(1.0);
            quemar.AplicarEfecto(pokemon);

            bool estaActivo = quemar.EstaActivo(pokemon);

            Assert.IsTrue(estaActivo, "El efecto de quemadura debería estar activo.");
        }

        /**
         * @test TestQuemarEstaQuemado
         * @brief Prueba para verificar si el Pokemon está quemado después de aplicar el efecto de quemadura.
         */
        [Test]
        public void TestQuemarEstaQuemado()
        {
            var quemar = new Quemar(1.0); 

            quemar.AplicarEfecto(pokemon);
            bool estaQuemado = pokemon.EstaQuemado;

            Assert.IsTrue(estaQuemado, "El efecto de quemadura debería estar activo.");
        }
    }
}
