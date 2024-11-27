using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Scyther
 * @brief Representa el Pokémon Scyther, con sus atributos y ataques específicos.
 *
 * La clase Scyther hereda de la clase base Pokemon y define los valores específicos de Scyther,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Scyther : Pokemon
{
    /**
     * @brief Constructor de la clase Scyther.
     *
     * Inicializa el Pokémon Scyther con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Scyther()
    {
        this.PokemonName = "Scyther";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Bicho();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Onda de vacío", 40, new Lucha(), 100)},
            {2, new AtaqueBasico("Ataque rápido", 40, new Normal(), 100)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Corte aéreo", 75, new Volador(), 95, new Paralizar(0.30))},
            {2, new AtaqueEspecial("Tijeras X", 80, new Bicho(), 100, new Dormir(0))}
        };
    }
}
