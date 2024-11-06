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
    
}