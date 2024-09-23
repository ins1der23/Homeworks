using HumanFriends.Model;

namespace HumanFriends.Service;

class ClassParser : IClassParser
{
    private string[] _parameters = [];

    private Kind CheckAndGetKind(string someString) // определяем строку в нужный тип и проверяем на соответствие
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
            _ => throw new FormatException()
        };
    }

    private AnimalCommand GetCommand(int commandId)
    {
        if (Enum.IsDefined(typeof(AnimalCommand), commandId)) return (AnimalCommand)commandId;
        else throw new EnumException();
    }

    private List<AnimalCommand> GetCommands()
    {
        string[] strings = _parameters[6].Split(",");
        List<AnimalCommand> commands = [];
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
    public IBaseAnimal GetAnimal(string someString)
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
            List<AnimalCommand> commands = GetCommands();
            bool happy = false;
            if ((int)kind < 4) happy = Convert.ToBoolean(Convert.ToInt32(_parameters[7]));
            switch (kind)
            {
                case Kind.Dog:
                    int breedId = Convert.ToInt32(_parameters[5]);
                    return new Dog(name, dob, vaccination, featureId, commands, happy, breedId);
            }
        }
        catch (System.Exception)
        {
            throw;
        }
        throw new FormatException();
    }
}

