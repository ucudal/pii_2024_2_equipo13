namespace Library;

/**
 * @class AtaqueBasico
 * @brief Representa un ataque básico de un Pokémon.
 *
 * La clase AtaqueBasico implementa la interfaz IAtaque y define las propiedades
 * de un ataque básico, como el nombre, el daño, el tipo y la precisión.
 */
public class AtaqueBasico : IAtaque
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
     * @brief Precisión del ataque.
     * @return La precisión del ataque.
     */
    public double Precision { get; set; }

    /**
     * @brief Tipo del ataque.
     * @return El tipo del ataque.
     */
    public Itipo Tipo { get; }

    /**
     * @brief Constructor de la clase AtaqueBasico.
     *
     * Inicializa un ataque básico con el nombre, el daño, el tipo y la precisión especificados.
     *
     * @param nombre El nombre del ataque.
     * @param daño La cantidad de daño que causa el ataque.
     * @param tipo El tipo del ataque.
     * @param precision La precisión del ataque.
     */
    public AtaqueBasico(string nombre, double daño, Itipo tipo, double precision)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.Precision = precision;
    }
    
}