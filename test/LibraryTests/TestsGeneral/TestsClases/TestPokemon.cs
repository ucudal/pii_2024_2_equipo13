using NUnit.Framework;
using Library;
using Library.Pokemons;
using Library.TiposPokemon;

namespace Ucu.Poo.DiscordBot.Domain.Tests.TestsGeneral.TestPokemon
{
    /**
     * @class TestPokemon
     * @brief Test suite para probar la funcionalidad de la clase Pokemon.
     *
     * Esta clase proporciona pruebas unitarias para la funcionalidad de la clase Pokemon, incluyendo
     * el manejo de efectos, ataques básicos y especiales, curación y verificación de resistencias y debilidades.
     */
    [TestFixture]
    public class TestPokemon
    {
        private Pokemon alakazam;
        private Pokemon arbok;
        private Pokemon arcanine;
        private Pokemon blastoise;
        private Pokemon machamp;
        private Pokemon marowak;
        private Pokemon pikachu;
        private Pokemon sandslash;
        private Pokemon scyther;
        private Pokemon snorlax;
        private Pokemon pokemon;
        private AtaqueBasico ataque;
        
        private Psiquico psiquico;
        private Lucha lucha;
        private Veneno veneno;
        private Bicho bicho;
        private Fantasma fantasma;
        private Agua agua;
        private Electrico electrico;
        private Normal normal;
        private Fuego fuego;
        private Hada hada;
        private Planta planta;
        private Roca roca;
        private Siniestro siniestro;
        private Tierra tierra;
        private Volador volador;
        private IEfectoAtaque Efecto;

        /**
         * @brief Configura el entorno de prueba antes de cada test.
         *
         * Este método inicializa las instancias de Pokemon y los tipos de ataque que serán utilizados en las pruebas.
         */
        [SetUp]
        public void Setup()
        {
            var tipo = new Agua(); 
            ataque = new AtaqueBasico("Agua", 90, tipo, 0.85);
            
            pokemon = new Alakazam(); 
            pokemon.TurnosDormido = 2;
            pokemon.EstaDormido = true;
            
            alakazam = new Alakazam();
            arbok = new Arbok();
            arcanine = new Arcanine();
            blastoise = new Blastoise();
            machamp = new Machamp();
            marowak = new Marowak();
            pikachu = new Pikachu();
            sandslash = new Sandslash();
            scyther = new Scyther();
            snorlax = new Snorlax();
            pokemon = new Alakazam();
            pokemon.VidaMax = 100;
            pokemon.VidaActual = 100;
            pokemon.AptoParaBatalla = true;
            psiquico = new Psiquico();
            lucha = new Lucha();
            veneno = new Veneno();
            bicho = new Bicho();
            fantasma = new Fantasma();
            agua = new Agua();
            electrico = new Electrico();
            normal = new Normal();
            fuego = new Fuego();
            hada = new Hada();
            planta = new Planta();
            roca = new Roca();
            siniestro = new Siniestro();
            tierra = new Tierra();
            volador = new Volador();
        }
        
        /**
         * @brief Prueba que el método ReducirTurnoDormido reduce los turnos dormido del Pokemon.
         */
        [Test]
        public void ReducirTurnoDormidoReducesTurnosDormido()
        {
            pokemon.ReducirTurnoDormido();

            Assert.AreEqual(0, pokemon.TurnosDormido, "TurnosDormido debería reducirse en 1.");
        }
        
        /**
         * @brief Prueba que el método GetAtaquesBasicos retorna la cadena correcta con los ataques básicos del Pokemon.
         */
        [Test]
        public void GetAtaquesBasicosReturnsCorrectString()
        {
            string result = pokemon.GetAtaquesBasicos();

            string expected = "1 - Confusión, Daño: 50, Tipo: Psiquico\n2 - Hipnosis, Daño: 70, Tipo: Psiquico\n";
            Assert.AreEqual(expected, result);
        }
        
        /**
         * @brief Prueba que el método ReducirTurnoDormido establece EstaDormido a false cuando TurnosDormido es cero.
         */
        [Test]
        public void ReducirTurnoDormidoSetsEstaDormidoToFalseWhenTurnosDormidoIsZero()
        {
            pokemon.TurnosDormido = 1;

            pokemon.ReducirTurnoDormido();
            
            Assert.IsFalse(pokemon.EstaDormido, "EstaDormido debería ser false cuando TurnosDormido es cero.");
        }
        
