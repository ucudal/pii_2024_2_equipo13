namespace Library;

public interface IEfectoAtaque
{
    double ProbabilidadEfecto { get; }
    
    bool EstaActivo(Pokemon objetivo);
    void AplicarEfecto(Pokemon objetivo);
    
    void RemoverEfecto(Pokemon objetivo);
    
    //metodo, para aplicar el efecto del ataque especial  en el ataque
}