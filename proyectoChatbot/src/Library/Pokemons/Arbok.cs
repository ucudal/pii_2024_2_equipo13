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
            {1,new AtaqueBasico("Mordisco", 55, new Veneno(),90)},
            {2,new AtaqueBasico("Ácido", 50, new Veneno(),90)}
            
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueEspecial("Bomba Lodo", 90, new Veneno(),100,new Envenenar(0.3))},
            {2,new AtaqueEspecial("Onda Tóxica", 95, new Veneno(),100,new Envenenar(0.1))}
        };
    }
}
