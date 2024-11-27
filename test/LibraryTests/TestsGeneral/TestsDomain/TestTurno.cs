using Library.Clases;
using Library.Pokemons;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests;

/// @brief Clase de pruebas para la funcionalidad de la clase Turno.
///
/// La clase <c>TurnoTests</c> contiene un conjunto de pruebas unitarias para verificar el correcto funcionamiento de la clase <c>Turno</c>.
/// Se asegura de que los turnos se cambien correctamente entre los jugadores, se validen los ataques especiales y se manejen condiciones especiales como quemaduras o envenenamientos.
public class TurnoTests
{
    private Turno turno;
    private Trainer jugador1;
    private Trainer jugador2;
    private Alakazam alakazam;
    private Arbok arbok;

    /// @brief Configura el entorno necesario para las pruebas.
    ///
    /// Inicializa los jugadores, los Pokémon y el objeto <c>Turno</c> antes de ejecutar cada prueba.
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Trainer("Jugador 1");
        jugador2 = new Trainer("Jugador 2");

        alakazam = new Alakazam();
        arbok = new Arbok();

        jugador1.Pokemons.Add(alakazam);
        jugador2.Pokemons.Add(arbok);

        jugador1.PokemonActivo = jugador1.Pokemons.FirstOrDefault();
        jugador2.PokemonActivo = jugador2.Pokemons.FirstOrDefault();

