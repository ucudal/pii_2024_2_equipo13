using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
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
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Pistola de Agua", 40, new Agua(), 100)},
            {2, new AtaqueBasico("Morder", 60, new Siniestro(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Bofetada", 50, new Roca(), 100, new Paralizar(1.0))},
            {2, new AtaqueEspecial("Pulso oscuro", 80, new Siniestro(), 100, new Paralizar(0.2))}
        };
    }
}
