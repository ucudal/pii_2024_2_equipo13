using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Scyther : Pokemon
{
    //Constructor 
    public Scyther()
    {
        this.Nombre = "Scyther";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Bicho();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
