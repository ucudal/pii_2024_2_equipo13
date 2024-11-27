using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Arcanine
 * @brief Representa el Pokémon Arcanine, con sus atributos y ataques específicos.
 *
 * La clase Arcanine hereda de la clase base Pokemon y define los valores específicos de Arcanine,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Arcanine : Pokemon
{
    /**
     * @brief Constructor de la clase Arcanine.
     *
     * Inicializa el Pokémon Arcanine con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Arcanine()
    {
        this.PokemonName = "Arcanine";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Fuego();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Golpe Roca", 50, new Lucha(), 90)},
            {2, new AtaqueBasico("Derribo", 70, new Normal(), 90)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Rueda Fuego", 80, new Veneno(), 100, new Quemar(0.1))},
            {2, new AtaqueEspecial("Colmillo Ígneo", 85, new Veneno(), 100, new Quemar(0.1))}
        };
    }
}