        /**
         * @brief Prueba que el método GetDaño retorna el valor correcto del ataque.
         */
        [Test]
        public void GetDañoReturnsCorrectValue()
        {
            var daño = ataque.Daño;
            Assert.AreEqual(90, daño, "Daño debería retornar el valor correcto.");
        }

        /**
         * @brief Prueba que el método GetTipo retorna el tipo correcto del ataque.
         */
        [Test]
        public void GetTipoReturnsCorrectValue()
        {
            var tipo = ataque.Tipo;
            Assert.IsInstanceOf<Agua>(tipo, "Tipo debería retornar el tipo correcto.");
        }
        
        /**
         * @brief Prueba que el método DañoRecibido reduce la vida actual del Pokemon.
         */
        [Test]
        public void DañoRecibidoReducesVidaActual()
        {
            pokemon.DañoRecibido(30);
            Assert.AreEqual(70, pokemon.VidaActual, "VidaActual debería reducirse por la cantidad de daño recibido.");
        }

        /**
         * @brief Prueba que el método DañoRecibido establece AptoParaBatalla a false cuando VidaActual es cero.
         */
        [Test]
        public void DañoRecibidoSetsAptoParaBatallaToFalseWhenVidaActualIsZero()
        {
            pokemon.DañoRecibido(100);
            Assert.AreEqual(0, pokemon.VidaActual, "VidaActual debería ser cero cuando el daño iguala VidaActual.");
            Assert.IsFalse(pokemon.AptoParaBatalla, "AptoParaBatalla debería ser false cuando VidaActual es cero.");
        }

        /**
         * @brief Prueba que el método DañoRecibido establece VidaActual a cero cuando el daño excede VidaActual.
         */
        [Test]
        public void DañoRecibidoSetsVidaActualToZeroWhenDamageExceedsVidaActual()
        {
            pokemon.DañoRecibido(150);
            Assert.AreEqual(0, pokemon.VidaActual, "VidaActual debería ser cero cuando el daño excede VidaActual.");
            Assert.IsFalse(pokemon.AptoParaBatalla, "AptoParaBatalla debería ser false cuando VidaActual es cero.");
        }
        
        /**
         * @brief Prueba la funcionalidad del efecto de ataque aplicado a un Pokémon.
         *
         * Esta prueba verifica que el efecto del ataque especial se aplica correctamente a un Pokémon.
         * Se crea un efecto de ataque específico y se asigna a un ataque especial. Luego se verifica
         * que el ataque especial tenga el efecto esperado.
         *
         * Pasos:
         * 1. Se crea una instancia de `EfectoAtaqueConcreto`.
         * 2. Se crea un ataque especial con el efecto de ataque.
         * 3. Se verifica que el efecto del ataque especial sea igual al efecto creado.
         *
         * @test Asegura que el efecto del ataque especial es el esperado.
         */
        [Test]
        public void TestEfectoAtaque()
        {
            IEfectoAtaque efecto = new EfectoAtaqueConcreto(); 
            var ataqueEspecial = new AtaqueEspecial("Ataque Test", 50, new Agua(), 1.0, efecto);

            var resultadoEfecto = ataqueEspecial.Efecto;
            Assert.That(resultadoEfecto, Is.EqualTo(efecto), "El efecto del ataque especial no es el esperado.");
        }

        [Test]
        public void TestNombre()
        {
            Assert.That(agua.Nombre, Is.EqualTo("Agua"), "El nombre del tipo no es el esperado.");
            Assert.That(bicho.Nombre, Is.EqualTo("Bicho"), "El nombre del tipo no es el esperado.");
            Assert.That(electrico.Nombre, Is.EqualTo("Electrico"), "El nombre del tipo no es el esperado.");
            Assert.That(fantasma.Nombre, Is.EqualTo("Fantasma"), "El nombre del tipo no es el esperado.");
            Assert.That(fuego.Nombre, Is.EqualTo("Fuego"), "El nombre del tipo no es el esperado.");
            Assert.That(hada.Nombre, Is.EqualTo("Hada"), "El nombre del tipo no es el esperado.");
            Assert.That(lucha.Nombre, Is.EqualTo("Lucha"), "El nombre del tipo no es el esperado.");
            Assert.That(normal.Nombre, Is.EqualTo("Normal"), "El nombre del tipo no es el esperado.");
            Assert.That(planta.Nombre, Is.EqualTo("Planta"), "El nombre del tipo no es el esperado.");
            Assert.That(psiquico.Nombre, Is.EqualTo("Psiquico"), "El nombre del tipo no es el esperado.");
            Assert.That(roca.Nombre, Is.EqualTo("Roca"), "El nombre del tipo no es el esperado.");
            Assert.That(siniestro.Nombre, Is.EqualTo("Siniestro"), "El nombre del tipo no es el esperado.");
            Assert.That(tierra.Nombre, Is.EqualTo("Tierra"), "El nombre del tipo no es el esperado.");
            Assert.That(veneno.Nombre, Is.EqualTo("Veneno"), "El nombre del tipo no es el esperado.");
            Assert.That(volador.Nombre, Is.EqualTo("Volador"), "El nombre del tipo no es el esperado.");


        }

