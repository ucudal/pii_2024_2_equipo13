using Library;
using Library.TiposPokemon;

public class Lucha : Itipo
{
    public string Nombre { get; }

    public Lucha()
    {
        this.Nombre = "Lucha";
    }

    public bool FuerteContra(Itipo otroTipo)
    {
        return otroTipo is Normal;
    }

    public bool DebilContra(Itipo otroTipo)
    {
        return otroTipo is Volador || otroTipo is Psiquico || otroTipo is Hada;
    }
}