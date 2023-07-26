namespace RPG;

public static class DesarrolloJuego
{
    const int AJUSTE = 500;

    private static int CalcularAtaque(Personaje p){
        return (p.Caracteristicas.Fuerza * p.Caracteristicas.Destreza * p.Caracteristicas.Nivel);
    }
    
    private static int CalcularDefensa(Personaje p){
        return (p.Caracteristicas.Velocidad * p.Caracteristicas.Blindaje);
    }

    private static int CalcularEfectividad(){
        return (new Random().Next(40, 101));
    }
    
    private static float CalcularDanioProvocado(int ataquePersonaje1, int efectividadPersonaje1, int defensaPersonaje2){
        return ((float)((ataquePersonaje1 * efectividadPersonaje1) - defensaPersonaje2) / AJUSTE);
    }

    private static void Combate(Jugador P1, Jugador P2, int efectividadP1, int efectividadP2){
        int ataqueP1 = 0, defensaP1 = 0;
        int ataqueP2 = 0, defensaP2 = 0;
        float danioP1 = 0f, danioP2 = 0f;
        bool turnoP1 = true;
        int rnd = 0;

        ataqueP1 = CalcularAtaque(P1.Luchador);
        defensaP1 = CalcularDefensa(P1.Luchador);

        ataqueP2 = CalcularAtaque(P2.Luchador);
        defensaP2 = CalcularDefensa(P2.Luchador);

        InterfazJuego.PresentacionCombatientes(P1, ataqueP1, defensaP1, efectividadP1, P2, ataqueP2, defensaP2, efectividadP2);

        Console.WriteLine("\n═════════════════════ ESTADO DEL COMBATE ═════════════════════════");
        while((P1.Luchador.Caracteristicas.Salud > 0) && (P2.Luchador.Caracteristicas.Salud > 0)){
            rnd = new Random().Next(1, 6);
            Thread.Sleep(900);

            if(turnoP1){
                danioP2 = CalcularDanioProvocado(ataqueP1, efectividadP1, defensaP2);
                P2.Luchador.Caracteristicas.Salud -= Math.Abs(danioP2);
                turnoP1 = false;
                Console.WriteLine($"\n                    {P1.Luchador.Nombre} ATACA A {P2.Luchador.Nombre}            ");
            } else{
                danioP1 = CalcularDanioProvocado(ataqueP2, efectividadP2, defensaP1);
                P1.Luchador.Caracteristicas.Salud -= Math.Abs(danioP1);
                turnoP1 = true;
                Console.WriteLine($"\n                    {P2.Luchador.Nombre} ATACA A {P1.Luchador.Nombre}             ");
            }

            Thread.Sleep(1000);
            if(P1.Luchador.Caracteristicas.Salud > 0 && P2.Luchador.Caracteristicas.Salud > 0){
                InterfazJuego.ComentariosEstadoCombate(rnd);
            } else{
                InterfazJuego.ComentariosEstadoCombate(6);
            }
        }
    }

    private static void BonusJugadorGanadorDelCombate(Jugador ganador){
        string[] paisesLatinos = {"Venezuela", "México", "Argentina", "Uruguay", "Paraguay", "Colombia", "Perú", "Bolivia", "Chile", "Ecuador", "Brasil", 
        "República Dominicana", "Cuba", "El Salvador", "Bélice", "Honduras", "Guatemala", "Nicaragua", "Costa Rica", "Puerto Rico", "Panamá"};
        if(ganador.Luchador.Caracteristicas.Salud >= 70 && ganador.Luchador.Caracteristicas.Salud <= 80){
            ganador.Luchador.Caracteristicas.Salud += 5;  
        } else{
            ganador.Luchador.Caracteristicas.Salud += 10;
        }

        // Aumenta el ataque o defensa de su personaje de acuerdo al pais de origen del mismo
        if(paisesLatinos.Contains(ganador.Luchador.PaisOrigen)){
            ganador.Luchador.Caracteristicas.Fuerza += 2;
            Thread.Sleep(800);
            Console.WriteLine($"\n{ganador.NombreJugador}, SU PERSONAJE HA RECIBIDO UN AUMENTO EN SALUD Y ATAQUE");
        } else{
            ganador.Luchador.Caracteristicas.Velocidad += 2;
            Console.WriteLine($"\n{ganador.NombreJugador}, SU PERSONAJE HA RECIBIDO UN AUMENTO EN SALUD Y DEFENSA");
        }
    }

    private static Jugador ObtenerGanadorDelCombate(Jugador P1, Jugador P2){
        Jugador ganadorCombate = new Jugador();

        if((P1.Luchador.Caracteristicas.Salud > P2.Luchador.Caracteristicas.Salud)){
            InterfazJuego.MostrarGanadorYPerdedor(P2, P1);
            ganadorCombate = P1;
        } else{
            InterfazJuego.MostrarGanadorYPerdedor(P1, P2);
            ganadorCombate = P2;
        }

        BonusJugadorGanadorDelCombate(ganadorCombate);
        ganadorCombate.CalcularPuntaje();
        Console.WriteLine($"\nPUNTAJE DE {ganadorCombate.NombreJugador.ToUpper()}: {ganadorCombate.Puntaje}\n");
        return ganadorCombate;
    }

    public static Jugador ObtenerGanadorDelTorneo(List<Jugador> listaJ){
        Jugador P1 = new Jugador();
        Jugador P2 = new Jugador();
        Jugador ganadorCombate = new Jugador();
        int efectPersonajeP1 = 0, efectPersonajeP2 = 0;
        bool torneoFinalizado = false, primerCombate = true;
        List<int> aux = new List<int>();
        int ind1 = 0, ind2 = 0, id = 9;

        while(!torneoFinalizado){
            
            InterfazJuego.MostrarEscenarioCombate(listaJ, id);
            
            if(primerCombate){
                ind1 = new Random().Next(0, 10);
                P1 = listaJ[ind1];
                do{
                    ind2 = new Random().Next(0, 10);
                    P2 = listaJ[ind2];
                }while(P1.Luchador.Nombre == P2.Luchador.Nombre);
                aux.Add(ind1);
                aux.Add(ind2);

                efectPersonajeP1 = CalcularEfectividad();
                primerCombate = false;
            } else{
                P1 = ganadorCombate;
                if(ganadorCombate == P2){
                    efectPersonajeP1 = efectPersonajeP2;
                }
                do{
                    ind2 = new Random().Next(0, 10);
                }while(aux.Contains(ind2));
                P2 = listaJ[ind2];
                aux.Add(ind2);
            }
            efectPersonajeP2 = CalcularEfectividad();

            Combate(P1, P2, efectPersonajeP1, efectPersonajeP2);
            ganadorCombate = ObtenerGanadorDelCombate(P1, P2);

            id--;

            if(aux.Count == 10) torneoFinalizado = true;

        }

        return ganadorCombate;
       
    }


}