namespace Library.EfectosAtaque;

public class Envenenar:IEfectoAtaque
{
    public bool EstaEnvenenado { get; set; }
    public double ProbabilidadEfecto { get; }
    public Envenenar(double probabilidad)
    {
        this.EstaEnvenenado = false;
        this.ProbabilidadEfecto = probabilidad;
    }
    public void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaEnvenenado = true;
        Console.WriteLine($"{objetivo} esta envenenado");
    }

    public void DañoVeneno(Pokemon objetivo)
    {
        if (objetivo.EstaEnvenenado)
        {
            double vida = objetivo.VidaActual - (objetivo.VidaActual * 0.05);
            vida = objetivo.VidaActual;
        }
    }

    public void RemoverEfecto(Pokemon objetivo)
    {
        objetivo.EstaEnvenenado = false;
    }

    public bool EstaActivo(Pokemon objetivo)
    {
        return this.EstaEnvenenado;
    }
}