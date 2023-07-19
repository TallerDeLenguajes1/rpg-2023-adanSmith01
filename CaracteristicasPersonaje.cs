namespace RPG;

public class CaracteristicasPersonaje
{
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int blindaje;
    private float salud;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Blindaje { get => blindaje; set => blindaje = value; }
    public float Salud { get => salud; set => salud = value; }
}