namespace Library;

public interface IPokemon
{
<<<<<<< HEAD
    string Nombre { get;}//Este getter, devuelve el nombre del Pokemon
    double VidaActual { get;} //Este getter, devuelve la vida actual del pokemon en el combate
    double VidaMax { get;} //Este getter, devuelve la vida máxima del Pokemon
    Itipo Tipo { get; } //Este Getter, devuelve el tipo del Pokemon.

    List<IAtaque> GetAtaques()
=======
    string Nombre { get; } // Obtiene el nombre del pokemon
    double VidaActual { get; } // Obtiene su vida actual
    double VidaMax { get; set; } // Establece y obtiene la vida con el que empieza el juego el pokemon
    Itipo Tipo { get; } // Obtiene el tipo de pokemon (tierra, fuego, planta, etc)

    List<IAtaque> GetAtaques(); // Genera una lista de los posibles ataques que tiene el pokemón

    void DañoRecibido(double daño)  //cada pokemon, gestiona su propio impacto del daño, con la devolucion del metodo ataque , se elimino Idefensa
>>>>>>> e0635a8ff7d095d38c622645a48004fa68080ab6
    {
        //Esta funcion, lo que hace es devolver una lista, con los ataques que tiene el pokemon
        return null;
    }

    void DañoRecibido(double daño)  
    {
        /*Este método, lo que hace es modificar la vida del pokemon, gestionando segun el ataque
         y la efectividad de los tipos, que efecto tiene en la salud del pokemon*/
    }

    void Curar() // Una función que permite curar la salud del pokemon - VidaActual
    {
        //Este método, lo que hace es curar al Pokemón,una cantidad establecida de salud.
    }

<<<<<<< HEAD
    bool PokemonEnCombate()
    {
        //Este método, determina si el Pokemon, esta apto para poder ser seleccionado, para disputar la batalla o no.
        return bool;
    }
=======
    bool PokemonEnCombate(); // Información si el pokemón está disponible para el combate (si está vivo)
>>>>>>> e0635a8ff7d095d38c622645a48004fa68080ab6
}