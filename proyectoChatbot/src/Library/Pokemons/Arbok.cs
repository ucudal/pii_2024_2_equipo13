using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Arbok : Pokemon
{
    
    //Constructor 
    public Arbok()
    {
        this.Nombre = "Arbok";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo =  new Veneno();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Envoltura", 15 ,new Normal(), 90)},
            {2, new AtaqueBasico("Morder", 60, new Normal(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Bomba de lodo", 65, new Tierra(), 85, new Paralizar(0.30))},
            {2, new AtaqueEspecial("Disparo de porquería", 120, new Veneno(), 80, new Envenenar(0.30))}
        };
    }
}
