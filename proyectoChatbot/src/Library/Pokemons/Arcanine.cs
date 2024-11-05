using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Velocidad Extrema ", 80, new Normal(), 100)},
            {2, new AtaqueBasico("Rueda de llamas", 60, new Fuego(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Blitz de bengalas", 120, new Fuego(), 100, new Quemar(0.10))},
            {2, new AtaqueEspecial("Crujido", 80, new Siniestro(), 100, new Paralizar(0.20))}
        };
    }

    
}