        turno = new Turno(jugador1, jugador2);
    }

    /// @brief Prueba que el cambio de turno cambie correctamente los jugadores actuales.
    ///
    /// Verifica que al finalizar un turno, los roles de jugador actual y rival se cambien correctamente.
    [Test]
    public void CambiarTurnoCorrectlySwitchesPlayers()
    {
        turno.FinalizarTurno();
        turno.CambiarTurno();

        Assert.AreEqual(jugador2, turno.JugadorActual);
        Assert.AreEqual(jugador1, turno.JugadorRival);
    }

    /// @brief Prueba que el ataque especial sea válido en turnos pares.
    ///
    /// Verifica que el método <c>ValidarAtaqueEspecial()</c> devuelva true cuando el contador de turnos es par.
    [Test]
    public void ValidarAtaqueEspecialReturnsTrueOnEvenTurns()
    {
        jugador1.ContadorTurnos = 2;

        bool result = turno.ValidarAtaqueEspecial();

        Assert.IsTrue(result, "Special attack should be valid on even turns.");
    }

    /// @brief Prueba que el ataque especial no sea válido en turnos impares.
    ///
    /// Verifica que el método <c>ValidarAtaqueEspecial()</c> devuelva false cuando el contador de turnos es impar.
    [Test]
    public void ValidarAtaqueEspecialReturnsFalseOnOddTurns()
    {
        jugador1.ContadorTurnos = 3;

        bool result = turno.ValidarAtaqueEspecial();

        Assert.IsFalse(result, "Special attack should not be valid on odd turns.");
    }

    /// @brief Prueba que el ataque especial no sea válido en el primer turno.
    ///
    /// Verifica que el método <c>ValidarAtaqueEspecial()</c> devuelva false cuando el contador de turnos es uno.
    [Test]
    public void ValidarAtaqueEspecialReturnsFalseOnFirstTurn()
    {
        jugador1.ContadorTurnos = 1;

        bool result = turno.ValidarAtaqueEspecial();

        Assert.IsFalse(result, "Special attack should not be valid on the first turn.");
    }

    /// @brief Prueba que se lance una excepción si los jugadores o Pokémon no están inicializados.
    ///
    /// Verifica que el método <c>CambiarTurno()</c> lance una excepción si alguno de los jugadores no está inicializado.
    [Test]
    public void CambiarTurnoThrowsExceptionIfPlayersOrPokemonsNotInitialized()
    {
        turno = new Turno(null, jugador2);

        Assert.Throws<InvalidOperationException>(() => turno.CambiarTurno());
    }

    /// @brief Prueba que se aplique daño por quemadura si el Pokémon está quemado.
    ///
    /// Verifica que al cambiar de turno, un Pokémon quemado reciba daño.
    [Test]
    public void CambiarTurnoAppliesBurnDamageIfPokemonIsBurned()
    {
        jugador1.PokemonActivo.EstaQuemado = true;
        turno.FinalizarTurno();

        turno.CambiarTurno();
        Assert.Less(jugador1.PokemonActivo.VidaActual, jugador1.PokemonActivo.VidaMax);
    }

    /// @brief Prueba que se aplique daño por envenenamiento si el Pokémon está envenenado.
    ///
    /// Verifica que al cambiar de turno, un Pokémon envenenado reciba daño.
    [Test]
    public void CambiarTurnoAppliesPoisonDamageIfPokemonIsPoisoned()
    {
        jugador1.PokemonActivo.EstaEnvenenado = true;
        turno.FinalizarTurno();

        turno.CambiarTurno();

        Assert.Less(jugador1.PokemonActivo.VidaActual, jugador1.PokemonActivo.VidaMax);
    }

    /// @brief Prueba que rendirse marque el turno como finalizado.
    ///
    /// Verifica que al rendirse, el atributo <c>Finalizado</c> se marque como true.
    [Test]
    public void TestRendirseMarksTurnAsFinalized()
    {
        Assert.IsFalse(turno.Finalizado);

        turno.Rendirse();

        Assert.IsTrue(turno.Finalizado);
    }

    /// @brief Prueba que el cambio de turno cambie correctamente los jugadores actuales.
    ///
    /// Verifica si el flujo de cambiar los turnos entre los jugadores funciona correctamente.
    [Test]
    public void TestCambiarTurnoCorrectlySwitchesPlayers()
    {
        turno.FinalizarTurno();
        turno.CambiarTurno();

        Assert.AreEqual(jugador2, turno.JugadorActual);
        Assert.AreEqual(jugador1, turno.JugadorRival);
    }

    /// @brief Prueba si la batalla está finalizada cuando el jugador actual no tiene Pokémon aptos para la batalla.
    ///
    /// Verifica que la batalla se marque como finalizada si el jugador actual no tiene Pokémon disponibles para luchar.
    [Test]
    public void TestBatallaFinalizadaJugadorActualSinPokemon()
    {
        foreach (var pokemon in jugador1.Pokemons)
        {
            pokemon.AptoParaBatalla = false;
        }

        bool batallaFinalizada = turno.BatallaFinalizada();

        Assert.IsTrue(batallaFinalizada, "La batalla debería estar finalizada cuando el jugador actual no tiene Pokémon aptos para la batalla.");
    }

    /// @brief Prueba si la batalla está finalizada cuando el jugador rival no tiene Pokémon aptos para la batalla.
    ///
    /// Verifica que la batalla se marque como finalizada si el jugador rival no tiene Pokémon disponibles para luchar.
    [Test]
    public void TestBatallaFinalizadaJugadorRivalSinPokemon()
    {
        foreach (var pokemon in jugador2.Pokemons)
        {
            pokemon.AptoParaBatalla = false;
        }

        bool batallaFinalizada = turno.BatallaFinalizada();

        Assert.IsTrue(batallaFinalizada, "La batalla debería estar finalizada cuando el jugador rival no tiene Pokémon aptos para la batalla.");
    }

    /// @brief Prueba si la batalla continúa cuando ambos jugadores tienen Pokémon aptos para la batalla.
    ///
    /// Verifica que la batalla no se marque como finalizada si ambos jugadores tienen Pokémon disponibles para luchar.
    [Test]
    public void TestBatallaFinalizadaAmbosJugadoresConPokemon()
    {
        jugador1.Pokemons[0].AptoParaBatalla = true;
        jugador2.Pokemons[0].AptoParaBatalla = true;

        bool batallaFinalizada = turno.BatallaFinalizada();

        Assert.IsFalse(batallaFinalizada, "La batalla no debería estar finalizada cuando ambos jugadores tienen Pokémon aptos para la batalla.");
    }

    /// @brief Prueba que al finalizar el turno se marque como finalizado.
    ///
    /// Verifica que el flujo de turnos funcione y que al final del turno se dé por concluido.
    [Test]
    public void TestFinalizarTurnoMarksTurnAsFinalized()
    {
        Assert.IsFalse(turno.Finalizado);

        turno.FinalizarTurno();

        Assert.IsTrue(turno.Finalizado);
    }
}