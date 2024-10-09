namespace Library;

public interface IPokemon
{
    string Nombre { get;}//Este getter, devuelve el nombre del Pokemon
    double VidaActual { get;} //Este getter, devuelve la vida actual del pokemon en el combate
    double VidaMax { get;} //Este getter, devuelve la vida máxima del Pokemon
    Itipo Tipo { get; } //Este Getter, devuelve el tipo del Pokemon.

    List<IAtaque> GetAtaques()
    {
        //Esta funcion, lo que hace es devolver una lista, con los ataques que tiene el pokemon
        return null;
    }

    void DañoRecibido(double daño)  
    {
        /*Este método, lo que hace es modificar la vida del pokemon, gestionando segun el ataque
         y la efectividad de los tipos, que efecto tiene en la salud del pokemon*/
    }

    void Curar()
    {
        //Este método, lo que hace es curar al Pokemón,una cantidad establecida de salud.
    }

    bool PokemonEnCombate()
    {
        //Este método, determina si el Pokemon, esta apto para poder ser seleccionado, para disputar la batalla o no.
        return bool;
    }
}