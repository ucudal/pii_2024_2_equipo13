namespace Library.EfectosAtaque;

public class Dormir:IEfectoAtaque
{
    private int turnosDormido;
    public double ProbabilidadEfecto { get; }
    public Dormir(double probabilidad)
    {
        this.turnosDormido = 0;
        this.ProbabilidadEfecto = probabilidad;
    }

    public  void AplicarEfecto(Pokemon objetivo)
    {
        objetivo.EstaDormido = true;
        Random random = new Random();
        turnosDormido=random.Next(1, 5);
        Console.WriteLine($"{objetivo} esta dormido por {turnosDormido} turnos");
    }

    public void ReducirTurno(Pokemon objetivo)
    {
        if (objetivo.EstaDormido)
        {
            turnosDormido--;
            if (turnosDormido==0)
            {
                RemoverEfecto(objetivo);
            }
        }
    }

    public void RemoverEfecto(Pokemon objetivo)
    {
         objetivo.EstaDormido= false;
        Console.WriteLine("El pokemon ha despertado");
    }

    public bool EstaActivo(Pokemon objetivo)
    {
        return objetivo.EstaDormido;
    }
    
}