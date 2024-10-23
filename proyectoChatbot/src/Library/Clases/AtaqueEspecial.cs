namespace Library;

public class AtaqueEspecial:IAtaque
{
    public string Nombre { get; } //Getter que devuelve el nombre del ataque, definido en el constructor
    public double Daño { get; } //Getter que devuelve el daño del ataque, definido en el constructor

    public Itipo Tipo { get; } //devuelve el tipo del ataque
    public IEfectoAtaque Efecto { get; }
    public double Precision { get; }

    public AtaqueEspecial(string nombre, double daño,Itipo tipo,double precision,IEfectoAtaque efecto)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.Precision = precision;
        this.Efecto = efecto;
        //constructor de ataque especial de un pokemon, donde se establece el nombre y el Daño. Ej:Impactrueno,30
    }
    
}