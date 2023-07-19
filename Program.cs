using System.Security.Cryptography;
using System.Globalization;
using RPG;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "rpgPersonajes.json";
        List<Personaje> listaPersonajes = new List<Personaje>();
        var fabricaPersonajes = new FabricaDePersonajes();
        var personajesJSON = new PersonajesJSON();

        // Se consulta primero si el archivo con los datos de los personajes existe o no
        if(!personajesJSON.ExisteArchivoPersonajes(path)){
            personajesJSON.GuardarPersonajes(fabricaPersonajes.GenerarListaPersonajesRPG(), path);
            listaPersonajes = personajesJSON.LeerPersonajes(path);
        } else{
            listaPersonajes = personajesJSON.LeerPersonajes(path);
        }

        // Se muestran los datos y características de los personajes
        //MostrarPersonajes(listaPersonajes);

        // Proceso del juego
        ProcesoJuego(listaPersonajes);
        
    }

    // Método para mostrar los datos y caracteristicas de los personajes del juego
    public static void MostrarPersonajes(List<Personaje> personajes){
        foreach (var p in personajes){
            Console.WriteLine($"┌ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ PERSONAJE: {p.Nombre.ToUpper()} ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ┐");
            Console.WriteLine($"| ===========DATOS===========");
            Console.WriteLine($"| NOMBRE: {p.Nombre}");
            Console.WriteLine($"| APODO: {p.Apodo}");
            Console.WriteLine($"| TIPO DE PERSONAJE: {p.Tipo}");
            Console.WriteLine($"| FECHA DE NACIMIENTO: {p.FechaNac.ToShortDateString()}");
            Console.WriteLine($"| NACIONALIDAD: {p.Nacionalidad}");
            Console.WriteLine($"| EDAD: {p.Edad}");
            Console.WriteLine($"| ===========CARACTERÍSTICAS===========");
            Console.WriteLine($"| VELOCIDAD: {p.Caracteristicas.Velocidad}");
            Console.WriteLine($"| DESTREZA: {p.Caracteristicas.Destreza}");
            Console.WriteLine($"| FUERZA: {p.Caracteristicas.Fuerza}");
            Console.WriteLine($"| NIVEL: {p.Caracteristicas.Nivel}");
            Console.WriteLine($"| BLINDAJE: {p.Caracteristicas.Blindaje}");
            Console.WriteLine($"| SALUD: {p.Caracteristicas.Salud}");
        }
    }

    const int AJUSTE = 500;

    public static void Combate(Personaje P1, Personaje P2, int efectP1, int efectP2){
        int ataqueP1 = 0, defensaP1 = 0;
        int ataqueP2 = 0, defensaP2 = 0;
        float danioP1 = 0f, danioP2 = 0f;
        bool turnoP1 = true;

        ataqueP1 = P1.Caracteristicas.Fuerza * P1.Caracteristicas.Destreza * P1.Caracteristicas.Nivel;
        defensaP1 = P1.Caracteristicas.Velocidad * P1.Caracteristicas.Blindaje;

        ataqueP2 = P2.Caracteristicas.Fuerza * P2.Caracteristicas.Destreza * P2.Caracteristicas.Nivel;
        defensaP2 = P2.Caracteristicas.Velocidad * P2.Caracteristicas.Blindaje;

        Console.WriteLine($"\n========{P1.Nombre.ToUpper()}, {P1.Apodo.ToUpper()} VS  {P2.Nombre.ToUpper()}, {P2.Apodo.ToUpper()}========\n");
        Console.WriteLine($"Ataque: {ataqueP1}\t\t\t\t\t Ataque: {ataqueP2}");
        Console.WriteLine($"Defensa: {defensaP1}\t\t\t\t\t Defensa: {defensaP2}");
        Console.WriteLine($"Efectividad: {efectP1}\t\t\t\t\t Efectividad: {efectP2}");
        Console.WriteLine($"Salud: {P1.Caracteristicas.Salud.ToString("0.0")}% \t\t\t\t\t Salud: {P2.Caracteristicas.Salud.ToString("0.0")}% ");

        Console.WriteLine("\nPresione ENTER para continuar");
        Console.ReadKey();

        int cursorL = Console.CursorLeft;
        int cursorT = Console.CursorTop;

        while((P1.Caracteristicas.Salud > 0) && (P2.Caracteristicas.Salud > 0)){
            if(turnoP1){
                danioP2 = (float)((ataqueP1 * efectP1) - defensaP2) / AJUSTE;
                P2.Caracteristicas.Salud -= Math.Abs(danioP2);
                turnoP1 = false;
            } else{
                danioP1 = (float)((ataqueP2 * efectP2) - defensaP1) / AJUSTE;
                P1.Caracteristicas.Salud -= Math.Abs(danioP1);
                turnoP1 = true;
            }

            Console.SetCursorPosition(cursorL, cursorT);
            if((P1.Caracteristicas.Salud > 0) && (P2.Caracteristicas.Salud > 0)) Console.Write($"Salud: {P1.Caracteristicas.Salud.ToString("0.0")}%  Salud: {P2.Caracteristicas.Salud.ToString("0.0")}% ");
            Thread.Sleep(300);
        }
    }

    public static Personaje EleccionPersonaje(List<Personaje> peleadores){
        int ind = new Random().Next(0, 10);
        return peleadores[ind];
    }

    public static Personaje DecidirGanador(Personaje P1, Personaje P2){
        string[] paisesLatinos = {"Venezuela", "México", "Argentina", "Uruguay", "Paraguay", "Colombia", "Perú", "Bolivia", "Chile", "Ecuador", "Brasil", 
        "República Dominicana", "Cuba", "El Salvador", "Belice", "Honduras", "Guatemala", "Nicaragua", "Costa Rica", "Puerto Rico", "Panamá"};
        Personaje ganadorPelea = new Personaje();

        if((P1.Caracteristicas.Salud > P2.Caracteristicas.Salud)){
            ganadorPelea = P1;
        } else{
            ganadorPelea = P2;
        }

        // Criterio del bonus del ganador a partir de su nacionalidad
        if(paisesLatinos.Contains(ganadorPelea.Nacionalidad)){
            ganadorPelea.Caracteristicas.Fuerza += 1;
            ganadorPelea.Caracteristicas.Blindaje += 1;
        } else{
            ganadorPelea.Caracteristicas.Destreza += 1;
            ganadorPelea.Caracteristicas.Velocidad += 1;
        }

        if(ganadorPelea.Caracteristicas.Salud < 90) ganadorPelea.Caracteristicas.Salud += 2;
        return ganadorPelea;
    }
    /*public static void Mensajes(Personaje P1, Personaje P2, int idMensaje){

    }*/

    public static void ProcesoJuego(List<Personaje> listaP){
        Personaje P1 = new Personaje();
        Personaje P2 = new Personaje();
        Personaje ganadorPelea = new Personaje();
        int efectividadP1 = 0, efectividadP2 = 0;
        bool torneoFinalizado = false, primeraPelea = true;
        List<int> aux = new List<int>();
        int ind1 = 0, ind2 = 0;

        while(!torneoFinalizado){

            // Se eligen los personajes de la primera pelea
            if(primeraPelea){
                ind1 = new Random().Next(0, 10);
                P1 = listaP[ind1];
                do{
                    ind2 = new Random().Next(0, 10);
                    P2 = listaP[ind2];
                }while(P1.Nombre == P2.Nombre);
                aux.Add(ind1);
                aux.Add(ind2);

                // Puede ser posible que los personajes tengan la misma efectividad
                efectividadP1 = new Random().Next(1, 101);
                primeraPelea = false;
            } else{
                P1 = ganadorPelea;
                if(ganadorPelea == P2){
                    efectividadP1 = efectividadP2;
                }
                do{
                    ind2 = new Random().Next(0, 10);
                }while(aux.Contains(ind2));
                P2 = listaP[ind2];
                aux.Add(ind2);
            }
            efectividadP2 = new Random().Next(1, 101);
            
            Combate(P1, P2, efectividadP1, efectividadP2);
            ganadorPelea = DecidirGanador(P1, P2);
            Console.WriteLine("//////// PELEA FINALIZADA ////////");

            if(aux.Count == 10) torneoFinalizado = true;

        }
       
    }
    
}