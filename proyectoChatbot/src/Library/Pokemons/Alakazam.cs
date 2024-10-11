using System.Runtime.CompilerServices;
using Library.TiposPokemon;

namespace Library.Pokemons;

public class Alakazam : IPokemon
{
    public string Nombre { get; } //Getter del nombre del Pokemon
    public double VidaActual { get; set; } //Getter VidaActual del Pokemon
    public double VidaMax { get;  } //Getter VidaMaxima del Pokemon

    public bool AptoParaBatalla { get; set; } //Getter, que va a indicar si el Pokemon esta apato para batalla o no
    public List<Itipo> Tipos { get; } //Getter del Tipo del Pokemon
    private List<IAtaque> AtaquesBasicos; //Lista, que contiene los ataquesBasicos
    private List<IAtaque> ataqueEspecial; //Lista que contiene los Ataques Especiales

    //Constructor 
    public Alakazam()
    {
        this.Nombre = "Alakazam";
        this.VidaActual = VidaMax;
        this.VidaMax = 100;
        this.Tipos = new List<Itipo> { new Psiquico() };
        this.AptoParaBatalla = true;
        this.AtaquesBasicos = new List<IAtaque>();
        this.ataqueEspecial = new List<IAtaque>();
    }

    public List<IAtaque> GetAtaquesBasicos()
    {
        //Este metodo devuelve la lista de ataques basicos del Pokemon
        return this.AtaquesBasicos;
    }

    public List<IAtaque> GetAtaqueEspecial()
    {
        //Devuelve una lista con el ataque especial
        return this.ataqueEspecial;
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
        Console.WriteLine($"{this.Nombre} se ha curado {cantidadCuracion} puntos de vida. Vida actual: {this.VidaActual}/{this.VidaMax}");
    }

    public double AtaqueEspecial(IPokemon objetivo)
    {
        IAtaque ataque = this.ataqueEspecial[0];
        double dañoInfligido = ataque.Daño;
        bool esFuerte = false;
        bool esDebil = false;
        foreach (Itipo tipoObjetivo in objetivo.Tipos)
        {
            // Verificar si el tipo del objetivo es fuerte contra el tipo del atacante
            if (tipoObjetivo.FuerteContra(this.Tipos))
            {
                dañoInfligido /= 2; // Reduce el daño a la mitad si el objetivo es fuerte
                esFuerte = true;
                break; // Salimos del bucle, ya que solo necesitamos una coincidencia
            }

            // Verificar si el tipo del objetivo es débil contra el tipo del atacante

            else if (tipoObjetivo.DebilContra(this.Tipos))
            {
                dañoInfligido *= 2; // Aumenta el daño al doble si el objetivo es débil
                esDebil = true;
                break; // Salimos del bucle, ya que solo necesitamos una coincidencia
            }
        }

        if (esDebil && esFuerte == false)
        {
            dañoInfligido = ataque.Daño;
        }

        // Infligir daño al objetivo
        objetivo.DañoRecibido(dañoInfligido);

        // Mostrar el daño infligido
        Console.WriteLine(
            $"{this.Nombre} ataca a {objetivo.Nombre} con {ataque.Nombre} y causa {dañoInfligido} de daño.");

        return dañoInfligido; // Retornar el daño infligido
    }

    public double AtaqueBasico(IPokemon objetivo)
    {
        IAtaque ataque = this.AtaquesBasicos[0];
        double dañoInfligido = ataque.Daño;
        bool esFuerte = false;
        bool esDebil = false;
        foreach (Itipo tipoObjetivo in objetivo.Tipos)
        {
            // Verificar si el tipo del objetivo es fuerte contra el tipo del atacante
            if (tipoObjetivo.FuerteContra(this.Tipos))
            {
                dañoInfligido /= 2; // Reduce el daño a la mitad si el objetivo es fuerte
                esFuerte = true;
                break; // Salimos del bucle, ya que solo necesitamos una coincidencia
            }

            // Verificar si el tipo del objetivo es débil contra el tipo del atacante

            else if (tipoObjetivo.DebilContra(this.Tipos))
            {
                dañoInfligido *= 2; // Aumenta el daño al doble si el objetivo es débil
                esDebil = true;
                break; // Salimos del bucle, ya que solo necesitamos una coincidencia
            }
        }

        if (esDebil && esFuerte == false)
        {
            dañoInfligido = ataque.Daño;
        }

        // Infligir daño al objetivo
        objetivo.DañoRecibido(dañoInfligido);

        // Mostrar el daño infligido
        Console.WriteLine($"{this.Nombre} ataca a {objetivo.Nombre} con {ataque.Nombre} y causa {dañoInfligido} de daño.");

        return dañoInfligido; // Retornar el daño infligido
    }
}
