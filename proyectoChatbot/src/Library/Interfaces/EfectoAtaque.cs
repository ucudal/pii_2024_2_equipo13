namespace Library;

public interface IEfectoAtaque
{
    double ProbabilidadEfecto { get; }
    
    bool EstaActivo(IPokemon objetivo);
    void AplicarEfecto(IPokemon objetivo);
    
    void RemoverEfecto(IPokemon objetivo);
    
    //metodo, para aplicar el efecto del ataque especial  en el ataque
}