namespace Library;

/**
 * @interface Itipo
 * @brief Interfaz que define las propiedades y métodos relacionados con el tipo de un Pokémon.
 *
 * La interfaz Itipo se implementa para representar el tipo de un Pokémon y verificar sus interacciones de efectividad con otros tipos.
 */
public interface Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     * @return El nombre del tipo de Pokémon, por ejemplo, "Fuego".
     */
    string Nombre { get; }

    /**
     * @brief Verifica si el tipo es inmune contra otro tipo.
     *
     * Este método comprueba si el tipo del Pokémon es inmune al tipo especificado,
     * lo que significa que el daño recibido sería nulo.
     *
     * @param otroTipo El otro tipo contra el que se verificará la inmunidad.
     * @return `true` si es inmune al otro tipo, `false` de lo contrario.
     */
    bool InmuneContra(Itipo otroTipo)
    {
        return true;
    }

    /**
     * @brief Verifica si el tipo es resistente contra otro tipo.
     *
     * Este método comprueba si el tipo del Pokémon es resistente al tipo especificado,
     * lo que significa que el daño recibido se reduciría a la mitad (0.5x).
     *
     * @param otroTipo El otro tipo contra el que se verificará la resistencia.
     * @return `true` si es resistente al otro tipo, `false` de lo contrario.
     */
    bool ResistenteContra(Itipo otroTipo)
    {
        return true;
    }

    /**
     * @brief Verifica si el tipo es débil contra otro tipo.
     *
     * Este método comprueba si el tipo del Pokémon es débil al tipo especificado,
     * lo que significa que el daño recibido se duplicaría (2x).
     *
     * @param otroTipo El otro tipo contra el que se verificará la debilidad.
     * @return `true` si es débil al otro tipo, `false` de lo contrario.
     */
    bool DebilContra(Itipo otroTipo)
    {
        return true;
    }
}