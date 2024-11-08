namespace Library;

/**
 * @interface IEfectoAtaque
 * @brief Interfaz que define los métodos y propiedades de un efecto de ataque especial.
 *
 * La interfaz IEfectoAtaque se implementa para aplicar efectos de estado en los Pokémon durante la batalla.
 */
public interface IEfectoAtaque
{
    /**
     * @brief Probabilidad de que el efecto se active.
     * @return La probabilidad de activación del efecto.
     */
    double ProbabilidadEfecto { get; }

    /**
     * @brief Verifica si el efecto está activo en el Pokémon objetivo.
     *
     * @param objetivo El Pokémon que se verificará.
     * @return `true` si el efecto está activo, `false` de lo contrario.
     */
    bool EstaActivo(Pokemon objetivo);

    /**
     * @brief Aplica el efecto al Pokémon objetivo.
     *
     * @param objetivo El Pokémon al que se le aplicará el efecto.
     */
    void AplicarEfecto(Pokemon objetivo);

    /**
     * @brief Remueve el efecto del Pokémon objetivo.
     *
     * @param objetivo El Pokémon al que se le removerá el efecto.
     */
    void RemoverEfecto(Pokemon objetivo);
}