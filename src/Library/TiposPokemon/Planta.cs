using Library;
using Library.TiposPokemon;

/**
 * @class Planta
 * @brief Representa el tipo de Pokémon "Planta" y define sus interacciones con otros tipos.
 *
 * La clase Planta implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Planta.
 */
public class Planta : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Planta.
     *
     * Inicializa el nombre del tipo como "Planta".
     */
    public Planta()
    {
        this.Nombre = "Planta";
    }

    /**
     * @brief Verifica si el tipo Planta es inmune a otro tipo.
     *
     * El tipo Planta no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Planta no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Planta es resistente a otro tipo.
     *
     * El tipo Planta es resistente a Agua, Eléctrico, Tierra y Planta.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Agua, Eléctrico, Tierra o Planta, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Electrico || otroTipo is Tierra || otroTipo is Planta;
    }

    /**
     * @brief Verifica si el tipo Planta es débil a otro tipo.
     *
     * El tipo Planta es débil a Fuego, Bicho, Veneno y Volador.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Fuego, Bicho, Veneno o Volador, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Bicho || otroTipo is Veneno || otroTipo is Volador;
    }
}
