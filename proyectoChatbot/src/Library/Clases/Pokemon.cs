namespace Library;

/**
 * @class Pokemon
 * @brief Clase abstracta que representa un Pokémon en una batalla.
 *
 * La clase `Pokemon` proporciona propiedades y métodos para gestionar el estado de un Pokémon,
 * realizar ataques básicos y especiales, y gestionar efectos como envenenamiento o quemaduras.
 */
public abstract class Pokemon
{
    /** @brief Nombre del Pokémon. */
    public string Nombre { get; protected set; }

    /** @brief Vida actual del Pokémon. */
    public double VidaActual { get; set; }

    /** @brief Vida máxima del Pokémon. */
    public double VidaMax { get; protected set; }

    /** @brief Indica si el Pokémon está dormido. */
    public bool EstaDormido { get; set; }

    /** @brief Indica si el Pokémon está paralizado. */
    public bool EstaParalizado { get; set; }

    /** @brief Indica si el Pokémon está envenenado. */
    public bool EstaEnvenenado { get; set; }

    /** @brief Indica si el Pokémon está quemado. */
    public bool EstaQuemado { get; set; }

    /** @brief Indica si el Pokémon está apto para la batalla. */
    public bool AptoParaBatalla { get; set; }

    /** @brief Tipo del Pokémon. */
    public Itipo Tipo { get; protected set; }

    /** @brief Diccionario de ataques básicos disponibles para el Pokémon. */
    protected Dictionary<int, IAtaque> AtaquesBasicos;

    /** @brief Diccionario de ataques especiales disponibles para el Pokémon. */
    protected Dictionary<int, IAtaque> AtaquesEspeciales;

    /** @brief Acceso de solo lectura a los ataques básicos del Pokémon. */
    public IReadOnlyDictionary<int, IAtaque> AtaquesBasicosPublicos => AtaquesBasicos;

    /** @brief Acceso de solo lectura a los ataques especiales del Pokémon. */
    public IReadOnlyDictionary<int, IAtaque> AtaquesEspecialesPublicos => AtaquesEspeciales;

    /**
     * @brief Muestra los ataques básicos del Pokémon en la consola.
     */
    public void GetAtaquesBasicos()
    {
        foreach (var ataque in AtaquesBasicos)
        {
            Console.WriteLine($"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}");
        }
    }

    /**
     * @brief Muestra los ataques especiales del Pokémon en la consola.
     */
    public void GetAtaqueEspecial()
    {
        foreach (var ataque in AtaquesEspeciales)
        {
            Console.WriteLine($"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}");
        }
    }

    /**
     * @brief Aplica daño al Pokémon y verifica si ha sido derrotado.
     * @param daño La cantidad de daño a aplicar.
     */
    public void DañoRecibido(double daño)
    {
        this.VidaActual -= daño;

        if (this.VidaActual <= 0)
        {
            this.VidaActual = 0;
            this.AptoParaBatalla = false;
            Console.WriteLine($"{this.Nombre} ha sido derrotado y ya no está apto para la batalla.");
        }
        else
        {
            Console.WriteLine($"{this.Nombre} ha recibido {daño} puntos de daño. Vida actual: {this.VidaActual}");
        }
    }

    /**
     * @brief Cura al Pokémon una cantidad fija de salud.
     */
    public void Curar()
    {
        double cantidadCuracion = this.VidaMax * 0.25;
        this.VidaActual += cantidadCuracion;

        if (this.VidaActual > this.VidaMax)
        {
            this.VidaActual = this.VidaMax;
        }

        Console.WriteLine(
            $"{this.Nombre} se ha curado {cantidadCuracion} puntos de vida. Vida actual: {this.VidaActual}/{this.VidaMax}");
    }

