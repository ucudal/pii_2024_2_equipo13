using System.ComponentModel.Design;

namespace Library.Items;

public class Revivir : IItem
{
    public string Nombre { get; }
    public string Descripcion { get; }

    public Revivir()
    {
        this.Nombre = "Revivir";
        this.Descripcion = "Revive a un pokemón con el 50% de vida";
    }

    public void Usar(Jugador jugador, IPokemon _)
    {
        IPokemon pokemonActivo = jugador.PokemonActivo;
        if (!pokemonActivo.AptoParaBatalla)
        {
            pokemonActivo.VidaActual = pokemonActivo.VidaActual * 0.5;
            pokemonActivo.AptoParaBatalla = true;
            Console.WriteLine($"El Pokemón {pokemonActivo.Nombre} ha sido revivido, y tiene el 50% de vida");
        }
        else
        {
            Console.WriteLine($"El Pokemón {pokemonActivo.Nombre} ya está apto para la batalla");
        }
        
    }
}