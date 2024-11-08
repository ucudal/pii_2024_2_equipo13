using Library;
using Library.TiposPokemon;

/**
 * @class Fuego
 * @brief Representa el tipo de Pokémon "Fuego" y define sus interacciones con otros tipos.
 *
 * La clase Fuego implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Fuego.
 */
public class Fuego : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Fuego.
     *
     * Inicializa el nombre del tipo como "Fuego".
     */
    public Fuego()
    {
        this.Nombre = "Fuego";
    }

    /**
     * @brief Verifica si el tipo Fuego es inmune a otro tipo.
     *
     * El tipo Fuego no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Fuego no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Fuego es resistente a otro tipo.
     *
     * El tipo Fuego es resistente a Planta, Bicho y Fuego.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Planta, Bicho o Fuego, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Bicho || otroTipo is Fuego;
    }

    /**
     * @brief Verifica si el tipo Fuego es débil a otro tipo.
     *
     * El tipo Fuego es débil a Agua, Tierra y Roca.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Agua, Tierra o Roca, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Tierra || otroTipo is Roca;
    }
}