    /**
     * @brief Realiza un ataque especial al Pokémon objetivo.
     * @param objetivo El Pokémon que recibirá el ataque.
     * @param ataqueElegido El índice del ataque especial a usar.
     * @return La cantidad de daño infligido.
     */
    public double AtaqueEspecial(Pokemon objetivo, int ataqueElegido)
    {
        if (this.AptoParaBatalla)
        {
            if (!this.PuedeAtacarDormido())
            {
                Console.WriteLine($"{this.Nombre} está dormido y no puede atacar.");
                return 0;
            }
            else if (!this.PuedeAtacarParalizado())
            {
                Console.WriteLine($"{this.Nombre} está paralizado y no puede atacar.");
                return 0;
            }

            if (AtaquesEspeciales.ContainsKey(ataqueElegido))
            {
                IAtaque ataqueSeleccionado = AtaquesEspeciales[ataqueElegido];
                double efectividadAtaque = 1;
                Random random = new Random();

                if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
                {
                    Console.WriteLine($"{this.Nombre} falló el ataque {ataqueSeleccionado.Nombre}.");
                    return 0;
                }

                if (objetivo.Tipo.DebilContra(ataqueSeleccionado.Tipo))
                {
                    efectividadAtaque *= 2;
                }
                else if (objetivo.Tipo.ResistenteContra(ataqueSeleccionado.Tipo))
                {
                    efectividadAtaque *= 0.5;
                }
                else if (objetivo.Tipo.InmuneContra(ataqueSeleccionado.Tipo))
                {
                    efectividadAtaque = 0;
                    Console.WriteLine("El ataque ha sido nulo.");
                    return 0;
                }

                double daño = ataqueSeleccionado.Daño * efectividadAtaque;

                if (random.NextDouble() <= 0.10)
                {
                    daño *= 1.2;
                    Console.WriteLine("¡Golpe crítico!");
                }

                objetivo.DañoRecibido(daño);

                if (ataqueSeleccionado is AtaqueEspecial ataqueEspecial)
                {
                    if (random.NextDouble() <= ataqueEspecial.Efecto.ProbabilidadEfecto)
                    {
                        ataqueEspecial.Efecto.AplicarEfecto(objetivo);
                        Console.WriteLine($"{objetivo.Nombre} ha sido afectado por {ataqueEspecial.Efecto.GetType().Name}!");
                    }
                }
            }
            else
            {
                Console.WriteLine("El ataque seleccionado no existe.");
                return 0;
            }
        }
        else
        {
            Console.WriteLine($"{this.Nombre} no está apto para la batalla");
        }
        return 0;
    }

    /**
     * @brief Realiza un ataque básico al Pokémon objetivo.
     * @param objetivo El Pokémon que recibirá el ataque.
     * @param ataqueElegido El índice del ataque básico a usar.
     * @return La cantidad de daño infligido.
     */
    public double AtaqueBasico(Pokemon objetivo, int ataqueElegido)
    {
        if (!this.PuedeAtacarDormido())
        {
            Console.WriteLine($"{this.Nombre} está dormido y no puede atacar.");
            return 0;
        }

        if (!this.PuedeAtacarParalizado())
        {
            Console.WriteLine($"{this.Nombre} está paralizado y no puede atacar.");
            return 0;
        }

        if (AtaquesBasicos.ContainsKey(ataqueElegido))
        {
            IAtaque ataqueSeleccionado = AtaquesBasicos[ataqueElegido];
            double efectividadAtaque = 1;
            Random random = new Random();

            if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
            {
                Console.WriteLine($"{this.Nombre} falló el ataque {ataqueSeleccionado.Nombre}.");
                return 0;
            }

            if (objetivo.Tipo.DebilContra(ataqueSeleccionado.Tipo))
            {
                efectividadAtaque *= 2;
            }
            else if (objetivo.Tipo.ResistenteContra(ataqueSeleccionado.Tipo))
            {
                efectividadAtaque *= 0.5;
            }
            else if (objetivo.Tipo.InmuneContra(ataqueSeleccionado.Tipo))
            {
                efectividadAtaque = 0;
                Console.WriteLine("El ataque ha sido nulo.");
                return 0;
            }

            double daño = ataqueSeleccionado.Daño * efectividadAtaque;

            if (random.NextDouble() <= 0.10)
            {
                daño *= 1.2;
                Console.WriteLine("¡Golpe crítico!");
            }

            objetivo.DañoRecibido(daño);
            return daño;
        }
        else
        {
            Console.WriteLine("El ataque seleccionado no existe.");
            return 0;
        }
    }

    /** @brief Verifica si el Pokémon está afectado por algún efecto de estado. */
    public bool EstaAfectadoPorEfecto()
    {
        return EstaDormido || EstaEnvenenado || EstaParalizado || EstaQuemado;
    }

    /** @brief Verifica si el Pokémon paralizado puede atacar en este turno. */
    public bool PuedeAtacarParalizado()
    {
        Random random = new Random();
        if (this.EstaParalizado)
        {
            return random.Next(1, 3) == 1;
        }
        return true;
    }

    /** @brief Verifica si el Pokémon dormido puede atacar en este turno. */
    public bool PuedeAtacarDormido()
    {
        return !this.EstaDormido;
    }

    /** @brief Aplica daño al Pokémon debido a quemadura. */
    public void AplicarDañoQuemadura()
    {
        if (this.EstaQuemado)
        {
            double daño = this.VidaActual * 0.10;
            this.DañoRecibido(daño);
            Console.WriteLine($"{this.Nombre} ha recibido {daño} de vida por quemadura");
        }
    }

    /** @brief Aplica daño al Pokémon debido a envenenamiento. */
    public void AplicarDañoVeneno()
    {
        if (this.EstaEnvenenado)
        {
            double dañoVeneno = this.VidaActual * 0.05;
            this.DañoRecibido(dañoVeneno);
            Console.WriteLine($"{this.Nombre} ha recibido {dañoVeneno} de daño por envenenamiento.");
        }
    }

    /** @brief Remueve todos los efectos de estado del Pokémon. */
    public void RemoverEfectos()
    {
        this.EstaDormido = false;
        this.EstaParalizado = false;
        this.EstaEnvenenado = false;
        this.EstaQuemado = false;
    }
}
