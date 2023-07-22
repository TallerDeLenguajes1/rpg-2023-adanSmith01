using System.Security.Cryptography;
using System.Globalization;
using RPG;

internal class Program
{
    
    private static void Main(string[] args){

        // Carga de los datos de los personajes del juego
        string rutaJSON = "rpgPersonajes.json";
        List<Personaje> listaPersonajes = new List<Personaje>();
        var fabricaPersonajes = new FabricaDePersonajes();
        var personajesJSON = new PersonajesJSON();


        if(!personajesJSON.ExisteArchivoPersonajes(rutaJSON)) personajesJSON.GuardarPersonajes(fabricaPersonajes.GenerarListaPersonajesRPG(), rutaJSON);
        listaPersonajes = personajesJSON.LeerPersonajes(rutaJSON);

        // Carga de los datos del historial de ganadores
        string rutaHistorialGanadores = "historial.csv";
        Procesos.CargarHistorialGanadores(rutaHistorialGanadores, null);

        // Variables para el ménu principal
        int opc = 0;
        string eleccion = String.Empty;

        //Lista de jugadores
        List<Jugador> listaJugadores = new List<Jugador>();

        do{
            InterfazRPG.MensajesYTituloJuego(1);
            
            Console.WriteLine("\n                              MENÚ PRINCIPAL                                   ");
            Console.WriteLine("\n                            1. Iniciar juego                                   ");
            Console.WriteLine("\n                          2. Opciones del juego                                ");
            Console.WriteLine("\n                                3. Salir                                       ");

            // Verificar que se ingresa la opción correcta
            do{
                Console.Write("\nElija la opcion: ");
                eleccion = Console.ReadLine();
            }while(!int.TryParse(eleccion, out opc) || (opc < 1 || opc > 3));

            // Si opc es 1, se desarrolla el juego
            if(opc == 1){
                Jugador ganadorTorneo = new Jugador();
                listaJugadores = Procesos.CargarJugadores(listaPersonajes);
                ganadorTorneo = Procesos.TorneoLuchadores(listaJugadores);
                InterfazRPG.MensajesYTituloJuego(2);
                Procesos.CargarHistorialGanadores(rutaHistorialGanadores, ganadorTorneo);
            }
            // Si opc es 2, el usuario puede ver el historial de los ganadores y el top 5 de ganadores
            // Si opc es 3, no se ejecuta el juego 
        }while((opc != 3));

        // LIMPIEZA
        listaJugadores.Clear();
        BorrarArchivo(rutaHistorialGanadores);
        BorrarArchivo(rutaJSON);

    }

    public static void BorrarArchivo(string ruta){
        File.Delete(ruta);
    }
    
}