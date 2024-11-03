namespace Library.TiposPokemon;

public class Siniestro:Itipo
{
    public string Nombre { get; }

    public Siniestro()
    {
        this.Nombre = "Siniestro";
    }

    public bool InmuneContra(Itipo otroTipo)
    {
        return false;
    }

    public bool ResistenteContra(Itipo otroTipo)
    {
        return otroTipo is Fantasma || otroTipo is Psiquico || otroTipo is Siniestro;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Bicho || otroTipo is Hada || otroTipo is Lucha;
    }
}