namespace Library;

public class AtaqueBasico:IAtaque
{
    public string Nombre { get; } //Getter que devuelve el nombre del ataque, definido en el constructor
    public double Daño { get; }   //Getter que devuelve el daño del ataque, definido en el constructor

    public AtaqueBasico(string nombre, double daño)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        //constructor de ataque basico de un pokemon, donde se establece el nombre y el Daño. Ej:Impactrueno,30.
    }
    
    public double Atacar(IPokemon objetivo)
    {
        //metodo de ataque definido en la Interfaz IPokemon,  donde se tiene como parametro, otro Pokemon
        //de tipo IPokemon llamado objetivo.
        return 0;
    }
}