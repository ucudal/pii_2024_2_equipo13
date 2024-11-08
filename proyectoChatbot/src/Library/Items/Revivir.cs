using System.ComponentModel.Design;

namespace Library.Items;

/**
 * @class Revivir
 * @brief Representa un ítem que revive a un Pokémon con el 50% de su vida máxima.
 *
 * La clase Revivir implementa la interfaz IItem y proporciona un ítem que revive
 * a un Pokémon desmayado con la mitad de su salud máxima.
 */
public class Revivir : IItem
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
     * @brief Constructor de la clase Revivir.
     *
     * Inicializa el nombre y la descripción del ítem.
     */
    public Revivir()
    {
        this.Nombre = "Revivir";
        this.Descripcion = "Revive a un Pokémon con el 50% de vida.";
    }
}
