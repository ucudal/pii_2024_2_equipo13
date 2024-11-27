using Library;
using Library.TiposPokemon;

/**
 * @class Tierra
 * @brief Representa el tipo de Pokémon "Tierra" y define sus interacciones con otros tipos.
 *
 * La clase Tierra implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Tierra.
 */
public class Tierra : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Tierra.
     *
     * Inicializa el nombre del tipo como "Tierra".
     */
    public Tierra()
    {
        this.Nombre = "Tierra";
    }

    /**
     * @brief Verifica si el tipo Tierra es inmune a otro tipo.
     *
     * El tipo Tierra es inmune a Eléctrico.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `true` si el tipo es Eléctrico, `false` de lo contrario.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Electrico;
    }

    /**
     * @brief Verifica si el tipo Tierra es resistente a otro tipo.
     *
     * El tipo Tierra es resistente a Roca y Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Roca o Veneno, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Roca || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Tierra es débil a otro tipo.
     *
     * El tipo Tierra es débil a Agua y Planta.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Agua o Planta, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Planta;
    }
}