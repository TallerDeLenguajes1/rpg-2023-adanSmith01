using System.Net;
using System.Text.Json;

namespace RPG;

public class FabricaDePersonajes
{
    private static Dictionary<string, string> paises = new Dictionary<string, string>()
    { 
        {"AD","Andorra"}, {"AE","Emiratos Árabes Unidos"}, {"AF","Afganistán"}, {"AG","Antigua y Barbuda"}, {"AI","Anguila"},
        {"AL","Albania"}, {"AM","Armenia"}, {"AN","Antillas Neerlandesas"}, {"AO","Angola"}, {"AQ","Antártida"}, {"AR","Argentina"},
        {"AS","Samoa Americana"}, {"AT","Austria"}, {"AU","Australia"}, {"AW","Aruba"}, {"AX","Islas Áland"}, {"AZ","Azerbaiyán"},
        {"BA","Bosnia y Herzegovina"}, {"BB","Barbados"}, {"BD","Bangladesh"}, {"BE","Bélgica"}, {"BF","Burkina Faso"},
        {"BG","Bulgaria"}, {"BH","Bahréin"}, {"BI","Burundi"}, {"BJ","Benin"}, {"BL","San Bartolomé"}, {"BM","Bermudas"},
        {"BN","Brunéi"}, {"BO","Bolivia"}, {"BR","Brasil"}, {"BS","Bahamas"}, {"BT","Bhután"}, {"BV","Isla Bouvet"},
        {"BW","Botsuana"}, {"BY","Belarús"}, {"BZ","Bélice"}, {"CA","Canadá"}, {"CC","Islas Cocos"}, {"CF","República Centro-Africana"},
        {"CG","Congo"}, {"CH","Suiza"}, {"CI","Costa de Marfil"}, {"CK","Islas Cook"}, {"CL","Chile"}, {"CM","Camerún"}, {"CN","China"},
        {"CO","Colombia"}, {"CR","Costa Rica"}, {"CU","Cuba"}, {"CV","Cabo Verde"}, {"CX","Islas Christmas"}, {"CY","Chipre"}, {"CZ","República Checa"},
        {"DE","Alemania"}, {"DJ","Yibuti"}, {"DK","Dinamarca"}, {"DM","Domínica"}, {"DO","República Dominicana"}, {"DZ","Argel"},
        {"EC","Ecuador"}, {"EE","Estonia"}, {"EG","Egipto"}, {"EH","Sahara Occidental"}, {"ER","Eritrea"}, {"ES","España"},
        {"ET","Etiopía"}, {"FI","Finlandia"}, {"FJ","Fiji"}, {"FK","Islas Malvinas"}, {"FM","Micronesia"}, {"FO","Islas Faroe"},
        {"FR","Francia"}, {"GA","Gabón"}, {"GB","Reino Unido"}, {"GD","Granada"}, {"GE","Georgia"}, {"GF","Guayana Francesa"},
        {"GG","Guernsey"}, {"GH","Ghana"}, {"GI","Gibraltar"}, {"GL","Groenlandia"}, {"GM","Gambia"}, {"GN","Guinea"}, {"GP","Guadalupe"},
        {"GQ","Guinea Ecuatorial"}, {"GR","Grecia"}, {"GS","Georgia del Sur e Islas Sandwich del Sur"}, {"GT","Guatemala"}, {"GU","Guam"},
        {"GW","Guinea-Bissau"}, {"GY","Guayana"}, {"HK","Hong Kong"}, {"HM","Islas Heard y McDonald"}, {"HN","Honduras"}, {"HR","Croacia"},
        {"HT","Haití"}, {"HU","Hungría"}, {"ID","Indonesia"}, {"IE","Irlanda"}, {"IL","Israel"}, {"IM","Isla de Man"}, {"IN","India"},
        {"IO","Territorio Británico del Océano Índico"}, {"IQ","Irak"}, {"IR","Irán"}, {"IS","Islandia"}, {"IT","Italia"}, {"JE","Jersey"},
        {"JM","Jamaica"}, {"JO","Jordania"}, {"JP","Japón"}, {"KE","Kenia"}, {"KG","Kirguistán"}, {"KH","Camboya"}, {"KI","Kiribati"},
        {"KM","Comoros"}, {"KN","San Cristóbal y Nieves"}, {"KP","Corea del Norte"}, {"KR","Corea del Sur"}, {"KW","Kuwait"}, {"KY","Islas Caimán"},
        {"KZ","Kazajstán"}, {"LA","Laos"}, {"LB","Líbano"}, {"LC","Santa Lucía"}, {"LI","Liechtenstein"}, {"LK","Sri Lanka"}, {"LR","Liberia"},
        {"LS","Lesotho"}, {"LT","Lituania"}, {"LU","Luxemburgo"}, {"LV","Letonia"}, {"LY","Libia"}, {"MA","Marruecos"}, {"MC","Mónaco"},
        {"MD","Moldova"}, {"ME","Montenegro"}, {"MG","Madagascar"}, {"MH","Islas Marshall"}, {"MK","Macedonia"}, {"ML","Mali"}, {"MM","Myanmar"},
        {"MN","Mongolia"}, {"MO","Macao"}, {"MQ","Martinica"}, {"MR","Mauritania"}, {"MS","Montserrat"}, {"MT","Malta"}, {"MU","Mauricio"},
        {"MV","Maldivas"}, {"MW","Malawi"}, {"MX","México"}, {"MY","Malasia"}, {"MZ","Mozambique"}, {"NA","Namibia"}, {"NC","Nueva Caledonia"},
        {"NE","Níger"}, {"NF","Islas Norkfolk"}, {"NG","Nigeria"}, {"NI","Nicaragua"}, {"NL","Países Bajos"}, {"NO","Noruega"}, {"NP","Nepal"},
        {"NR","Nauru"}, {"NU","Niue"}, {"NZ","Nueva Zelanda"}, {"OM","Omán"}, {"PA","Panamá"}, {"PE","Perú"}, {"PF","Polinesia Francesa"},
        {"PG","Papúa Nueva Guinea"}, {"PH","Filipinas"}, {"PK","Pakistán"}, {"PL","Polonia"}, {"PM","San Pedro y Miquelón"}, {"PN","Islas Pitcairn"},
        {"PR","Puerto Rico"}, {"PS","Palestina"}, {"PT","Portugal"}, {"PW","Islas Palaos"}, {"PY","Paraguay"}, {"QA","Qatar"}, {"RE","Reunión"},
        {"RO","Rumanía"}, {"RS","Serbia y Montenegro"}, {"RU","Rusia"}, {"RW","Ruanda"}, {"SA","Arabia Saudita"}, {"SB","Islas Solomón"},
        {"SC","Seychelles"}, {"SD","Sudán"}, {"SE","Suecia"}, {"SG","Singapur"}, {"SH","Santa Elena"}, {"SI","Eslovenia"}, {"SJ","Islas Svalbard y Jan Mayen"},
        {"SK","Eslovaquia"}, {"SL","Sierra Leona"}, {"SM","San Marino"}, {"SN","Senegal"}, {"SO","Somalia"}, {"SR","Surinam"}, {"ST","Santo Tomé y Príncipe"},
        {"SV","El Salvador"}, {"SY","Siria"}, {"SZ","Suazilandia"}, {"TC","Islas Turcas y Caicos"}, {"TD","Chad"}, {"TF","Territorios Australes Franceses"},
        {"TG","Togo"}, {"TH","Tailandia"}, {"TZ","Tanzania"}, {"TJ","Tayikistán"}, {"TK","Tokelau"}, {"TL","Timor-Leste"}, {"TM","Turkmenistán"},
        {"TN","Túnez"}, {"TO","Tonga"}, {"TR","Turquía"}, {"TT","Trinidad y Tobago"}, {"TV","Tuvalu"}, {"TW","Taiwán"}, {"UA","Ucrania"},
        {"UG","Uganda"}, {"US","Estados Unidos de América"}, {"UY","Uruguay"}, {"UZ","Uzbekistán"}, {"VA","Ciudad del Vaticano"}, {"VC","San Vicente y las Granadinas"},
        {"VE","Venezuela"}, {"VG","Islas Vírgenes Británicas"}, {"VI","Islas Vírgenes de los Estados Unidos de América"}, {"VN","Vietnam"},
        {"VU","Vanuatu"}, {"WF","Wallis y Futuna"}, {"WS","Samoa"}, {"YE","Yemen"}, {"YT","Mayotte"},
        {"ZA","Sudáfrica"}, {"XX","Desconocido"}
    };
    private string ObtenerCodigoPaisOrigen(string nombrePersonaje){
        string url = @$"https://api.nationalize.io?name={nombrePersonaje}";
        var peticion = (HttpWebRequest) WebRequest.Create(url);
        peticion.Method = "GET";
        peticion.ContentType = "application/json";
        peticion.Accept = "application/json";
        PersonajeOrigen p = null;
        string codPais = "XX";
        int id = 0;
        
        try
        {
            using (WebResponse response = peticion.GetResponse()){
                using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return codPais;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            List<string> codPaises = new List<string>(paises.Keys);
                            bool valido = false;
                            string info = objReader.ReadToEnd();
                            p = JsonSerializer.Deserialize<PersonajeOrigen>(info);
                            while(!valido && (id < 4)){
                                codPais = p.country[id].country_id;
                                if(codPaises.Contains(codPais)) valido = true;
                                id++;
                            }

                            if(id > 4) codPais = "XX";
                        }
                    }
            }
        }
        catch (WebException ex)
        {
            return "XX";
        }

        return codPais;
    }

    private string ObtenerPaisOrigenPersonaje(string nombrePersonaje){
        return paises[ObtenerCodigoPaisOrigen(nombrePersonaje)];
    }

    private Personaje GenerarPersonaje(TipoPersonaje tipo){
        Personaje nuevoPersonaje = new Personaje();
        nuevoPersonaje.Caracteristicas = new CaracteristicasPersonaje();
        int aux = new Random().Next(0, 4);

        switch(tipo){
            case TipoPersonaje.Sicario:
            string[ , ] nombresYApodosSicarios = {{"Dennis", "El oculto"},{"Sara", "La inocente"},{"Robert", "El ingenioso"},{"Isabel", "La histerica"}};
            nuevoPersonaje.Nombre = nombresYApodosSicarios[aux, 0];
            nuevoPersonaje.Apodo = nombresYApodosSicarios[aux, 1];
            break;
            case TipoPersonaje.Psicopata:
            string[ , ] nombresYApodosPsicopatas = {{"Jeremy", "El salvaje"},{"Sofia", "La gata"},{"Gaston", "El sangriento"},{"Susan", "La tierna"}};
            nuevoPersonaje.Nombre = nombresYApodosPsicopatas[aux, 0];
            nuevoPersonaje.Apodo = nombresYApodosPsicopatas[aux, 1];
            break;
            case TipoPersonaje.Ladron:
            string[ , ] nombresYApodosLadrones = {{"Jessica", "La sigilosa"},{"Lucas", "El nocturno"},{"Jorge", "El picaron"},{"Monica", "La atrevida"}};
            nuevoPersonaje.Nombre = nombresYApodosLadrones[aux, 0];
            nuevoPersonaje.Apodo = nombresYApodosLadrones[aux, 1];
            break;
            case TipoPersonaje.Mafioso:
            string[ , ] nombresYApodosMafiosos = {{"Miguel", "El grosero"},{"Camila", "La gritona"},{"Joshua", "El agresivo"},{"Pamela", "La negociadora"}};
            nuevoPersonaje.Nombre = nombresYApodosMafiosos[aux, 0];
            nuevoPersonaje.Apodo = nombresYApodosMafiosos[aux, 1];
            break;
            case TipoPersonaje.Terrorista:
            string[ , ] nombresYApodosTerroristas = {{"Ricardo", "El mas hábil"},{"Estela", "La actriz"},{"Guillermo", "El guerrero"},{"Rocio", "La tenebrosa"}};
            nuevoPersonaje.Nombre = nombresYApodosTerroristas[aux, 0];
            nuevoPersonaje.Apodo = nombresYApodosTerroristas[aux, 1];
            break;
        }

        // Definiendo los datos restantes del personaje en cuestión
        nuevoPersonaje.Tipo = tipo;
        nuevoPersonaje.FechaNac = new DateTime(new Random().Next(1980, 2001), new Random().Next(1, 13), new Random().Next(1, 29));
        nuevoPersonaje.Edad = (DateTime.Now.Subtract(nuevoPersonaje.FechaNac).Days) / 365;
        nuevoPersonaje.PaisOrigen = ObtenerPaisOrigenPersonaje(nuevoPersonaje.Nombre);
        
        // Se generan los valores de las características del personaje en cuestión
        nuevoPersonaje.Caracteristicas.Nivel = new Random().Next(3, 9);
        nuevoPersonaje.Caracteristicas.Velocidad = new Random().Next(5, 11);
        nuevoPersonaje.Caracteristicas.Destreza = new Random().Next(2, 6);
        nuevoPersonaje.Caracteristicas.Fuerza = new Random().Next(3, 9);
        nuevoPersonaje.Caracteristicas.Blindaje = new Random().Next(5, 11);
        nuevoPersonaje.Caracteristicas.Salud = 100;

        return nuevoPersonaje;
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