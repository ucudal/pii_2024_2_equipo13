namespace Library;

public interface IItem
{
    string Nombre { get; }
    string Descripcion { get; }

    void Usar(Jugador jugador, IPokemon _);

}