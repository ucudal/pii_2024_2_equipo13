using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Machamp : Pokemon
{
    //Constructor 
    public Machamp()
    {
        this.Nombre = "Machamp";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Lucha();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
