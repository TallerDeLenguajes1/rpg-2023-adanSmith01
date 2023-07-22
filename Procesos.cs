namespace RPG;

public static class Procesos
{
    // CONSTANTES
    const int AJUSTE = 500;
    const int MAX_JUGADORES = 10;

    private static void Combate(Jugador P1, Jugador P2, int efectPersonajeP1, int efectPersonajeP2){
        int ataqueP1 = 0, defensaP1 = 0;
        int ataqueP2 = 0, defensaP2 = 0;
        float danioP1 = 0f, danioP2 = 0f;
        bool turnoP1 = true;

        ataqueP1 = P1.Luchador.Caracteristicas.Fuerza * P1.Luchador.Caracteristicas.Destreza * P1.Luchador.Caracteristicas.Nivel;
        defensaP1 = P1.Luchador.Caracteristicas.Velocidad * P1.Luchador.Caracteristicas.Blindaje;

        ataqueP2 = P2.Luchador.Caracteristicas.Fuerza * P2.Luchador.Caracteristicas.Destreza * P2.Luchador.Caracteristicas.Nivel;
        defensaP2 = P2.Luchador.Caracteristicas.Velocidad * P2.Luchador.Caracteristicas.Blindaje;

        Console.WriteLine($"\n========{P1.NombreJugador.ToUpper()} VS  {P2.NombreJugador.ToUpper()}========\n");
        Console.WriteLine($"{P1.Luchador.Nombre.ToUpper()}, {P1.Luchador.Apodo.ToUpper()}\t\t\t\t\t{P2.Luchador.Nombre.ToUpper()}, {P2.Luchador.Apodo.ToUpper()}");
        Console.WriteLine($"Ataque: {ataqueP1}\t\t\t\t\t Ataque: {ataqueP2}");
        Console.WriteLine($"Defensa: {defensaP1}\t\t\t\t\t Defensa: {defensaP2}");
        Console.WriteLine($"Efectividad: {efectPersonajeP1}\t\t\t\t\t Efectividad: {efectPersonajeP2}");
        Console.WriteLine($"Salud: {P1.Luchador.Caracteristicas.Salud.ToString("0.0")}% \t\t\t\t\t Salud: {P2.Luchador.Caracteristicas.Salud.ToString("0.0")}% ");

        Console.WriteLine("\nPresione ENTER para continuar");
        Console.ReadKey();

        int cursorL = Console.CursorLeft;
        int cursorT = Console.CursorTop;

        while((P1.Luchador.Caracteristicas.Salud > 0) && (P2.Luchador.Caracteristicas.Salud > 0)){
            if(turnoP1){
                danioP2 = (float)((ataqueP1 * efectPersonajeP1) - defensaP2) / AJUSTE;
                P2.Luchador.Caracteristicas.Salud -= Math.Abs(danioP2);
                turnoP1 = false;
            } else{
                danioP1 = (float)((ataqueP2 * efectPersonajeP2) - defensaP1) / AJUSTE;
                P1.Luchador.Caracteristicas.Salud -= Math.Abs(danioP1);
                turnoP1 = true;
            }

            Console.SetCursorPosition(cursorL, cursorT);
            if((P1.Luchador.Caracteristicas.Salud > 0) && (P2.Luchador.Caracteristicas.Salud > 0)) Console.Write($"Salud: {P1.Luchador.Caracteristicas.Salud.ToString("0.0")}%  Salud: {P2.Luchador.Caracteristicas.Salud.ToString("0.0")}% ");
            Thread.Sleep(300);
        }
    }

