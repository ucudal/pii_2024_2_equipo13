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
    
    public void UsarEn(Pokemon pokemon)
    {
        if (!pokemon.AptoParaBatalla)
        {
            pokemon.VidaActual = pokemon.VidaMax/2;
            pokemon.AptoParaBatalla = true;
            Console.WriteLine($"{pokemon.Nombre} ha sido revivido.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} se encuentra apto para la pelea.");
        }
    }
}