        [Test]
        public void TestDañoRecibido()
        {
            double vidaInicial = alakazam.VidaActual;
            double daño = 50;

            alakazam.DañoRecibido(daño);

            Assert.That(alakazam.VidaActual, Is.EqualTo(vidaInicial - daño),
                "El daño recibido no se aplicó correctamente.");
        }


        [Test]
        public void TestCurarVidaMaxima()
        {
            // Arrange
            alakazam.VidaActual = alakazam.VidaMax;

            // Act
            alakazam.Curar();

            // Assert
            Assert.That(alakazam.VidaActual, Is.EqualTo(alakazam.VidaMax),
                "La curación no se aplicó correctamente cuando la vida ya estaba al máximo.");
        }

        [Test]
        public void TestAtaqueBasicoFallo()
        {
            
            double vidaInicial = arbok.VidaActual;
            int ataqueElegido = 1; 

            alakazam.AtaquesBasicosPublicos[ataqueElegido].Precision = 0;

            double daño = alakazam.AtaqueBasico(arbok, ataqueElegido, out string mensaje);

            Assert.That(daño, Is.EqualTo(0), "El ataque básico debería haber fallado.");
            Assert.That(arbok.VidaActual, Is.EqualTo(vidaInicial), "El ataque básico no debería haber causado daño.");
        }
        
        
        [Test]
        public void TestAtaqueEspecialFallo()
        {
            double vidaInicial = arbok.VidaActual;
            int ataqueElegido = 1; 

            
            alakazam.AtaquesEspecialesPublicos[ataqueElegido].Precision = 0;

            double daño = alakazam.AtaqueEspecial(arbok, ataqueElegido, out string mensaje);

            Assert.That(daño, Is.EqualTo(0), "El ataque especial debería haber fallado.");
            Assert.That(arbok.VidaActual, Is.EqualTo(vidaInicial),
                "El ataque especial no debería haber causado daño.");
        }
        /**
    * @brief Testa la funcionalidad del método `EstaAfectadoPorEfecto` para verificar si un Pokémon tiene algún efecto de estado activo.
    *
    * Este test verifica que el método `EstaAfectadoPorEfecto` retorna `true` cuando el Pokémon está afectado
    * por algún efecto de estado, como sueño, parálisis, envenenamiento o quemadura.
    *
    * Pasos:
    * 1. Se asigna al Pokémon (`alakazam`) un estado de efecto activo (en este caso, sueño).
    * 2. Se llama al método `EstaAfectadoPorEfecto`.
    * 3. Se verifica que el método retorna `true` indicando que el Pokémon está afectado por un efecto.
    *
    * @test
    * Asegura que el método `EstaAfectadoPorEfecto` detecta correctamente cuando un Pokémon tiene algún efecto de estado activo.
    */
        [Test]
        public void TestGetAtaqueEspecial()
        {
            string ataquesEspeciales = alakazam.GetAtaqueEspecial();

            StringAssert.Contains("Ataques Especiales:", ataquesEspeciales, "No se encontraron ataques especiales.");
        }
        /**
     * @brief Testa la funcionalidad del método `EstaAfectadoPorEfecto` para verificar si un Pokémon tiene algún efecto de estado activo.
     *
     * Este test verifica que el método `EstaAfectadoPorEfecto` retorna `true` cuando el Pokémon está afectado
     * por algún efecto de estado, como sueño, parálisis, envenenamiento o quemadura.
     *
     * Pasos:
     * 1. Se asigna al Pokémon (`alakazam`) un estado de efecto activo (en este caso, sueño).
     * 2. Se llama al método `EstaAfectadoPorEfecto`.
     * 3. Se verifica que el método retorna `true` indicando que el Pokémon está afectado por un efecto.
     *
     * @test
     * Asegura que el método `EstaAfectadoPorEfecto` detecta correctamente cuando un Pokémon tiene algún efecto de estado activo.
     */
        [Test]
        public void TestEstaAfectadoPorEfecto()
        {
            alakazam.EstaDormido = true;

            Assert.IsTrue(alakazam.EstaAfectadoPorEfecto(), "El Pokémon debería estar afectado por un efecto.");
        }
        
