using System.IO.Compression;
using HumanFriends.Model;

namespace HumanFriends.Service;

class ClassParser : IClassParser
{
    private string[] _parameters = [];

    private Kind CheckAndGetKind(string someString) // определяем строку с данными о животном в нужный тип и проверяем на соответствие
    {
        string[] strings = someString.Split(";");
        int kindId;
        try
        {
            kindId = Convert.ToInt32(strings[1]);
        }
        catch (System.Exception)
        {
            throw;
        }
        _parameters = strings;
        return kindId switch
        {
            1 => strings.Length == 9 ? Kind.Dog : throw new FormatException(),
            2 => strings.Length == 9 ? Kind.Cat : throw new FormatException(),
            3 => strings.Length == 8 ? Kind.Hamster : throw new FormatException(),
            4 => strings.Length == 9 ? Kind.Horse : throw new FormatException(),
            5 => strings.Length == 8 ? Kind.Camel : throw new FormatException(),
            6 => strings.Length == 8 ? Kind.Donkey : throw new FormatException(),
            _ => throw new FormatException()
        };
    }

    private AnimalCommand GetCommand(int commandId)
    {
        if (Enum.IsDefined(typeof(AnimalCommand), commandId)) return (AnimalCommand)commandId;
        else throw new EnumException();
    }

    private HashSet<AnimalCommand> GetCommands()
    {
        string[] strings = _parameters[6].Split(",");
        HashSet<AnimalCommand> commands = [];
        if (strings[0].Equals("")) return commands;
        try
        {
            foreach (var item in strings)
            {
                int commandId = Convert.ToInt32(item);
                commands.Add(GetCommand(commandId));
            }
            return commands;
        }
        catch (System.Exception)
        {
            throw;
        }


    }
    public IBaseAnimal GetAnimal(string someString) // получаем животное из строки и определяем в нужный класс 
    {
        _parameters = [];
        Kind kind = CheckAndGetKind(someString);
        try
        {
            int id = Convert.ToInt32(_parameters[0]);
            string name = _parameters[2];
            DateTime dob = Convert.ToDateTime(_parameters[3]);
            bool vaccination = Convert.ToBoolean(Convert.ToInt32(_parameters[4]));
            int featureId = Convert.ToInt32(_parameters[5]);
            HashSet<AnimalCommand> commands = GetCommands();
            bool happy = false;
            if (Pet.kinds.Contains(kind)) happy = Convert.ToBoolean(Convert.ToInt32(_parameters[7]));
            int currentLoad = 0;
            if (PackAnimal.kinds.Contains(kind)) currentLoad = Convert.ToInt32(_parameters[7]);
            switch (kind)
            {
                case Kind.Dog:
                    int breedId = Convert.ToInt32(_parameters[8]);
                    return new Dog(name, dob, vaccination, featureId, commands, happy, breedId, id);
                case Kind.Cat:
                    breedId = Convert.ToInt32(_parameters[8]);
                    return new Cat(name, dob, vaccination, featureId, commands, happy, breedId, id);
                case Kind.Hamster:
                    return new Hamster(name, dob, vaccination, featureId, commands, happy, id);
                case Kind.Horse:
                    breedId = Convert.ToInt32(_parameters[8]);
                    return new Horse(name, dob, vaccination, featureId, commands, currentLoad, breedId, id);
                case Kind.Camel:
                    return new Camel(name, dob, vaccination, featureId, commands, currentLoad, id);
                case Kind.Donkey:
                    return new Donkey(name, dob, vaccination, featureId, commands, currentLoad, id);
                default:
                    throw new FormatException();
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
}

