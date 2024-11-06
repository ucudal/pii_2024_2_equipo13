using Library;
using Library.Clases;
using Library.Pokemons;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Jugador serio = new Jugador("serio");
        Jugador cima = new Jugador("cima");
        Pokemon Alakazam = new Alakazam();
        Pokemon arbok = new Arbok();
        serio.Pokemons.Add(Alakazam);
        cima.Pokemons.Add(arbok);
        serio.Atacar(cima);
    }
}
