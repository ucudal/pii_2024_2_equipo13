using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Onda de vacío", 40, new Lucha(), 100)},
            {2, new AtaqueBasico("Ataque rápido", 40, new Normal(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Corte aéreo", 75, new Volador(), 95, new Paralizar(0.30))},
            {2, new AtaqueEspecial("Tijeras X", 80, new Bicho(), 100, new Dormir(0))}
        };
    }
}
