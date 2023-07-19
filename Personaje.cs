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

    [EnumMember(Value = "Policia")]
    Policia,

    [EnumMember(Value = "AgenteEspecial")]
    AgenteEspecial
}

public class Personaje
{
    private string nombre;
    private string apodo;
    private TipoPersonaje tipo;
    private DateTime fechaNac;
    private string nacionalidad;
    private int edad;
    private CaracteristicasPersonaje caracteristicas;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = value;}
    public CaracteristicasPersonaje Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

}