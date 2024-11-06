using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Golpe al cuerpo", 85, new Normal(), 100)},
            {2, new AtaqueBasico("Alta Potencia", 95, new Tierra(), 95)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Rayo", 90, new Electrico(), 100, new Paralizar(0.3) )},
            {2, new AtaqueEspecial("Explosión de fuego", 110, new Fuego(), 85, new Quemar(0.10))}
        };
    }
}
