using NUnit.Framework;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Library;
using Library.Clases;
using Library.EfectosAtaque;
using Library.Items;
using Library.Pokemons;
using Library.TiposPokemon;
using Ucu.Poo.DiscordBot.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

/// @brief Clase de pruebas para la funcionalidad de la clase Facade.
///
/// La clase <c>FacadeTests</c> contiene un conjunto de pruebas unitarias para verificar el correcto funcionamiento de la clase <c>Facade</c>.
/// Se asegura de que las operaciones relacionadas con la lista de espera, los entrenadores y las batallas se realicen correctamente.
public class FacadeTests
{
    private Facade facade;
    private Trainer trainer1;
    private Trainer trainer2;

    /// @brief Configura el entorno necesario para las pruebas.
    ///
    /// Inicializa la instancia de <c>Facade</c> y crea dos entrenadores para las pruebas.
    [SetUp]
    public void SetUp()
    {
        facade = Facade.Instance;
        trainer1 = new Trainer("Trainer1");
        trainer2 = new Trainer("Trainer2");
        facade.AddTrainerToWaitingList(trainer1.DisplayName);
        facade.AddTrainerToWaitingList(trainer2.DisplayName);
    }

    /// @brief Restablece el estado de la fachada después de cada prueba.
    ///
    /// Llama a <c>Facade.Reset()</c> para limpiar la instancia.
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    /// @brief Prueba la adición de entrenadores a la lista de espera.
    ///
    /// Verifica que los entrenadores sean agregados correctamente a la lista de espera.
    [Test]
    public void AddTrainingToWaitingList()
    {
        var facade = Facade.Instance;
        Trainer ash = new Trainer("Ash");
        Trainer misty = new Trainer("Misty");

        facade.AddTrainerToWaitingList(ash.DisplayName);
        facade.AddTrainerToWaitingList(misty.DisplayName);

        Assert.That(facade.GetAllTrainersWaiting().Count, Is.EqualTo(61));
    }

    /// @brief Prueba un ataque básico cuando no hay un turno actual.
    ///
    /// Verifica que el método <c>AtacarBasico()</c> devuelva un mensaje de error cuando no hay un turno activo.
    [Test]
    public void AtacarBasico_NoCurrentTurn_ReturnsErrorMessage()
    {
        facade.IniciarBatalla(trainer1.DisplayName, trainer2.DisplayName);
        string result = facade.AtacarBasico(trainer1, trainer2, 1);

        Assert.That(result, Is.EqualTo("Uno o ambos jugadores no están disponibles para atacar."));
    }

    /// @brief Prueba la eliminación de un entrenador de la lista de espera.
    ///
    /// Verifica que el método <c>RemoveTrainerFromWaitingList()</c> elimine correctamente al entrenador y devuelva el mensaje adecuado.
    [Test]
    public void RemoveTrainerFromWaitingListTrainerDoesNotExistReturnsNotInListMessage()
    {
        var facade = Facade.Instance;
        Trainer ash = new Trainer("Ash");
        Trainer misty = new Trainer("Misty");
        facade.AddTrainerToWaitingList(ash.DisplayName);
        facade.AddTrainerToWaitingList(misty.DisplayName);
        string result = facade.RemoveTrainerFromWaitingList("Misty");
        string result2 = facade.RemoveTrainerFromWaitingList("Ash");
        Assert.That(result, Is.EqualTo("Misty removido de la lista de espera"));
        Assert.That(result2, Is.EqualTo("Ash removido de la lista de espera"));
    }

    /// @brief Prueba la inicialización de una batalla con un equipo incompleto.
    ///
    /// Verifica que el método <c>IniciarBatalla()</c> devuelva un mensaje de error si el entrenador no tiene un equipo completo.
    [Test]
    public void IniciarBatalla_TrainerWithoutCompleteTeam_ReturnsErrorMessage()
    {
        facade.AddTrainerToWaitingList("Trainer1");

        string result = facade.IniciarBatalla("Trainer1");

        Assert.That(result, Is.EqualTo("No tienes un equipo completo para iniciar una batalla."));
    }