        /**
     * @brief Testa la funcionalidad del método `AplicarDañoQuemadura` para reducir la vida de un Pokémon quemado.
     *
     * Este test verifica que el método `AplicarDañoQuemadura` aplica correctamente el daño por quemadura,
     * reduciendo la vida actual del Pokémon en un 10% de su valor inicial cuando está quemado.
     *
     * Pasos:
     * 1. Se asigna el estado de quemadura al Pokémon (`alakazam`).
     * 2. Se almacena la vida actual inicial del Pokémon.
     * 3. Se llama al método `AplicarDañoQuemadura`.
     * 4. Se verifica que la vida actual del Pokémon se reduce en un 10% del valor inicial.
     *
     * @test
     * Asegura que el método `AplicarDañoQuemadura` reduce correctamente la vida del Pokémon en la proporción esperada.
     */
        [Test]
        public void TestAplicarDañoQuemadura()
        {
            
            alakazam.EstaQuemado = true;
            double vidaInicial = alakazam.VidaActual;

            alakazam.AplicarDañoQuemadura();

            Assert.That(alakazam.VidaActual, Is.EqualTo(vidaInicial * 0.90),
                "El daño por quemadura no se aplicó correctamente.");
        }
            /**
     * @brief Testa la funcionalidad del método `AplicarDañoVeneno` para reducir la vida de un Pokémon envenenado.
     *
     * Este test verifica que el método `AplicarDañoVeneno` aplica correctamente el daño por envenenamiento,
     * reduciendo la vida actual del Pokémon en un 5% de su valor inicial cuando está envenenado.
     *
     * Pasos:
     * 1. Se asigna el estado de envenenamiento al Pokémon (`alakazam`).
     * 2. Se almacena la vida actual inicial del Pokémon.
     * 3. Se llama al método `AplicarDañoVeneno`.
     * 4. Se verifica que la vida actual del Pokémon se reduce en un 5% del valor inicial.
     *
     * @test
     * Asegura que el método `AplicarDañoVeneno` reduce correctamente la vida del Pokémon en la proporción esperada.
     */
        [Test]
        public void TestAplicarDañoVeneno()
        {
            alakazam.EstaEnvenenado = true;
            double vidaInicial = alakazam.VidaActual;

            alakazam.AplicarDañoVeneno();

            Assert.That(alakazam.VidaActual, Is.EqualTo(vidaInicial * 0.95),
                "El daño por envenenamiento no se aplicó correctamente.");
        }
            /**
     * @brief Testa la funcionalidad del método `Curar` para restaurar la vida de un Pokémon.
     *
     * Este test verifica que el método `Curar` incrementa la vida actual de un Pokémon
     * en un 25% de su vida máxima, sin exceder el límite de vida máxima.
     *
     * Pasos:
     * 1. Se asigna a un Pokémon (`alakazam`) la mitad de su vida máxima como vida actual.
     * 2. Se calcula la vida esperada tras aplicar la curación (25% de la vida máxima).
     * 3. Se llama al método `Curar`.
     * 4. Se verifica que la vida actual del Pokémon coincide con la vida esperada.
     *
     * @test
     * Asegura que el método `Curar` funciona correctamente, restaurando la cantidad adecuada de vida.
     */
        [Test]
        public void TestCurar()
        {
            alakazam.VidaActual = alakazam.VidaMax / 2;
            double vidaEsperada = alakazam.VidaActual + (alakazam.VidaMax * 0.25);

            alakazam.Curar();

            Assert.That(alakazam.VidaActual, Is.EqualTo(vidaEsperada), "La curación no se aplicó correctamente.");
        }
        
