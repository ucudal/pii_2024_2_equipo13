using Library.Clases;
using Library.Pokemons;

namespace Library.Tests;

public class TurnoTests
{
    private Turno turno;
    private Jugador jugador1;
    private Jugador jugador2;
    private Alakazam alakazam;
    private Arbok arbok;
    
    [SetUp]
    public void SetUp()
    { 
        //Se incializan, los distintos objetos, que van a ser utilizados para los test
        // Inicializar jugadores
        jugador1 = new Jugador("Jugador 1");
        jugador2 = new Jugador("Jugador 2");

        // Crear instancias reales de Pokémon
        alakazam = new Alakazam();
        arbok = new Arbok();

        // Asignar Pokémon a los jugadores
        jugador1.Pokemons.Add(alakazam);
        jugador2.Pokemons.Add(arbok);

        // Asegurarse de que los jugadores tienen un Pokémon activo
        jugador1.PokemonActivo = jugador1.Pokemons.FirstOrDefault();
        jugador2.PokemonActivo = jugador2.Pokemons.FirstOrDefault();

        // Inicializar el turno
        turno = new Turno(jugador1, jugador2);
    }


    [Test]
    public void Test_CambiarTurno_CorrectlySwitchesPlayers()
    {
        //Este test, verifica si esta funcionando, el flujo de cambiar los turnos, entre los jugadores
        // Finalizar el turno actual
        turno.FinalizarTurno();

        // Cambiar turno
        turno.CambiarTurno();

        // Verificar que ahora es el turno del jugador 2
        Assert.AreEqual(jugador2, turno.JugadorActual);
        Assert.AreEqual(jugador1, turno.JugadorRival);
    }
    [Test]
    public void Test_CambiarPokemonActivo_CorrectlyChangesActivePokemon()
    { 
        //Este test, comprueba que no se puede cambiar a un pokemon, o que no se tiene, o que no esta disponible para la batalla
        // Cambiar el Pokémon activo de Jugador 1 a Alakazam
        jugador1.CambiarPokemonActivo("Alakazam");

        // Verificar que Alakazam es el Pokémon activo del Jugador 1
        Assert.AreEqual(alakazam, jugador1.PokemonActivo);

        // Cambiar el Pokémon activo de Jugador 2 a Charizard
        jugador2.CambiarPokemonActivo("Arbok");

        // Verificar que Charizard es el Pokémon activo del Jugador 2
        Assert.AreEqual(arbok, jugador2.PokemonActivo);
    }

    [Test]
    public void Test_CambiarPokemonActivo_InvalidPokemonDoesNotChangeActivePokemon()
    { 
        // Cambiar el Pokémon activo de Jugador 1 a un Pokémon que no tiene (Pikachu)
        jugador1.CambiarPokemonActivo("Pikachu");

        // Verificar que el Pokémon activo de Jugador 1 sigue siendo Alakazam, ya que Pikachu no está en su equipo
        Assert.AreEqual(alakazam, jugador1.PokemonActivo);
    }
    [Test]
    public void Test_FinalizarTurno_MarksTurnAsFinalized()
    { 
        //Este metodo Verifica, que el flujo de turnos funciona y que al final del turno se da por concluido.
        // Verificar que al inicio el turno no está finalizado
        Assert.IsFalse(turno.Finalizado);

        // Finalizar el turno
        turno.FinalizarTurno();

        // Verificar que el turno ha sido marcado como finalizado
        Assert.IsTrue(turno.Finalizado);
    }
    public class WaitListTests
    {
        private WaitList waitList;
        private Jugador jugador1;
        private Jugador jugador2;

        [SetUp]
        public void SetUp()
        {
            waitList = new WaitList();
            jugador1 = new Jugador("Jugador 1");
            jugador2 = new Jugador("Jugador 2");
        }

        [Test]
        public void Test_SalaDeEspera_AddsPlayerToWaitList()
        {
            var result = waitList.SalaDeEspera(jugador1);
            Assert.AreEqual($"{jugador1.Nombre} ha sido agregado a la lista de espera.", result);
            Assert.IsTrue(waitList.WaitListJugador.Contains(jugador1));
        }

        [Test]
        public void Test_StartBattle_InsufficientPlayers()
        {
            waitList.SalaDeEspera(jugador1);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                waitList.StartBattle();
                var expected = "No hay suficientes jugadores para iniciar una batalla.\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void Test_StartBattle_SufficientPlayersWithSixPokemons()
        {
            for (int i = 0; i < 6; i++)
            {
                jugador1.Pokemons.Add(new Alakazam());
                jugador2.Pokemons.Add(new Arbok());
            }
            waitList.SalaDeEspera(jugador1);
            waitList.SalaDeEspera(jugador2);
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                waitList.StartBattle();
                var expected = $"{jugador1.Nombre} y {jugador2.Nombre} han sido seleccionados para la batalla.\r\n";
                Assert.IsTrue(sw.ToString().Contains(expected));
            }
        }
    }
}