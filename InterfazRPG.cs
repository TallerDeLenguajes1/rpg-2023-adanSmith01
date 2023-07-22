namespace RPG;

public static class InterfazRPG
{
    //////////////////////////////// INTERFAZ DEL JUEGO //////////////////////////////

    public static void Cargando(){
        Console.WriteLine("                                                  CARGANDO                                                  ");
        int i = 0;

        while(i < 107){
            Console.Write(@"/");
            Thread.Sleep(40);
            i++;
        }
    }
    public static void MensajesYTituloJuego(int id){
        switch(id){
            // Título del juego
            case 1:
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
            break;

            case 2:
            int i = 0, cl = Console.CursorLeft, ct = Console.CursorTop;
            bool cambiaColor = false;

            while(i < 50){
                if(!cambiaColor){
                    Console.ResetColor();
                    cambiaColor = true;
                }else{
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    cambiaColor = false;
                }
                Console.WriteLine(" .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.  .----------------. ");
                Console.WriteLine("| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |");
                Console.WriteLine("| |    ______    | || |      __      | || | ____  _____  | || |      __      | || |  ________    | || |     ____     | || |  _______     | |");
                Console.WriteLine("| |  .' ___  |   | || |     /  \\     | || ||_   \\|_   _| | || |     /  \\     | || | |_   ___ `.  | || |   .'    `.   | || | |_   __ \\    | |");
                Console.WriteLine("| | / .'   \\_|   | || |    / /\\ \\    | || |  |   \\ | |   | || |    / /\\ \\    | || |   | |   `. \\ | || |  /  .--.  \\  | || |   | |__) |   | |");
                Console.WriteLine("| | | |    ____  | || |   / ____ \\   | || |  | |\\ \\| |   | || |   / ____ \\   | || |   | |    | | | || |  | |    | |  | || |   |  __ /    | |");
                Console.WriteLine("| | \\ `.___]  _| | || | _/ /    \\ \\_ | || | _| |_\\   |_  | || | _/ /    \\ \\_ | || |  _| |___.' / | || |  \\  `--'  /  | || |  _| |  \\ \\_  | |");
                Console.WriteLine("| |  `._____.'   | || ||____|  |____|| || ||_____|\\____| | || ||____|  |____|| || | |________.'  | || |   `.____.'   | || | |____| |___| | |");
                Console.WriteLine("| |              | || |              | || |              | || |              | || |              | || |              | || |              | |");
                Console.WriteLine("| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |");
                Console.WriteLine(" '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' ");
                Console.SetCursorPosition(cl, ct);
                Thread.Sleep(600);
                i++;
            }
            break;

            case 3:
            break;
        }
    }

    public static void MostrarPersonajes(List<Personaje> personajes){
        foreach (var p in personajes){
            Console.WriteLine($"┌ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ PERSONAJE: {p.Nombre.ToUpper()} ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ┐");
            Console.WriteLine($"| ===========DATOS===========");
            Console.WriteLine($"| NOMBRE: {p.Nombre}");
            Console.WriteLine($"| APODO: {p.Apodo}");
            Console.WriteLine($"| TIPO DE PERSONAJE: {p.Tipo}");
            Console.WriteLine($"| FECHA DE NACIMIENTO: {p.FechaNac.ToShortDateString()}");
            Console.WriteLine($"| NACIONALIDAD: {p.PaisOrigen}");
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
}