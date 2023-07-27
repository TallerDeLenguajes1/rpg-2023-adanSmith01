using System.Security.Cryptography;
using System.Globalization;
using RPG;

internal class Program
{
    const int MAX_CANT_JUGADORES = 10;
    const int TOP_MEJORES_JUGADORES = 5;

    private static void Main(string[] args){

        // Rutas de archivos importantes del juego
        string rutaJSON = "rpgPersonajes.json";
        string rutaHistorialGanadores = "historial.csv";

        List<Personaje> listaPersonajes = new List<Personaje>();
        var fabricaPersonajes = new FabricaDePersonajes();
        var personajesJSON = new PersonajesJSON();
        int opc = 0;
        string eleccion = String.Empty;
        List<Jugador> listaJugadores = new List<Jugador>();

        if(!personajesJSON.ExisteArchivoPersonajes(rutaJSON)) personajesJSON.GuardarPersonajes(fabricaPersonajes.GenerarListaPersonajesRPG(), rutaJSON);
        
        HistorialGanadores.PrecargarHistorialGanadores(rutaHistorialGanadores);
        InterfazJuego.MensajeCargando();
        InterfazJuego.ContextoJuego();

        do{
            InterfazJuego.TituloDelJuego();

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
                if(opc == 2) InterfazJuego.MostrarTopMejoresJugadores(TOP_MEJORES_JUGADORES, rutaHistorialGanadores);

                InterfazJuego.MensajeCargando();
            }
            
        }while((opc != 3));
    }

    public static List<Jugador> CargarJugadores(List<Personaje> listaP){
        List<Jugador> listaJugadores = new List<Jugador>();
        int cant;
        string aux = String.Empty, nombreJugador = String.Empty;

        // Se controla que la cantidad de jugadores sea correcta
        do{
            Console.Write("Número de jugadores (máximo 10): ");
            aux = Console.ReadLine();
            
            if(!int.TryParse(aux, out cant)){
                Console.WriteLine("\nERROR. Dato inválido.\n");
            } else{
                if(cant < 1 || cant > MAX_CANT_JUGADORES){
                    Console.WriteLine("\nERROR. Número inválido de jugadores.\n");
                }
            }
        }while(!int.TryParse(aux, out cant) || (cant < 1 || cant > MAX_CANT_JUGADORES));

        Console.WriteLine("\nACLARACIÓN: Los nombres de los jugadores deben ser solo de 3 caracteres\n");
        for(int i = 0; i < MAX_CANT_JUGADORES; i++){
            Jugador J = new Jugador();
            if(i < cant){
                
                do{
                    Console.Write($"> NOMBRE DEL JUGADOR {i + 1}: ");
                    nombreJugador = Console.ReadLine();
                }while(nombreJugador.Length != 3);
            } else{
                nombreJugador = $"JUG_{i + 1}";
            }
            J.NombreJugador = nombreJugador.ToUpper();
            J.Luchador = listaP[i];
            listaJugadores.Add(J);
        }
        
        return listaJugadores;
    }
    public static void EjecutarJuego(List<Personaje> listaPersonajes, List<Jugador> listaJugadores, PersonajesJSON cargaPersonajes, string rutaHistorialGanadores, string rutaJSON){
        Jugador ganadorTorneo = new Jugador();
        listaPersonajes = cargaPersonajes.LeerPersonajes(rutaJSON);
        InterfazJuego.MostrarPersonajesDelJuego(listaPersonajes);
        listaJugadores = CargarJugadores(listaPersonajes);
        InterfazJuego.MostrarJugadores(listaJugadores);
        ganadorTorneo = DesarrolloJuego.ObtenerGanadorDelTorneo(listaJugadores);
        InterfazJuego.MensajeGanadorTorneo(ganadorTorneo);
        HistorialGanadores.GuardarGanadorAHistorial(rutaHistorialGanadores, ganadorTorneo);
        listaJugadores.Clear();
    }
}