    // Método que carga el nombre y personaje de lucha de los jugadores
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
                if(cant < 1 || cant > MAX_JUGADORES){
                    Console.WriteLine("\nERROR. Número inválido de jugadores.\n");
                }
            }
        }while(!int.TryParse(aux, out cant) || (cant < 1 || cant > MAX_JUGADORES));


        for(int i = 0; i < MAX_JUGADORES; i++){
            Jugador J = new Jugador();
            if(i < cant){
                do{
                    Console.Write($"> NOMBRE DEL JUGADOR {i + 1}: ");
                    nombreJugador = Console.ReadLine();
                }while(nombreJugador.Length != 3);
            } else{
                nombreJugador = $"JUG{i + 1}";
            }
            J.NombreJugador = nombreJugador.ToUpper();
            J.Luchador = listaP[i];
            listaJugadores.Add(J);
        }

        return listaJugadores;
    }

    public static Jugador DecidirGanadorDelCombate(Jugador P1, Jugador P2){
        string[] paisesLatinos = {"Venezuela", "México", "Argentina", "Uruguay", "Paraguay", "Colombia", "Perú", "Bolivia", "Chile", "Ecuador", "Brasil", 
        "República Dominicana", "Cuba", "El Salvador", "Belice", "Honduras", "Guatemala", "Nicaragua", "Costa Rica", "Puerto Rico", "Panamá"};
        Jugador ganadorPelea = new Jugador();

        if((P1.Luchador.Caracteristicas.Salud > P2.Luchador.Caracteristicas.Salud)){
            ganadorPelea = P1;
        } else{
            ganadorPelea = P2;
        }

        // Criterio del bonus del ganador a partir de su nacionalidad
        if(paisesLatinos.Contains(ganadorPelea.Luchador.PaisOrigen)){
            ganadorPelea.Luchador.Caracteristicas.Fuerza += 1;
        } else{
            ganadorPelea.Luchador.Caracteristicas.Velocidad += 1;
        }

        if(ganadorPelea.Luchador.Caracteristicas.Salud < 90) ganadorPelea.Luchador.Caracteristicas.Salud += 2;

        ganadorPelea.CalcularPuntaje();
        return ganadorPelea;
    }

    public static Jugador TorneoLuchadores(List<Jugador> listaJ){
        Jugador P1 = new Jugador();
        Jugador P2 = new Jugador();
        Jugador ganadorPelea = new Jugador();
        int efectPersonajeP1 = 0, efectPersonajeP2 = 0;
        bool torneoFinalizado = false, primerCombate = true;
        List<int> aux = new List<int>();
        int ind1 = 0, ind2 = 0;

        while(!torneoFinalizado){

            // Se eligen a los jugadores del primer combate
            if(primerCombate){
                ind1 = new Random().Next(0, 10);
                P1 = listaJ[ind1];
                do{
                    ind2 = new Random().Next(0, 10);
                    P2 = listaJ[ind2];
                }while(P1.Luchador.Nombre == P2.Luchador.Nombre);
                aux.Add(ind1);
                aux.Add(ind2);

                //efectividadP1 = new Random().Next(1, 101);
                efectPersonajeP1 = new Random().Next(40, 101);
                primerCombate = false;
            } else{
                P1 = ganadorPelea;
                if(ganadorPelea == P2){
                    efectPersonajeP1 = efectPersonajeP2;
                }
                do{
                    ind2 = new Random().Next(0, 10);
                }while(aux.Contains(ind2));
                P2 = listaJ[ind2];
                aux.Add(ind2);
            }
            //efectividadP2 = new Random().Next(1, 101);
            efectPersonajeP2 = new Random().Next(40, 101);

            Combate(P1, P2, efectPersonajeP1, efectPersonajeP2);
            ganadorPelea = DecidirGanadorDelCombate(P1, P2);
            Console.WriteLine("//////// PELEA FINALIZADA ////////");

            if(aux.Count == 10) torneoFinalizado = true;

        }

        return ganadorPelea;
       
    }

    ////////////// MÉTODOS PARA GESTIONAR DATOS DEL JUEGO ////////////

    public static bool ExisteHistorialGanadores(string ruta){
        FileInfo infoArchivo = new FileInfo(ruta);

        if(infoArchivo.Exists && infoArchivo.Length > 0){
            return true;
        } else{
            return false;
        }
    }


    public static void CargarHistorialGanadores(string rutaArchivo, Jugador ganador){
        FileInfo info = new FileInfo(rutaArchivo);

        if(!ExisteHistorialGanadores(rutaArchivo)){
            // Si el archivo no existe, tendrá información de ganadores por defecto
            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                sw.WriteLine("RDA,430");
                sw.WriteLine("ASW,321");
                sw.WriteLine("DES,231");
                sw.WriteLine("WER,201");
                sw.WriteLine("TER,198");
            }
        } else{
            int i = 0, cant = 0, puntajeGuardado = 0;
            List<string> registroGanadores = new List<string>();
            string linea = String.Empty, regGanador = String.Empty;
            bool guardado = false;
            string[] lineaSplit;

            using (StreamReader sr = new StreamReader(rutaArchivo))
            {
                while((linea = sr.ReadLine()) != null){
                    registroGanadores.Add(linea);
                }
            }

            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                cant = registroGanadores.Count;

                while((i < cant) && !guardado){
                    lineaSplit = registroGanadores[i].Split(',');

                    if(int.TryParse(lineaSplit[1], out puntajeGuardado)){
                        regGanador = $"{ganador.NombreJugador},{ganador.Puntaje}";
                        if(puntajeGuardado <= ganador.Puntaje){
                            registroGanadores.Insert(i, regGanador);
                            guardado = true;
                        }
                    }

                    i++;
                }

                if(!guardado) registroGanadores.Add(regGanador);

                registroGanadores.ForEach(sw.WriteLine);
            }
        }
    }

    public static Dictionary<string, string> LeerHistorial(string rutaHistorialGanadores){
        Dictionary<string, string> puntajesJugadores = new Dictionary<string, string>();
        string linea;
        string[] lineaSplit;

        using (StreamReader sr = new StreamReader(rutaHistorialGanadores)){
            while( (linea = sr.ReadLine()) != null){
                lineaSplit = linea.Split(',');
                puntajesJugadores.Add(lineaSplit[0], lineaSplit[1]);
            }
        }

        return puntajesJugadores; 
    }
}