            /**
     * @brief Testa la funcionalidad para remover todos los efectos de estado de un Pokémon.
     *
     * Este test verifica que el método `RemoverEfectos` elimina correctamente
     * los efectos de estado aplicados a un Pokémon, como sueño, parálisis,
     * envenenamiento y quemaduras.
     *
     * Pasos:
     * 1. Se aplican varios efectos de estado a un Pokémon (`alakazam`).
     * 2. Se llama al método `RemoverEfectos`.
     * 3. Se comprueba que todos los efectos de estado han sido removidos correctamente.
     *
     * @test
     * Asegura que el método `RemoverEfectos` funciona como se espera, eliminando
     * cada uno de los efectos de estado aplicados al Pokémon.
     */
        [Test]
        public void TestRemoverEfectos()
        {
            alakazam.EstaDormido = true;
            alakazam.EstaParalizado = true;
            alakazam.EstaEnvenenado = true;
            alakazam.EstaQuemado = true;

            alakazam.RemoverEfectos();

            Assert.IsFalse(alakazam.EstaDormido, "El efecto de sueño no se removió correctamente.");
            Assert.IsFalse(alakazam.EstaParalizado, "El efecto de parálisis no se removió correctamente.");
            Assert.IsFalse(alakazam.EstaEnvenenado, "El efecto de envenenamiento no se removió correctamente.");
            Assert.IsFalse(alakazam.EstaQuemado, "El efecto de quemadura no se removió correctamente.");
        }
            /**
     * @brief Testa la funcionalidad de inmunidad entre diferentes tipos de elementos.
     *
     * Este test verifica si las relaciones de inmunidad entre tipos de elementos
     * (como Agua, Fuego, Fantasma, etc.) están correctamente implementadas.
     *
     * - Casos positivos: Se valida que un tipo sea inmune a otro cuando corresponde.
     * - Casos negativos: Se valida que un tipo no sea inmune a otro en los casos indicados.
     *
     * Ejemplos:
     * - `Fantasma` debe ser inmune a `Lucha` y `Normal`, pero no a `Bicho`.
     * - `Tierra` debe ser inmune a `Electrico`, pero no a `Bicho`.
     * - `Volador` debe ser inmune a `Tierra`, pero no a `Bicho`.
     *
     * @test
     * Asegura que los métodos InmuneContra retornen los valores esperados para
     * cada combinación de tipos.
     */
        [Test]
        public void TestTiposInmuneContra()
        {
            Assert.IsFalse(agua.InmuneContra(bicho), "Agua no es inmune a Bicho.");
            Assert.IsFalse(bicho.InmuneContra(fuego), "Bicho no es inmune a Fuego.");
            Assert.IsTrue(electrico.InmuneContra(electrico), "Electrico es inmune a Electrico.");
            Assert.IsFalse(electrico.InmuneContra(bicho), "Electrico no es inmune a Bicho.");
            Assert.IsTrue(fantasma.InmuneContra(lucha), "Fantasma es inmune a Lucha.");
            Assert.IsTrue(fantasma.InmuneContra(normal), "Fantasma es inmune a Normal.");
            Assert.IsTrue(fantasma.InmuneContra(normal), "Fantasma es inmune a Normal.");
            Assert.IsFalse(fantasma.InmuneContra(bicho), "Fantasma no es inmune a Bicho.");
            Assert.IsFalse(fuego.InmuneContra(bicho), "Fuego no es inmune a Bicho.");
            Assert.IsFalse(hada.InmuneContra(bicho), "Hada no es inmune a Bicho.");
            Assert.IsFalse(lucha.InmuneContra(bicho), "Lucha no es inmune a Bicho.");
            Assert.IsTrue(normal.InmuneContra(fantasma), "Normal es inmune a Fantasma.");
            Assert.IsFalse(normal.InmuneContra(bicho), "Normal no es inmune a Bicho.");
            Assert.IsFalse(planta.InmuneContra(bicho), "Planta no es inmune a Bicho.");
            Assert.IsFalse(psiquico.InmuneContra(bicho), "Psiquico no es inmune a Bicho.");
            Assert.IsFalse(roca.InmuneContra(bicho), "Roca no es inmune a Bicho.");
            Assert.IsFalse(siniestro.InmuneContra(bicho), "Siniestro no es inmune a Bicho.");
            Assert.IsTrue(tierra.InmuneContra(electrico), "Tierra es inmune a Electrico.");
            Assert.IsFalse(tierra.InmuneContra(bicho), "Tierra no es inmune a Bicho.");
            Assert.IsFalse(veneno.InmuneContra(bicho), "Veneno no es inmune a Bicho.");
            Assert.IsTrue(volador.InmuneContra(tierra), "Volador es inmune a Tierra.");
            Assert.IsFalse(volador.InmuneContra(bicho), "Volador no es inmune a Bicho.");

        }
        
