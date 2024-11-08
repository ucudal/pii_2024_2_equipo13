using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Marowak
 * @brief Representa el Pokémon Marowak, con sus atributos y ataques específicos.
 *
 * La clase Marowak hereda de la clase base Pokemon y define los valores específicos de Marowak,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Marowak : Pokemon
{
    /**
     * @brief Constructor de la clase Marowak.
     *
     * Inicializa el Pokémon Marowak con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Marowak()
    {
        this.Nombre = "Marowak";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Tierra();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Cabezazo", 70, new Normal(), 100)},
            {2, new AtaqueBasico("Punzón Dinámico", 100, new Normal(), 50)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Explosión de fuego", 120, new Fuego(), 85, new Quemar(0.10))},
            {2, new AtaqueEspecial("Golpe Trueno", 75, new Electrico(), 100, new Paralizar(0.10))}
        };
    }
}
