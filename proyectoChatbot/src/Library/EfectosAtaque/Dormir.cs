namespace Library.EfectosAtaque;

/**
 * @class Dormir
 * @brief Clase que representa el efecto de estado "Dormir" en un Pokémon.
 *
 * La clase Dormir implementa la interfaz IEfectoAtaque y aplica el efecto de
 * dormir a un Pokémon, impidiéndole atacar durante un número determinado de turnos.
 */
public class Dormir : IEfectoAtaque
{
    /**
     * @brief Número de turnos que el Pokémon permanece dormido.
     */
    private int turnosDormido;

    /**
     * @brief Probabilidad de que el efecto de dormir se active.
     */
    public double ProbabilidadEfecto { get; }

    /**
     * @brief Constructor de la clase Dormir.
     *
     * Inicializa el efecto de dormir con una probabilidad de activación especificada.
     *
     * @param probabilidad La probabilidad de que el efecto de dormir se active.
     */
    public Dormir(double probabilidad)
    {
        this.turnosDormido = 0;
        this.ProbabilidadEfecto = probabilidad;
    }

    /**
     * @brief Aplica el efecto de dormir al Pokémon objetivo.
     *
     * Pone al Pokémon en estado dormido e inicializa un número aleatorio de turnos
     * durante los cuales el Pokémon permanecerá dormido.
     *
     * @param objetivo El Pokémon que recibirá el efecto de dormir.
     */
    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaDormido = true;
        Random random = new Random();
        turnosDormido = random.Next(1, 5);
        Console.WriteLine($"{objetivo.Nombre} está dormido por {turnosDormido} turnos.");
    }

    /**
     * @brief Reduce el contador de turnos de sueño del Pokémon.
     *
     * Si el contador llega a cero, el efecto de dormir se elimina del Pokémon.
     *
     * @param objetivo El Pokémon al que se le reducirá el turno de sueño.
     */
    public void ReducirTurno(Pokemon objetivo)
    {
        if (objetivo.EstaDormido)
        {
            turnosDormido--;
            if (turnosDormido == 0)
            {
                RemoverEfecto(objetivo);
            }
        }
    }

    /**
     * @brief Elimina el efecto de dormir del Pokémon.
     *
     * Despierta al Pokémon, permitiéndole atacar nuevamente.
     *
     * @param objetivo El Pokémon al que se le removerá el efecto de dormir.
     */
    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaDormido = false;
        Console.WriteLine($"{objetivo.Nombre} ha despertado.");
    }

    /**
     * @brief Verifica si el efecto de dormir sigue activo en el Pokémon.
     *
     * @param objetivo El Pokémon que se verificará.
     * @return `true` si el Pokémon está dormido, `false` de lo contrario.
     */
    public bool EstaActivo(Pokemon objetivo)
    {
        return objetivo.EstaDormido;
    }
}
