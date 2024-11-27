using Library;
using Library.TiposPokemon;

/**
 * @class Electrico
 * @brief Representa el tipo de Pokémon "Eléctrico" y define sus interacciones con otros tipos.
 *
 * La clase Electrico implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Eléctrico.
 */
public class Electrico : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Electrico.
     *
     * Inicializa el nombre del tipo como "Electrico".
     */
    public Electrico()
    {
        this.Nombre = "Electrico";
    }

    /**
     * @brief Verifica si el tipo Eléctrico es inmune a otro tipo.
     *
     * El tipo Eléctrico es inmune a otros ataques del tipo Eléctrico.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `true` si el tipo es Eléctrico, `false` de lo contrario.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Electrico;
    }

    /**
     * @brief Verifica si el tipo Eléctrico es resistente a otro tipo.
     *
     * El tipo Eléctrico es resistente a Volador.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Volador, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Volador;
    }

    /**
     * @brief Verifica si el tipo Eléctrico es débil a otro tipo.
     *
     * El tipo Eléctrico es débil a Tierra.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Tierra, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra;
    }
}