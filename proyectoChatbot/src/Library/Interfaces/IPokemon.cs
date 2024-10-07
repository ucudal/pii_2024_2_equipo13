namespace Library;

public interface IPokemon
{
    string Nombre { get; }
    double VidaActual { get; }
    double VidaMax { get; set; }
    TipoPokemon Tipo { get; }

    List<IAtaque> GetAtaques();

    void DañoRecibido(double daño)  //cada pokemon, gestiona su propio impacto del daño, con la devolucion del metodo ataque , se elimino Idefensa
    {
        
    }

    void CurarPokemon(double curacion)
    {
        
    }

    bool PokemonEnCombate();
}