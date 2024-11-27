namespace Library.TiposPokemon;

/**
 * @class Siniestro
 * @brief Representa el tipo de Pokémon "Siniestro" y define sus interacciones con otros tipos.
 *
 * La clase Siniestro implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Siniestro.
 */
public class Siniestro : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Siniestro.
     *
     * Inicializa el nombre del tipo como "Siniestro".
     */
    public Siniestro()
    {
        this.Nombre = "Siniestro";
    }

    /**
     * @brief Verifica si el tipo Siniestro es inmune a otro tipo.
     *
     * El tipo Siniestro no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Siniestro no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Siniestro es resistente a otro tipo.
     *
     * El tipo Siniestro es resistente a Fantasma, Psíquico y Siniestro.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Fantasma, Psíquico o Siniestro, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Fantasma || otroTipo is Psiquico || otroTipo is Siniestro;
    }

    /**
     * @brief Verifica si el tipo Siniestro es débil a otro tipo.
     *
     * El tipo Siniestro es débil a Bicho, Hada y Lucha.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Bicho, Hada o Lucha, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Hada || otroTipo is Lucha;
    }
}