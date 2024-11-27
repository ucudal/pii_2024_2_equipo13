using Library.Clases;
using Library.Pokemons;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests.TesTsGeneral.TestWaitList;

/// @brief Clase de pruebas para la funcionalidad de la lista de espera (WaitList).
///
/// La clase <c>WaitListTests</c> contiene un conjunto de pruebas unitarias para verificar el correcto funcionamiento
/// de la clase <c>WaitList</c>, asegurando que los jugadores sean agregados correctamente a la lista de espera y
/// que se obtengan resultados esperados cuando se consultan los entrenadores en espera.
[TestFixture]
public class WaitListTests
{
    private WaitList waitList;
    private Trainer jugador1;
    private Trainer jugador2;

    /// @brief Configura el entorno necesario para las pruebas.
    ///
    /// Inicializa una nueva instancia de <c>WaitList</c> y dos objetos de <c>Trainer</c> antes de ejecutar cada prueba.
    [SetUp]
    public void SetUp()
    {
        waitList = new WaitList();
        jugador1 = new Trainer("Jugador 1");
        jugador2 = new Trainer("Jugador 2");
    }

    /// @brief Prueba la adición de un entrenador a la lista de espera.
    ///
    /// Verifica que un entrenador sea agregado correctamente a la lista de espera y que el mensaje de confirmación sea el esperado.
    [Test]
    public void TestSalaDeEsperaAddsPlayerToWaitList()
    {
        string result = waitList.AñadirTrainer(jugador1);
        Assert.AreEqual($"{jugador1.DisplayName} ha sido agregado a la lista de espera.", result);
        Assert.IsTrue(waitList.WaitListJugador.Contains(jugador1));
    }

    /// @brief Prueba la obtención de un entrenador aleatorio de la lista de espera cuando está vacía.
    ///
    /// Verifica que el método <c>GetRandomTrainerWaiting()</c> devuelva null cuando no hay entrenadores en la lista de espera.
    [Test]
    public void TestGetRandomTrainerWaitingReturnsNullWhenEmpty()
    {
        Trainer? result = waitList.GetRandomTrainerWaiting();
        Assert.IsNull(result);
    }

    /// @brief Prueba la obtención de un entrenador aleatorio de la lista de espera cuando contiene entrenadores.
    ///
    /// Verifica que el método <c>GetRandomTrainerWaiting()</c> devuelva un entrenador cuando la lista de espera tiene entrenadores y que el entrenador devuelto esté en la lista.
    [Test]
    public void TestGetRandomTrainerWaitingReturnsTrainerWhenNotEmpty()
    {
        waitList.AñadirTrainer(jugador1);
        waitList.AñadirTrainer(jugador2);

        Trainer? result = waitList.GetRandomTrainerWaiting();
        Assert.IsNotNull(result);
        Assert.IsTrue(waitList.WaitListJugador.Contains(result));
    }
}