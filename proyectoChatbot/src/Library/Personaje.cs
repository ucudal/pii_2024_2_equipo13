namespace Library;

public class Personaje: IPersonaje
{
    public string Nombre { get; }
    private List<IPokemon> Pokemons;

    public Personaje(string nombre)
    {
        this.Nombre = nombre;
    }

    public void ChoosePokemon()
    {
        
    }
}