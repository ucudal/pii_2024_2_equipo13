using NUnit.Framework;
using Library.Clases;
using Library.Pokemons;
using Ucu.Poo.DiscordBot.Domain;
using System;
using System.IO;
using Library.Items;

/// @brief Clase de pruebas para la funcionalidad de la clase Trainer.
///
/// La clase <c>TestTrainer</c> contiene un conjunto de pruebas unitarias para verificar el correcto funcionamiento de la clase <c>Trainer</c>.
/// Se asegura de que las funciones relacionadas con los entrenadores, como cambiar de Pokémon, usar items, y administrar el inventario de Pokémon, funcionen correctamente.
[TestFixture]
public class TestTrainer
{
    private Turno turnojuego;
    private Trainer jugador1;
    private Trainer jugador2;
    private Trainer trainer;
    private Alakazam alakazam;
    private Arbok arbok;
    private Blastoise blastoise;
    private Pikachu pikachu;
    private Sandslash sandslash;
    private Snorlax snorlax;
    private Machamp machamp;

    /// @brief Configura el entorno necesario para las pruebas.
    ///
    /// Inicializa los jugadores, los Pokémon y el objeto <c>Trainer</c> antes de ejecutar cada prueba.
    [SetUp]
    public void Setup()
    {
        jugador1 = new Trainer("Jugador 1");
        jugador2 = new Trainer("Jugador 2");

        // Crear instancias reales de Pokémon
        alakazam = new Alakazam();
        blastoise = new Blastoise();
        arbok = new Arbok();
        pikachu = new Pikachu();
        sandslash = new Sandslash();
        snorlax = new Snorlax();
        machamp = new Machamp();

        trainer = new Trainer("Ash");

        // Asignar Pokémon a los jugadores
        jugador1.Pokemons.Add(alakazam);
        jugador1.Pokemons.Add(blastoise);
        jugador2.Pokemons.Add(arbok);

        trainer.pokebolasInventario(alakazam);
        trainer.pokebolasInventario(arbok);

        // Asignar el Pokémon activo manualmente y verificar que no sea null
        jugador1.PokemonActivo = jugador1.Pokemons[0];
        jugador2.PokemonActivo = jugador2.Pokemons[0];

        Assert.IsNotNull(jugador1.PokemonActivo, "PokemonActivo en jugador1 no debería ser null");
        Assert.IsNotNull(jugador2.PokemonActivo, "PokemonActivo en jugador2 no debería ser null");

        // Verificar que AtaquesBasicosPublicos contiene el ataque en el índice 1
        Assert.IsTrue(jugador1.PokemonActivo.AtaquesBasicosPublicos.ContainsKey(1),
            "El ataque en el índice 1 no está disponible en AtaquesBasicosPublicos");

        // Inicializamos turno
        turnojuego = new Turno(jugador1, jugador2);
    }

    /// @brief Prueba el cambio de Pokémon activo en caso de que el actual no esté apto para batalla.
    ///
    /// Verifica que el Pokémon activo cambie a uno apto para batalla si el actual no puede luchar.
    [Test]
    public void CambiarPokemonChangesToFitPokemon()
    {
        alakazam.AptoParaBatalla = false;
        arbok.AptoParaBatalla = true;
        trainer.PokemonActivo = alakazam;

        string result = trainer.CambiarPokemon();

        Assert.AreEqual(arbok, trainer.PokemonActivo, "El Pokémon activo debería ser Arbok.");
        StringAssert.Contains("ha cambiado automáticamente al Pokémon Arbok", result, "El mensaje de éxito no se encontró en la salida.");
    }

    /// @brief Prueba los nombres y descripciones de los ítems del juego.
    ///
    /// Verifica que los nombres y descripciones de los ítems <c>CuraTotal</c>, <c>Revivir</c> y <c>Superpocion</c> sean los esperados.
    [Test]
    public void TestNombreDescripcionItems()
    {
        var curaTotal = new CuraTotal();
        var revivir = new Revivir();
        var superpocion = new Superpocion();

        Assert.AreEqual("Cura Total", curaTotal.Nombre, "El nombre del ítem no es el esperado.");
        Assert.AreEqual("Cura toda la salud de tu Pokémon y remueve los efectos especiales.", curaTotal.Descripcion, "La descripción del ítem no es la esperada.");

        Assert.AreEqual("Revivir", revivir.Nombre, "El nombre del ítem no es el esperado.");
        Assert.AreEqual("Revive a un Pokémon con el 50% de vida.", revivir.Descripcion, "La descripción del ítem no es la esperada.");

        Assert.AreEqual("Super Poción", superpocion.Nombre, "El nombre del ítem no es el esperado.");
        Assert.AreEqual("Recupera 70HP.", superpocion.Descripcion, "La descripción del ítem no es la esperada.");
    }

    /// @brief Prueba la adición de un Pokémon al inventario del entrenador.
    ///
    /// Verifica que un Pokémon sea agregado al inventario si no está presente.
    [Test]
    public void TestAddPokemonToInventoryPokemonNotInInventory()
    {
        trainer.pokebolasInventario(alakazam);
        Assert.Contains(alakazam, trainer.Pokemons, "El Pokémon no fue añadido al inventario.");
    }

