using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Marowak : Pokemon
{
    public Marowak()
    {
        this.Nombre = "Marowak";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Tierra();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueBasico("Cabezazo",70,new Normal(), 100)},
            {2, new AtaqueBasico("Punzón Dinámico", 100,new Normal(), 50)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Explosión de fuego", 120, new Fuego(), 85, new Quemar(0.10) )},
            {2, new AtaqueEspecial("Golpe Trueno", 75, new Electrico(), 100, new Paralizar(0.10))}
        };
    }
}