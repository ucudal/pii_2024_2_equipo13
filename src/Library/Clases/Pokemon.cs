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
    public string PokemonName { get; protected set; }

    /** @brief Vida actual del Pokémon. */
    public double VidaActual { get; set; }

    /** @brief Vida máxima del Pokémon. */
    public double VidaMax { get; set; }

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
    
    private int _turnosDormido;
    public int TurnosDormido { get => _turnosDormido; set => _turnosDormido = value; }

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
    
    public Pokemon Clone()
    {
        // Clona las propiedades necesarias
        Pokemon clone = (Pokemon)this.MemberwiseClone();
        // Crea nuevas instancias de los diccionarios de ataques para evitar referencias compartidas
        clone.AtaquesBasicos = new Dictionary<int, IAtaque>(this.AtaquesBasicos);
        clone.AtaquesEspeciales = new Dictionary<int, IAtaque>(this.AtaquesEspeciales);
        return clone;
    }
    
    public string GetAtaquesBasicos()
    {
        string resultado = "";

        foreach (var ataque in AtaquesBasicos)
        {
            resultado +=
                ($"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}\n");
        }

        return resultado;
    }

    /**
     * @brief Muestra los ataques especiales del Pokémon en la consola.
     */
    public string GetAtaqueEspecial()
    {
        // Acumulador de texto para los ataques especiales
        string resultado = "Ataques Especiales:\n";

        foreach (var ataque in AtaquesEspeciales)
        {
            resultado +=
                $"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}\n";
        }

        return resultado;
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
            Console.WriteLine($"{this.PokemonName} ha sido derrotado y ya no está apto para la batalla.");
        }
        else
        {
            Console.WriteLine($"{this.PokemonName} ha recibido {daño} puntos de daño. Vida actual: {this.VidaActual}");
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
            $"{this.PokemonName} se ha curado {cantidadCuracion} puntos de vida. Vida actual: {this.VidaActual}/{this.VidaMax}");
    }

    /**
     * @brief Realiza un ataque especial al Pokémon objetivo.
     * @param objetivo El Pokémon que recibirá el ataque.
     * @param ataqueElegido El índice del ataque especial a usar.
     * @return La cantidad de daño infligido.
     */
    public double AtaqueEspecial(Pokemon objetivo, int ataqueElegido, out string mensaje)
{
    mensaje = "";

    // Verificar si el Pokémon está apto para la batalla
    if (!this.AptoParaBatalla)
    {
        mensaje = $"{PokemonName} no está apto para atacar.";
        return 0;
    }

    // Verificar si el Pokémon está dormido
    if (!this.PuedeAtacarDormido())
    {
        mensaje = $"{PokemonName} está dormido y no puede atacar.";
        return 0;
    }

    // Verificar si el Pokémon está paralizado
    if (!this.PuedeAtacarParalizado())
    {
        mensaje = $"{PokemonName} está paralizado y no puede atacar.";
        return 0;
    }

    // Verificar si el ataque existe en los ataques especiales
    if (!AtaquesEspeciales.ContainsKey(ataqueElegido))
    {
        mensaje = "El ataque seleccionado no existe.";
        return 0;
    }

    // Obtener el ataque seleccionado
    IAtaque ataqueSeleccionado = AtaquesEspeciales[ataqueElegido];
    double efectividadAtaque = 1;
    Random random = new Random();

    // Verificar precisión del ataque
    if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
    {
        mensaje = $"{PokemonName} falló el ataque {ataqueSeleccionado.Nombre}.";
        return 0;
    }

    // Calcular efectividad según el tipo del objetivo
    if (objetivo.Tipo.DebilContra(ataqueSeleccionado.Tipo))
    {
        efectividadAtaque *= 2;
        mensaje += "¡Es muy efectivo! ";
    }
    else if (objetivo.Tipo.ResistenteContra(ataqueSeleccionado.Tipo))
    {
        efectividadAtaque *= 0.5;
        mensaje += "No es muy efectivo. ";
    }
    else if (objetivo.Tipo.InmuneContra(ataqueSeleccionado.Tipo))
    {
        efectividadAtaque = 0;
        mensaje += $"{PokemonName} realizó un ataque nulo.";
        return 0;
    }

    // Calcular daño
    double daño = ataqueSeleccionado.Daño * efectividadAtaque;

    // Verificar golpe crítico
    if (random.NextDouble() <= 0.10)
    {
        daño *= 1.2;
        mensaje += "¡Golpe crítico! ";
    }

    // Aplicar el daño al objetivo
    // Construir el mensaje final
    objetivo.DañoRecibido(daño);
    mensaje += $"{PokemonName} infligió {daño} de daño a {objetivo.PokemonName} usando {ataqueSeleccionado.Nombre}.";

    // Aplicar efectos adicionales si es un ataque especial
    if (ataqueSeleccionado is AtaqueEspecial ataqueEspecial)
    {
        if (random.NextDouble() <= ataqueEspecial.Efecto.ProbabilidadEfecto)
        {
            ataqueEspecial.Efecto.AplicarEfecto(objetivo);
            mensaje += $" ¡{objetivo.PokemonName} ha sido afectado por {ataqueEspecial.Efecto.GetType().Name}!";
        }
    }

    return daño;
}


    /**
     * @brief Realiza un ataque básico al Pokémon objetivo.
     * @param objetivo El Pokémon que recibirá el ataque.
     * @param ataqueElegido El índice del ataque básico a usar.
     * @return La cantidad de daño infligido.
     */
   public double AtaqueBasico(Pokemon objetivo, int ataqueElegido, out string mensaje)
{
    mensaje = "";

    if (!this.AptoParaBatalla)
    {
        mensaje = $"{PokemonName} no está apto para atacar.";
        return 0;
    }

    if (!this.PuedeAtacarDormido())
    {
        mensaje = $"{PokemonName} está dormido y no puede atacar.";
        return 0;
    }

    if (!this.PuedeAtacarParalizado())
    {
        mensaje = $"{PokemonName} está paralizado y no puede atacar.";
        return 0;
    }

    if (AtaquesBasicos.ContainsKey(ataqueElegido))
    {
        IAtaque ataqueSeleccionado = AtaquesBasicos[ataqueElegido];
        double efectividad = 1;
        Random random = new Random();

        // Calcular si el ataque falla
        if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
        {
            mensaje = $"{PokemonName} falló el ataque {ataqueSeleccionado.Nombre}.";
            return 0;
        }

        // Calcular efectividad según tipo
        if (objetivo.Tipo.DebilContra(ataqueSeleccionado.Tipo))
        {
            efectividad *= 2;
            mensaje += "¡Es muy efectivo! ";
        }
        else if (objetivo.Tipo.ResistenteContra(ataqueSeleccionado.Tipo))
        {
            efectividad *= 0.5;
            mensaje += "No es muy efectivo. ";
        }
        else if (objetivo.Tipo.InmuneContra(ataqueSeleccionado.Tipo))
        {
            efectividad = 0;
            mensaje = $"{PokemonName} realizó un ataque nulo.";
            return 0;
        }

        // Calcular daño
        double daño = ataqueSeleccionado.Daño * efectividad;

        // Verificar golpe crítico
        if (random.NextDouble() <= 0.10)
        {
            daño *= 1.2;
            mensaje += "¡Golpe crítico! ";
        }

        // Aplicar daño al objetivo, NO al atacante
        objetivo.DañoRecibido(daño);
        mensaje += $"{PokemonName} infligió {daño} de daño a {objetivo.PokemonName} usando {ataqueSeleccionado.Nombre}.";
        return daño;
    }
    else
    {
        mensaje = "El ataque seleccionado no existe.";
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
            Console.WriteLine($"{this.PokemonName} ha recibido {daño} de vida por quemadura");
        }
    }

    /** @brief Aplica daño al Pokémon debido a envenenamiento. */
    public void AplicarDañoVeneno()
    {
        if (this.EstaEnvenenado)
        {
            double dañoVeneno = this.VidaActual * 0.05;
            this.DañoRecibido(dañoVeneno);
            Console.WriteLine($"{this.PokemonName} ha recibido {dañoVeneno} de daño por envenenamiento.");
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
    
    /** @brief Reduce los turnos del Pokemon dormido. */
    public void ReducirTurnoDormido()
    {
        if (this.EstaDormido)
        {
            _turnosDormido--;
            if (_turnosDormido == 0)
            {
                this.EstaDormido=false;
            }
        }
    }
}
