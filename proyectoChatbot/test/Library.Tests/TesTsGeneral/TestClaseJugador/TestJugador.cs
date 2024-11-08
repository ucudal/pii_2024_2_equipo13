using Library.Clases;
using Library.Pokemons;

[TestFixture]
public class TestJugador
{
    private Turno _turnojuego;
    private Jugador _jugador1;
    private Jugador _jugador2;
    private Alakazam _alakazam;
    private Arbok _arbok;
    private Blastoise _blastoise;

    [SetUp]
    public void Setup()
    {
        _jugador1 = new Jugador("Jugador 1");
        _jugador2 = new Jugador("Jugador 2");

        // Crear instancias reales de Pokémon
        _alakazam = new Alakazam();
        _blastoise = new Blastoise();
        _arbok = new Arbok();

        // Asignar Pokémon a los jugadores
        _jugador1.Pokemons.Add(_alakazam);
        _jugador1.Pokemons.Add(_blastoise);
        _jugador2.Pokemons.Add(_arbok);

        // Asignar el Pokémon activo manualmente y verificar que no sea null
        _jugador1.PokemonActivo = _jugador1.Pokemons[0];
        _jugador2.PokemonActivo = _jugador2.Pokemons[0];

        Assert.IsNotNull(_jugador1.PokemonActivo, "PokemonActivo en _jugador1 no debería ser null");
        Assert.IsNotNull(_jugador2.PokemonActivo, "PokemonActivo en _jugador2 no debería ser null");

        // Verificar que AtaquesBasicosPublicos contiene el ataque en el índice 1
        Assert.IsTrue(_jugador1.PokemonActivo.AtaquesBasicosPublicos.ContainsKey(1),
            "El ataque en el índice 1 no está disponible en AtaquesBasicosPublicos");

        // Inicializamos turno
        _turnojuego = new Turno(_jugador1, _jugador2);
    }

    [Test]
    //(como alaracion) en este metodo, se prueba que funcione la distinta funcionalidad, como la efetividad de tipos, manejada dentro de cada pokemon
    public void Test_Ataque_Jugador_Con_Efectividad_De_Tipos()
    {
        // Arrange
        double vidaInicial = _jugador2.PokemonActivo.VidaActual;

        // Simular entrada del usuario: "1" para ataque básico y "1" para el índice del ataque en el diccionario
        using (var consoleInput = new StringReader("1\n1\n"))
        {
            Console.SetIn(consoleInput);

            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Act
                _jugador1.Atacar(_jugador2);

                // Obtener el daño esperado del ataque básico en el índice 1
                double dañoEsperado = _jugador1.PokemonActivo.AtaquesBasicosPublicos[1].Daño;

                // Assert
                Console.WriteLine($"{vidaInicial}");
                Assert.That(_jugador1.PokemonActivo.AtaquesBasicosPublicos[1].Daño * 2,
                    Is.EqualTo(_jugador1.PokemonActivo.AtaqueBasico(_jugador2.PokemonActivo, 1)),
                    "El daño recibido no coincide con el daño esperado.");
            }
        }
    }

    [Test]
    public void Usar_Item_Jugador()
    {
        //arrange
        using (var consoleInput = new StringReader("1\nAlakazam\n"))
        {
            Console.SetIn(consoleInput);

            // Capturamos la salida de consola para verificar mensajes de éxito
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                double vidaInicial = _alakazam.VidaActual;
                int cantidadItemsInicial = _jugador1.ItemsJugador.Count;

                _jugador1.UsarItem();
                // Assert
                // Verificar que el Pokémon haya sido curado
                Assert.That(_alakazam.VidaActual, Is.EqualTo(vidaInicial + 70),"El Pokémon  recibio la curación esperada.");

                // Verificar que la Superpocion haya sido eliminada del inventario
                Assert.That(_jugador1.ItemsJugador.Count, Is.EqualTo(cantidadItemsInicial - 1), "La Superpocion no fue eliminada del inventario.");

                // Verificar que el mensaje de éxito se imprimió en la consola
                StringAssert.Contains("La superpoción fue usada en Alakazam.", consoleOutput.ToString(), "El mensaje de éxito no se encontró en la salida de consola.");
            }
        }
    }

    [Test]
    public void Cambiar_El_Pokemon_Activo_Del_Jugador()
    {
        // Act
        _jugador1.CambiarPokemonActivo("Blastoise");

        // Assert
        Assert.That(_jugador1.PokemonActivo, Is.EqualTo(_blastoise), "El Pokémon activo no es el esperado.");
    }
}
