using Library;
using Library.TiposPokemon;

/**
 * @class Psiquico
 * @brief Representa el tipo de Pokémon "Psíquico" y define sus interacciones con otros tipos.
 *
 * La clase Psiquico implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Psíquico.
 */
public class Psiquico : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Psiquico.
     *
     * Inicializa el nombre del tipo como "Psiquico".
     */
    public Psiquico()
    {
        this.Nombre = "Psiquico";
    }

    /**
     * @brief Verifica si el tipo Psíquico es inmune a otro tipo.
     *
     * El tipo Psíquico no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Psíquico no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Psíquico es resistente a otro tipo.
     *
     * El tipo Psíquico es resistente a Lucha y Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Lucha o Veneno, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Lucha || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Psíquico es débil a otro tipo.
     *
     * El tipo Psíquico es débil a Bicho y Fantasma.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Bicho o Fantasma, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Fantasma;
    }
}