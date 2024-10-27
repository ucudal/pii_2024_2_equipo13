using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Arbok : Pokemon
{
    
    //Constructor 
    public Arbok()
    {
        this.Nombre = "Arbok";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Veneno();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
