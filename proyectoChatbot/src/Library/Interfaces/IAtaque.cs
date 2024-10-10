namespace Library;

public interface IAtaque
{
    //Interfaz, que se implementa para los ataques
    public string Nombre { get; } //getter del  nombre del ataque
    public double Daño { get; } //getter del daño del ataque

    double Atacar(IPokemon objetivo)
    {
        //este metodo, se implementa en la clase AtaqueBasico y AtaqueBasico, y se usa para los ataques de los Pokemon
        return 0;
    }
}