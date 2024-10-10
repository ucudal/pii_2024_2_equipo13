using Library.TiposPokemon;

namespace Library.Pokemons;

public class Pidgeot:IPokemon
{
    public string Nombre { get; } //Getter del nombre del Pokemon
    public double VidaActual { get; } //Getter VidaActual del Pokemon
    public double VidaMax { get;} //Getter VidaMaxima del Pokemon
    
    public bool AptoParaBatalla { get; set;} //Getter, que va a indicar si el Pokemon esta apato para batalla o no
    public List<Itipo> Tipos { get; } //Getter del Tipo del Pokemon
    private List<IAtaque> AtaquesBasicos; //Lista, que contiene los ataquesBasicos
    private List<IAtaque> AtaqueEspecial; //Lista que contiene los Ataques Especiales

    //Constructor 
    public Pidgeot()
    {
        this.Nombre = "Pidgeot";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipos = new List<Itipo> { new Normal(),new Volador()};
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new List<IAtaque>();
        this.AtaqueEspecial = new List<IAtaque>();
    }
    public List<IAtaque> GetAtaquesBasicos()
    {
        //Este metodo devuelve la lista de ataques basicos del Pokemon
        return null;
    }

    public List<IAtaque> GetAtaqueEspecial()
    {
        //Devuelve una lista con el ataque especial
        return null;
    }
    
    void DañoRecibido(double daño)  
    {
        /*Este método, lo que hace es modificar la vida del pokemon, gestionando segun el ataque
         y la efectividad de los tipos, que efecto tiene en la salud del pokemon*/
    }

    void Curar() // Una función que permite curar la salud del pokemon - VidaActual
    {
        //Este método, lo que hace es curar al Pokemón,una cantidad establecida de salud.
    }

    public bool PokemonEnCombate()
    {
        //Este metodo, determina si el pokemon esta apto para  continuar en batalla, o ser elegido para esta
        return true;
    }
}