namespace RPG;

public static class HistorialGanadores
{
    public static bool ExisteHistorialGanadores(string rutaHistorial){
        FileInfo infoArchivo = new FileInfo(rutaHistorial);

        if(infoArchivo.Exists && infoArchivo.Length > 0){
            return true;
        } else{
            return false;
        }
    }

    // Su finalidad es para tener un historial de ganadores por defecto
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

    // El nombre y puntaje del ganador se guardan de forma descendente respecto al puntaje
    public static void GuardarGanadorAHistorial(string rutaHistorial, Jugador ganador){
        FileInfo info = new FileInfo(rutaHistorial);

        if(ExisteHistorialGanadores(rutaHistorial) && ganador != null){
        
            int i = 0, cant = 0, puntajeGuardado = 0;
            List<string> registroGanadores = new List<string>();
            string linea = String.Empty, regGanador = String.Empty;
            bool guardado = false;
            string[] lineaSplit;

            using (StreamReader sr = new StreamReader(rutaHistorial))
            {
                while((linea = sr.ReadLine()) != null){
                    registroGanadores.Add(linea);
                }
            }

            using (StreamWriter sw = new StreamWriter(rutaHistorial))
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