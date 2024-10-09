namespace Library.Pokemons;

public class Arcanine:IPokemon
{
    public string Nombre { get; }
    public double VidaActual { get; }
    public double VidaMax { get; set; }
    public Itipo Tipo { get; }
    public List<IAtaque> GetAtaques()
    {
        throw new NotImplementedException();
    }

    public bool PokemonEnCombate()
    {
        throw new NotImplementedException();
    }
}