    /// @brief Prueba que no se agregue un Pokémon duplicado al inventario del entrenador.
    ///
    /// Verifica que un Pokémon no se agregue más de una vez si ya está en el inventario.
    [Test]
    public void TestAddPokemonToInventoryPokemonAlreadyInInventory()
    {
        trainer.pokebolasInventario(alakazam);

        trainer.pokebolasInventario(alakazam);
        int count = trainer.Pokemons.Count(p => p == alakazam);
        Assert.AreEqual(1, count, "El Pokémon fue añadido más de una vez al inventario.");
    }

    /// @brief Prueba la adición de múltiples Pokémon al inventario del entrenador.
    ///
    /// Verifica que varios Pokémon puedan ser agregados al inventario sin problemas.
    [Test]
    public void TestAddMultiplePokemonsToInventory()
    {
        trainer.pokebolasInventario(alakazam);
        trainer.pokebolasInventario(arbok);
        Assert.Contains(alakazam, trainer.Pokemons, "Alakazam no fue añadido al inventario.");
        Assert.Contains(arbok, trainer.Pokemons, "Arbok no fue añadido al inventario.");
    }

    /// @brief Prueba el uso de un ítem en un Pokémon.
    ///
    /// Verifica que se pueda usar un ítem en un Pokémon y que este sea eliminado del inventario.
    [Test]
    public void UsarItemJugador()
    {
        double vidaInicial = alakazam.VidaActual;
        int cantidadItemsInicial = jugador1.ItemsJugador.Count;

        string resultado = jugador1.UsarItem("1", "Alakazam");

        Assert.That(alakazam.VidaActual, Is.EqualTo(vidaInicial + 0),
            "El Pokémon recibió la curación esperada.");

        // Verificar que la Superpocion haya sido eliminada del inventario
        Assert.That(jugador1.ItemsJugador.Count, Is.EqualTo(cantidadItemsInicial - 1),
            "La Superpocion no fue eliminada del inventario.");

        // Verificar que el mensaje de éxito se imprimió en la consola
        StringAssert.Contains("La superpoción fue usada en Alakazam.", resultado,
            "El mensaje de éxito no se encontró en la salida.");
    }

    /// @brief Prueba el cambio del Pokémon activo del jugador.
    ///
    /// Verifica que el jugador pueda cambiar su Pokémon activo a otro disponible en su inventario.
    [Test]
    public void CambiarElPokemonActivoDelJugador()
    {
        jugador1.CambiarPokemonActivo("Blastoise", true);

        Assert.That(jugador1.PokemonActivo, Is.EqualTo(blastoise), "El Pokémon activo no es el esperado.");
    }

    /// @brief Prueba la obtención del estado de los Pokémon del jugador.
    ///
    /// Verifica que el método <c>ObtenerEstadoPokemons()</c> devuelva correctamente el estado de los Pokémon del jugador.
    [Test]
    public void TestObtenerEstadoPokemons()
    {
        string estado = jugador1.ObtenerEstadoPokemons();

        StringAssert.Contains("Alakazam - Vida:", estado, "El estado de Alakazam no se encontró en la salida.");
        StringAssert.Contains("Blastoise - Vida:", estado, "El estado de Blastoise no se encontró en la salida.");
    }

