namespace Library;

public class AtaqueEspecial:IAtaque
{
    public string Nombre { get; }
    public double Daño { get; }

    public AtaqueEspecial(string nombre, double daño)
    {
        this.Nombre = nombre;
        this.Daño = daño;
    }

    public double Atacar(IPokemon objetivo)
    {
        
    }
}