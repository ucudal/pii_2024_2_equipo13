namespace Library;

public abstract class Pokemon
{
    public string Nombre { get; protected set; }
    public double VidaActual { get; set; }
    public double VidaMax { get; protected set; }
    public bool EstaDormido { get; set; }
    public bool EstaParalizado { get; set; }
    public bool EstaEnvenenado { get; set; }
    public bool EstaQuemado { get; set; }
    public bool AptoParaBatalla { get; set; }
    public Itipo Tipo { get; protected set; }
    protected Dictionary<int, IAtaque> AtaquesBasicos;
    protected Dictionary<int, IAtaque> AtaquesEspeciales;
    

    public void GetAtaquesBasicos()
    {
        foreach (var ataque in AtaquesBasicos)
        {
            Console.WriteLine($"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}");
        }
    }
    public void  GetAtaqueEspecial()
    {
        foreach (var ataque in AtaquesEspeciales)
        {
            Console.WriteLine($"{ataque.Key} - {ataque.Value.Nombre}, Daño: {ataque.Value.Daño}, Tipo: {ataque.Value.Tipo.GetType().Name}");
        }
    }
    
    public void DañoRecibido(double daño)
    {
        this.VidaActual -= daño;

        // Verificar si el Pokémon está derrotado
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
        //este metodo, gestiona la salud de los pokemons, siendo invocado en los metodos de ataque.
    }

    public void Curar()
    {
        //Este método, lo que hace es curar al Pokemón,una cantidad establecida de salud.
        // Calcular la cantidad de curación (un cuarto de la vida máxima)
        double cantidadCuracion = this.VidaMax * 0.25;

        // Incrementar la vida actual con la cantidad de curación
        this.VidaActual += cantidadCuracion;

        // Asegurar que la vida actual no exceda la vida máxima
        if (this.VidaActual > this.VidaMax)
        {
            this.VidaActual = this.VidaMax;
        }

        // Mensaje de curación
        Console.WriteLine(
            $"{this.Nombre} se ha curado {cantidadCuracion} puntos de vida. Vida actual: {this.VidaActual}/{this.VidaMax}");
    }
    
    public double AtaqueEspecial(Pokemon objetivo,int ataqueElegido)
    {
        if (this.AptoParaBatalla)
        {
            if (!this.PuedeAtacarDormido())
            {
                Console.WriteLine($"{this.Nombre} está dormido y no puede atacar.");
                return 0; // Si el Pokémon está dormido, no puede atacar
            }
            else if (!this.PuedeAtacarParalizado())
            {
                Console.WriteLine($"{this.Nombre} está paralizado y no puede atacar.");
                return 0; // Si el Pokémon está paralizado y no puede atacar, retorna 0
            }

            if (AtaquesEspeciales.ContainsKey(ataqueElegido))
            {
                IAtaque ataqueSeleccionado = AtaquesEspeciales[ataqueElegido];
                double efectividadAtaque = 1;
                Random random = new Random();

                // Verificar si el ataque es preciso (si acierta o no)
                if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
                {
                    Console.WriteLine($"{this.Nombre} falló el ataque {ataqueSeleccionado.Nombre}.");
                    return 0; // Si falla el ataque, no se realiza daño
                }

                // Verificar debilidades y resistencias basadas en el tipo del ataque
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
                    return 0; // Si el objetivo es inmune, no se hace daño
                }

                // Calcular el daño base
                double daño = ataqueSeleccionado.Daño * efectividadAtaque;

                // Verificar si es un golpe crítico (10% de probabilidad)
                if (random.NextDouble() <= 0.10)
                {
                    daño *= 1.2; // Aumentar el daño en un 20%
                    Console.WriteLine("¡Golpe crítico!");
                }

                // Aplicar el daño al objetivo
                objetivo.DañoRecibido(daño);
                return daño; // Retornar el daño infligido
            }
            else
            {
                Console.WriteLine("El ataque seleccionado no existe.");
                return 0; // Si el ataque no existe, retorna 0 daño
            }
        }
        else
        {
            Console.WriteLine($"{this.Nombre} no esta apto para la batalla");
        }
        return 0;
    }
    
    public double AtaqueBasico(Pokemon objetivo, int ataqueElegido)
{
    // Verificar si el Pokémon atacante puede realizar el ataque (no está dormido ni paralizado)
    if (!this.PuedeAtacarDormido())
    {
        Console.WriteLine($"{this.Nombre} está dormido y no puede atacar.");
        return 0; // Si el Pokémon está dormido, no puede atacar
    }

    if (!this.PuedeAtacarParalizado())
    {
        Console.WriteLine($"{this.Nombre} está paralizado y no puede atacar.");
        return 0; // Si el Pokémon está paralizado y no puede atacar, retorna 0
    }

    // Verificar si el ataque existe en el diccionario de ataques básicos
    if (AtaquesBasicos.ContainsKey(ataqueElegido))
    {
        IAtaque ataqueSeleccionado = AtaquesBasicos[ataqueElegido];
        double efectividadAtaque = 1;
        Random random = new Random();

        // Verificar si el ataque es preciso (si acierta o no)
        if (random.NextDouble() > (ataqueSeleccionado.Precision / 100.0))
        {
            Console.WriteLine($"{this.Nombre} falló el ataque {ataqueSeleccionado.Nombre}.");
            return 0; // Si falla el ataque, no se realiza daño
        }

        // Verificar debilidades y resistencias basadas en el tipo del ataque
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
            return 0; // Si el objetivo es inmune, no se hace daño
        }

        // Calcular el daño base
        double daño = ataqueSeleccionado.Daño * efectividadAtaque;

        // Verificar si es un golpe crítico (10% de probabilidad)
        if (random.NextDouble() <= 0.10)
        {
            daño *= 1.2; // Aumentar el daño en un 20%
            Console.WriteLine("¡Golpe crítico!");
        }
        //falta aplicar, que se aplique el efecto especial del ataque contra el pokemon efectivo
        
        // Aplicar el daño al objetivo
        objetivo.DañoRecibido(daño);
        return daño; // Retornar el daño infligido
    }
    else
    {
        Console.WriteLine("El ataque seleccionado no existe.");
        return 0; // Si el ataque no existe, retorna 0 daño
    }
}
    
    
    public bool EstaAfectadoPorEfecto()
    {
        return EstaDormido || EstaEnvenenado || EstaParalizado||EstaQuemado;
    }
    
    public bool PuedeAtacarParalizado()
    {
        Random random = new Random();
        if (this.EstaParalizado)
        {
            int probabilidadAtaque=random.Next(1,3);
            if (probabilidadAtaque==1)
            {
                return true;
            }
            else if (probabilidadAtaque==2)
            {
                return false;
            }
        }
        return true;
    }
    
    public bool PuedeAtacarDormido()
    {
        if (this.EstaDormido)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void AplicarDañoQuemadura()
    {
        if(this.EstaQuemado)
        {
            double daño = this.VidaActual * 0.10;
            this.DañoRecibido(daño);
            Console.WriteLine($"{this.Nombre} ha recibido {daño} de vida por quemadura");
        }
    }
    public void AplicarDañoVeneno()
    {
        if (this.EstaEnvenenado)
        {
            double dañoVeneno = this.VidaActual * 0.05;
            this.DañoRecibido(dañoVeneno);
            Console.WriteLine($"{this.Nombre} ha recibido {dañoVeneno} de daño por envenenamiento.");
        }
    }

    public void RemoverEfectos()
    {
        this.EstaDormido = false;
        this.EstaParalizado = false;
        this.EstaEnvenenado = false;
        this.EstaQuemado = false;
    }




}