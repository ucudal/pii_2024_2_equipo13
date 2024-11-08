using Library;
using Library.TiposPokemon;

/**
 * @class Hada
 * @brief Representa el tipo de Pokémon "Hada" y define sus interacciones con otros tipos.
 *
 * La clase Hada implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Hada.
 */
public class Hada : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Hada.
     *
     * Inicializa el nombre del tipo como "Hada".
     */
    public Hada()
    {
        this.Nombre = "Hada";
    }

    /**
     * @brief Verifica si el tipo Hada es inmune a otro tipo.
     *
     * El tipo Hada no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Hada no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Hada es resistente a otro tipo.
     *
     * El tipo Hada es resistente a Lucha y Bicho.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Lucha o Bicho, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Bicho;
    }

    /**
     * @brief Verifica si el tipo Hada es débil a otro tipo.
     *
     * El tipo Hada es débil a Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Veneno, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Veneno;
    }
}