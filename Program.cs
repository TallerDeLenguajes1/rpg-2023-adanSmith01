using System.Security.Cryptography;
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
        MostrarPersonajes(listaPersonajes);

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
            Console.WriteLine($"| EDAD: {p.Edad}");
            Console.WriteLine($"| ===========CARACTERÍSTICAS===========");
            Console.WriteLine($"| VELOCIDAD: {p.DatosSecundarios.Velocidad}");
            Console.WriteLine($"| DESTREZA: {p.DatosSecundarios.Destreza}");
            Console.WriteLine($"| FUERZA: {p.DatosSecundarios.Fuerza}");
            Console.WriteLine($"| NIVEL: {p.DatosSecundarios.Nivel}");
            Console.WriteLine($"| ARMADURA: {p.DatosSecundarios.Armadura}");
            Console.WriteLine($"| SALUD: {p.DatosSecundarios.Salud}");
        }
    }

    public static void ProcesoJuego(List<Personaje> listaP){
        int turno = 1;
        float danioP1, danioP2;
        // Ataque, efectividad y defensa de P1
        int ataqueP1 = 0;
        int efectividadP1 = 0;
        int defensaP1 = 0;

        // Ataque, efectividad y defensa de P2
        int ataqueP2 = 0;
        int efectividadP2 = 0;
        int defensaP2 = 0;

        // Constante de Ajuste
        const int AJUSTE = 500;
        
        int ind1, ind2;
        bool combateFinalizado = false;
        List<int> indicesPersonajes = new List<int>();
        Personaje P1 = new Personaje();
        Personaje P2 = new Personaje();
        Personaje ganadorPelea = new Personaje();
        Personaje siguientePeleador = new Personaje();

       while(!combateFinalizado){
            if(indicesPersonajes.Count < 2){
                do
                {
                    ind1 = new Random().Next(0, 10);
                    ind2 = new Random().Next(0, 10);

                    if (ind1 != ind2)
                    {
                        P1 = listaP[ind1];
                        P2 = listaP[ind2];
                        indicesPersonajes.Add(ind1);
                        indicesPersonajes.Add(ind2);
                    }
                } while (ind1 == ind2);

                efectividadP1 = new Random().Next(1, 101);
                efectividadP2 = new Random().Next(1, 101);

            } else{
                do{
                    ind1 = new Random().Next(0, 10);
                }while(indicesPersonajes.Contains(ind1));
                indicesPersonajes.Add(ind1);

                if(ganadorPelea.Equals(P1)){
                    P2 = listaP[ind1];
                    efectividadP2 = new Random().Next(1, 101);
                } else{
                    if(ganadorPelea.Equals(P2)){
                        P1 = listaP[ind1];
                        efectividadP1 = new Random().Next(1, 101);
                    }
                }
            }

            ataqueP1 = P1.DatosSecundarios.Fuerza * P1.DatosSecundarios.Destreza * P1.DatosSecundarios.Nivel;
            defensaP1 = P1.DatosSecundarios.Armadura * P1.DatosSecundarios.Velocidad;


            ataqueP2 = P2.DatosSecundarios.Fuerza * P2.DatosSecundarios.Destreza * P2.DatosSecundarios.Nivel;
            defensaP2 = P2.DatosSecundarios.Armadura * P2.DatosSecundarios.Velocidad;

            Console.WriteLine($"\n========{P1.Nombre.ToUpper()}, {P1.Apodo.ToUpper()} VS  {P2.Nombre.ToUpper()}, {P2.Apodo.ToUpper()}========\n");
            Console.WriteLine($"Ataque: {ataqueP1}\t\t\t\t\t Ataque: {ataqueP2}");
            Console.WriteLine($"Defensa: {defensaP1}\t\t\t\t\t Defensa: {defensaP2}");
            Console.WriteLine($"Efectividad: {efectividadP1}\t\t\t\t\t Efectividad: {efectividadP2}");
            Console.WriteLine($"Salud: {P1.DatosSecundarios.Salud.ToString("0.0")}% \t\t\t\t\t Salud: {P2.DatosSecundarios.Salud.ToString("0.0")}% ");

            Console.WriteLine("\nPresione ENTER para continuar");
            Console.ReadKey();

            int initialLeft = Console.CursorLeft;
            int initialTop = Console.CursorTop;

            while(P1.DatosSecundarios.Salud > 0 && P2.DatosSecundarios.Salud > 0){
                if(turno == 1){
                    danioP2 = (float)((ataqueP1 * efectividadP1) - defensaP2) / AJUSTE;
                    P2.DatosSecundarios.Salud -= danioP2;
                    turno = 2;
                } else{
                    danioP1 = (float)((ataqueP2 * efectividadP2) - defensaP1) / AJUSTE;
                    P1.DatosSecundarios.Salud -= danioP1;
                    turno = 1;
                }

                Console.SetCursorPosition(initialLeft, initialTop);
                Console.Write($"Salud: {P1.DatosSecundarios.Salud.ToString("0.0")}%  Salud: {P2.DatosSecundarios.Salud.ToString("0.0")}% ");
                Thread.Sleep(300);

            }

            if((P1.DatosSecundarios.Salud > P2.DatosSecundarios.Salud)){
                P1.DatosSecundarios.Fuerza += 1;
                P1.DatosSecundarios.Destreza += 1;
                P1.DatosSecundarios.Nivel += 1;
                if(P1.DatosSecundarios.Salud < 90) P1.DatosSecundarios.Salud += 10;
                efectividadP1 += 2;
                ganadorPelea = P1;
            } else{
                P2.DatosSecundarios.Fuerza += 1;
                P2.DatosSecundarios.Destreza += 1;
                P2.DatosSecundarios.Nivel += 1;
                if(P2.DatosSecundarios.Salud < 90) P2.DatosSecundarios.Salud += 10;
                efectividadP2 += 2;
                ganadorPelea = P2;
            }

            if(indicesPersonajes.Count == 10){
                combateFinalizado = true;

                Console.WriteLine($"\n¡¡¡¡¡¡FELICIDADES {ganadorPelea.Nombre.ToUpper()}, {ganadorPelea.Apodo.ToUpper()}!!!!!!\n");
            }
       }
    }

    
    
}