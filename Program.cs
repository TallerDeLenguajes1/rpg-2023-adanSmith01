using RPG;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "rpgPersonajes.json";
        List<Personaje> listaPersonajes = new List<Personaje>();

        if(!PersonajesJSON.ExisteArchivoPersonajes(path)){
            PersonajesJSON.GuardarPersonajes(FabricaDePersonajes.GenerarListaPersonajesRPG(), path);
            listaPersonajes = PersonajesJSON.LeerPersonajes(path);
        } else{
            listaPersonajes = PersonajesJSON.LeerPersonajes(path);
        }

        // Se muestran los datos y características de los personajes
        mostrarPersonajes(listaPersonajes);
        
    }

    public static void mostrarPersonajes(List<Personaje> personajes){
        foreach (var p in personajes){
            Console.WriteLine($"┌ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ PERSONAJE: {p.Nombre.ToUpper()} ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ┐");
            Console.WriteLine($"| ===========DATOS===========");
            Console.WriteLine($"| NOMBRE: {p.Nombre}");
            Console.WriteLine($"| APODO: {p.Apodo}");
            Console.WriteLine($"| TIPO DE PERSONAJE: {p.Tipo.ToString()}");
            Console.WriteLine($"| FECHA DE NACIMIENTO: {p.FechaNac.ToShortDateString()}");
            Console.WriteLine($"| EDAD: {p.Edad}");
            Console.WriteLine($"| ===========CARACTERÍSTICAS===========");
            Console.WriteLine($"| VELOCIDAD: {p.DatosSecundarios.Velocidad}");
            Console.WriteLine($"| DESTREZA: {p.DatosSecundarios.Destreza}");
            Console.WriteLine($"| FUERZA: {p.DatosSecundarios.Fuerza}");
            Console.WriteLine($"| NIVEL: {p.DatosSecundarios.Nivel}");
            Console.WriteLine($"| ARMADURA: {p.DatosSecundarios.Armadura}");
            Console.WriteLine($"| SALUD: {p.DatosSecundarios.Salud}");
        }
    }
}