            /**
     * @brief Testa la funcionalidad de resistencia entre diferentes tipos de elementos.
     *
     * Este test verifica si las relaciones de resistencia entre tipos de elementos
     * (como Agua, Fuego, Planta, etc.) están correctamente implementadas.
     *
     * - Casos positivos: Se valida que un tipo sea resistente a otro cuando corresponde.
     * - Casos negativos: Se valida que un tipo no sea resistente a otro en los casos indicados.
     *
     * Ejemplos:
     * - `Agua` debe ser resistente a `Fuego` y `Tierra`, pero no a `Bicho`.
     * - `Fuego` debe ser resistente a `Fuego`, `Planta` y `Bicho`, pero no a `Veneno`.
     *
     * @test
     * Asegura que los métodos ResistenteContra retornen los valores esperados para
     * cada combinación de tipos.
     */
        [Test]
        public void TestTiposResistenteContra()
        {
            Assert.IsTrue(agua.ResistenteContra(fuego), "Agua resistente a Fuego.");
            Assert.IsTrue(agua.ResistenteContra(tierra), "Agua resistente a Tierra.");
            Assert.IsFalse(agua.ResistenteContra(bicho), "Agua no resistente a Bicho.");
            Assert.IsTrue(bicho.ResistenteContra(lucha), "Agua resistente a Lucha.");
            Assert.IsTrue(bicho.ResistenteContra(tierra), "Agua resistente a Tierra.");
            Assert.IsTrue(bicho.ResistenteContra(planta), "Agua resistente a Planta.");
            Assert.IsFalse(bicho.ResistenteContra(fuego), "Bicho no resistente a Fuego.");
            Assert.IsTrue(electrico.ResistenteContra(volador), "Electrico resistente a Volador.");
            Assert.IsFalse(electrico.ResistenteContra(agua), "Electrico no resistente a Agua.");
            Assert.IsTrue(fantasma.ResistenteContra(bicho), "Fantasma resistente a Bicho.");
            Assert.IsTrue(fantasma.ResistenteContra(veneno), "Fantasma resistente a Veneno.");
            Assert.IsFalse(fantasma.ResistenteContra(normal), "Fantasma no resistente a Normal.");
            Assert.IsTrue(fuego.ResistenteContra(fuego), "Fuego resistente a Fuego.");
            Assert.IsTrue(fuego.ResistenteContra(planta), "Fuego resistente a Planta.");
            Assert.IsTrue(fuego.ResistenteContra(bicho), "Fuego resistente a Bicho.");
            Assert.IsFalse(fuego.ResistenteContra(veneno), "Fuego no resistente a Veneno.");
            Assert.IsTrue(hada.ResistenteContra(lucha), "Hada resistente a Lucha.");
            Assert.IsTrue(hada.ResistenteContra(bicho), "Hada resistente a Bicho.");
            Assert.IsFalse(hada.ResistenteContra(fuego), "Hada no resistente a Fuego.");
            Assert.IsTrue(lucha.ResistenteContra(roca), "Lucha resistente a Roca.");
            Assert.IsTrue(lucha.ResistenteContra(bicho), "Lucha resistente a Bicho.");
            Assert.IsFalse(lucha.ResistenteContra(fantasma), "Lucha no resistente a Fantasma.");
            Assert.IsFalse(normal.ResistenteContra(bicho), "Normal no resistente a Bicho.");
            Assert.IsTrue(planta.ResistenteContra(agua), "Planta resistente a Agua.");
            Assert.IsTrue(planta.ResistenteContra(tierra), "Planta resistente a Tierra.");
            Assert.IsTrue(planta.ResistenteContra(electrico), "Planta resistente a Electrico.");
            Assert.IsTrue(planta.ResistenteContra(planta), "Planta resistente a Planta.");
            Assert.IsFalse(planta.ResistenteContra(fuego), "Planta no resistente a Fuego.");
            Assert.IsTrue(psiquico.ResistenteContra(lucha), "Psiquico resistente a Lucha.");
            Assert.IsTrue(psiquico.ResistenteContra(veneno), "Psiquico resistente a Veneno.");
            Assert.IsFalse(psiquico.ResistenteContra(bicho), "Psiquico no resistente a Bicho.");
            Assert.IsTrue(roca.ResistenteContra(fuego), "Roca resistente a Fuego.");
            Assert.IsTrue(roca.ResistenteContra(volador), "Roca resistente a Volador.");
            Assert.IsTrue(roca.ResistenteContra(veneno), "Roca resistente a Veneno.");
            Assert.IsTrue(roca.ResistenteContra(normal), "Roca resistente a Normal.");
            Assert.IsFalse(roca.ResistenteContra(agua), "Roca no resistente a Agua.");
            Assert.IsTrue(siniestro.ResistenteContra(fantasma), "Siniestro resistente a Fantasma.");
            Assert.IsTrue(siniestro.ResistenteContra(psiquico), "Siniestro resistente a Psiquico.");
            Assert.IsTrue(siniestro.ResistenteContra(siniestro), "Siniestro resistente a Siniestro.");
            Assert.IsFalse(siniestro.ResistenteContra(bicho), "Siniestro no resistente a Bicho.");
            Assert.IsTrue(tierra.ResistenteContra(roca), "Tierra resistente a Roca.");
            Assert.IsTrue(tierra.ResistenteContra(veneno), "Tierra resistente a Veneno.");
            Assert.IsFalse(tierra.ResistenteContra(bicho), "Tierra no resistente a Bicho.");
            Assert.IsTrue(veneno.ResistenteContra(bicho), "Veneno resistente a Bicho.");
            Assert.IsTrue(veneno.ResistenteContra(planta), "Veneno resistente a Planta.");
            Assert.IsTrue(veneno.ResistenteContra(hada), "Veneno resistente a Hada.");
            Assert.IsTrue(veneno.ResistenteContra(veneno), "Veneno resistente a Veneno.");
            Assert.IsFalse(veneno.ResistenteContra(agua), "Veneno no resistente a Agua.");
            Assert.IsTrue(volador.ResistenteContra(planta), "Volador resistente a Planta.");
            Assert.IsTrue(volador.ResistenteContra(normal), "Volador resistente a Normal.");
            Assert.IsTrue(volador.ResistenteContra(bicho), "Volador resistente a Bicho.");
            Assert.IsFalse(volador.ResistenteContra(roca), "Volador no resistente a Roca.");

        }
            /**
     * @brief Tests the weakness of different Pokémon types against each other.
     *
     * This method verifies that the `DebilContra` method correctly identifies the weaknesses
     * of various Pokémon types against other types.
     */
        [Test]
        public void TestTiposDebilContra()
        {
            Assert.IsTrue(agua.DebilContra(planta), "Agua debil contra Planta.");
            Assert.IsTrue(agua.DebilContra(electrico), "Agua debil contra Electrico.");
            Assert.IsFalse(agua.DebilContra(bicho), "Agua no debil contra Bicho.");
            Assert.IsTrue(bicho.DebilContra(fuego), "Bicho debil contra Fuego.");
            Assert.IsTrue(bicho.DebilContra(volador), "Bicho debil contra Volador.");
            Assert.IsTrue(bicho.DebilContra(veneno), "Bicho debil contra Veneno.");
            Assert.IsFalse(bicho.DebilContra(agua), "Bicho no debil contra Agua.");
            Assert.IsTrue(electrico.DebilContra(tierra), "Electrico debil contra Tierra.");
            Assert.IsFalse(electrico.DebilContra(bicho), "Electrico no debil contra Bicho.");
            Assert.IsTrue(fantasma.DebilContra(fantasma), "Fantasma debil contra Fantasma.");
            Assert.IsFalse(fantasma.DebilContra(bicho), "Fantasma no debil contra Bicho.");
            Assert.IsTrue(fuego.DebilContra(agua), "Fuego debil contra Agua.");
            Assert.IsTrue(fuego.DebilContra(tierra), "Fuego debil contra Tierra.");
            Assert.IsTrue(fuego.DebilContra(roca), "Fuego debil contra Roca.");
            Assert.IsFalse(fuego.DebilContra(bicho), "Fuego no debil contra Bicho.");
            Assert.IsTrue(hada.DebilContra(veneno), "Hada debil contra Veneno.");
            Assert.IsFalse(hada.DebilContra(bicho), "Hada no debil contra Bicho.");
            Assert.IsTrue(lucha.DebilContra(volador), "Lucha debil contra Volador.");
            Assert.IsTrue(lucha.DebilContra(psiquico), "Lucha debil contra Psiquico.");
            Assert.IsTrue(lucha.DebilContra(hada), "Lucha debil contra Hada.");
            Assert.IsFalse(lucha.DebilContra(bicho), "Lucha no debil contra Bicho.");
            Assert.IsTrue(normal.DebilContra(lucha), "Normal debil contra Lucha.");
            Assert.IsFalse(normal.DebilContra(bicho), "Normal no debil contra Bicho.");
            Assert.IsTrue(planta.DebilContra(fuego), "Planta debil contra Fuego.");
            Assert.IsTrue(planta.DebilContra(volador), "Planta debil contra Volador.");
            Assert.IsTrue(planta.DebilContra(bicho), "Planta debil contra Bicho.");
            Assert.IsTrue(planta.DebilContra(veneno), "Planta debil contra Veneno.");
            Assert.IsFalse(planta.DebilContra(agua), "Planta no debil contra Agua.");
            Assert.IsTrue(psiquico.DebilContra(bicho), "Psiquico debil contra Bicho.");
            Assert.IsTrue(psiquico.DebilContra(fantasma), "Psiquico debil contra Fantasma.");
            Assert.IsFalse(psiquico.DebilContra(veneno), "Psiquico no debil contra Veneno.");
            Assert.IsTrue(roca.DebilContra(agua), "Roca debil contra Agua.");
            Assert.IsTrue(roca.DebilContra(planta), "Roca debil contra Planta.");
            Assert.IsTrue(roca.DebilContra(lucha), "Roca debil contra Lucha.");
            Assert.IsTrue(roca.DebilContra(tierra), "Roca debil contra Tierra.");
            Assert.IsFalse(roca.DebilContra(bicho), "Roca no debil contra Bicho.");
            Assert.IsTrue(siniestro.DebilContra(lucha), "Siniestro debil contra Lucha.");
            Assert.IsTrue(siniestro.DebilContra(bicho), "Siniestro debil contra Bicho.");
            Assert.IsTrue(siniestro.DebilContra(hada), "Siniestro debil contra Hada.");
            Assert.IsFalse(siniestro.DebilContra(fantasma), "Siniestro no debil contra Fantasma.");
            Assert.IsTrue(tierra.DebilContra(agua), "Tierra debil contra Agua.");
            Assert.IsTrue(tierra.DebilContra(planta), "Tierra debil contra Planta.");
            Assert.IsFalse(tierra.DebilContra(bicho), "Tierra no debil contra Bicho.");
            Assert.IsTrue(veneno.DebilContra(tierra), "Veneno debil contra Tierra.");
            Assert.IsTrue(veneno.DebilContra(psiquico), "Veneno debil contra Psiquico.");
            Assert.IsFalse(veneno.DebilContra(bicho), "Veneno no debil contra Bicho.");
            Assert.IsTrue(volador.DebilContra(electrico), "Volador debil contra Electrico.");
            Assert.IsTrue(volador.DebilContra(roca), "Volador debil contra Roca.");
            Assert.IsFalse(volador.DebilContra(bicho), "Volador no debil contra Bicho.");
        }

    }
    