    /// @brief Prueba la obtención de un entrenador aleatorio de la lista de espera.
    ///
    /// Verifica que el método <c>ObtenerTrainerRandom()</c> devuelva un entrenador aleatorio de la lista.
    [Test]
    public void ObtenerTrainerRandomWhenCalledReturnsRandomTrainer()
    {
        facade.AddTrainerToWaitingList("Trainer3");
        facade.AddTrainerToWaitingList("Trainer4");

        Trainer randomTrainer = facade.ObtenerTrainerRandom("Trainer1");

        Assert.IsNotNull(randomTrainer);
        Assert.AreNotEqual("Trainer1", randomTrainer.DisplayName);
        Assert.Contains(randomTrainer.DisplayName, new List<string> { "Trainer2", "Trainer3", "Trainer4" });
    }

    /// @brief Prueba la visualización de ataques disponibles cuando el entrenador no existe.
    ///
    /// Verifica que el método <c>MostrarAtaquesDisponibles()</c> devuelva un mensaje de error si el entrenador no existe.
    [Test]
    public void MostrarAtaquesDisponibles_WhenTrainerDoesNotExist_ReturnsErrorMessage()
    {
        string result = facade.MostrarAtaquesDisponibles("NonExistentTrainer");

        Assert.That(result, Is.EqualTo("No se pudo determinar los ataques disponibles"));
    }

    /// @brief Prueba la visualización de ítems disponibles cuando el entrenador no existe.
    ///
    /// Verifica que el método <c>MostrarItemsDisponibles()</c> devuelva un mensaje de error si el entrenador no existe.
    [Test]
    public void MostrarItemsDisponibles_WhenTrainerDoesNotExist_ReturnsErrorMessage()
    {
        string result = facade.MostrarItemsDisponibles("NonExistentTrainer");

        Assert.That(result, Is.EqualTo("No se pudo determinar los items disponibles"));
    }

    /// @brief Prueba que el método <c>Rendirse()</c> devuelva un mensaje adecuado si no es el turno del jugador.
    ///
    /// Verifica que un jugador reciba un mensaje de error si intenta rendirse fuera de su turno.
    [Test]
    public void RendirseWhenCalledReturnsCorrectMessage()
    {
        facade.IniciarBatalla(trainer1.DisplayName, trainer2.DisplayName);
        string result = facade.Rendirse(trainer1.DisplayName);
        Assert.That(result, Is.EqualTo($"No es tu turno."));
    }

    /// @brief Prueba que el método <c>RealizarAccion()</c> devuelva un mensaje adecuado si no es el turno del jugador.
    ///
    /// Verifica que un jugador reciba un mensaje de error si intenta realizar una acción fuera de su turno.
    [Test]
    public void RealizarAccionWhenCalledReturnsCorrectMessage()
    {
        facade.IniciarBatalla(trainer1.DisplayName, trainer2.DisplayName);
        string result = facade.RealizarAccion(trainer1.DisplayName, "cambiar", null, "Pikachu");
        Assert.That(result, Is.EqualTo($"No es tu turno."));
    }

    /// @brief Prueba la notificación del turno del jugador actual cuando no hay una batalla en curso.
    ///
    /// Verifica que el método <c>NotificarTurnoJugadorActual()</c> devuelva el mensaje adecuado cuando no hay una batalla en curso.
    [Test]
    public void NotificarTurnoJugadorActualWhenCalledReturnsCorrectMessage()
    {
        facade.IniciarBatalla(trainer1.DisplayName, trainer2.DisplayName);
        string result = facade.NotificarTurnoJugadorActual();
        Assert.That(result, Is.EqualTo($"No hay una batalla en curso."));
    }

    /// @brief Prueba la adición de un entrenador a la lista de espera cuando no está agregado.
    ///
    /// Verifica que el entrenador sea agregado correctamente a la lista de espera si no estaba agregado.
    [Test]
    public void AddTrainerToWaitingListWhenTrainerWasNotAddedReturnsAdded()
    {
        string result = Facade.Instance.AddTrainerToWaitingList("user");
        Assert.That(result, Is.EqualTo("user ha sido agregado a la lista de espera."));
    }

