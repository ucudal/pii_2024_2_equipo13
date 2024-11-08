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
    
}
