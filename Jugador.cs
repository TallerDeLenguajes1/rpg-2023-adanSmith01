namespace RPG;

public class Jugador
{
    public string NombreJugador;
    public Personaje Luchador;
    private float puntaje;

    public float Puntaje {get => puntaje; }

    public void CalcularPuntaje(){
        puntaje += 100 + new Random().Next(1, 100);
    }
}