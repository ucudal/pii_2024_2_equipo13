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

    public void UsarEn(Pokemon pokemon)
    {
        pokemon.VidaActual = Math.Min(pokemon.VidaActual + 70, pokemon.VidaMax);
    }
}