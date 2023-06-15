namespace RPG;

public enum typeCharacter{
    Ogro,
    Soldado,
    Caballero, 
    Duende,
    Bruja
}


public class Character{
    private typeCharacter type;
    private string name;
    //private string nickname;
    //private DateTime date;
    private int age;
    private Characteristics_Character secondaryData;

    public Character (typeCharacter type){
        this.type = type;
    }

    public string Name { get => name; set => name = value;}
    //public string Nickname { get => nickname; set => nickname = value; }
    //public DateTime Date { get => date; set => date = value; }
    public int Age { get => age; set => age = value; }

}


public class factoryCharacters{
    private Character generateCharacterGeneric(typeCharacter type){
        var createCharacter = new Character(type);
        
        switch(type){
            case typeCharacter.Ogro:
            createCharacter.Name = "Ogro_";
            createCharacter.Age = 40;
            break;
            case typeCharacter.Soldado:
            createCharacter.Name = "Soldaddo_";
            createCharacter.Age = 50;
            break;
            case typeCharacter.Caballero:
            createCharacter.Name = "Caballero_";
            createCharacter.Age = 50;
            break;
            case typeCharacter.Duende:
            createCharacter.Name = "Duende_";
            createCharacter.Age = 45;
            break;
            default:
            createCharacter.Name = "Bruja_";
            createCharacter.Age = 70;
            break;
        }

        return createCharacter;
    }
}