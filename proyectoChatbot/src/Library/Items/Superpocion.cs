namespace Library.Items;

public class Superpocion : IItem
{
    public string Nombre { get; }
    public string Descripcion { get; }

    public Superpocion()
    {
        this.Nombre = "Super Poción";
        this.Descripcion = "Recupera 70HP";
    }

    public void Usar(Jugador jugador, IPokemon _)
    {
        IPokemon pokemonActivo = jugador.PokemonActivo;
        pokemonActivo.VidaActual += 70;
        if (pokemonActivo.VidaActual > pokemonActivo.VidaMax)
            pokemonActivo.VidaActual = pokemonActivo.VidaMax;
        
        Console.WriteLine($"{pokemonActivo.Nombre} ha recuperado 70 puntos de vida");
    }
}