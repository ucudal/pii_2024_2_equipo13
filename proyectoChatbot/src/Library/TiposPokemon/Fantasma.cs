namespace Library.TiposPokemon;

/**
 * @class Fantasma
 * @brief Representa el tipo de Pokémon "Fantasma" y define sus interacciones con otros tipos.
 *
 * La clase Fantasma implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Fantasma.
 */
public class Fantasma : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Fantasma.
     *
     * Inicializa el nombre del tipo como "Fantasma".
     */
    public Fantasma()
    {
        this.Nombre = "Fantasma";
    }

    /**
     * @brief Verifica si el tipo Fantasma es inmune a otro tipo.
     *
     * El tipo Fantasma es inmune a Lucha y Normal.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `true` si el tipo es Lucha o Normal, `false` de lo contrario.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Normal;
    }

    /**
     * @brief Verifica si el tipo Fantasma es resistente a otro tipo.
     *
     * El tipo Fantasma es resistente a Bicho y Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Bicho o Veneno, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Fantasma es débil a otro tipo.
     *
     * El tipo Fantasma es débil a otros Pokémon de tipo Fantasma.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Fantasma, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Fantasma;
    }
}