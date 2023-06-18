namespace RPG;


// Los tipos de personajes que aparecerán en el juego
public enum TipoPersonaje
{
    Sicario,
    Prisionero,
    Ladron,
    Policia,
    AgenteEspecial
}

public class Personaje
{
    private string nombre;
    private string apodo;
    private TipoPersonaje tipo;
    private DateTime fechaNac;
    private int edad;
    private Caracteristicas datosSecundarios = new Caracteristicas();

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public Caracteristicas DatosSecundarios { get => datosSecundarios; set => datosSecundarios = value; }
}