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

        //Historia de usuario 1
        [Test]
        public void Test_SeleccionarPokemonsParaJugador()
        {
            _jugador1.Pokemons.Clear();

            using (var reader = new StringReader("Pikachu\nBlastoise\nArbok\nMachamp\nSnorlax\nAlakazam\n"))
            {
                Console.SetIn(reader);

                _battleFacade.SeleccionarPokemonsParaJugador(_jugador1);
                
                Assert.That(_jugador1.Pokemons.Count, Is.EqualTo(6), "El jugador debe seleccionar exactamente 6 Pokémon.");
            }
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        //Historia de usuario 2
        [Test]
        public void Test_MostrarAtaquesDisponibles()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _battleFacade.MostrarAtaquesDisponibles(_jugador1);
                string output = sw.ToString();

                StringAssert.Contains("Confusión", output);
                StringAssert.Contains("Hipnosis", output);
                StringAssert.Contains("Psicorayo", output);
                StringAssert.Contains("Hiperrayo", output);
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        //Historia de usuario 3
        [Test]
        public void Test_MostrarVida()
        {
            _battleFacade.IniciarBatalla();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _battleFacade.MostrarVida();
                string output = sw.ToString();

                StringAssert.Contains("Ash HP: 100/100", output);
                StringAssert.Contains("Gary HP: 100/100", output);
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        // Historia de usuario 4
        [Test]
        public void Test_EjecutarAtaque()
        {
            _battleFacade.IniciarBatalla();
            double dañoEsperado = _jugador1.PokemonActivo.AtaquesBasicosPublicos[1].Daño;
            double vidaInicial = _jugador2.PokemonActivo.VidaActual;

            using (var consoleInput = new StringReader("1\n1\n"))
            using (var consoleOutput = new StringWriter())
            {
                Console.SetIn(consoleInput);
                Console.SetOut(consoleOutput);

                _jugador1.Atacar(_jugador2);
                double vidaDespuesDelAtaque = _jugador2.PokemonActivo.VidaActual;
                double dañoReal = vidaInicial - vidaDespuesDelAtaque;

                Assert.That(dañoReal, Is.EqualTo(dañoEsperado * 2), "El daño infligido no coincide con el daño esperado.");
            }
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        
        //Historia de usuario 5
        [Test]
        public void Test_MostrarTurnoActual()
        {
            // Iniciar la batalla para que el turno actual esté activo
            _battleFacade.IniciarBatalla();

            // Capturar la salida de la consola para validar el mensaje de turno
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Llamar al método para mostrar el turno actual
                _battleFacade.MostrarTurnoActual();

                // Obtener el texto capturado
                string output = consoleOutput.ToString();

                // Validar que el mensaje de turno esté presente en la salida
                StringAssert.Contains("Es el turno de", output, "El mensaje del turno actual no es el esperado.");
            }
            // Restaurar la salida de la consola
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        
        
        //Historia de usuario 6
        [Test]
        public void Test_BatallaFinalizada()
        {
            // Iniciar la batalla para establecer el contexto
            _battleFacade.IniciarBatalla();
            // Simular la condición de fin de batalla configurando `AptoParaBatalla` en `false` para todos los Pokémon del Jugador 2
            foreach (var pokemon in _jugador2.Pokemons)
            {
                pokemon.AptoParaBatalla = false;
            }
            _battleFacade.BatallaFinalizada();
            // Capturar la salida de la consola
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Llamar a `BatallaFinalizada` y verificar que la batalla termina
                bool isFinished = _battleFacade.BatallaFinalizada();

                // Verificar que la batalla finalice correctamente
                Assert.IsTrue(isFinished, "La batalla debería estar finalizada cuando todos los Pokémon del oponente están fuera de combate.");

                // Obtener el texto capturado y validar que el mensaje de finalización esté presente
                string output = consoleOutput.ToString();
                StringAssert.Contains("La batalla ha finalizado", output, "El mensaje de finalización de la batalla no es el esperado.");
            }

            // Restaurar la salida de la consola
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        
        //Historia de usuario 7
        [Test]
        public void Test_CambiarPokemonActivo()
        {
            // Iniciar la batalla para permitir el cambio de Pokémon activo
            _battleFacade.IniciarBatalla();
            _battleFacade.CambiarPokemonActivo("Blastoise");
            // Capturar la salida de la consola
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Llamar al método para cambiar el Pokémon activo del jugador
                _battleFacade.CambiarPokemonActivo("Blastoise");

                // Verificar que el Pokémon activo ha cambiado a "Blastoise"
                Assert.That(_jugador1.PokemonActivo.Nombre, Is.EqualTo("Blastoise"), "El Pokémon activo debería cambiar a Blastoise.");
            }
            
            // Restaurar la salida de la consola
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        
        
        // Historia de usuario 8: Usar un ítem durante la batalla
        [Test]
        public void Test_UsarItemSuperpocion()
        {
            _battleFacade.IniciarBatalla();
            double vidaInicial = _jugador1.PokemonActivo.VidaActual;

            using (var simulatedInput = new StringReader("1\nAlakazam\n"))
            using (var consoleOutput = new StringWriter())
            {
                Console.SetIn(simulatedInput);
                Console.SetOut(consoleOutput);

                _battleFacade.UsarItemDelJugador();
                
                Assert.That(_jugador1.PokemonActivo.VidaActual, Is.EqualTo(vidaInicial + 70), "La vida de Alakazam debería haberse incrementado en 70 puntos.");
            }
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        
        //Hisotria de usuario 9
        [Test]
        public void Test_AgregarJugadorALaListaDeEspera()
        {
            Assert.DoesNotThrow(() => _battleFacade.AgregarJugadorALaListaDeEspera(_jugador1));
        }
         //Historia de usuario 10
        [Test]
        public void Test_MostrarListaDeEspera()
        {
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador1);
            _battleFacade.AgregarJugadorALaListaDeEspera(_jugador2);
            Assert.DoesNotThrow(() => _battleFacade.MostrarListaDeEspera());
        }
        
        //historia de usuario 11
        [Test]
        public void Test_IniciarBatalla()
        {
            Assert.DoesNotThrow(() => _battleFacade.IniciarBatalla());
            Assert.IsNotNull(_battleFacade, "La batalla debería haber comenzado con dos jugadores en la lista de espera.");
        }
    }
}
