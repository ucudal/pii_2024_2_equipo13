using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Corte Cruzado", 100, new Normal(), 80 )},
            {2, new AtaqueBasico("Golpe Karate", 50, new Normal(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Terremoto", 100, new Tierra(), 100, new Paralizar(0.1))},
            {2, new AtaqueEspecial("Pueñetazo de fuego", 75, new Fuego(), 100, new Quemar(0.1))}
        };
    }
}
