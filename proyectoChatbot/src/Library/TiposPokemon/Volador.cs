using Library;
using Library.TiposPokemon;

/**
 * @class Volador
 * @brief Representa el tipo de Pokémon "Volador" y define sus interacciones con otros tipos.
 *
 * La clase Volador implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Volador.
 */
public class Volador : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Volador.
     *
     * Inicializa el nombre del tipo como "Volador".
     */
    public Volador()
    {
        this.Nombre = "Volador";
    }

    /**
     * @brief Verifica si el tipo Volador es inmune a otro tipo.
     *
     * El tipo Volador es inmune a Tierra.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `true` si el tipo es Tierra, `false` de lo contrario.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Tierra;
    }

    /**
     * @brief Verifica si el tipo Volador es resistente a otro tipo.
     *
     * El tipo Volador es resistente a Planta, Normal y Bicho.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Planta, Normal o Bicho, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Normal || otroTipo is Bicho;
    }

    /**
     * @brief Verifica si el tipo Volador es débil a otro tipo.
     *
     * El tipo Volador es débil a Eléctrico y Roca.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Eléctrico o Roca, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Electrico || otroTipo is Roca;
    }
}