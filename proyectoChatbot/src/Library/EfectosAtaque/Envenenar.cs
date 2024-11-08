namespace Library.EfectosAtaque;

/**
 * @class Envenenar
 * @brief Clase que representa el efecto de estado "Envenenamiento" en un Pokémon.
 *
 * La clase Envenenar implementa la interfaz IEfectoAtaque y aplica el efecto de
 * envenenamiento a un Pokémon, causando daño a lo largo de varios turnos.
 */
public class Envenenar : IEfectoAtaque
{
    /**
     * @brief Indica si el efecto de envenenamiento está activo.
     */
    public bool EstaEnvenenado { get; set; }

    /**
     * @brief Probabilidad de que el efecto de envenenamiento se active.
     */
    public double ProbabilidadEfecto { get; }

    /**
     * @brief Constructor de la clase Envenenar.
     *
     * Inicializa el efecto de envenenamiento con una probabilidad de activación especificada.
     *
     * @param probabilidad La probabilidad de que el efecto de envenenamiento se active.
     */
    public Envenenar(double probabilidad)
    {
        this.EstaEnvenenado = false;
        this.ProbabilidadEfecto = probabilidad;
    }

    /**
     * @brief Aplica el efecto de envenenamiento al Pokémon objetivo.
     *
     * Pone al Pokémon en estado envenenado, causando daño continuo en cada turno.
     *
     * @param objetivo El Pokémon que recibirá el efecto de envenenamiento.
     */
    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaEnvenenado = true;
        Console.WriteLine($"{objetivo.Nombre} está envenenado.");
    }

    /**
     * @brief Aplica daño por envenenamiento al Pokémon objetivo.
     *
     * Reduce la vida del Pokémon en un 5% de su vida actual por cada turno envenenado.
     *
     * @param objetivo El Pokémon que recibirá el daño por envenenamiento.
     */
    public void DañoVeneno(Pokemon objetivo)
    {
        if (objetivo.EstaEnvenenado)
        {
            double vida = objetivo.VidaActual - (objetivo.VidaActual * 0.05);
            objetivo.VidaActual = vida;
        }
    }

    /**
     * @brief Elimina el efecto de envenenamiento del Pokémon.
     *
     * Permite que el Pokémon deje de recibir daño continuo por envenenamiento.
     *
     * @param objetivo El Pokémon al que se le removerá el efecto de envenenamiento.
     */
    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaEnvenenado = false;
    }

    /**
     * @brief Verifica si el efecto de envenenamiento sigue activo en el Pokémon.
     *
     * @param objetivo El Pokémon que se verificará.
     * @return `true` si el efecto de envenenamiento está activo, `false` de lo contrario.
     */
    public bool EstaActivo(Pokemon objetivo)
    {
        return this.EstaEnvenenado;
    }
}
