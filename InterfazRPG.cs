namespace RPG;

public static class InterfazRPG
{
    //////////////////////////////// INTERFAZ DEL JUEGO //////////////////////////////

    public static void Cargando(){
        Console.WriteLine("                                                  CARGANDO                                                  ");
        int i = 0;

        while(i < 107){
            Console.Write(@"▓");
            Thread.Sleep(40);
            i++;
        }
    }

    public static void TituloJuego(){
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("  /$$$$$$  /$$$$$$$  /$$$$$$ /$$      /$$ /$$$$$$ /$$   /$$  /$$$$$$  /$$                   ");
        Console.WriteLine(" /$$__  $$| $$__  $$|_  $$_/| $$$    /$$$|_  $$_/| $$$ | $$ /$$__  $$| $$                   ");
        Console.WriteLine("| $$  \\__/| $$  \\ $$  | $$  | $$$$  /$$$$  | $$  | $$$$| $$| $$  \\ $$| $$                   ");
        Console.WriteLine("| $$      | $$$$$$$/  | $$  | $$ $$/$$ $$  | $$  | $$ $$ $$| $$$$$$$$| $$                   ");
        Console.WriteLine("| $$      | $$__  $$  | $$  | $$  $$$| $$  | $$  | $$  $$$$| $$__  $$| $$                   ");
        Console.WriteLine("| $$    $$| $$  \\ $$  | $$  | $$\\  $ | $$  | $$  | $$\\  $$$| $$  | $$| $$                   ");
        Console.WriteLine("|  $$$$$$/| $$  | $$ /$$$$$$| $$ \\/  | $$ /$$$$$$| $$ \\  $$| $$  | $$| $$$$$$$$            ");
        Console.WriteLine(" \\______/ |__/  |__/|______/|__/     |__/|______/|__/  \\__/|__/  |__/|________/            ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("             /$$$$$$$$ /$$$$$$  /$$$$$$  /$$   /$$ /$$$$$$$$                               ");
        Console.WriteLine("            | $$_____/|_  $$_/ /$$__  $$| $$  | $$|__  $$__/                               ");
        Console.WriteLine("            | $$        | $$  | $$  \\__/| $$  | $$   | $$                                  ");
        Console.WriteLine("            | $$$$$     | $$  | $$ /$$$$| $$$$$$$$   | $$                                  ");
        Console.WriteLine("            | $$__/     | $$  | $$|_  $$| $$__  $$   | $$                                  ");
        Console.WriteLine("            | $$        | $$  | $$  \\ $$| $$  | $$   | $$                                  ");
        Console.WriteLine("            | $$       /$$$$$$|  $$$$$$/| $$  | $$   | $$                                  ");
        Console.WriteLine("            |__/      |______/ \\______/ |__/  |__/   |__/                                  ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("                                                                                           ");
    }

    public static void MostrarPersonajesJuego(List<Personaje> listaP){
        Thread.Sleep(200);
        Console.WriteLine("\n==================================== LUCHADORES ================================\n");
        foreach(var p in listaP){
            Thread.Sleep(900);
            p.MostrarDatosYCaracteristicasPersonaje();
        }
        Console.Write("\nPresione ENTER para continuar");
        Console.ReadKey();
    }
    public static void MostrarJugadores(List<Jugador> listaJ){
        Console.WriteLine("\n");
        Console.WriteLine("   NOMBRE   ║     PERSONAJE ");
        Console.WriteLine("════════════╬═════════════════");
        foreach(var j in listaJ){
            if(j.NombreJugador.Length == 3) Console.WriteLine($"    {j.NombreJugador}     ║  {j.Luchador.Nombre}, {j.Luchador.Apodo}");
            if(j.NombreJugador.Length == 5) Console.WriteLine($"   {j.NombreJugador}    ║  {j.Luchador.Nombre}, {j.Luchador.Apodo}");
            if(j.NombreJugador.Length == 6) Console.WriteLine($"  JUG_10    ║  {j.Luchador.Nombre}, {j.Luchador.Apodo}");
        }
        Console.Write("\nPresione ENTER para continuar");
        Console.ReadKey();
    }
    public static void Comentarios(int id){
        switch(id){
            case 1:
            Console.WriteLine("\n                     ¡QUE BUENA GOLPIZA!                    ");
            break;

            case 2:
            Console.WriteLine("\n               ¡NO CREO QUE SANE DESPUÉS DE ESO!           ");
            break;

            case 3:
            Console.WriteLine("\n                    ¡MARAVILLOSA JUGADA!                  ");
            break;

            case 4:
            Console.WriteLine("\n        AUCH! POR SUERTE, LA AMBULANCIA SE ENCUENTRA CERCA  ");
            break;

            case 5:
            Console.WriteLine("\n                        ¡QUE RAPIDEZ!                        ");
            break;

            case 6:
            Console.WriteLine("\n              PARECE QUE HAY UN GANADOR DEL COMBATE          ");
            break;
        }
    }

    public static void PresentacionCombatientes(Jugador P1, int ataqueP1, int defensaP1, int efectividadP1, Jugador P2, int ataqueP2, int defensaP2, int efectividadP2){
        Console.WriteLine($"\n════════════════════════════════ {P1.NombreJugador.ToUpper()} ════════════════════════════════\n");
        Console.WriteLine($"  Personaje: {P1.Luchador.Nombre.ToUpper()}, {P1.Luchador.Apodo.ToUpper()}\n");
        Console.WriteLine($"  Ataque: {ataqueP1}\n");
        Console.WriteLine($"  Defensa: {defensaP1}\n");
        Console.WriteLine($"  Efectividad: {efectividadP1}\n");
        Console.WriteLine($"  Salud: {P1.Luchador.Caracteristicas.Salud.ToString("0.0")}%\n");

        Console.WriteLine("\n================================ VS ======================================\n");
        Thread.Sleep(700);

        Console.WriteLine($"\n════════════════════════════════ {P2.NombreJugador.ToUpper()} ════════════════════════════════\n");
        Console.WriteLine($"  Personaje: {P2.Luchador.Nombre.ToUpper()}, {P2.Luchador.Apodo.ToUpper()}\n");
        Console.WriteLine($"  Ataque: {ataqueP2}\n");
        Console.WriteLine($"  Defensa: {defensaP2}\n");
        Console.WriteLine($"  Efectividad: {efectividadP2}\n");
        Console.WriteLine($"  Salud: {P2.Luchador.Caracteristicas.Salud.ToString("0.0")}%\n");
    }

    public static void Ganaste(){
        Console.ForegroundColor = ConsoleColor.Yellow;
        string mensaje = @"
        .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.  .----------------. 
        | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
        | |    ______    | || |      __      | || | ____  _____  | || |      __      | || |    _______   | || |  _________   | || |  _________   | |
        | |  .' ___  |   | || |     /  \     | || ||_   \|_   _| | || |     /  \     | || |   /  ___  |  | || | |  _   _  |  | || | |_   ___  |  | |
        | | / .'   \_|   | || |    / /\ \    | || |  |   \ | |   | || |    / /\ \    | || |  |  (__ \_|  | || | |_/ | | \_|  | || |   | |_  \_|  | |
        | | | |    ____  | || |   / ____ \   | || |  | |\ \| |   | || |   / ____ \   | || |   '.___`-.   | || |     | |      | || |   |  _|  _   | |
        | | \ `.___]  _| | || | _/ /    \ \_ | || | _| |_\   |_  | || | _/ /    \ \_ | || |  |`\____) |  | || |    _| |_     | || |  _| |___/ |  | |
        | |  `._____.'   | || ||____|  |____|| || ||_____|\____| | || ||____|  |____|| || |  |_______.'  | || |   |_____|    | || | |_________|  | |
        | |              | || |              | || |              | || |              | || |              | || |              | || |              | |
        | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
        '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
        ";
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    public static void MensajeGanadorTorneo(Jugador ganador){
        int altura = 20;
        Console.WriteLine("\n");
        if(ganador.NombreJugador.Length == 3) for(int i = 0; i < (altura * 4); i++) Console.Write(" ");
        if(ganador.NombreJugador.Length == 5) for(int i = 0; i < (altura * 4 - 1); i++) Console.Write(" ");
        if(ganador.NombreJugador.Length == 6) for(int i = 0; i < (altura * 4 - 2); i++) Console.Write(" ");
        Console.Write($"{ganador.NombreJugador}\n");

        for(int fila = 1; fila <= altura; fila++){
            Thread.Sleep(40);
            for(int espacio = altura * 4 - fila; espacio > 0; espacio--) Console.Write(" ");

            Console.Write("┌");

            for(int linea = 1; linea <= (2*fila + 1); linea++) Console.Write("─");

            Console.Write("┐");

            Console.Write("\n");
        }
        Ganaste();
    }
}