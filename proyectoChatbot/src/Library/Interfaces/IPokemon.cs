namespace Library;

public interface IPokemon
{
    string Nombre { get;}//Este getter, devuelve el nombre del Pokemon
    double VidaActual { get; set; } //Este getter, devuelve la vida actual del pokemon en el combate
    double VidaMax { get;} //Este getter, devuelve la vida máxima del Pokemon
    Itipo Tipo { get; } //Este Getter, devuelve el tipo o tipos del Pokemon.
    public bool EstaDormido { get; set; }
    public bool EstaParalizado { get;  set; }
    public bool EstaEnvenenado { get; set; }
    public bool EstaQuemado { get;set; }
    public bool EstaAfectadoPorEfecto();
    bool AptoParaBatalla { get; set; }

     void GetAtaquesBasicos()
    {
        // Devuelva una lista con los ataques básicos que tiene el Pokemon
    } 
    void GetAtaqueEspecial()
    {
        // Devuelva una lista con los ataques Especiales que tiene el Pokemon
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
    
    
    double AtaqueEspecial(IPokemon objetivo,int AtaqueElegido);//Este metodo, se encarga del Ataque Especial de los pokemon

    double AtaqueBasico(IPokemon objetivo,int AtaqueElegido); //Este metodo, se encarga de los Ataques Basicos de los Pokemon

    bool PuedeAtacarParalizado();

    bool PuedeAtacarDormido();

    void AplicarDañoVeneno();

    void AplicarDañoQuemadura();




}