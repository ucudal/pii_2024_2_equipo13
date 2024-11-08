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
        string result = waitList.SalaDeEspera(jugador1);
        Assert.AreEqual($"{jugador1.Nombre} ha sido agregado a la lista de espera.", result);
        Assert.IsTrue(waitList.WaitListJugador.Contains(jugador1));
    }

    [Test]
    public void Test_StartBattle_InsufficientPlayers()
    {
        waitList.SalaDeEspera(jugador1);
             var resultado=waitList.StartBattle();
            var expected ="No hay suficientes jugadores para iniciar una batalla.";
            Assert.That(expected,Is.EqualTo(resultado.FirstOrDefault()));
        
    }

    [Test]
    public void Test_StartBattle_SufficientPlayersWithSixPokemons()
    {
        for (int i = 0; i < 6; i++)
        {
            jugador1.Pokemons.Add(new Alakazam());
            jugador2.Pokemons.Add(new Arbok());
        }

        // Añadir los jugadores a la lista de espera
        waitList.SalaDeEspera(jugador1);
        waitList.SalaDeEspera(jugador2);
    
        // Capturar la salida de las notificaciones generadas por StartBattle
        var resultado = waitList.StartBattle();
    
        // Verificar que la notificación de inicio de batalla contiene los nombres de ambos jugadores
        var expected = $"{jugador1.Nombre} y {jugador2.Nombre} han sido seleccionados para la batalla.";
        Assert.IsTrue(resultado.Contains(expected), "La notificación no contiene el mensaje esperado para el inicio de batalla.");
    }
}