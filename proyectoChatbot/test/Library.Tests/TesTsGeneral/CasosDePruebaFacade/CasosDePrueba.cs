using System;
using NUnit.Framework;
using Library;
using Library.Clases;
using Library.Items;
using Library.Pokemons;

namespace LibraryTests
{
    [TestFixture]
    public class BattleFacadeTests
    {
        private BattleFacade _battleFacade;
        private Jugador _jugador1;
        private Jugador _jugador2;
        private Pokemon _alakazam;
        private Pokemon _arbok;
        private Pokemon _Blastoise;
        [SetUp]
        public void Setup()
        {
            _battleFacade = new BattleFacade();
            _jugador1 = new Jugador("Ash");
            _jugador2 = new Jugador("Gary");
            _alakazam = new Alakazam();
            _arbok = new Arbok();
            _Blastoise = new Blastoise();
            _jugador1.Pokemons.Add(_alakazam);
            _jugador2.Pokemons.Add(_arbok);
            _jugador1.Pokemons.Add(_Blastoise);
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador1);
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador2);
        }
        //Caso de prueba 1
        [Test]
        public void Test_SeleccionarPokemonsParaJugador()
        {
            _jugador1.Pokemons.Clear();//para evitar interferencia, con otras pruebas
            
            // Simular la selección de Pokémon con entradas con los nombres del los pokemons
            using (var  reader = new StringReader("Pikachu\nBlastoise\nArbok\nMachamp\nSnorlax\nAlakazam\n"))
            {
                Console.SetIn(reader); // Redirigir Console.In al StringReader

                // Ejecutar el método que usa Console.ReadLine() para la selección
                _battleFacade.SeleccionarPokemonsParaJugador(_jugador1);
        
                // Validar que se hayan seleccionado 6 Pokémon del jugador
                Assert.That(6,Is.EqualTo(_jugador1.Pokemons.Count), "El jugador debe seleccionar exactamente 6 Pokémon.");
            }

            // Restaurar la entrada estándar de la consola
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
        
        //Caso de prueba 2
        [Test]
        public void Test_MostrarAtaquesDisponibles()
        {
            _battleFacade.MostrarAtaquesDisponibles(_jugador1);
            // Redirigir la salida de la consola a un StringWriter para capturar el texto impreso
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Llamar al método que imprime los ataques disponibles
                _battleFacade.MostrarAtaquesDisponibles(_jugador1);

                // Obtener el texto capturado
                string output = sw.ToString();

                // Realizar aserciones para verificar que el texto capturado contenga los ataques esperados
                StringAssert.Contains("Confusión", output);
                StringAssert.Contains("Hipnosis", output);
                StringAssert.Contains("Psicorayo", output);
                StringAssert.Contains("Hiperrayo", output);
            }

            // Restaurar la salida de la consola a la salida estándar
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        
        
        //Historia de usuario 3
        [Test]
        public void Test_MostrarVida()
        {
            // Agregar jugadores a la lista de espera e iniciar batalla
            _battleFacade.IniciarBatalla();
            _battleFacade.MostrarVida();

            // Redirigir la salida de la consola a un StringWriter temporalmente para capturar el texto
            using (var sw = new StringWriter())
            {
                TextWriter originalOutput = Console.Out;
                Console.SetOut(sw);

                // Llamar al método que imprime la vida de los Pokémon
                _battleFacade.MostrarVida();

                // Obtener el texto capturado y restaurar la salida original
                string output = sw.ToString();
                Console.SetOut(originalOutput);

                // Realizar aserciones para verificar el contenido
                StringAssert.Contains("Ash HP: 100/100", output);
                StringAssert.Contains("Gary HP: 100/100", output);
            }
        }
        // Historia de ususrio 4
        [Test]
        public void Test_EjecutarAtaque()
        {
            // Historia de usuario 4: Realizar un ataque
            //agrego a los jugadores a la lista de espera
            _battleFacade.IniciarBatalla();
            double dañoEsperado = _jugador1.PokemonActivo.AtaquesBasicosPublicos[1].Daño;
            /*como el primer ataque basico de alakazam es de tipo psiquico, y arbok, es debil frente a este tipo de ataques,
             el ataque va a infligir el doble de daño*/
            
            // Vida del oponente antes del ataque
            double vidaInicial = _jugador2.PokemonActivo.VidaActual;

            // Configuración para simular la entrada de usuario
            using (var consoleInput =
                   new StringReader("1\n1\n")) // "1" para ataque básico y "1" para el índice del ataque
            {
                Console.SetIn(consoleInput);

                // Capturar la salida de la consola
                using (var consoleOutput = new StringWriter())
                {
                    Console.SetOut(consoleOutput);

                    // Ejecutar el método que realiza el ataque
                    _jugador1.Atacar(_jugador2);

                    // Verificar el daño infligido comparando la vida actual
                    double vidaDespuesDelAtaque = _jugador2.PokemonActivo.VidaActual;
                    double dañoReal = vidaInicial - vidaDespuesDelAtaque;

                    // Aserción para verificar si el daño infligido es el esperado
                    Assert.That(dañoEsperado*2,Is.EqualTo(dañoReal), "El daño infligido no coincide con el daño esperado.");

                }
            }
        }
        
        // Historia de usuario 5: Mostrar el turno actual
        [Test]
        public void Test_MostrarTurnoActual()
        {
            _battleFacade.IniciarBatalla();
            Assert.DoesNotThrow(() => _battleFacade.MostrarTurnoActual());
        }

        // Historia de usuario 6: Verificar que la batalla finaliza cuando corresponde
        
        [Test]
        public void Test_BatallaFinalizada()
        {
            _battleFacade.IniciarBatalla();

            // Simulamos la condición de fin de batalla configurando `AptoParaBatalla` en `false` para todos los Pokémon del Jugador 2, ya que si uno
            // de los dos tiene todos, sus pokemons no aptos para la batalla, la batalla deberia terminar.
            foreach (var pokemon in _jugador2.Pokemons)
            {
                pokemon.AptoParaBatalla = false;
            }

            bool isFinished = _battleFacade.BatallaFinalizada();

            // Verificar que la batalla finalice
            Assert.IsTrue(isFinished, "La batalla debería estar finalizada cuando todos los Pokémon del oponente están fuera de combate.");
        }

        // Historia de usuario 7: Cambiar el Pokémon activo
        [Test]
        public void Test_CambiarPokemonActivo()
        {
            _battleFacade.IniciarBatalla();
            Assert.DoesNotThrow(() => _battleFacade.CambiarPokemonActivo("Blastoise"));
            Assert.That(_jugador1.PokemonActivo.Nombre,Is.EqualTo("Blastoise"), "El Pokémon activo debería cambiar a Blastoise.");
        }

        // Historia de usuario 8: Usar un ítem durante la batalla
        [Test]
        public void Test_UsarItemSuperpocion()
        {
            _battleFacade.IniciarBatalla();
            // Configuración: Se asegura que Alakazam esté en la lista de Pokémon de Jugador1
            double vidaInicial = _jugador1.PokemonActivo.VidaActual;

            // Simular las entradas del usuario: Opción 1 para Superpoción y luego el nombre "Alakazam"
            var simulatedInput = new StringReader("1\nAlakazam\n");
            Console.SetIn(simulatedInput);

            // Captura la salida de consola para hacer las aserciones
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Llama a UsarItemDelJugador a través del facade
                _battleFacade.UsarItemDelJugador();
                // Verifica que la vida de Alakazam haya aumentado en 70 puntos (asumiendo que el aumento es de 70)
                Assert.That(_jugador1.PokemonActivo.VidaActual, Is.EqualTo(vidaInicial + 70), "La vida de Alakazam debería haberse incrementado en 70 puntos.");
            }

            // Restaura la entrada y salida estándar de la consola
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        
        [Test]
        public void Test_AgregarJugadorALaListaDeEspera()
        {
            // Historia de usuario 9: Agregar un jugador a la lista de espera
            Assert.DoesNotThrow(() => _battleFacade.AgregarJugadorALaListaDeEspera(_jugador1));
        }

        [Test]
        public void Test_MostrarListaDeEspera()
        {
            // Historia de usuario 10: Mostrar la lista de espera
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador1);
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador2);
            Assert.DoesNotThrow(() => _battleFacade.MostrarListaDeEspera());
        }

        [Test]
        public void Test_IniciarBatalla()
        {
            // Historia de usuario 11: Iniciar batalla con jugadores en la lista de espera
            Assert.DoesNotThrow(() => _battleFacade.IniciarBatalla());
            Assert.IsNotNull(_battleFacade, "La batalla debería haber comenzado con dos jugadores en la lista de espera.");
        }
    }
}
