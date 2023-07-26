namespace RPG;

public static class InterfazJuego
{

    public static void MensajeCargando(){
        Console.WriteLine("                                                  CARGANDO                                                  ");
        int i = 0;

        while(i < 107){
            Console.Write(@"▓");
            Thread.Sleep(40);
            i++;
        }

        Thread.Sleep(700);
    }

    private static void Pausa(){
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPresione ENTER para continuar");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static void ContextoJuego(){
        string part1 = "¿QUÉ PASARÍA SI SE JUNTAN LOS 10 CRIMINALES MÁS BUSCADOS EN EL MUNDO A LUCHAR ENTRE SÍ POR SU LIBERTAD? 🕊️";
        string part2 = "Y POR UN CUANTIOSO PREMIO POR SUPUESTO 💰";
        string part3 = "¿SU AMBICIÓN LOS LLEVARÁ HACIA LA VICTORIA? 😁";
        string part4 = "¿O HACIA LA MUERTE? 💀";

        Console.WriteLine("\n");
        foreach(var c in part1){
            Thread.Sleep(70);
            Console.Write(c);
        }

        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach(var c in part2){
            Thread.Sleep(30);
            Console.Write(c);
        }

        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.White;
        foreach(var c in part3){
            Thread.Sleep(70);
            Console.Write(c);
        }

        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Red;
        foreach(var c in part4){
            Thread.Sleep(110);
            Console.Write(c);
        }

        Console.ResetColor();

        Pausa();
    }