    /// @brief Prueba el ataque de un jugador sin Pokémon apto para la batalla.
    ///
    /// Verifica que no se pueda realizar un ataque si el Pokémon activo no está apto para la batalla.
    [Test]
    public void TestAtacarSinPokemonApto()
    {
        jugador1.PokemonActivo.AptoParaBatalla = false;

        string resultado = jugador1.AtacarBasico(jugador2, jugador1.Pokemons.IndexOf(jugador1.PokemonActivo));
        StringAssert.Contains("no tiene un Pokémon apto para atacar", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba el uso de un ítem cuando el jugador no tiene ítems disponibles.
    ///
    /// Verifica que se muestre un mensaje de error adecuado cuando el jugador intenta usar un ítem que no tiene en su inventario.
    [Test]
    public void TestUsarItemSinItem()
    {
        jugador1.ItemsJugador.Clear();

        string resultado = jugador1.UsarItem("1", "Alakazam");

        StringAssert.Contains("No quedan Super Pociones en la lista de ítems", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba el cambio de un Pokémon activo no disponible en el inventario.
    ///
    /// Verifica que se muestre un mensaje de error adecuado cuando el jugador intenta cambiar su Pokémon activo a uno que no está en su inventario.
    [Test]
    public void TestCambiarPokemonActivoNoDisponible()
    {
        string resultado = jugador1.CambiarPokemonActivo("Pikachu", true);

        StringAssert.Contains("no fue encontrado en la lista de Pokémon", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba el uso de un ítem en un Pokémon no existente.
    ///
    /// Verifica que se muestre un mensaje de error adecuado cuando se intenta usar un ítem en un Pokémon que no está en el inventario.
    [Test]
    public void UsarItemSuperpocionPokemonNoExistente()
    {
        string opcion = "1";
        string nombrePokemon = "Pikachu";

        string resultado = jugador1.UsarItem(opcion, nombrePokemon);

        StringAssert.Contains("Pokémon no encontrado.", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba el uso del ítem Revivir en un Pokémon apto para la batalla.
    ///
    /// Verifica que no se pueda usar el ítem <c>Revivir</c> en un Pokémon que ya está vivo.
    [Test]
    public void UsarItemRevivirPokemonAptoParaBatalla()
    {
        string opcion = "2";
        string nombrePokemon = "Alakazam";

        string resultado = jugador1.UsarItem(opcion, nombrePokemon);

        StringAssert.Contains("está vivo, no es posible usar el ítem Revivir.", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba el uso de una opción de ítem inválida.
    ///
    /// Verifica que se muestre un mensaje de error adecuado cuando se intenta usar una opción de ítem inválida.
    [Test]
    public void UsarItemOpcionInvalida()
    {
        string opcion = "4";
        string nombrePokemon = "Alakazam";

        string resultado = jugador1.UsarItem(opcion, nombrePokemon);

        StringAssert.Contains("Opción inválida. Selecciona una opción válida", resultado, "El mensaje de error no se encontró en la salida.");
    }

    /// @brief Prueba que la lista de ítems sea devuelta correctamente.
    ///
    /// Verifica que el método <c>GetItems()</c> devuelva la lista correcta de ítems en el inventario del entrenador.
    [Test]
    public void TestGetItemsReturnsCorrectItems()
    {
        // Act
        string items = trainer.GetItems();

        // Assert
        StringAssert.Contains("1. Super Poción - Recupera 70HP.", items, "Super Poción no se encontró en la lista de ítems.");
        StringAssert.Contains("2. Revivir - Revive a un Pokémon con el 50% de vida.", items, "Revivir no se encontró en la lista de ítems.");
        StringAssert.Contains("3. Cura Total - Cura toda la salud de tu Pokémon y remueve los efectos especiales.", items, "Cura Total no se encontró en la lista de ítems.");
    }

    /// @brief Prueba que la lista de ítems esté vacía cuando no hay ítems disponibles.
    ///
    /// Verifica que el método <c>GetItems()</c> devuelva una lista vacía si no hay ítems en el inventario.
    [Test]
    public void TestGetItemsReturnsEmptyWhenNoItems()
    {
        trainer.ItemsJugador.Clear();

        string items = trainer.GetItems();

        Assert.IsEmpty(items, "La lista de ítems debería estar vacía.");
    }

    /// @brief Prueba que los ítems no se dupliquen en la lista de ítems del entrenador.
    ///
    /// Verifica que cada ítem aparezca una sola vez en la lista devuelta por <c>GetItems()</c>.
    [Test]
    public void TestGetItemsDoesNotDuplicateItems()
    {
        trainer.ItemsJugador.Add(new Superpocion());

        string items = trainer.GetItems();

        int superPocionCount = items.Split(new string[] { "Super Poción" }, StringSplitOptions.None).Length - 1;
        Assert.AreEqual(1, superPocionCount, "Super Poción aparece más de una vez en la lista de ítems.");
    }

    /// @brief Prueba que el jugador tenga los ítems correctos en su inventario.
    ///
    /// Verifica que el inventario del jugador contenga la cantidad esperada de cada tipo de ítem.
    [Test]
    public void TestGetItemsJugadorReturnsCorrectItems()
    {
        var items = trainer.ItemsJugador;

        Assert.IsNotNull(items, "ItemsJugador should not be null.");
        Assert.IsNotEmpty(items, "ItemsJugador should not be empty.");
        Assert.That(items, Has.Exactly(4).InstanceOf<Superpocion>(), "ItemsJugador should contain 4 Superpocion items.");
        Assert.That(items, Has.Exactly(1).InstanceOf<Revivir>(), "ItemsJugador should contain 1 Revivir item.");
        Assert.That(items, Has.Exactly(2).InstanceOf<CuraTotal>(), "ItemsJugador should contain 2 CuraTotal items.");
    }

    /// @brief Prueba que el inventario del jugador devuelva los Pokémon correctos.
    ///
    /// Verifica que el método <c>GetPokemons()</c> devuelva correctamente los Pokémon que tiene el jugador.
    [Test]
    public void TestGetPokemonsReturnsCorrectPokemons()
    {
        var alakazam = new Alakazam();
        var arbok = new Arbok();
        trainer.pokebolasInventario(alakazam);
        trainer.pokebolasInventario(arbok);

        var pokemons = trainer.Pokemons;

        Assert.IsNotNull(pokemons, "Pokemons should not be null.");
        Assert.IsNotEmpty(pokemons, "Pokemons should not be empty.");
        Assert.Contains(alakazam, pokemons, "Pokemons should contain Alakazam.");
        Assert.Contains(arbok, pokemons, "Pokemons should contain Arbok.");
    }
}