using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Sandslash : Pokemon
{
    //Constructor 
    public Sandslash()
    {
        this.Nombre = "Sandslash";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Tierra();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Barra oblicua", 70, new Normal(), 100)},
            {2, new AtaqueBasico("Garra de metal", 50, new Tierra(), 95)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Picadura de veneno", 15, new Veneno(), 100, new Envenenar(0.30))},
            {2, new AtaqueEspecial("Cortador de furia", 40, new Bicho(), 95, new Paralizar(0.0))}
        };
    }
}
