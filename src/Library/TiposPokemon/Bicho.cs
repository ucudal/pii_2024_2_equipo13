using Library;
using Library.TiposPokemon;

/**
 * @class Bicho
 * @brief Representa el tipo de Pokémon "Bicho" y define sus interacciones con otros tipos.
 *
 * La clase Bicho implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Bicho.
 */
public class Bicho : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Bicho.
     *
     * Inicializa el nombre del tipo como "Bicho".
     */
    public Bicho()
    {
        this.Nombre = "Bicho";
    }

    /**
     * @brief Verifica si el tipo Bicho es inmune a otro tipo.
     *
     * El tipo Bicho no es inmune a ningún tipo.
     *
     * @param otroTipo Lista de tipos contra los que se verificará la inmunidad (actualmente no se usa).
     * @return `false` siempre, ya que el tipo Bicho no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Bicho es débil a otro tipo.
     *
     * El tipo Bicho es débil a Fuego, Volador y Veneno.
     *
     * @param otroTipo El otro tipo contra el que se verificará la debilidad.
     * @return `true` si el otro tipo es Fuego, Volador o Veneno, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Volador || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Bicho es resistente a otro tipo.
     *
     * El tipo Bicho es resistente a Lucha, Tierra y Planta.
     *
     * @param otroTipo El otro tipo contra el que se verificará la resistencia.
     * @return `true` si el otro tipo es Lucha, Tierra o Planta, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Tierra || otroTipo is Planta;
    }
}