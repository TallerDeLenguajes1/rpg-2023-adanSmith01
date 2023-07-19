using System.Net;
using System.Text.Json;

namespace RPG;

public class FabricaDePersonajes
{
    private PersonajePaises ObtenerPosiblesPaisesPersonaje(string nombrePersonaje){
        string url = @$"https://api.nationalize.io?name={nombrePersonaje}";
        var peticion = (HttpWebRequest) WebRequest.Create(url);
        peticion.Method = "GET";
        peticion.ContentType = "application/json";
        peticion.Accept = "application/json";
        PersonajePaises p = null;
        
        try
        {
            using (WebResponse response = peticion.GetResponse()){
                using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string info = objReader.ReadToEnd();
                            p = JsonSerializer.Deserialize<PersonajePaises>(info);
                        }
                    }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Problemas de acceso a la API");
        }

        return p;
    }

    private string ObtenerNacionalidadPersonaje(PersonajePaises p, string rutaArchivoPaises){
        string nacionalidadPersonaje = "";
        int rand;
        string randString;
        string linea = "";
        string[] lineaSplit;

        if(p != null){
            rand = new Random().Next(0, 5);
            string codPais = p.country[rand].country_id;
            using (StreamReader s = new StreamReader(rutaArchivoPaises)){
                linea = s.ReadLine();
                while((linea != null) && (nacionalidadPersonaje == "")){
                    lineaSplit = linea.Split(';');
                    if(lineaSplit[1] == codPais){
                        nacionalidadPersonaje = lineaSplit[2];
                    }
                    linea = s.ReadLine();
                }
            }
        } else{
            randString = new Random().Next(0, 240).ToString();
            using (StreamReader st = new StreamReader(rutaArchivoPaises)){
                linea = st.ReadLine();
                while((linea != null) && (nacionalidadPersonaje == "")){
                    lineaSplit = linea.Split(';');
                    if(lineaSplit[0] == randString){
                        nacionalidadPersonaje = lineaSplit[2];
                    }
                    linea = st.ReadLine();
                }
            }
        }

        return nacionalidadPersonaje;
    }

    private Personaje GenerarPersonaje(TipoPersonaje tipo){
        Personaje nuevoPersonaje = new Personaje();
        
        switch(tipo){
            case TipoPersonaje.Sicario:
            nuevoPersonaje = CrearSicario();
            break;
            case TipoPersonaje.Psicopata:
            nuevoPersonaje = CrearPsicopata();
            break;
            case TipoPersonaje.Ladron:
            nuevoPersonaje = CrearLadron();
            break;
            case TipoPersonaje.Policia:
            nuevoPersonaje = CrearPolicia();
            break;
            case TipoPersonaje.AgenteEspecial:
            nuevoPersonaje = CrearAgenteEspecial();
            break;
        }

        nuevoPersonaje.Nacionalidad = ObtenerNacionalidadPersonaje(ObtenerPosiblesPaisesPersonaje(nuevoPersonaje.Nombre), "paises.txt");
        nuevoPersonaje.Caracteristicas.Salud = 100;

        return nuevoPersonaje;
    }

    private  Personaje CrearSicario(){
        Personaje sicario = new Personaje();
        sicario.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodos = {{"Dennis", "El oculto"},{"Sara", "La inocente"},{"Robert", "El ingenioso"}};
        sicario.Nombre = nombresYApodos[aux, 0];
        sicario.Apodo = nombresYApodos[aux, 1];
        sicario.Tipo = TipoPersonaje.Sicario;
        sicario.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        sicario.Edad = (DateTime.Now.Subtract(sicario.FechaNac).Days) / 365;
        sicario.Caracteristicas.Nivel = new Random().Next(7, 11);
        sicario.Caracteristicas.Velocidad = new Random().Next(7, 11);
        sicario.Caracteristicas.Destreza = new Random().Next(4, 6);
        sicario.Caracteristicas.Fuerza = new Random().Next(7, 11);
        sicario.Caracteristicas.Blindaje = new Random().Next(7, 11);

        return sicario;
    }

    private  Personaje CrearPsicopata(){
        Personaje psicopata = new Personaje();
        psicopata.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 3);
    
        string[ , ] nombresYApodos = {{"Jeremy", "El salvaje"},{"Sofia", "La gata"},{"Gaston", "El sangriento"}};
        psicopata.Nombre = nombresYApodos[aux, 0];
        psicopata.Apodo = nombresYApodos[aux, 1];
        psicopata.Tipo = TipoPersonaje.Psicopata;
        psicopata.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        psicopata.Edad = (DateTime.Now.Subtract(psicopata.FechaNac).Days) / 365;
        psicopata.Caracteristicas.Nivel = new Random().Next(2, 4);
        psicopata.Caracteristicas.Velocidad = new Random().Next(4, 7);
        psicopata.Caracteristicas.Destreza = new Random().Next(2, 4);
        psicopata.Caracteristicas.Fuerza = new Random().Next(4, 7);
        psicopata.Caracteristicas.Blindaje = new Random().Next(4, 7);

        return psicopata;
    }

    private  Personaje CrearLadron(){
        Personaje ladron = new Personaje();
        ladron.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodos = {{"Jessica", "La sigilosa"},{"Lucas", "El nocturno"},{"Jorge", "El picaron"}};
        ladron.Nombre = nombresYApodos[aux, 0];
        ladron.Apodo = nombresYApodos[aux, 1];
        ladron.Tipo = TipoPersonaje.Ladron;
        ladron.FechaNac = new DateTime(new Random().Next(1980, 2000), new Random().Next(1, 13), new Random().Next(1, 29)).Date;
        ladron.Edad = (DateTime.Now.Subtract(ladron.FechaNac).Days) / 365;
        ladron.Caracteristicas.Nivel = new Random().Next(1, 3);
        ladron.Caracteristicas.Velocidad = new Random().Next(1, 4);
        ladron.Caracteristicas.Destreza = new Random().Next(1, 3);
        ladron.Caracteristicas.Fuerza = new Random().Next(1, 4);
        ladron.Caracteristicas.Blindaje = new Random().Next(1, 4);

        return ladron;
    }

    private  Personaje CrearPolicia(){
        Personaje policia = new Personaje();
        policia.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodos = {{"Miguel", "El grosero"},{"Camila", "La gritona"},{"Joshua", "El agresivo"}};
        policia.Nombre = nombresYApodos[aux, 0];
        policia.Apodo = nombresYApodos[aux, 1];
        policia.Tipo = TipoPersonaje.Policia;
        policia.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        policia.Edad = (DateTime.Now.Subtract(policia.FechaNac).Days) / 365;
        policia.Caracteristicas.Nivel = new Random().Next(1, 6);
        policia.Caracteristicas.Velocidad = new Random().Next(1, 6);
        policia.Caracteristicas.Destreza = new Random().Next(1, 4);
        policia.Caracteristicas.Fuerza = new Random().Next(1, 6);
        policia.Caracteristicas.Blindaje = new Random().Next(1, 6);

        return policia;
    }

    private  Personaje CrearAgenteEspecial(){
        Personaje agenteEspecial = new Personaje();
        agenteEspecial.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodos = {{"Ricardo", "El mas hábil"},{"Estela", "La actriz"},{"Guillermo", "El guerrero"}};
        agenteEspecial.Nombre = nombresYApodos[aux, 0];
        agenteEspecial.Apodo = nombresYApodos[aux, 1];
        agenteEspecial.Tipo = TipoPersonaje.AgenteEspecial;
        agenteEspecial.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        agenteEspecial.Edad = (DateTime.Now.Subtract(agenteEspecial.FechaNac).Days) / 365;
        agenteEspecial.Caracteristicas.Nivel = new Random().Next(5, 11);
        agenteEspecial.Caracteristicas.Velocidad = new Random().Next(5, 11);
        agenteEspecial.Caracteristicas.Destreza = new Random().Next(3, 6);
        agenteEspecial.Caracteristicas.Fuerza = new Random().Next(5, 11);
        agenteEspecial.Caracteristicas.Blindaje = new Random().Next(5, 11);

        return agenteEspecial;
    }

    private  bool PersonajesIguales(Personaje p1, Personaje p2){
        bool coincidenNombre = (p1.Nombre == p2.Nombre);
        bool coincidenApodo = (p1.Apodo == p2.Apodo);
        bool coincidenFecha = (p1.FechaNac == p2.FechaNac);
        bool coincidenEdad = (p1.Edad == p2.Edad);
        bool coincidenVelocidad = (p1.Caracteristicas.Velocidad == p2.Caracteristicas.Velocidad);
        bool coincidenDestreza = (p1.Caracteristicas.Destreza == p2.Caracteristicas.Destreza);
        bool coincidenFuerza = (p1.Caracteristicas.Fuerza == p2.Caracteristicas.Fuerza);
        bool coincidenNivel = (p1.Caracteristicas.Nivel == p2.Caracteristicas.Nivel);
        bool coincidenArmadura = (p1.Caracteristicas.Blindaje == p2.Caracteristicas.Blindaje);

        return (coincidenNombre || coincidenApodo || coincidenFecha || coincidenEdad || coincidenVelocidad || coincidenDestreza || coincidenFuerza || coincidenNivel || coincidenArmadura);
    }
    public  List<Personaje> GenerarListaPersonajesRPG(){
        List<Personaje> listaPersonajes = new List<Personaje>();
        foreach (TipoPersonaje tipoP in Enum.GetValues(typeof(TipoPersonaje))){
            var personaje1 = new Personaje();
            var personaje2 = new Personaje();

            do{
                personaje1 = GenerarPersonaje(tipoP);
                personaje2 = GenerarPersonaje(tipoP);
            }while(PersonajesIguales(personaje1, personaje2));

            listaPersonajes.Add(personaje1);
            listaPersonajes.Add(personaje2);
        }

        return listaPersonajes;
    }

}