    public static void TituloDelJuego(){
        Console.WriteLine("                                                                                           ");
        Console.WriteLine("                                                                                           ");
        Console.WriteLine(" /$$$$$$$  /$$$$$$$$  /$$$$$$  /$$$$$$$$ /$$   /$$                   ");
        Console.WriteLine("| $$__  $$| $$_____/ /$$__  $$|__  $$__/| $$  | $$                   ");
        Console.WriteLine(@"| $$  \ $$| $$      | $$  \ $$   | $$   | $$  | $$                   ");
        Console.WriteLine("| $$  | $$| $$$$$   | $$$$$$$$   | $$   | $$$$$$$$                   ");
        Console.WriteLine("| $$  | $$| $$__/   | $$__  $$   | $$   | $$__  $$                   ");
        Console.WriteLine("| $$  | $$| $$      | $$  | $$   | $$   | $$  | $$                    ");
        Console.WriteLine("| $$$$$$$/| $$$$$$$$| $$  | $$   | $$   | $$  | $$            ");
        Console.WriteLine("|_______/ |________/|__/  |__/   |__/   |__/  |__/           ");
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

    public static void MostrarPersonajesDelJuego(List<Personaje> listaP){
        Thread.Sleep(200);
        Console.WriteLine("\n==================================== LUCHADORES ================================\n");
        foreach(var p in listaP){
            Thread.Sleep(900);
            p.MostrarDatosYCaracteristicas();
        }
        Pausa();
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
        Pausa();
    }

    public static void MostrarEscenarioCombate(List<Jugador> listaJ, int id){
        Console.WriteLine($"\nEL SIGUIENTE COMBATE SERÁ EN \"{listaJ[id].Luchador.PaisOrigen.ToUpper()}\" \n");
    }

    public static void ComentariosEstadoCombate(int id){
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

    public static void MostrarGanadorYPerdedor(Jugador P1, Jugador P2){
        Thread.Sleep(1000);
        Console.WriteLine($"\n                         {P1.NombreJugador} HA PERDIDO                   \n");
        Thread.Sleep(1000);
        Console.WriteLine($"                     ¡¡¡ VICTORIA PARA {P2.NombreJugador} !!!           \n");
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

        Pausa();
    }

    public static void MensajeGanaste(){
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

    public static void BolsaDeDinero(Personaje personajeGanador){
        string bolsa = @"     
                                                               ?YYYYYYYYYJJ?7!~^^^^^^^~^                                
                                                               ~YYYYYYYYYYYYYYYYYYYY555!                                
                                                                7YYYYYYYYYYYYYYYYYYY55Y:                                
                                                                 7YYYYYYYYYYYYYYYYYY55?                                 
                                                                  7YYYYYYYYYYYYYYYYY55~                                 
                                                                   7YYYYYYY555YYYYYY5Y:                                 
                                                                   .?YYYYYYY555YYYY55?                                  
                                                                    :YYJYYYY5555YY555~                                  
                                                                     75YYYYY55555555Y:                                  
                                                                     :Y55555555YYYYY?                                   
                                                                     .???777!!!!~~~~^.                                  
                                                                     .^^^^^^^^^^^^^^^.                                  
                                                                     .^~~~~~~~~!!!!7~                                   
                                                                      !??JJJJYYYYYYYJ.                                  
                                                                     .Y5555555555YYJY?.                                 
                                                                     ~5Y5YYYY5YYYYYY55?:                                
                                                                    ^Y55YYYYYYYYJYY5555Y!.                              
                                                                  ~Y55YYYYYYYY55555YY555J!.                            
                                                                ^J55YYYYYYYYYY55555YYYYY55Y7:                          
                                                             :?YYYYYYYYYYYYYYYYYYYYYYYYY555Y7:                        
                                                           .!YYYYYYYYYYYYYYYYYYYYYYYYYYYY55555?:                      
                                                         ~JYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY5555557:                    
                                                        :?YYYYYYJJJYYYYYYYYYYYYYYYYYYYYYYYY555555Y7.                  
                                                      ~YYYYYYYYYYYJYYYYYJ7777?JJYYYYYYYYYYYY5YYY55Y!.                
                                                    .?YYYYYYYYYYYYYYYYYY!:::^^~!YYYYYYYYYYYYYY555555J:               
                                                  ^JYYYYYYYYYYYYYYYJJ77~^^^^^^~!77?JJYYYYYYYY555555557.             
                                                 !YYYYYYYYYYYYYYJ7!^^::^^^^^^^^:::^^~!JYJYYYY555555555J:            
                                               .7YYYYYYYYYYYYYY?^^^^^^^^^^^^^^^:::^^~!JYYYYYYYY55555555Y~           
                                              .7J?JYYYYYYYYYYY?^^^^^^^^^~~!777!!!~~~!?YYYYYYYYY5555555555!          
                                             .!JJJJYYYYYYYYYYY!:^^^^^^^^~7YYYYYJJJYJJJYYYYYYYYY555555555557         
                                             7YJYYYYYYYYYYYYYY?^^^^^^^^^^^^~!7?77?JJJJYYYYYYYYYY555555555557        
                                            ~YYYYYYYYYYYYYYYYYY7^^:^^^^^^^^^^^^^^~~7JYYYYYYYYYYY555555555555~ .     
                                            ^YYYYYYYYYYYYYYYYYYYYJ7!^^::^^^^^^^^^^::^^!?YYYYYYYYYY55555555555Y:      
                                            ?YYYYYYYYYYYYYYYYYYYYYYYJ??7!~~^^:^^^^^^^^^~7YYYYYYYYY5555555555Y57      
                                           ^YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYJ?7^^^^^^^^^~!JYYYYYYYY55555555YYY5J.     
                                           7YYYYYYYYYYYYYYYYYYYY?~!7??JJJYJJJ?^^^^^^^^^~!JYYJYYYYY555555YYY555Y:     
                                           ?YYYYYYYYYYYYYYYYYYYJ^:::^^^^^^^~^^^^^^^^^^~~7YYYYYJYYY55555YYY5555Y:     
                                           ?YYYYYYYYYYYYYYYYYYY7:^^^^^^^^^^^^^^^^^^^^~!?YYYYYYYYJY555YY5555555Y.     
                                           ?YYYYYYYYYYYYYYYYYYY?7!~~^^^^^^^^^^^^^~~!??YYYYYYYYYYYYYYY5555555557      
                                           ~YYYYYYYYYYYYYYYYYYYYYYYYJJ??~^^^^^~!JJJYYYYYYYYYYYYYYYYYYY5555555J.      
                                            ?YYYYYYYYYYYYYYYYYYYYYYYYYYY7^^:^^~!YYYYYYYYYYYYYYYY555555YY5555Y:       
                                            .7YYYYYYYYYYYJYYYYYYYYYYYYYYJJJ????JYYYYYYYYYYYYJYY555555555Y55?.        
                                              ~JYYYYYYYJYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY555555555555Y~          
                                               .~JYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY55555555555J!.           
                                                 .^!JYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYJJYYY55555555555Y7^.             
                                                   .:~7?JYYYYYYYYYYYYYYYYYYYYYYYYJJJYY555555555YJ7^.                
                                                        .^~!??JYYYYYYYYYYYYYYYYYYYY555555YYJ7!^.                    
                                                             .::^~!!77????JJ??77?777!~^::.                         
                                                                                
        ";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n                                                       {personajeGanador.Nombre.ToUpper()} SE LLEVA UN BILLÓN DE DÓLARES $$$\n");
        Thread.Sleep(300);
        Console.WriteLine(bolsa);
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
        MensajeGanaste();
        Console.WriteLine($"                                                        NOMBRE: {ganador.NombreJugador}     PUNTAJE: {ganador.Puntaje}");
        BolsaDeDinero(ganador.Luchador);
        Pausa();
    }

    public static void MostrarTopMejoresJugadores(int top, string rutaHistorialGanadores){
        if(!HistorialGanadores.ExisteHistorialGanadores(rutaHistorialGanadores)){
            Console.WriteLine($"ERROR. No puede leerse el archivo de ruta \"{rutaHistorialGanadores}\" ");
        } else{
            string[] registroGanador;
            Console.WriteLine("\n   NOMBRE   ║   PUNTAJE");
            Console.WriteLine("════════════╬════════════");

            using (StreamReader sr = new StreamReader(rutaHistorialGanadores))
            {
                for(int i = 0; i < top; i++){
                    registroGanador = sr.ReadLine().Split(',');
                    if(registroGanador[0].Length == 3) Console.WriteLine($"    {registroGanador[0]}     ║     {registroGanador[1]}");
                    if(registroGanador[0].Length == 5) Console.WriteLine($"   {registroGanador[0]}    ║     {registroGanador[1]}");
                    if(registroGanador[0].Length == 6) Console.WriteLine($"  JUG_10    ║     {registroGanador[1]}");
                    Console.WriteLine("            ║           ");
                }
            }
            
        }

        Pausa();
    }
}