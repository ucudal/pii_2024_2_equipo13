namespace Library;

public class Jugador
{
    private List<IPokemon> Pokemons; //lista de Pokemons, del jugador
    private IPokemon pokemonActivo; //Es el Pokemon que esta activo en batalla, y que tambien al inicio de la batalla, se defince como el inicial
    public string Nombre { get; } //Getter que devuelve el nombre del jugador, se usa pra mostrar el nombre de jugador por pantalla
    public IPokemon PokemonActivo { get; } //Este Getter, devuelve cual es el Pokemon activo en batalla  del jugador
    private List<IPokemon> PokemonsDisponibles; //Esta lista, contiene los pokemons dispoinbles del juego
    public Jugador(string nombre)
    {
        this.Nombre = nombre;
        this.Pokemons = new List<IPokemon>();
        this.pokemonActivo = null;
        /*Constructor del objeto jugador, que establece el nombre del jugador, y incializa una lista vacia.
         que contendra los pokemons del jugador*/
    }
    
    public void SeleccionarPokemonInicial()
    { 
        Console.WriteLine("Elige a tu pokemon Inicial");
        string pokemonInicial=Console.ReadLine();
        foreach (IPokemon pokemon in Pokemons)
        {
            if (pokemon.Nombre.Equals(pokemonInicial,StringComparison.OrdinalIgnoreCase))
            {
                pokemonActivo=pokemon;
            }
            else
            {
                Console.WriteLine("El pokemon ingresado, no se encuntra dentro de tus Pokemon");
            }
        }
        
        //Este metodo, lo que hace es definir, con que Pokemon inicia la batalla el jugador y lo asigna al pokemonActivo.
    }
    public void ElegirPokemons()
    {
        //Este metodo, elige los pokemons del usuario, de los pokemons disponibles y los asigna a la lista Pokemons
    }
    
}