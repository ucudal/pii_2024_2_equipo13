using Library.TiposPokemon;

namespace Library;

/**
 * @class AtaqueEspecial
 * @brief Representa un ataque especial de un Pokémon.
 *
 * La clase AtaqueEspecial implementa la interfaz IAtaque y define las propiedades
 * de un ataque especial, como el nombre, el daño, el tipo, la precisión y el efecto.
 */
public class AtaqueEspecial : IAtaque
{
    /**
     * @brief Nombre del ataque.
     * @return El nombre del ataque, definido en el constructor.
     */
    public string Nombre { get; }

    /**
     * @brief Daño del ataque.
     * @return El daño del ataque, definido en el constructor.
     */
    public double Daño { get; }

    /**
     * @brief Tipo del ataque.
     * @return El tipo del ataque.
     */
    public Itipo Tipo { get; }

    /**
     * @brief Efecto especial del ataque.
     * @return El efecto que aplica el ataque.
     */
    public IEfectoAtaque Efecto { get; }

    /**
     * @brief Precisión del ataque.
     * @return La precisión del ataque.
     */
    public double Precision { get; set; }

    /**
     * @brief Constructor de la clase AtaqueEspecial.
     *
     * Inicializa un ataque especial con el nombre, el daño, el tipo, la precisión y el efecto especificados.
     *
     * @param nombre El nombre del ataque.
     * @param daño La cantidad de daño que causa el ataque.
     * @param tipo El tipo del ataque.
     * @param precision La precisión del ataque.
     * @param efecto El efecto especial que aplica el ataque.
     */
    public AtaqueEspecial(string nombre, double daño, Itipo tipo, double precision, IEfectoAtaque efecto)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.Precision = precision;
        this.Efecto = efecto;
    }
}