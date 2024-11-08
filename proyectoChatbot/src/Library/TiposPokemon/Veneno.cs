using Library;

/**
 * @class Veneno
 * @brief Representa el tipo de Pokémon "Veneno" y define sus interacciones con otros tipos.
 *
 * La clase Veneno implementa la interfaz Itipo y proporciona las propiedades y métodos
 * para verificar las inmunidades, resistencias y debilidades del tipo Veneno.
 */
public class Veneno : Itipo
{
    /**
     * @brief Nombre del tipo de Pokémon.
     */
    public string Nombre { get; }

    /**
     * @brief Constructor de la clase Veneno.
     *
     * Inicializa el nombre del tipo como "Veneno".
     */
    public Veneno()
    {
        this.Nombre = "Veneno";
    }

    /**
     * @brief Verifica si el tipo Veneno es inmune a otro tipo.
     *
     * El tipo Veneno no es inmune a ningún tipo.
     *
     * @param otroTipo El tipo contra el que se verificará la inmunidad.
     * @return `false` siempre, ya que el tipo Veneno no es inmune a ningún tipo.
     */
    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    /**
     * @brief Verifica si el tipo Veneno es resistente a otro tipo.
     *
     * El tipo Veneno es resistente a Planta, Hada, Bicho y Veneno.
     *
     * @param otroTipo El tipo contra el que se verificará la resistencia.
     * @return `true` si el tipo es Planta, Hada, Bicho o Veneno, `false` de lo contrario.
     */
    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Planta || otroTipo is Hada || otroTipo is Bicho || otroTipo is Veneno;
    }

    /**
     * @brief Verifica si el tipo Veneno es débil a otro tipo.
     *
     * El tipo Veneno es débil a Tierra y Psíquico.
     *
     * @param otroTipo El tipo contra el que se verificará la debilidad.
     * @return `true` si el tipo es Tierra o Psíquico, `false` de lo contrario.
     */
    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Tierra || otroTipo is Psiquico;
    }
}