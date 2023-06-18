using RPG;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "rpgPersonajes.json";

        if(!PersonajesJSON.ExisteArchivoPersonajes(path)){
            PersonajesJSON.GuardarPersonajes(FabricaDePersonajes.GenerarListaPersonajesRPG(), path);
            List<Personaje> listaPersonajes = PersonajesJSON.LeerPersonajes(path);
        } else{
            List<Personaje> listaPersonajes = PersonajesJSON.LeerPersonajes(path);
        }
        
    }
}