    public class EfectoAtaqueConcreto : IEfectoAtaque
    {
            /**
     * @brief Applies the effect to the given Pokémon.
     *
     * This method applies the current effect to the specified Pokémon.
     *
     * @param pokemon The Pokémon to which the effect will be applied.
     */
        public void AplicarEfecto(Pokemon pokemon)
        {
            throw new System.NotImplementedException();
        }
            /**
     * @brief Reduces the turn count for the given Pokémon.
     *
     * This method decreases the turn count for the specified Pokémon, typically used for status effects.
     *
     * @param pokemon The Pokémon whose turn count will be reduced.
     */
        public void ReducirTurno(Pokemon pokemon)
        {
            throw new System.NotImplementedException();
        }
            /**
     * @brief Removes the effect from the given Pokémon.
     *
     * This method removes the current effect from the specified Pokémon.
     *
     * @param pokemon The Pokémon from which the effect will be removed.
     */
        public void RemoverEfecto(Pokemon pokemon)
        {
            throw new System.NotImplementedException();
        }

        public double ProbabilidadEfecto { get; }
            /**
     * @brief Checks if the effect is active on the given Pokémon.
     *
     * This method determines whether the effect is currently active on the specified Pokémon.
     *
     * @param pokemon The Pokémon to check for the active effect.
     * @return `true` if the effect is active on the Pokémon, `false` otherwise.
     */

        public bool EstaActivo(Pokemon pokemon)
        {
            throw new System.NotImplementedException();
        }
    }
}
