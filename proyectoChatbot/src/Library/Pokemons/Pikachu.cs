using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Chispa", 65, new Electrico(), 100)},
            {2, new AtaqueBasico("Carga Salvaje", 90, new Electrico(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Rayo", 90, new Electrico(), 70, new Paralizar(0.3))},
            {2, new AtaqueEspecial("Interruptor de voltios", 70, new Electrico(), 100, new Paralizar(0.0))}
        };
    }
}
