namespace Library.EfectosAtaque;

public class Paralizar:IEfectoAtaque
{
    public bool EstaParalizado{ get;  set; }
    public double ProbabilidadEfecto { get; }
    public Paralizar(double probabilidad)
    {
        this.EstaParalizado = false;
        this.ProbabilidadEfecto = probabilidad;
    }

    public void AplicarEfecto(IPokemon objetivo)
    {
        objetivo.EstaParalizado = true;
        Console.WriteLine($"{objetivo} esta paralizado");
    }

    

    public void RemoverEfecto(IPokemon objetivo)
    {
        objetivo.EstaParalizado = false;
        Console.WriteLine($"{objetivo}, ya no tiene Paralisis");
    }

    public bool EstaActivo(IPokemon objetivo)
    {
        return this.EstaParalizado;
    }
}