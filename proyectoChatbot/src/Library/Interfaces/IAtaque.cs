namespace Library;

public interface IAtaque
{
    //Interfaz, que se implementa para los ataques
    public string Nombre { get; } //getter del  nombre del ataque
    public double Daño { get; } //getter del daño del ataque
    
    public Itipo Tipo { get; }
    public double Precision { get; }
    
}