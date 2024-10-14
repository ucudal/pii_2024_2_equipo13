namespace Library;

public interface IPokemon
{
    string Nombre { get;}//Este getter, devuelve el nombre del Pokemon
    double VidaActual { get;} //Este getter, devuelve la vida actual del pokemon en el combate
    double VidaMax { get;} //Este getter, devuelve la vida máxima del Pokemon
    List<Itipo> Tipos { get; } //Este Getter, devuelve el tipo o tipos del Pokemon.
    
    bool AptoParaBatalla { get; set; }

    List<IAtaque> GetAtaquesBasicos()
    {
        // Devuelva una lista con los ataques básicos que tiene el Pokemon
        return null;
    } 
    List<IAtaque> GetAtaqueEspecial()
    {
        // Devuelva una lista con los ataques Especiales que tiene el Pokemon
        return null;
    } 
    
    void DañoRecibido(double daño)  
    {
        /*Este método, lo que hace es modificar la vida del pokemon, gestionando segun el ataque
         y la efectividad de los tipos, que efecto tiene en la salud del pokemon*/
    }

    void Curar() // Una función que permite curar la salud del pokemon - VidaActual
    {
        //Este método, lo que hace es curar al Pokemón,una cantidad establecida de salud.
    }
    
    
    double AtaqueEspecial(IPokemon objetivo);//Este metodo, se encarga del Ataque Especial de los pokemon

    double AtaqueBasico(IPokemon objetivo); //Este metodo, se encarga de los Ataques Basicos de los Pokemon
    

}