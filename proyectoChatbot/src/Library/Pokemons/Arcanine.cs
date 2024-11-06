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
            { 1, new AtaqueBasico("Golpe Roca", 50, new Lucha(), 90) },
            { 2, new AtaqueBasico("Derribo",70, new Normal(), 90) }
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            
            {1,new AtaqueEspecial("Rueda Fuego", 80, new Veneno(),100,new Quemar(0.1))},
            {2,new AtaqueEspecial("Colmillo Igneo", 85, new Veneno(),100,new Quemar(0.1))}
        };
    }

    
}
