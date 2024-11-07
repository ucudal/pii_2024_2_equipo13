using Library.Items;

namespace Library.Clases;
/// <summary>
/// Representa un jugador en el juego de Pokemón
/// </summary>
public class Jugador
{
    // Lista de Pokemón del jugador
    private List<Pokemon> pokemons;
    // Lista de items del jugador
    private List<IItem> itemsJugador;
    // Getter y settes para la lista de items del jugador
    public List<IItem> ItemsJugador
    {
        get { return itemsJugador; }
        set { itemsJugador = value; }
    }
    // Getter y setter para la lista de Pokemón del jugador
    public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } } 
    // Pokemón activo del jugador
    private Pokemon pokemonActivo;
    // Nombre del jugador
    public string Nombre { get; } 
    // Getter y setter para el Pokemón activo del jugador
    public Pokemon PokemonActivo
    {
        get
        {
            // Asegurarse de que haya un PokemonActivo asignado
            if (pokemonActivo == null && pokemons.Any())
            {
                pokemonActivo = pokemons.First();
            }
            return pokemonActivo;
        }
        set { pokemonActivo = value; }
    }

    //constructor del jugador
    public Jugador(string nombre)
    {
        this.Nombre = nombre;
        this.pokemons = new List<Pokemon>();
        this.PokemonActivo = this.pokemons.FirstOrDefault();
        this.itemsJugador = new List<IItem>(); 
        this.itemsJugador.Add(new Revivir());
        this.itemsJugador.Add(new CuraTotal());
        this.itemsJugador.Add(new CuraTotal());
        for (int i = 0; i < 4; i++)
        {
            this.itemsJugador.Add(new Superpocion());
        }
        /*Constructor del objeto jugador, que establece el nombre del jugador, y incializa una lista vacia.
         que contendra los pokemons del jugador*/
    }
    public void Atacar(Jugador oponente)
    {
        if (!PokemonActivo.AptoParaBatalla)
        {
            Console.WriteLine($"{Nombre} no tiene un Pokémon apto para atacar.");
            return;
        }
        
        Console.WriteLine($"¿Qué ataque deseas realizar {Nombre}?\n1- Ataque Básico\n2- Ataque Especial");
        string opcion = Console.ReadLine();
        while (opcion != "1" && opcion != "2")
        {
            Console.WriteLine($"¿Qué ataque deseas realizar {Nombre}?\n1- Ataque Básico\n2- Ataque Especial");
            string lectura = Console.ReadLine();
            opcion = (lectura == "1" || lectura == "2") ? lectura : opcion;

        }
        Pokemon objetivo = oponente.PokemonActivo;

        if (opcion == "1")
        {
            Console.WriteLine("Ataques Básicos Disponibles:");
            PokemonActivo.GetAtaquesBasicos();
            Console.WriteLine("Ingresa el número del ataque que deseas realizar:");
            try
            {
                int ataqueSeleccionado = int.Parse(Console.ReadLine());
                double daño = PokemonActivo.AtaqueBasico(objetivo, ataqueSeleccionado);
                Console.WriteLine(
                    $"{Nombre} ataca a {oponente.Nombre} con un ataque básico y le inflige {daño} de daño.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. No se ingresó un número válido. Turno perdido.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Se selecciono, un ataque no existente.Turno perdido");
            }
        }
        else if (opcion == "2")
        {
            Console.WriteLine("Ataques Especiales Disponibles:");
            PokemonActivo.GetAtaqueEspecial();
            Console.WriteLine("Ingresa el número del ataque especial que deseas realizar:");
            try
            {
                int ataqueSeleccionado = int.Parse(Console.ReadLine());
                double daño = PokemonActivo.AtaqueEspecial(objetivo, ataqueSeleccionado);
                Console.WriteLine($"{Nombre} ataca a {oponente.Nombre} con un ataque especial y le inflige {daño} de daño.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. No se ingresó un número válido. Turno perdido.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Se selecciono, un ataque no existente.Turno perdido");
            }
        }
    }
    
    public void UsarItem()
        {
            Console.WriteLine("¿Que item desea usar para curar a su pokemon?\n 1-Superpocion.\n 2-Revivir.\n 3-Cura Total");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                    Console.WriteLine("¿A que pokemon desea darle la superpocion?");
                    string nombrePokemon = Console.ReadLine();
                    Pokemon pokemonSeleccionado = this.Pokemons.FirstOrDefault(p => p.Nombre.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));
                    IItem superPocion = this.ItemsJugador.FirstOrDefault(item => item is Superpocion);

                if (superPocion == null)
                {
                    Console.WriteLine("No quedan Super Pociones en la lista de items.");
                }
                
                else if (pokemonSeleccionado != null)
                {
                    pokemonSeleccionado.VidaActual += 70;
                    this.ItemsJugador.Remove(superPocion);
                    Console.WriteLine($"La superpoción fue usada en {pokemonSeleccionado.Nombre}.");
                }
                else
                {
                    Console.WriteLine("Pokémon no encontrado.");
                }
            }
            else if (opcion == "2")
            {
                Console.WriteLine("¿A que pokemon desea darle el Revivir?");
                string nombrePokemon = Console.ReadLine();
                IItem revivir = this.ItemsJugador.FirstOrDefault(item => item is Revivir);
                if (revivir == null)
                {
                    Console.WriteLine("No quedan items Revivir en la lista.");
                }
                else
                {
                    Pokemon pokemonSeleccionado = this.Pokemons.FirstOrDefault(p => p.Nombre.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));
                    if (this.Pokemons.Contains(pokemonSeleccionado))
                    {
                        if (pokemonSeleccionado.AptoParaBatalla == false)
                        {
                            pokemonSeleccionado.AptoParaBatalla = true;
                            pokemonSeleccionado.VidaActual = pokemonSeleccionado.VidaMax * 0.5;
                            this.ItemsJugador.Remove(revivir);
                            Console.WriteLine($"El item Revivir ha sido usado para {pokemonSeleccionado}.");

                        }
                        else
                        {
                            Console.WriteLine($"{pokemonSeleccionado} esta vivo, no es posible usar el item Revivir");
                        }
                    }
                }
                
            }
            else if (opcion=="3")
            {
                Console.WriteLine("¿A que pokemon desea darle la Cura Total?");
                string nombrePokemon = Console.ReadLine();
                Pokemon pokemonSeleccionado = this.Pokemons.FirstOrDefault(p => p.Nombre.Equals(nombrePokemon, StringComparison.OrdinalIgnoreCase));
                IItem curaTotal = this.ItemsJugador.FirstOrDefault(item => item is CuraTotal);
                if (curaTotal == null)
                {
                    Console.WriteLine("No quedan items Cura Total en la lista.");
                }
                else
                {
                    pokemonSeleccionado.VidaActual = pokemonSeleccionado.VidaMax;
                    pokemonSeleccionado.RemoverEfectos();
                    this.ItemsJugador.Remove(curaTotal);
                    Console.WriteLine($"El item Cura Total ha sido usado en {pokemonSeleccionado}");
                }
            }
        }
    public void CambiarPokemonActivo(string nombreNuevoPokemon)
    {
        // Buscar el nuevo Pokémon en la lista de Pokémon del jugador
        Pokemon nuevoPokemon = this.Pokemons.FirstOrDefault(p => p != null && p.Nombre != null && p.Nombre.Equals(nombreNuevoPokemon, StringComparison.OrdinalIgnoreCase));

        // Verificar si el Pokémon fue encontrado y está apto para la batalla
        if (nuevoPokemon != null && nuevoPokemon.AptoParaBatalla)
        {
            // Cambiar el Pokémon activo del jugador
            this.PokemonActivo = nuevoPokemon;
            Console.WriteLine($"{this.Nombre} ha cambiado a {nuevoPokemon.Nombre} como su Pokémon activo.");
        }
        else
        {
            // Si el Pokémon no fue encontrado o no está apto para la batalla
            Console.WriteLine($"{nombreNuevoPokemon} no está disponible o no es apto para la batalla.");
        }
    }

}