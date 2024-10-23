using System.Runtime.CompilerServices;
using Library.EfectosAtaque;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Alakazam : IPokemon
{
    public string Nombre { get; } //Getter del nombre del Pokemon
    public double VidaActual { get; set; } //Getter VidaActual del Pokemon
    public double VidaMax { get; } //Getter VidaMaxima del Pokemon
    
    public bool EstaDormido { get; set; }
    public bool EstaParalizado { get;  set; }
    public bool EstaEnvenenado { get; set; }
    public bool EstaQuemado { get;set; }

    public bool AptoParaBatalla { get; set; } //Getter, que va a indicar si el Pokemon esta apato para batalla o no
    public Itipo Tipo { get; } //Getter del Tipo del Pokemon
    private Dictionary<int, IAtaque> AtaquesBasicos; //Lista, que contiene los ataquesBasicos
    private Dictionary<int, IAtaque> AtaquesEspeciales; //Lista que contiene los Ataques Especiales
    

    //Constructor 
    public Alakazam()
    {
        this.Nombre = "Alakazam";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipo = new Psiquico();
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueBasico("Confusión", 50, new Psiquico(),90)},
            {2,new AtaqueBasico("Hipnosis", 70, new Psiquico(),95)}
        };
        this.AtaquesEspeciales = new Dictionary<int, IAtaque>
        {
            {1,new AtaqueEspecial("Psicorayo", 100, new Psiquico(),80,new Paralizar(0.50))},
            {2,new AtaqueEspecial("Hiperrayo", 150, new Normal(),75,new Quemar(0.3))}
        };
    }

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

    public double AtaqueEspecial(IPokemon objetivo,int ataqueElegido)
    {
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

        return 0;
    }

    public double AtaqueBasico(IPokemon objetivo, int ataqueElegido)
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

}
    
