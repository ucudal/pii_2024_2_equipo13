namespace Library.Items;

/**
 * @class Superpocion
 * @brief Representa un ítem que recupera 70 puntos de vida (HP) de un Pokémon.
 *
 * La clase Superpocion implementa la interfaz IItem y proporciona un ítem que
 * permite recuperar una cantidad fija de salud a un Pokémon durante la batalla.
 */
public class Superpocion : IItem
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
     * @brief Constructor de la clase Superpocion.
     *
     * Inicializa el nombre y la descripción del ítem.
     */
    public Superpocion()
    {
        this.Nombre = "Super Poción";
        this.Descripcion = "Recupera 70HP.";
    }
}