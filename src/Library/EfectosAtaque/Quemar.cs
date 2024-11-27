namespace Library.EfectosAtaque;

/**
 * @class Quemar
 * @brief Clase que representa el efecto de estado "Quemadura" en un Pokémon.
 *
 * La clase Quemar implementa la interfaz IEfectoAtaque y aplica el efecto de
 * quemadura a un Pokémon, causando daño adicional en cada turno.
 */
public class Quemar : IEfectoAtaque
{
    /**
     * @brief Indica si el efecto de quemadura está activo.
     */
    public bool EstaQuemado { get; set; }

    /**
     * @brief Probabilidad de que el efecto de quemadura se active.
     */
    public double ProbabilidadEfecto { get; }

    /**
     * @brief Constructor de la clase Quemar.
     *
     * Inicializa el efecto de quemadura con una probabilidad de activación especificada.
     *
     * @param probabilidad La probabilidad de que el efecto de quemadura se active.
     */
    public Quemar(double probabilidad)
    {
        this.EstaQuemado = false;
        this.ProbabilidadEfecto = probabilidad;
    }

    /**
     * @brief Aplica el efecto de quemadura al Pokémon objetivo.
     *
     * Pone al Pokémon en estado quemado, causando daño adicional en cada turno.
     *
     * @param objetivo El Pokémon que recibirá el efecto de quemadura.
     */
    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaQuemado = true;
        Console.WriteLine($"{objetivo.PokemonName} está quemado.");
    }

    /**
     * @brief Elimina el efecto de quemadura del Pokémon.
     *
     * Permite que el Pokémon deje de recibir daño adicional por quemadura.
     *
     * @param objetivo El Pokémon al que se le removerá el efecto de quemadura.
     */
    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaQuemado = false;
        Console.WriteLine($"{objetivo.PokemonName} ya no está quemado.");
    }

    /**
     * @brief Verifica si el efecto de quemadura sigue activo en el Pokémon.
     *
     * @param objetivo El Pokémon que se verificará.
     * @return `true` si el efecto de quemadura está activo, `false` de lo contrario.
     */
    public bool EstaActivo(Pokemon objetivo)
    {
        return objetivo.EstaQuemado;
    }
}
