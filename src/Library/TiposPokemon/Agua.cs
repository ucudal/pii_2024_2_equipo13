namespace Library.TiposPokemon;

/**
 * @class Agua
 * @brief Representa el tipo de Pokémon "Agua" y define sus interacciones con otros tipos.
 *
 * La clase Agua implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Agua.
 */
public class Agua : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Agua.
     *
     * Inicializa el nombre del tipo como "Agua".
     */
    public Agua()
    {
        this.Nombre = "Agua";
    }

    /**
     * @brief Verifica si el tipo Agua es inmune a otro tipo.
     *
     * @param otroTipo El otro tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Agua no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Agua es resistente a otro tipo.
     *
     * El tipo Agua es resistente a Fuego y Tierra.
     *
     * @param otroTipo El otro tipo contra el que se verificará la resistencia.
     * @return `true` si el otro tipo es Fuego o Tierra, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Tierra;
    }

    /**
     * @brief Verifica si el tipo Agua es débil a otro tipo.
     *
     * El tipo Agua es débil a Planta y Eléctrico.
     *
     * @param otroTipo El otro tipo contra el que se verificará la debilidad.
     * @return `true` si el otro tipo es Planta o Eléctrico, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Electrico;
    }
}