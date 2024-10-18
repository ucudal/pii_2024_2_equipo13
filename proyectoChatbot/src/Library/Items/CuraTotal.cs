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

    
}