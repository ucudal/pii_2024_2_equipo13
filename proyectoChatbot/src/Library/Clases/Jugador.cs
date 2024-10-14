namespace Library;

public class Jugador
{
    private List<IPokemon> pokemons; //lista de Pokemons, del jugador

    public List<IPokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    } //getter de la lista de pokemons del jugador

    private IPokemon pokemonActivo; //Es el Pokemon que esta activo en batalla, y que tambien al inicio de la batalla, se defince como el inicial
    public string Nombre { get; } //Getter que devuelve el nombre del jugador, se usa pra mostrar el nombre de jugador por pantalla
    public IPokemon PokemonActivo { get;set; } //Este Getter, devuelve cual es el Pokemon activo en batalla  del jugador
    private List<IPokemon> PokemonsDisponibles; //Esta lista, contiene los pokemons dispoinbles del juego
    //constructor
    public Jugador(string nombre)
    {
        this.Nombre = nombre;
        this.pokemons = new List<IPokemon>();
        this.pokemonActivo = null;
        /*Constructor del objeto jugador, que establece el nombre del jugador, y incializa una lista vacia.
         que contendra los pokemons del jugador*/
    }
}