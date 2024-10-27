using Library.Items;

namespace Library;

public class Jugador
{
    private List<Pokemon> pokemons; //lista de Pokemons, del jugador
    private List<IItem> itemsJugador; //lista de items del jugador
    public List<IItem> ItemsJugador
    {
        get { return itemsJugador; }
        set { itemsJugador = value; }
    } // getter y setter de la lista de items del jugador


    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    } //getter de la lista de pokemons del jugador

    private Pokemon pokemonActivo; //Es el Pokemon que esta activo en batalla, y que tambien al inicio de la batalla, se defince como el inicial
    public string Nombre { get; } //Getter que devuelve el nombre del jugador, se usa pra mostrar el nombre de jugador por pantalla
    public Pokemon PokemonActivo { get;set; } //Este Getter, devuelve cual es el Pokemon activo en batalla  del jugador
    private List<Pokemon> PokemonsDisponibles; //Esta lista, contiene los pokemons dispoinbles del juego
    //constructor
    public Jugador(string nombre)
    {
        this.Nombre = nombre;
        this.pokemons = new List<Pokemon>();
        this.pokemonActivo = null;
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
}