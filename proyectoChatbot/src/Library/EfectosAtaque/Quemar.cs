namespace Library.EfectosAtaque;

public class Quemar:IEfectoAtaque
{
    public bool EstaQuemado { get; set; }
    public double ProbabilidadEfecto { get; }
    public Quemar(double probabilidad) 
    {
        this.EstaQuemado = false;
        this.ProbabilidadEfecto = probabilidad;
    }

    public void AplicarEfecto(IPokemon objetivo)
    {
        objetivo.EstaQuemado = true;
        Console.WriteLine($"{objetivo} esta quemado");
    }
    

    public void RemoverEfecto(IPokemon objetivo)
    {
        objetivo.EstaQuemado = false;
        Console.WriteLine($"{objetivo} ya no esta quemado");
    }

    public bool EstaActivo(IPokemon objetivo)
    {
        return objetivo.EstaQuemado;
    }
}