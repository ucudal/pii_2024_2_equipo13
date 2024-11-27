namespace Library;

/**
 * @interface IAtaque
 * @brief Interfaz que define las propiedades básicas de un ataque.
 *
 * La interfaz IAtaque se implementa para definir los atributos de los ataques en el juego.
 */
public interface IAtaque
{
    /**
     * @brief Nombre del ataque.
     * @return El nombre del ataque.
     */
    public string Nombre { get; }

    /**
     * @brief Daño que causa el ataque.
     * @return La cantidad de daño que causa el ataque.
     */
    public double Daño { get; }

    /**
     * @brief Tipo de ataque.
     * @return El tipo del ataque.
     */
    public Itipo Tipo { get; }

    /**
     * @brief Precisión del ataque.
     * @return La precisión del ataque, expresada como un porcentaje.
     */
    public double Precision { get; set; }
}