    /// @brief Prueba la adición de un entrenador a la lista de espera cuando ya está agregado.
    ///
    /// Verifica que el entrenador reciba un mensaje adecuado si intenta agregarse a la lista de espera nuevamente.
    [Test]
    public void AddTrainerToWaitingListWhenTrainerWasAddedReturnsExisting()
    {
        Facade.Instance.AddTrainerToWaitingList("user");
        string result = Facade.Instance.AddTrainerToWaitingList("user");
        Assert.That(result, Is.EqualTo("user ya ha sido agregado a la lista de espera"));
    }

    /// @brief Prueba la eliminación de un entrenador de la lista de espera.
    ///
    /// Verifica que un entrenador pueda ser eliminado correctamente de la lista de espera.
    [Test]
    public void RemoveTrainerFromWaitingListWhenTrainerWasAddedReturnsRemoved()
    {
        Facade.Instance.AddTrainerToWaitingList("user");
        string result = Facade.Instance.RemoveTrainerFromWaitingList("user");
        Assert.That(result, Is.EqualTo("user removido de la lista de espera"));
    }

    /// @brief Prueba la eliminación de un entrenador de la lista de espera cuando no estaba agregado.
    ///
    /// Verifica que se devuelva un mensaje adecuado si se intenta eliminar un entrenador que no está en la lista de espera.
    [Test]
    public void RemoveTrainerFromWaitingListWhenTrainerWasNotAddedReturnsNotAdded()
    {
        string result = Facade.Instance.RemoveTrainerFromWaitingList("user");
        Assert.That(result, Is.EqualTo("user no está en la lista de espera"));
    }

    /// @brief Prueba la obtención de todos los entrenadores en la lista de espera.
    ///
    /// Verifica que el método <c>GetAllTrainersWaiting()</c> devuelva la lista correcta de entrenadores en espera.
    [Test]
    public void GetAllTrainersWaitingWhenSomebodyIsWaitingReturnsSomebody()
    {
        Facade.Instance.AddTrainerToWaitingList("user");
        string result = Facade.Instance.GetAllTrainersWaiting();
        Assert.That(result, Does.Contain("user"));
    }

    /// @brief Prueba que un entrenador no esté en la lista de espera.
    ///
    /// Verifica que se devuelva un mensaje adecuado si el entrenador no está en la lista de espera.
    [Test]
    public void TrainerIsWaitingWhenNotAddedReturnsNotWaiting()
    {
        string result = Facade.Instance.TrainerIsWaiting("user");
        Assert.That(result, Is.EqualTo("user no está en la lista de espera"));
    }

    /// @brief Prueba que un entrenador esté en la lista de espera.
    ///
    /// Verifica que el método <c>TrainerIsWaiting()</c> devuelva el mensaje adecuado si el entrenador está en la lista de espera.
    [Test]
    public void TrainerIsWaitingWhenAddedReturnsWaiting()
    {
        Facade.Instance.AddTrainerToWaitingList("user");
        string result = Facade.Instance.TrainerIsWaiting("user");
        Assert.That(result, Is.EqualTo("user está en la lista de espera"));
    }

    /// @brief Prueba la obtención de un entrenador por su nombre de visualización.
    ///
    /// Verifica que el método <c>GetTrainerByDisplayName()</c> devuelva el entrenador correcto si existe.
    [Test]
    public void GetTrainerByDisplayNameReturnsCorrectTrainer()
    {
        Trainer result = facade.GetTrainerByDisplayName("Trainer1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Trainer1", result.DisplayName);
    }

    /// @brief Prueba la obtención de un entrenador por su nombre de visualización cuando no existe.
    ///
    /// Verifica que el método <c>GetTrainerByDisplayName()</c> devuelva null si el entrenador no existe.
    [Test]
    public void GetTrainerByDisplayNameReturnsNullForNonExistentTrainer()
    {
        Trainer result = facade.GetTrainerByDisplayName("NonExistentTrainer");

        Assert.IsNull(result);
    }

    /// @brief Prueba para obtener todos los entrenadores en espera cuando nadie está en espera.
    ///
    /// Se espera que la respuesta indique que no hay nadie en espera.
    [Test]
    public void GetAllTrainersWaitingWhenNobodyIsWaitingReturnsNobodyIsWaiting()
    {
        string result = Facade.Instance.GetAllTrainersWaiting();
        Assert.That(result, Is.EqualTo("Jugadores en espera:\n1. Trainer1\n2. Trainer2\n"));
    }

