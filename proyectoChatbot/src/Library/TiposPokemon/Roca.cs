namespace Library.TiposPokemon;

/**
 * @class Roca
 * @brief Representa el tipo de Pokémon "Roca" y define sus interacciones con otros tipos.
 *
 * La clase Roca implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Roca.
 */
public class Roca : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Roca.
     *
     * Inicializa el nombre del tipo como "Roca".
     */
    public Roca()
    {
        this.Nombre = "Roca";
    }

    /**
     * @brief Verifica si el tipo Roca es inmune a otro tipo.
     *
     * El tipo Roca no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Roca no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Roca es resistente a otro tipo.
     *
     * El tipo Roca es resistente a Fuego, Normal, Volador y Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Fuego, Normal, Volador o Veneno, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Fuego || otroTipo is Normal || otroTipo is Volador || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Roca es débil a otro tipo.
     *
     * El tipo Roca es débil a Agua, Tierra, Lucha y Planta.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Agua, Tierra, Lucha o Planta, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Agua || otroTipo is Tierra || otroTipo is Lucha || otroTipo is Planta;
    }
}