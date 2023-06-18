namespace RPG;

public static class FabricaDePersonajes
{
    private static Personaje GenerarPersonaje(TipoPersonaje tipo){
        Personaje nuevoPersonaje = new Personaje();
        
        switch(tipo){
            case TipoPersonaje.Sicario:
            nuevoPersonaje = crearSicario();
            break;
            case TipoPersonaje.Prisionero:
            nuevoPersonaje = crearPrisionero();
            break;
            case TipoPersonaje.Ladron:
            nuevoPersonaje = crearLadron();
            break;
            case TipoPersonaje.Policia:
            nuevoPersonaje = crearPolicia();
            break;
            case TipoPersonaje.AgenteEspecial:
            nuevoPersonaje = crearAgenteEspecial();
            break;
        }

        nuevoPersonaje.DatosSecundarios.Salud = 100;

        return nuevoPersonaje;
    }

    private static Personaje crearSicario(){
        Personaje sicario = new Personaje();
        int aux = new Random().Next(0, 3);
        int nivelAleatorio = new Random().Next(1, 5);
        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("velocidad", 30);
        datos.Add("destreza", 7);
        datos.Add("fuerza", 10);
        datos.Add("armadura", 50);

        string[ , ] nombresYApodosDeSicarios = new string[ , ]{{"Dennis", "El oculto"},{"Sara", "La inocente"},{"Robert", "El ingenioso"}};
        sicario.Nombre = nombresYApodosDeSicarios[aux, 0];
        sicario.Apodo = nombresYApodosDeSicarios[aux, 1];
        sicario.Tipo = TipoPersonaje.Sicario;
        sicario.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        sicario.Edad = (DateTime.Now.Subtract(sicario.FechaNac).Days) / 365;
        sicario.DatosSecundarios.Nivel = nivelAleatorio;
        sicario.DatosSecundarios.Velocidad = datos["velocidad"]*nivelAleatorio;
        sicario.DatosSecundarios.Destreza = datos["destreza"]*nivelAleatorio;
        sicario.DatosSecundarios.Fuerza = datos["fuerza"]*nivelAleatorio;
        sicario.DatosSecundarios.Armadura = datos["armadura"]*nivelAleatorio;

        return sicario;
    }

    private static Personaje crearPrisionero(){
        Personaje prisionero = new Personaje();
        int aux = new Random().Next(0, 3);
        int nivelAleatorio = new Random().Next(1, 5);
        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("velocidad", 50);
        datos.Add("destreza", 6);
        datos.Add("fuerza", 20);
        datos.Add("armadura", 40);

        string[ , ] nombresYApodosDePrisioneros = new string[ , ]{{"Jeremy", "El salvaje"},{"Sofia", "La gata"},{"Gaston", "El sangriento"}};
        prisionero.Nombre = nombresYApodosDePrisioneros[aux, 0];
        prisionero.Apodo = nombresYApodosDePrisioneros[aux, 1];
        prisionero.Tipo = TipoPersonaje.Prisionero;
        prisionero.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        prisionero.Edad = (DateTime.Now.Subtract(prisionero.FechaNac).Days) / 365;
        prisionero.DatosSecundarios.Nivel = nivelAleatorio;
        prisionero.DatosSecundarios.Velocidad = datos["velocidad"]*nivelAleatorio;
        prisionero.DatosSecundarios.Destreza = datos["destreza"]*nivelAleatorio;
        prisionero.DatosSecundarios.Fuerza = datos["fuerza"]*nivelAleatorio;
        prisionero.DatosSecundarios.Armadura = datos["armadura"]*nivelAleatorio;

        return prisionero;
    }

    private static Personaje crearLadron(){
        Personaje ladron = new Personaje();
        int aux = new Random().Next(0, 3);
        int nivelAleatorio = new Random().Next(1, 5);
        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("velocidad", 30);
        datos.Add("destreza", 4);
        datos.Add("fuerza", 15);
        datos.Add("armadura", 10);

        string[ , ] nombresYApodosDeLadrones = new string[ , ]{{"Jessica", "La sigilosa"},{"Lucas", "El nocturno"},{"Jorge", "El picaron"}};
        ladron.Nombre = nombresYApodosDeLadrones[aux, 0];
        ladron.Apodo = nombresYApodosDeLadrones[aux, 1];
        ladron.Tipo = TipoPersonaje.Ladron;
        ladron.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        ladron.Edad = (DateTime.Now.Subtract(ladron.FechaNac).Days) / 365;
        ladron.DatosSecundarios.Nivel = nivelAleatorio;
        ladron.DatosSecundarios.Velocidad = datos["velocidad"]*nivelAleatorio;
        ladron.DatosSecundarios.Destreza = datos["destreza"]*nivelAleatorio;
        ladron.DatosSecundarios.Fuerza = datos["fuerza"]*nivelAleatorio;
        ladron.DatosSecundarios.Armadura = datos["armadura"]*nivelAleatorio;

        return ladron;
    }

