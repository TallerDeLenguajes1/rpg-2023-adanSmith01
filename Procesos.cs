namespace RPG;

public static class Procesos
{
    // CONSTANTES
    const int AJUSTE = 500;
    const int MAX_JUGADORES = 10;

    private static void Combate(Jugador P1, Jugador P2, int efectividadP1, int efectividadP2){
        int ataqueP1 = 0, defensaP1 = 0;
        int ataqueP2 = 0, defensaP2 = 0;
        float danioP1 = 0f, danioP2 = 0f;
        bool turnoP1 = true;
        int rnd = 0;

        ataqueP1 = P1.Luchador.Caracteristicas.Fuerza * P1.Luchador.Caracteristicas.Destreza * P1.Luchador.Caracteristicas.Nivel;
        defensaP1 = P1.Luchador.Caracteristicas.Velocidad * P1.Luchador.Caracteristicas.Blindaje;

        ataqueP2 = P2.Luchador.Caracteristicas.Fuerza * P2.Luchador.Caracteristicas.Destreza * P2.Luchador.Caracteristicas.Nivel;
        defensaP2 = P2.Luchador.Caracteristicas.Velocidad * P2.Luchador.Caracteristicas.Blindaje;

        InterfazRPG.PresentacionCombatientes(P1, ataqueP1, defensaP1, efectividadP1, P2, ataqueP2, defensaP2, efectividadP2);

        Console.WriteLine("\n═════════════════════ ESTADO DEL COMBATE ═════════════════════════");
        while((P1.Luchador.Caracteristicas.Salud > 0) && (P2.Luchador.Caracteristicas.Salud > 0)){
            rnd = new Random().Next(1, 6);
            Thread.Sleep(900);

            if(turnoP1){
                danioP2 = (float)((ataqueP1 * efectividadP1) - defensaP2) / AJUSTE;
                P2.Luchador.Caracteristicas.Salud -= Math.Abs(danioP2);
                turnoP1 = false;
                Console.WriteLine($"\n                    {P1.Luchador.Nombre} ATACA A {P2.Luchador.Nombre}            ");
            } else{
                danioP1 = (float)((ataqueP2 * efectividadP2) - defensaP1) / AJUSTE;
                P1.Luchador.Caracteristicas.Salud -= Math.Abs(danioP1);
                turnoP1 = true;
                Console.WriteLine($"\n                    {P2.Luchador.Nombre} ATACA A {P1.Luchador.Nombre}             ");
            }

            Thread.Sleep(1000);
            if(P1.Luchador.Caracteristicas.Salud > 0 && P2.Luchador.Caracteristicas.Salud > 0){
                InterfazRPG.ComentariosEstadoCombate(rnd);
            } else{
                InterfazRPG.ComentariosEstadoCombate(6);
            }
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
                nombreJugador = $"JUG_{i + 1}";
            }
            J.NombreJugador = nombreJugador.ToUpper();
            J.Luchador = listaP[i];
            listaJugadores.Add(J);
        }
        
        return listaJugadores;
    }

    public static Jugador DecidirGanadorDelCombate(Jugador P1, Jugador P2){
        string[] paisesLatinos = {"Venezuela", "México", "Argentina", "Uruguay", "Paraguay", "Colombia", "Perú", "Bolivia", "Chile", "Ecuador", "Brasil", 
        "República Dominicana", "Cuba", "El Salvador", "Bélice", "Honduras", "Guatemala", "Nicaragua", "Costa Rica", "Puerto Rico", "Panamá"};
        Jugador ganadorPelea = new Jugador();

        if((P1.Luchador.Caracteristicas.Salud > P2.Luchador.Caracteristicas.Salud)){
            Thread.Sleep(1000);
            Console.WriteLine($"\n                         {P2.NombreJugador} HA PERDIDO                   \n");
            Thread.Sleep(1000);
            Console.WriteLine($"                     ¡¡¡ VICTORIA PARA {P1.NombreJugador} !!!           \n");
            ganadorPelea = P1;
        } else{
            Thread.Sleep(1000);
            Console.WriteLine($"\n                        {P1.NombreJugador} HA PERDIDO                    \n");
            Thread.Sleep(1000);
            Console.WriteLine($"                     ¡¡¡ VICTORIA PARA {P2.NombreJugador} !!!           \n");
            ganadorPelea = P2;
        }

        if(ganadorPelea.Luchador.Caracteristicas.Salud >= 70 && ganadorPelea.Luchador.Caracteristicas.Salud <= 80){
            ganadorPelea.Luchador.Caracteristicas.Salud += 5;  
        } else{
            ganadorPelea.Luchador.Caracteristicas.Salud += 10;
        }

        // Criterio del bonus del ganador a partir de su nacionalidad
        if(paisesLatinos.Contains(ganadorPelea.Luchador.PaisOrigen)){
            ganadorPelea.Luchador.Caracteristicas.Fuerza += 2;
            Console.WriteLine($"\n{ganadorPelea.NombreJugador}, SU PERSONAJE HA RECIBIDO UN AUMENTO EN SALUD Y ATAQUE");
        } else{
            ganadorPelea.Luchador.Caracteristicas.Velocidad += 2;
            Console.WriteLine($"\n{ganadorPelea.NombreJugador}, SU PERSONAJE HA RECIBIDO UN AUMENTO EN SALUD Y DEFENSA");
        }


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
        int ind1 = 0, ind2 = 0, id = 9;

        while(!torneoFinalizado){
            
            InterfazRPG.MostrarEscenarioCombate(listaJ, id);
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

            id--;

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

    public static void PrecargarHistorialGanadores(string rutaHistorial){
        FileInfo info = new FileInfo(rutaHistorial);

        if(!ExisteHistorialGanadores(rutaHistorial)){
            // Si el archivo no existe, tendrá información de ganadores por defecto
            using (StreamWriter sw = new StreamWriter(rutaHistorial))
            {
                sw.WriteLine("RDA,430");
                sw.WriteLine("JUG_10,321");
                sw.WriteLine("DES,231");
                sw.WriteLine("JUG_1,201");
                sw.WriteLine("TER,198");
            }
        }
    }

    public static void GuardarGanadorAHistorial(string rutaArchivo, Jugador ganador){
        FileInfo info = new FileInfo(rutaArchivo);

        if(ExisteHistorialGanadores(rutaArchivo) && ganador != null){
        
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
            
        } else{
            Console.WriteLine("\nERROR. HAY PROBLEMAS PARA GUARDAR EL GANADOR DEL TORNEO\n");
        }
    }

}