namespace Library;

public class AtaqueBasico:IAtaque
{
    public string Nombre { get; }
    public double Daño { get; }

    public AtaqueBasico(string nombre, double daño)
    {
        this.Nombre = nombre;
        this.Daño = daño;
    }
    
    public double Atacar(IPokemon objetivo)
    {
        
    }
}