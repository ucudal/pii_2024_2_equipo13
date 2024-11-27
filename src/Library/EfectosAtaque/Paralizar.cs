namespace Library.EfectosAtaque;

/**
 * @class Paralizar
 * @brief Clase que representa el efecto de estado "Parálisis" en un Pokémon.
 *
 * La clase Paralizar implementa la interfaz IEfectoAtaque y aplica el efecto de
 * parálisis a un Pokémon, impidiéndole atacar en ciertos turnos.
 */
public class Paralizar : IEfectoAtaque
{
    /**
     * @brief Indica si el efecto de parálisis está activo.
     */
    public bool EstaParalizado { get; set; }

    /**
     * @brief Probabilidad de que el efecto de parálisis se active.
     */
    public double ProbabilidadEfecto { get; }

    /**
     * @brief Constructor de la clase Paralizar.
     *
     * Inicializa el efecto de parálisis con una probabilidad de activación especificada.
     *
     * @param probabilidad La probabilidad de que el efecto de parálisis se active.
     */
    public Paralizar(double probabilidad)
    {
        this.EstaParalizado = false;
        this.ProbabilidadEfecto = probabilidad;
    }

    /**
     * @brief Aplica el efecto de parálisis al Pokémon objetivo.
     *
     * Pone al Pokémon en estado de parálisis, afectando su capacidad de atacar.
     *
     * @param objetivo El Pokémon que recibirá el efecto de parálisis.
     */
    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaParalizado = true;
        Console.WriteLine($"{objetivo.PokemonName} está paralizado.");
    }

    /**
     * @brief Elimina el efecto de parálisis del Pokémon.
     *
     * Permite que el Pokémon ataque nuevamente sin la restricción de la parálisis.
     *
     * @param objetivo El Pokémon al que se le removerá el efecto de parálisis.
     */
    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaParalizado = false;
        Console.WriteLine($"{objetivo.PokemonName} ya no tiene parálisis.");
    }

    /**
     * @brief Verifica si el efecto de parálisis sigue activo en el Pokémon.
     *
     * @param objetivo El Pokémon que se verificará.
     * @return `true` si el efecto de parálisis está activo, `false` de lo contrario.
     */
    public bool EstaActivo(Pokemon objetivo)
    {
        return objetivo.EstaParalizado;
    }
}
