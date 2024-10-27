using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Blastoise : Pokemon
{
    
    //Constructor 
    public Blastoise()
    {
        this.Nombre = "Blastoise";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo = new Agua();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }
}
