namespace Library;

public interface IAtaque
{
    public string Nombre { get; }
    public double Daño { get; }
    double Atacar(IPokemon objetivo);
}