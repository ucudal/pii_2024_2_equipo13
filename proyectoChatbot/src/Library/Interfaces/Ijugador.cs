namespace Library;

public interface Ijugador
{
    string Nombre { get; } //Getter que devuelve el nombre del jugador, se usa pra mostrar el nombre de jugador por pantalla
    public void ElegirPokemons()
    {
        //Este metodo, elige los pokemons del usuario, de los pokemons disponibles y los asigna a la lista Pokemons
    }

    public void SeleccionarPokemonInicial()
    {
        //Este metodo, lo que hace es definir, con que Pokemon inicia la batalla el jugador y lo asigna al pokemonActivo.
    }
}