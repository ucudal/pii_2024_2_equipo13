namespace Library;

public interface IPokemon
{
    string Nombre { get; } // Obtiene el nombre del pokemon
    double VidaActual { get; } // Obtiene su vida actual
    double VidaMax { get; set; } // Establece y obtiene la vida con el que empieza el juego el pokemon
    Itipo Tipo { get; } // Obtiene el tipo de pokemon (tierra, fuego, planta, etc)

    List<IAtaque> GetAtaques(); // Genera una lista de los posibles ataques que tiene el pokemón

    void DañoRecibido(double daño)  //cada pokemon, gestiona su propio impacto del daño, con la devolucion del metodo ataque , se elimino Idefensa
    {
        
    }

    void Curar() // Una función que permite curar la salud del pokemon - VidaActual
    {
        
    }

    bool PokemonEnCombate(); // Información si el pokemón está disponible para el combate (si está vivo)
}