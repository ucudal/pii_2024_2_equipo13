using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Alakazam : Pokemon
{
    //Constructor 
    public Alakazam()
    {
        this.Nombre = "Alakazam";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Psiquico();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueBasico("Confusión", 50, new Psiquico(),90)},
            {2,new AtaqueBasico("Hipnosis", 70, new Psiquico(),95)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueEspecial("Psicorayo", 100, new Psiquico(),80,new Paralizar(0.50))},
            {2,new AtaqueEspecial("Hiperrayo", 150, new Normal(),75,new Quemar(0.3))}
        };
    }
    
}
    
