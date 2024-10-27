using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Arcanine : Pokemon
{
    

    //Constructor 
    public Arcanine()
    {
        this.Nombre = "Arcanine";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo = new Fuego();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>();
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>();
    }

    
}
