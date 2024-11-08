using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Machamp
 * @brief Representa el Pokémon Machamp, con sus atributos y ataques específicos.
 *
 * La clase Machamp hereda de la clase base Pokemon y define los valores específicos de Machamp,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Machamp : Pokemon
{
    /**
     * @brief Constructor de la clase Machamp.
     *
     * Inicializa el Pokémon Machamp con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Machamp()
    {
        this.Nombre = "Machamp";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Lucha();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Corte Cruzado", 100, new Normal(), 80)},
            {2, new AtaqueBasico("Golpe Karate", 50, new Normal(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Terremoto", 100, new Tierra(), 100, new Paralizar(0.1))},
            {2, new AtaqueEspecial("Puñetazo de fuego", 75, new Fuego(), 100, new Quemar(0.1))}
        };
    }
}
