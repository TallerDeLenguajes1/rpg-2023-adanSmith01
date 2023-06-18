namespace RPG;
using System.Text.Json;

public static class PersonajesJSON
{
    public static void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo){
        string listaJSON = JsonSerializer.Serialize(listaPersonajes);

        if(!File.Exists(nombreArchivo)){
            File.WriteAllText(nombreArchivo, listaJSON);
        }
    }

    public static List<Personaje> LeerPersonajes(string nombreArchivo){
        List<Personaje> listaP = new List<Personaje>();

        if(File.Exists(nombreArchivo)){
            string personajesRPG = File.ReadAllText(nombreArchivo);
            listaP = JsonSerializer.Deserialize<List<Personaje>>(personajesRPG);
        }

        return listaP;
    }

    public static bool ExisteArchivoPersonajes(string nombreArchivo){
        FileInfo archivoJson = new FileInfo(nombreArchivo);

        if(File.Exists(nombreArchivo) && archivoJson.Length > 0){
            return true;
        } else{
            return false;
        }
    }
}