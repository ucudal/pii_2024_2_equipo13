namespace Library.TiposPokemon;

/**
 * @class Normal
 * @brief Representa el tipo de Pokémon "Normal" y define sus interacciones con otros tipos.
 *
 * La clase Normal implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Normal.
 */
public class Normal : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Normal.
     *
     * Inicializa el nombre del tipo como "Normal".
     */
    public Normal()
    {
        this.Nombre = "Normal";
    }

    /**
     * @brief Verifica si el tipo Normal es inmune a otro tipo.
     *
     * El tipo Normal es inmune a Fantasma.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `true` si el tipo es Fantasma, `false` de lo contrario.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return otroTipo is Fantasma;
    }

    /**
     * @brief Verifica si el tipo Normal es resistente a otro tipo.
     *
     * El tipo Normal no es especialmente resistente a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `false` siempre, ya que el tipo Normal no es resistente a ningún tipo.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Normal es débil a otro tipo.
     *
     * El tipo Normal es débil a Lucha.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Lucha, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Lucha;
    }
}