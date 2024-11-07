using Library.Clases;
using Library.Pokemons;

namespace Library.Tests.TesTsGeneral.TestWaitList;

[TestFixture]
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
        using (var stringwriter = new StringWriter())
        {
            Console.SetOut(stringwriter);
            waitList.StartBattle();
            var expected = "No hay suficientes jugadores para iniciar una batalla.\r\n";
            Assert.AreEqual(expected, stringwriter.ToString());
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

        using (var stringwriter = new StringWriter())
        {
            Console.SetOut(stringwriter);
            waitList.StartBattle();
            var expected = $"{jugador1.Nombre} y {jugador2.Nombre} han sido seleccionados para la batalla.\r\n";
            Assert.IsTrue(stringwriter.ToString().Contains(expected));
        }
    }
}