using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Pikachu
 * @brief Representa el Pokémon Pikachu, con sus atributos y ataques específicos.
 *
 * La clase Pikachu hereda de la clase base Pokemon y define los valores específicos de Pikachu,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Pikachu : Pokemon
{
    /**
     * @brief Constructor de la clase Pikachu.
     *
     * Inicializa el Pokémon Pikachu con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Pikachu()
    {
        this.Nombre = "Pikachu";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Electrico();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Chispa", 65, new Electrico(), 100)},
            {2, new AtaqueBasico("Carga Salvaje", 90, new Electrico(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Rayo", 90, new Electrico(), 70, new Paralizar(0.3))},
            {2, new AtaqueEspecial("Interruptor de voltios", 70, new Electrico(), 100, new Paralizar(0.0))}
        };
    }
}
