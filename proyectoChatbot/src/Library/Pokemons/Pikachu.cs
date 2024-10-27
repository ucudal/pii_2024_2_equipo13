using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Pikachu : Pokemon
{
    //Constructor 
    public Pikachu()
    {
        this.Nombre = "Pikachu";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Electrico();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
