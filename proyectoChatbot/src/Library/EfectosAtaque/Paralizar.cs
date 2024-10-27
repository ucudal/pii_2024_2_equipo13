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

    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaParalizado = true;
        Console.WriteLine($"{objetivo} esta paralizado");
    }

    

    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaParalizado = false;
        Console.WriteLine($"{objetivo}, ya no tiene Paralisis");
    }

    public bool EstaActivo(Pokemon objetivo)
    {
        return this.EstaParalizado;
    }
}