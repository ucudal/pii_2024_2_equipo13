using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Snorlax
 * @brief Representa el Pokémon Snorlax, con sus atributos y ataques específicos.
 *
 * La clase Snorlax hereda de la clase base Pokemon y define los valores específicos de Snorlax,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Snorlax : Pokemon
{
    /**
     * @brief Constructor de la clase Snorlax.
     *
     * Inicializa el Pokémon Snorlax con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Snorlax()
    {
        this.Nombre = "Snorlax";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Normal();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Golpe al cuerpo", 85, new Normal(), 100)},
            {2, new AtaqueBasico("Alta Potencia", 95, new Tierra(), 95)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Rayo", 90, new Electrico(), 100, new Paralizar(0.3))},
            {2, new AtaqueEspecial("Explosión de fuego", 110, new Fuego(), 85, new Quemar(0.10))}
        };
    }
}
