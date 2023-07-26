using System.Security.Cryptography;
using System.Globalization;
using RPG;

internal class Program
{
    private static void Main(string[] args){

        string rutaJSON = "rpgPersonajes.json";
        List<Personaje> listaPersonajes = new List<Personaje>();
        var fabricaPersonajes = new FabricaDePersonajes();
        var personajesJSON = new PersonajesJSON();

        if(!personajesJSON.ExisteArchivoPersonajes(rutaJSON)) personajesJSON.GuardarPersonajes(fabricaPersonajes.GenerarListaPersonajesRPG(), rutaJSON);
        
        string rutaHistorialGanadores = "historial.csv";
        Procesos.PrecargarHistorialGanadores(rutaHistorialGanadores);
        const int TOP_MEJORES_JUGADORES = 5;
        
        int opc = 0;
        string eleccion = String.Empty;

        
        List<Jugador> listaJugadores = new List<Jugador>();

        InterfazRPG.MensajeCargando();
        InterfazRPG.ContextoJuego();
        do{
            InterfazRPG.TituloJuego();

            Console.WriteLine("\n                              MENÚ PRINCIPAL                                   ");
            Console.WriteLine("\n                            1. Iniciar juego                                   ");
            Console.WriteLine($"\n                    2. Ver top {TOP_MEJORES_JUGADORES} de mejores jugadores                               ");
            Console.WriteLine("\n                                3. Salir                                       ");

            
            do{
                Console.Write("\nElija la opcion: ");
                eleccion = Console.ReadLine();
            }while(!int.TryParse(eleccion, out opc) || (opc < 1 || opc > 3));

            if(opc != 3){
                if(opc == 1) EjecutarJuego(listaPersonajes, listaJugadores, personajesJSON, rutaHistorialGanadores, rutaJSON);
                if(opc == 2) InterfazRPG.MostrarTopMejoresJugadores(TOP_MEJORES_JUGADORES, rutaHistorialGanadores);
                InterfazRPG.MensajeCargando();
            }
            
        }while((opc != 3));
    }

    public static void EjecutarJuego(List<Personaje> listaPersonajes, List<Jugador> listaJugadores, PersonajesJSON cargaPersonajes, string rutaHistorialGanadores, string rutaJSON){
        Jugador ganadorTorneo = new Jugador();
        listaPersonajes = cargaPersonajes.LeerPersonajes(rutaJSON);
        InterfazRPG.MostrarPersonajesJuego(listaPersonajes);
        listaJugadores = Procesos.CargarJugadores(listaPersonajes);
        InterfazRPG.MostrarJugadores(listaJugadores);
        ganadorTorneo = Procesos.TorneoLuchadores(listaJugadores);
        InterfazRPG.MensajeGanadorTorneo(ganadorTorneo);
        Procesos.GuardarGanadorAHistorial(rutaHistorialGanadores, ganadorTorneo);
        listaJugadores.Clear();
    }
}