namespace Library.Items;

/**
 * @class CuraTotal
 * @brief Representa un ítem que cura completamente la salud de un Pokémon y remueve los efectos de estado.
 *
 * La clase CuraTotal implementa la interfaz IItem y proporciona un ítem que restaura toda la vida
 * de un Pokémon y elimina cualquier efecto de estado especial que tenga.
 */
public class CuraTotal : IItem
{
    /**
     * @brief Nombre del ítem.
     */
    public string Nombre { get; }

    /**
     * @brief Descripción del ítem.
     */
    
    public string Descripcion { get; }

    /**
     * @brief  Es el Constructor de la clase CuraTotal.
     *
     * Inicializa el nombre y la descripción del ítem.
     */
    public CuraTotal()
    {
        this.Nombre = "Cura Total";
        this.Descripcion = "Cura toda la salud de tu Pokémon y remueve los efectos especiales.";
    }
}