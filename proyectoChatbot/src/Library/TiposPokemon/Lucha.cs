using Library;
using Library.TiposPokemon;

/**
 * @class Lucha
 * @brief Representa el tipo de Pokémon "Lucha" y define sus interacciones con otros tipos.
 *
 * La clase Lucha implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Lucha.
 */
public class Lucha : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Lucha.
     *
     * Inicializa el nombre del tipo como "Lucha".
     */
    public Lucha()
    {
        this.Nombre = "Lucha";
    }

    /**
     * @brief Verifica si el tipo Lucha es inmune a otro tipo.
     *
     * El tipo Lucha no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Lucha no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Lucha es resistente a otro tipo.
     *
     * El tipo Lucha es resistente a Bicho y Roca.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Bicho o Roca, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Roca;
    }

    /**
     * @brief Verifica si el tipo Lucha es débil a otro tipo.
     *
     * El tipo Lucha es débil a Volador, Psíquico y Hada.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Volador, Psíquico o Hada, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Volador || otroTipo is Psiquico || otroTipo is Hada;
    }
}