    private static Personaje crearPolicia(){
        Personaje policia = new Personaje();
        int aux = new Random().Next(0, 3);
        int nivelAleatorio = new Random().Next(1, 5);
        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("velocidad", 50);
        datos.Add("destreza", 5);
        datos.Add("fuerza", 25);
        datos.Add("armadura", 35);

        string[ , ] nombresYApodosDePolicias = new string[ , ]{{"Miguel", "El grosero"},{"Camila", "La gritona"},{"Joshua", "El agresivo"}};
        policia.Nombre = nombresYApodosDePolicias[aux, 0];
        policia.Apodo = nombresYApodosDePolicias[aux, 1];
        policia.Tipo = TipoPersonaje.Policia;
        policia.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        policia.Edad = (DateTime.Now.Subtract(policia.FechaNac).Days) / 365;
        policia.DatosSecundarios.Nivel = nivelAleatorio;
        policia.DatosSecundarios.Velocidad = datos["velocidad"]*nivelAleatorio;
        policia.DatosSecundarios.Destreza = datos["destreza"]*nivelAleatorio;
        policia.DatosSecundarios.Fuerza = datos["fuerza"]*nivelAleatorio;
        policia.DatosSecundarios.Armadura = datos["armadura"]*nivelAleatorio;

        return policia;
    }

    private static Personaje crearAgenteEspecial(){
        Personaje agenteEspecial = new Personaje();
        int aux = new Random().Next(0, 3);
        int nivelAleatorio = new Random().Next(1, 5);
        Dictionary<string, int> datos = new Dictionary<string, int>();
        datos.Add("velocidad", 50);
        datos.Add("destreza", 6);
        datos.Add("fuerza", 20);
        datos.Add("armadura", 40);

        string[ , ] nombresYApodosDeAgentesEspeciales = new string[ , ]{{"Ricardo", "El mas hábil"},{"Estela", "La actriz"},{"Guillermo", "El guerrero"}};
        agenteEspecial.Nombre = nombresYApodosDeAgentesEspeciales[aux, 0];
        agenteEspecial.Apodo = nombresYApodosDeAgentesEspeciales[aux, 1];
        agenteEspecial.Tipo = TipoPersonaje.AgenteEspecial;
        agenteEspecial.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        agenteEspecial.Edad = (DateTime.Now.Subtract(agenteEspecial.FechaNac).Days) / 365;
        agenteEspecial.DatosSecundarios.Nivel = nivelAleatorio;
        agenteEspecial.DatosSecundarios.Velocidad = datos["velocidad"]*nivelAleatorio;
        agenteEspecial.DatosSecundarios.Destreza = datos["destreza"]*nivelAleatorio;
        agenteEspecial.DatosSecundarios.Fuerza = datos["fuerza"]*nivelAleatorio;
        agenteEspecial.DatosSecundarios.Armadura = datos["armadura"]*nivelAleatorio;

        return agenteEspecial;
    }

    private static bool sonIguales(Personaje p1, Personaje p2){
        bool coincidenNombre = (p1.Nombre == p2.Nombre);
        bool coincidenApodo = (p1.Apodo == p2.Apodo);
        bool coincidenFecha = (p1.FechaNac == p2.FechaNac);
        bool coincidenEdad = (p1.Edad == p2.Edad);
        bool coincidenVelocidad = (p1.DatosSecundarios.Velocidad == p2.DatosSecundarios.Velocidad);
        bool coincidenDestreza = (p1.DatosSecundarios.Destreza == p2.DatosSecundarios.Destreza);
        bool coincidenFuerza = (p1.DatosSecundarios.Fuerza == p2.DatosSecundarios.Fuerza);
        bool coincidenNivel = (p1.DatosSecundarios.Nivel == p2.DatosSecundarios.Nivel);
        bool coincidenArmadura = (p1.DatosSecundarios.Armadura == p2.DatosSecundarios.Armadura);

        return (coincidenNombre || coincidenApodo || coincidenFecha || coincidenEdad || coincidenVelocidad || coincidenDestreza || coincidenFuerza || coincidenNivel || coincidenArmadura);
    }
    public static List<Personaje> GenerarListaPersonajesRPG(){
        List<Personaje> listaPersonajes = new List<Personaje>();
        foreach (TipoPersonaje tipoP in Enum.GetValues(typeof(TipoPersonaje))){
            var personaje1 = new Personaje();
            var personaje2 = new Personaje();

            do{
                personaje1 = GenerarPersonaje(tipoP);
                personaje2 = GenerarPersonaje(tipoP);
            }while(sonIguales(personaje1, personaje2));

            listaPersonajes.Add(personaje1);
            listaPersonajes.Add(personaje2);
        }

        return listaPersonajes;
    }

}