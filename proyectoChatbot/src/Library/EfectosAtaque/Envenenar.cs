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
    public void AplicarEfecto(IPokemon objetivo)
    {
        objetivo.EstaEnvenenado = true;
        Console.WriteLine($"{objetivo} esta envenado");
    }

    public void DañoVeneno(IPokemon objetivo)
    {
        if (objetivo.EstaEnvenenado)
        {
            double vida = objetivo.VidaActual - (objetivo.VidaActual * 0.05);
            vida = objetivo.VidaActual;
        }
    }

    public void RemoverEfecto(IPokemon objetivo)
    {
        objetivo.EstaEnvenenado = false;
    }

    public bool EstaActivo(IPokemon objetivo)
    {
        return this.EstaEnvenenado;
    }
}