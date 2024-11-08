using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Blastoise
 * @brief Representa el Pokémon Blastoise, con sus atributos y ataques específicos.
 *
 * La clase Blastoise hereda de la clase base Pokemon y define los valores específicos de Blastoise,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Blastoise : Pokemon
{
    /**
     * @brief Constructor de la clase Blastoise.
     *
     * Inicializa el Pokémon Blastoise con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Blastoise()
    {
        this.Nombre = "Blastoise";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
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
