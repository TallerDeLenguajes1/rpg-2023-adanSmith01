namespace RPG;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// Los tipos de personajes que aparecerán en el juego
public enum TipoPersonaje
{
    [EnumMember(Value = "Sicario")]
    Sicario,

    [EnumMember(Value = "Psicopata")]
    Psicopata,

    [EnumMember(Value = "Ladron")]
    Ladron,

    [EnumMember(Value = "Mafioso")]
    Mafioso,

    [EnumMember(Value = "Terrorista")]
    Terrorista
}

public class Personaje
{
    private string nombre;
    private string apodo;
    private TipoPersonaje tipo;
    private DateTime fechaNac;
    private string paisOrigen;
    private int edad;
    private CaracteristicasPersonaje caracteristicas;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public string PaisOrigen { get => paisOrigen; set => paisOrigen = value;}
    public CaracteristicasPersonaje Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

}