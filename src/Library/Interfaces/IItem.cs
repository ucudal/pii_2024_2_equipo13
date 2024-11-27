namespace Library;

/**
 * @interface IItem
 * @brief Interfaz que define las propiedades básicas de un ítem.
 *
 * La interfaz IItem se implementa para representar ítems que pueden ser utilizados en la batalla.
 */
public interface IItem
{
    /**
     * @brief Nombre del ítem.
     * @return El nombre del ítem.
     */
    string Nombre { get; }

    /**
     * @brief Descripción del ítem.
     * @return Una breve descripción del ítem.
     */
    string Descripcion { get; }
}