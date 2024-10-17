namespace Library.Items;

public class CuraTotal : IItem
{
    public string Nombre { get; }
    public string Descripcion { get; }

    public CuraTotal()
    {
        this.Nombre = "Cura Total";
        this.Descripcion = "Cura toda la salud de tu Pokemón";
    }

    public void Usar(Jugador jugador, IPokemon _)
    {
        IPokemon pokemonActivo = jugador.PokemonActivo;
        pokemonActivo.VidaActual = pokemonActivo.VidaMax;
        Console.WriteLine($"La salud del Pokemón {pokemonActivo.Nombre} ha sido restaurada al máximo ");
    }
}