namespace RPG;

public class FabricaDePersonajes
{
    private  Personaje GenerarPersonaje(TipoPersonaje tipo){
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

    private  Personaje crearSicario(){
        Personaje sicario = new Personaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodosDeSicarios = new string[ , ]{{"Dennis", "El oculto"},{"Sara", "La inocente"},{"Robert", "El ingenioso"}};
        sicario.Nombre = nombresYApodosDeSicarios[aux, 0];
        sicario.Apodo = nombresYApodosDeSicarios[aux, 1];
        sicario.Tipo = TipoPersonaje.Sicario;
        sicario.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        sicario.Edad = (DateTime.Now.Subtract(sicario.FechaNac).Days) / 365;
        sicario.DatosSecundarios.Nivel = new Random().Next(7, 11);
        sicario.DatosSecundarios.Velocidad = new Random().Next(7, 11);
        sicario.DatosSecundarios.Destreza = new Random().Next(4, 6);
        sicario.DatosSecundarios.Fuerza = new Random().Next(7, 11);
        sicario.DatosSecundarios.Armadura = new Random().Next(7, 11);

        return sicario;
    }

    private  Personaje crearPrisionero(){
        Personaje prisionero = new Personaje();
        int aux = new Random().Next(0, 3);
    
        string[ , ] nombresYApodosDePrisioneros = new string[ , ]{{"Jeremy", "El salvaje"},{"Sofia", "La gata"},{"Gaston", "El sangriento"}};
        prisionero.Nombre = nombresYApodosDePrisioneros[aux, 0];
        prisionero.Apodo = nombresYApodosDePrisioneros[aux, 1];
        prisionero.Tipo = TipoPersonaje.Prisionero;
        prisionero.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        prisionero.Edad = (DateTime.Now.Subtract(prisionero.FechaNac).Days) / 365;
        prisionero.DatosSecundarios.Nivel = new Random().Next(2, 4);
        prisionero.DatosSecundarios.Velocidad = new Random().Next(4, 7);
        prisionero.DatosSecundarios.Destreza = new Random().Next(2, 4);
        prisionero.DatosSecundarios.Fuerza = new Random().Next(4, 7);
        prisionero.DatosSecundarios.Armadura = new Random().Next(4, 7);

        return prisionero;
    }

    private  Personaje crearLadron(){
        Personaje ladron = new Personaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodosDeLadrones = new string[ , ]{{"Jessica", "La sigilosa"},{"Lucas", "El nocturno"},{"Jorge", "El picaron"}};
        ladron.Nombre = nombresYApodosDeLadrones[aux, 0];
        ladron.Apodo = nombresYApodosDeLadrones[aux, 1];
        ladron.Tipo = TipoPersonaje.Ladron;
        ladron.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        ladron.Edad = (DateTime.Now.Subtract(ladron.FechaNac).Days) / 365;
        ladron.DatosSecundarios.Nivel = new Random().Next(1, 3);
        ladron.DatosSecundarios.Velocidad = new Random().Next(1, 4);
        ladron.DatosSecundarios.Destreza = new Random().Next(1, 3);
        ladron.DatosSecundarios.Fuerza = new Random().Next(1, 4);
        ladron.DatosSecundarios.Armadura = new Random().Next(1, 4);

        return ladron;
    }

    private  Personaje crearPolicia(){
        Personaje policia = new Personaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodosDePolicias = new string[ , ]{{"Miguel", "El grosero"},{"Camila", "La gritona"},{"Joshua", "El agresivo"}};
        policia.Nombre = nombresYApodosDePolicias[aux, 0];
        policia.Apodo = nombresYApodosDePolicias[aux, 1];
        policia.Tipo = TipoPersonaje.Policia;
        policia.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        policia.Edad = (DateTime.Now.Subtract(policia.FechaNac).Days) / 365;
        policia.DatosSecundarios.Nivel = new Random().Next(1, 6);
        policia.DatosSecundarios.Velocidad = new Random().Next(1, 6);
        policia.DatosSecundarios.Destreza = new Random().Next(1, 4);
        policia.DatosSecundarios.Fuerza = new Random().Next(1, 6);
        policia.DatosSecundarios.Armadura = new Random().Next(1, 6);

        return policia;
    }

    private  Personaje crearAgenteEspecial(){
        Personaje agenteEspecial = new Personaje();
        int aux = new Random().Next(0, 3);

        string[ , ] nombresYApodosDeAgentesEspeciales = new string[ , ]{{"Ricardo", "El mas hábil"},{"Estela", "La actriz"},{"Guillermo", "El guerrero"}};
        agenteEspecial.Nombre = nombresYApodosDeAgentesEspeciales[aux, 0];
        agenteEspecial.Apodo = nombresYApodosDeAgentesEspeciales[aux, 1];
        agenteEspecial.Tipo = TipoPersonaje.AgenteEspecial;
        agenteEspecial.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 30)).Date;
        agenteEspecial.Edad = (DateTime.Now.Subtract(agenteEspecial.FechaNac).Days) / 365;
        agenteEspecial.DatosSecundarios.Nivel = new Random().Next(5, 11);
        agenteEspecial.DatosSecundarios.Velocidad = new Random().Next(5, 11);
        agenteEspecial.DatosSecundarios.Destreza = new Random().Next(3, 6);
        agenteEspecial.DatosSecundarios.Fuerza = new Random().Next(5, 11);
        agenteEspecial.DatosSecundarios.Armadura = new Random().Next(5, 11);

        return agenteEspecial;
    }

    private  bool sonIguales(Personaje p1, Personaje p2){
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
    public  List<Personaje> GenerarListaPersonajesRPG(){
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