    /// @brief Prueba para iniciar una batalla sin oponente y sin entrenadores en espera.
    ///
    /// Se espera que la respuesta indique que el usuario no tiene un equipo completo para iniciar una batalla.
    [Test]
    public void StartBattleWhenNoOpponentAndNobodyIsWaitingReturnsNobodyIsWaiting()
    {
        string result = Facade.Instance.IniciarBatalla("user", null);
        Assert.That(result, Is.EqualTo("No tienes un equipo completo para iniciar una batalla."));
    }

    /// @brief Prueba para iniciar una batalla con un oponente que no está en espera.
    ///
    /// Se espera que la respuesta indique que el usuario no tiene un equipo completo para iniciar una batalla.
    [Test]
    public void StartBattleWhenOpponentButIsNotWaitingReturnsNotWaiting()
    {
        string result = Facade.Instance.IniciarBatalla("user", "opponent");
        Assert.That(result, Is.EqualTo("No tienes un equipo completo para iniciar una batalla."));
    }

    /// @brief Prueba para iniciar una batalla sin oponente pero con un entrenador en espera.
    ///
    /// Agrega un oponente a la lista de espera y se espera que la respuesta indique que el usuario no tiene un equipo completo.
    [Test]
    public void StartBattleWhenNoOpponentButOneWaitingReturnsBattleWithWaiting()
    {
        Facade.Instance.AddTrainerToWaitingList("opponent");
        string result = Facade.Instance.IniciarBatalla("user", null);
        Assert.That(result, Is.EqualTo("No tienes un equipo completo para iniciar una batalla."));
    }

    /// @brief Prueba para iniciar una batalla con un oponente que está en espera.
    ///
    /// Agrega un oponente a la lista de espera y se espera que la respuesta indique que el usuario no tiene un equipo completo.
    [Test]
    public void StartBattleWhenOpponentWaitingReturnsBattleWithOpponent()
    {
        Facade.Instance.AddTrainerToWaitingList("opponent");
        string result = Facade.Instance.IniciarBatalla("user", "opponent");
        Assert.That(result, Is.EqualTo("No tienes un equipo completo para iniciar una batalla."));
    }

    /// @brief Prueba para obtener el oponente en una batalla cuando no hay una batalla en curso.
    ///
    /// Se espera que el oponente retornado sea nulo.
    [Test]
    public void ObtenerOponenteEnBatallaReturnsNullWhenNoBattle()
    {
        Trainer? opponent = facade.ObtenerOponenteEnBatalla(trainer1.DisplayName);

        Assert.IsNull(opponent);
    }

    /// @brief Prueba para mostrar los Pokémon disponibles para selección.
    ///
    /// Prueba tanto el caso cuando hay Pokémon disponibles como cuando la lista está vacía.
    [Test]
    public void MostrarPokemonsDisponibles_Test()
    {
        // Arrange
        SelectorPokemon selectorPokemon = new SelectorPokemon();

        // Act: Caso 1 - Lista inicial de Pokémon
        string resultadoConPokemons = selectorPokemon.MostrarPokemonsDisponibles();

        // Assert: Verificar la lista inicial de Pokémon
        string resultadoEsperadoConPokemons = "Por favor selecciona tus 6 Pokémon de la siguiente lista:\n" +
                                              "- Alakazam\n" +
                                              "- Marowak\n" +
                                              "- Pikachu\n" +
                                              "- Machamp\n" +
                                              "- Snorlax\n" +
                                              "- Arbok\n" +
                                              "- Sandslash\n" +
                                              "- Scyther\n" +
                                              "- Blastoise\n" +
                                              "- Arcanine\n";
        Assert.That(resultadoConPokemons, Is.EqualTo(resultadoEsperadoConPokemons));

        // Act: Caso 2 - Lista de Pokémon vacía
        selectorPokemon.PokemonsDisponibles.Clear(); // Vaciar la lista de Pokémon
        string resultadoSinPokemons = selectorPokemon.MostrarPokemonsDisponibles();

        // Assert: Verificar mensaje para lista vacía
        Assert.That(resultadoSinPokemons, Is.EqualTo("No hay Pokémon disponibles."));
    }
}