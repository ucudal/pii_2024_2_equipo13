using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

/**
 * @class Arbok
 * @brief Representa el Pokémon Arbok, con sus atributos y ataques específicos.
 *
 * La clase Arbok hereda de la clase base Pokemon y define los valores específicos de Arbok,
 * como su nombre, tipo, vida máxima y una lista de ataques básicos y especiales.
 */
public class Arbok : Pokemon
{
    /**
     * @brief Constructor de la clase Arbok.
     *
     * Inicializa el Pokémon Arbok con su nombre, tipo, vida máxima y una lista de ataques
     * básicos y especiales disponibles.
     */
    public Arbok()
    {
        this.Nombre = "Arbok";
        this.VidaMax = 100;
        this.VidaActual = VidaMax;
        this.Tipo = new Veneno();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueBasico("Mordisco", 55, new Veneno(), 90)},
            {2, new AtaqueBasico("Ácido", 50, new Veneno(), 90)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1, new AtaqueEspecial("Bomba Lodo", 90, new Veneno(), 100, new Envenenar(0.3))},
            {2, new AtaqueEspecial("Onda Tóxica", 95, new Veneno(), 100, new Envenenar(0.1))}
        };
    }
}
