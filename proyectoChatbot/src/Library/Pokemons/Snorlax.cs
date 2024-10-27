using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Snorlax : Pokemon
{
    //Constructor 
    public Snorlax()
    {
        this.Nombre = "Snorlax";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Normal();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
