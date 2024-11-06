namespace Library;

public class AtaqueBasico:IAtaque
{
    public string Nombre { get; } //Getter que devuelve el nombre del ataque, definido en el constructor
    public double Daño { get; }   //Getter que devuelve el daño del ataque, definido en el constructor
    public double Precision { get; }
    
    public Itipo Tipo { get; } //devuelve el tipo del ataque

    public AtaqueBasico(string nombre, double daño,Itipo tipo,double precision)
    {
        //Constructor del ataque basico de un pokemon, donde se establece el nombre, el daño, el tipo y la precision. 
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.Precision = precision;
    }
}